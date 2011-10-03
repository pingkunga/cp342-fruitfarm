Imports System.Data
Imports System.Data.OleDb

Partial Class Editmemberdetail
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim dtReader As OleDbDataReader
    Dim strConnString, strSQL As String

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()

        If Not Page.IsPostBack() Then
            ViewData()
        End If
    End Sub

    Sub ViewData()
        Dim dtAdapter As OleDbDataAdapter
        Dim dt As New DataTable
        strSQL = "SELECT * FROM MEMBER WHERE m_fname = '" & Session("strUser") & "' "
        dtAdapter = New OleDbDataAdapter(strSQL, objConn)
        dtAdapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            Me.txtm_fname.Text = dt.Rows(0)("m_fname")
            Me.txtm_lname.Text = dt.Rows(0)("m_lname")
            Me.txtm_password.Text = dt.Rows(0)("m_password")
            Me.txtm_address.Text = dt.Rows(0)("m_address")
            Me.ProvinceList1.SelectedValue = dt.Rows(0)("province_id")
            Me.txtm_tel.Text = dt.Rows(0)("m_tel")
            Me.txtm_email.Text = dt.Rows(0)("m_email")
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click

        strSQL = "UPDATE MEMBER SET " & _
        " m_fname = '" & Me.txtm_fname.Text & "' " & _
        " ,m_lname = '" & Me.txtm_lname.Text & "' " & _
        " ,m_password = '" & Me.txtm_password.Text & "' " & _
        " ,m_address = '" & Me.txtm_address.Text & "' " & _
        " ,province_id = '" & Me.ProvinceList1.SelectedValue & "' " & _
        " ,m_tel = '" & Me.txtm_tel.Text & "' " & _
        " ,m_email = '" & Me.txtm_email.Text & "' " & _
        " WHERE m_fname = '" & Session("strUser") & "' "

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
        Response.Redirect("Memberdetail.aspx")

    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

End Class