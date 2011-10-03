Imports System.Data
Imports System.Data.OleDb
Partial Class Register
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strConnString, strSQL, seqCust As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
    End Sub

    Public Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Dim nextCust As String

        seqCust = "SELECT MAX(c_id) FROM CUSTOMER"
        objCmd = New OleDbCommand(seqCust, objConn)
        nextCust = objCmd.ExecuteScalar()
        nextCust = nextCust + 1

        strSQL = "INSERT INTO CUSTOMER " & _
        " VALUES " & _
        " ('" & nextCust & "','" & Me.txtc_fname.Text & "','" & Me.txtc_lname.Text & "', " & _
        " '" & Me.txtc_address.Text & "','" & Me.DropDownList1.SelectedValue & "','" & Me.txtc_tel.Text & "','" & Me.txtc_email.Text & "','" & Me.txtc_password.Text & "')"

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
            Me.lblStatus.Text = "Register Complete"
            Me.HyperLink1.Visible = True
            Me.HyperLink2.Visible = True
        Catch ex As Exception
            Me.lblStatus.Visible = True
            Me.lblStatus.Text = "Register Fail Error (" & ex.Message & ")"
            Me.HyperLink1.Visible = True
            Me.HyperLink2.Visible = True
        End Try
    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("FirstPage.aspx")

    End Sub

End Class
