Imports System.Data.OleDb
Imports System.Data

Partial Class User
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()

        BindData()
    End Sub

    Sub BindData()
        Dim strSQL As String
        strSQL = "SELECT * FROM CUSTOMER WHERE c_fname = '" & Session("strUser") & "' AND C_PASSWORD = '" & Session("pass") & "' "

        Dim dtReader As OleDbDataReader
        objCmd = New OleDbCommand(strSQL, objConn)
        dtReader = objCmd.ExecuteReader()

        '*** BindData to Repeater ***'
        myRepeater.DataSource = dtReader
        myRepeater.DataBind()

        dtReader.Close()
        dtReader = Nothing

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Response.Redirect("Edituser.aspx")

    End Sub
End Class
