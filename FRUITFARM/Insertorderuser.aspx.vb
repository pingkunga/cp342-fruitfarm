Imports System.Data
Imports System.Data.OleDb

Partial Class Insertorderuser
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strConnString, strSQL, nextB, custID, cust As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
    End Sub

    Public Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Dim nextBill As String

        nextB = "SELECT MAX(order_number) FROM ORDERHEAD"
        objCmd = New OleDbCommand(nextB, objConn)
        nextBill = objCmd.ExecuteScalar()
        nextBill = nextBill + 1
        Session("orderuser") = nextBill

        cust = "SELECT c_id FROM CUSTOMER where c_fname = '" & Session("strUser") & "' AND c_password = '" & Session("pass") & "' "
        objCmd = New OleDbCommand(cust, objConn)
        custID = objCmd.ExecuteScalar()

        strSQL = "INSERT INTO ORDERHEAD " & _
        " VALUES " & _
        " ('" & nextBill & "','" & Me.txtorder_date.Text & "','" & custID & "','N','-')"

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
            Me.lblStatus.Text = "Add Complete"
            Me.HyperLink1.Visible = True
            Me.HyperLink2.Visible = True
        Catch ex As Exception
            Me.lblStatus.Visible = True
            Me.lblStatus.Text = "Add Fail Error (" & ex.Message & ")"
            Me.HyperLink1.Visible = True
            Me.HyperLink2.Visible = True
        End Try
        Response.Redirect("Insertorderuserdetail.aspx")
    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Orderuser.aspx")

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

End Class
