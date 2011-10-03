Imports System.Data
Imports System.Data.OleDb

Partial Class Insertorderuserdetail
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strConnString, strSQL, seqbill As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
    End Sub

    Public Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Dim nextCust, checkAdd, checkA As String
        Dim stateAdd As String = "N"
        Dim data, d, tprice As String

        checkA = "SELECT status FROM ORDERHEAD where order_number = '" & Session("orderuser") & "'"
        objCmd = New OleDbCommand(checkA, objConn)
        checkAdd = objCmd.ExecuteScalar()

        d = "SELECT price_kg FROM FRUITSTOCK WHERE f_id = '" & Me.FruitList1.SelectedValue & "' "
        objCmd = New OleDbCommand(d, objConn)
        data = objCmd.ExecuteScalar()

        tprice = data * Me.txtorder_quantity_kg.Text

        If stateAdd = checkAdd Then

            seqbill = "SELECT order_number FROM ORDERHEAD WHERE order_number = '" & Session("orderuser") & "' "
            objCmd = New OleDbCommand(seqbill, objConn)
            nextCust = objCmd.ExecuteScalar()

            Try
                strSQL = "INSERT INTO ORDERDETAIL " & _
                " VALUES " & _
                " ('" & nextCust & "','" & Me.FruitList1.SelectedValue & "','" & Me.txtorder_quantity_kg.Text & "', " & _
                " '" & tprice & "')"

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
            Catch ex As Exception
                MsgBox("Add Fail")
            End Try
        Else
            MsgBox("You Can't Add Order Detail")
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Orderuserdetail.aspx")

    End Sub

    Sub HyperLink3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HyperLink3.Click
        Response.Redirect("Orderuser.aspx")

    End Sub

End Class
