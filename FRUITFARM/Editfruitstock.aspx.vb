Imports System.Data
Imports System.Data.OleDb

Partial Class Editfruitstock
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
        strSQL = "SELECT * FROM FRUITSTOCK WHERE f_id = '" & Request.QueryString("f_id") & "' "
        dtAdapter = New OleDbDataAdapter(strSQL, objConn)
        dtAdapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            Me.txtf_id.Text = dt.Rows(0)("f_id")
            Me.txtf_name.Text = dt.Rows(0)("f_name")
            Me.txtinstock_kg.Text = dt.Rows(0)("instock_kg")
            Me.txtfprice.Text = dt.Rows(0)("price_kg")
        End If
    End Sub

    Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click

        strSQL = "UPDATE FRUITSTOCK SET " & _
        " f_id = '" & Me.txtf_id.Text & "' " & _
        " ,f_name = '" & Me.txtf_name.Text & "' " & _
        " ,instock_kg = '" & Me.txtinstock_kg.Text & "' " & _
        " ,price_kg = '" & Me.txtfprice.Text & "' " & _
        " WHERE f_id = '" & Request.QueryString("f_id") & "' "

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
        Response.Redirect("Fruitstock.aspx")

    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

End Class
