Imports System.Data
Imports System.Data.OleDb

Partial Class LogCustomer
    Inherits System.Web.UI.Page

    Dim conn As OleDbConnection
    Dim cmd As OleDbCommand
    Dim ConnString As String
    Dim user As String
    Dim pass As String

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        '--customer check--'
        '---------------------------------------------------------------Connect
        ConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        'ใส่สตริง ConnString สำหรับการติดต่อ Access Database
        conn = New OleDbConnection(ConnString)
        'การเปิดการติดต่อกับ Access Database
        Try
            conn.Open()
            'Response.Write("connect database successFully")
        Catch ex As Exception
            'Response.Write("Cannot connect database")
        End Try
        '---------------------------------------------------------------Connect
        '---------------------------------------------------------------Check
        Dim strsql As String
        Dim intNumRows As Integer
        user = Me.CustUser.Text.ToString()
        pass = Me.CustPass.Text.ToString()
        strsql = "SELECT COUNT(*) FROM CUSTOMER WHERE C_FNAME = '" & user & "' AND C_PASSWORD = '" & pass & "' "
        cmd = New OleDbCommand(strsql, conn)
        intNumRows = CInt(cmd.ExecuteScalar())
        If (intNumRows > 0) Then
            Session("strUser") = user
            Session("pass") = pass
            Response.Redirect("User.aspx")

        Else
            MsgBox("Failed")
        End If
        '---------------------------------------------------------------Check
    End Sub

End Class
