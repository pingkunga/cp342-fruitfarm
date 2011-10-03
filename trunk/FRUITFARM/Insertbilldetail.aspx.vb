Imports System.Data
Imports System.Data.OleDb

Partial Class InsertBIS
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strConnString, strSQL, seqbill As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")
        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Public Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Dim nextCust, checkAdd, checkA As String
        Dim stateAdd As String = "N"

        checkA = "SELECT status FROM BILLHEAD where bill_number = '" & Session("bill") & "'"
        objCmd = New OleDbCommand(checkA, objConn)
        checkAdd = objCmd.ExecuteScalar()

        If stateAdd = checkAdd Then

            seqbill = "SELECT bill_number FROM BILLHEAD WHERE bill_number = '" & Session("bill") & "' "
            objCmd = New OleDbCommand(seqbill, objConn)
            nextCust = objCmd.ExecuteScalar()

            strSQL = "INSERT INTO BILLDETAIL " & _
            " VALUES " & _
            " ('" & nextCust & "','" & Me.FruitList1.SelectedValue & "','" & Me.txtbill_quantity_kg.Text & "', " & _
            " '" & Me.txtbill_price.Text & "')"

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
                Me.HyperLink3.Visible = True
            Catch ex As Exception
                Me.lblStatus.Visible = True
                Me.lblStatus.Text = "Add Fail Error (" & ex.Message & ")"
                Me.HyperLink1.Visible = True
                Me.HyperLink3.Visible = True
            End Try
        Else
            MsgBox("You Can't Add Bill Detail")
        End If
    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Billdetail.aspx")

    End Sub

    Sub HyperLink3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HyperLink3.Click
        Response.Redirect("Bill.aspx")

    End Sub

End Class
