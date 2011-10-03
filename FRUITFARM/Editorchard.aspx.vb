Imports System.Data
Imports System.Data.OleDb

Partial Class Editorchard
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim dtReader As OleDbDataReader
    Dim strConnString, strSQL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()

        If Not Page.IsPostBack() Then
            ViewData()
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub ViewData()
        Dim dtAdapter As OleDbDataAdapter
        Dim dt As New DataTable
        strSQL = "SELECT * FROM ORCHARD WHERE orc_id = '" & Request.QueryString("orc_id") & "' "
        dtAdapter = New OleDbDataAdapter(strSQL, objConn)
        dtAdapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            Me.txtorc_id.Text = dt.Rows(0)("orc_id")
            Me.txtorc_name.Text = dt.Rows(0)("orc_name")
            Me.txtorc_address.Text = dt.Rows(0)("orc_address")
            Me.ProvinceList1.SelectedValue = dt.Rows(0)("province_id")
            Me.txtorc_tel.Text = dt.Rows(0)("orc_tel")
            Me.txtorc_email.Text = dt.Rows(0)("orc_email")
        End If
    End Sub

    Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click

        strSQL = "UPDATE ORCHARD SET " & _
        " orc_id = '" & Me.txtorc_id.Text & "' " & _
        " ,orc_name = '" & Me.txtorc_name.Text & "' " & _
        " ,orc_address = '" & Me.txtorc_address.Text & "' " & _
        " ,province_id = '" & Me.ProvinceList1.SelectedValue & "' " & _
        " ,orc_tel = '" & Me.txtorc_tel.Text & "' " & _
        " ,orc_email = '" & Me.txtorc_email.Text & "' " & _
        " WHERE orc_id = '" & Request.QueryString("orc_id") & "' "

        objCmd = New OleDbCommand
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With

        Me.pnlAdd1.Visible = False
        Try
            objCmd.ExecuteNonQuery()
            Me.lblStatus.Visible = True
            Me.lblStatus.Text = "Update Complete"
            Me.HyperLink1.Visible = True
        Catch ex As Exception
            Me.lblStatus.Visible = True
            Me.lblStatus.Text = "Update Fail"
            Me.HyperLink1.Visible = True
        End Try

    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Orchard.aspx")

    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

End Class
