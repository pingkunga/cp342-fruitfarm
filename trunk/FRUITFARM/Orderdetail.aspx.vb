Imports System.Data
Imports System.Data.OleDb

Partial Class Orderdetail
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")
        Dim strConnString As String
        Session("order") = Request.QueryString("order_number")

        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()

        BindData()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub BindData()
        Dim strSQL, paid, total, p As String
        Dim can As String = "-"

        strSQL = "SELECT OD.order_number,OD.f_id,FS.f_name,OD.order_quantity_kg,OD.order_price FROM ORDERDETAIL OD JOIN ORDERHEAD OH ON(OD.order_number=OH.order_number) " & _
                    " JOIN FRUITSTOCK FS ON(FS.f_id=OD.f_id) WHERE OD.order_number = '" & Session("order") & "' "

        Try
            total = "SELECT SUM(order_price) FROM ORDERDETAIL WHERE order_number = '" & Session("order") & "' "
            objCmd = New OleDbCommand(total, objConn)
            paid = objCmd.ExecuteScalar()

            If paid < 0 Then
                totalPaid.Text = can
            Else
                totalPaid.Text = paid
            End If


            Dim dtReader As OleDbDataReader
            objCmd = New OleDbCommand(strSQL, objConn)
            dtReader = objCmd.ExecuteReader()

            '*** BindData to GridView ***'
            myRepeater.DataSource = dtReader
            myRepeater.DataBind()

            dtReader.Close()
            dtReader = Nothing
        Catch ex As Exception
            Response.Redirect("Order.aspx")
        End Try
    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

    Sub myRepeater_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles myRepeater.ItemDataBound
        '*** Order Number ***'
        Dim lblorder_number As Label = CType(e.Item.FindControl("lblorder_number"), Label)
        If Not IsNothing(lblorder_number) Then
            lblorder_number.Text = e.Item.DataItem("order_number")
        End If

        '*** Fruit ID ***'
        Dim lblf_id As Label = CType(e.Item.FindControl("lblf_id"), Label)
        If Not IsNothing(lblf_id) Then
            lblf_id.Text = e.Item.DataItem("f_id")
        End If

        Dim lblf_name As Label = CType(e.Item.FindControl("lblf_name"), Label)
        If Not IsNothing(lblf_name) Then
            lblf_name.Text = e.Item.DataItem("f_name")
        End If

        '*** Quantity ***'
        Dim lblorder_quantity_kg As Label = CType(e.Item.FindControl("lblorder_quantity_kg"), Label)
        If Not IsNothing(lblorder_quantity_kg) Then
            lblorder_quantity_kg.Text = e.Item.DataItem("order_quantity_kg")
        End If

        '*** Price ***'
        Dim lblorder_price As Label = CType(e.Item.FindControl("lblorder_price"), Label)
        If Not IsNothing(lblorder_price) Then
            lblorder_price.Text = e.Item.DataItem("order_price")
        End If

        Dim hplEdit As HyperLink = CType(e.Item.FindControl("hplEdit"), HyperLink)
        If Not IsNothing(hplEdit) Then
            hplEdit.Text = "Price"
            hplEdit.NavigateUrl = "Editorderdetail.aspx?order_number=" & e.Item.DataItem("order_number") & "&f_id=" & e.Item.DataItem("f_id")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Order Detail?');")
        End If
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL, checkDel, checkD As String
            Dim stateDel As String = "N"
            Dim lblorder_number As Label = CType(e.Item.FindControl("lblorder_number"), Label)

            checkD = "SELECT status FROM ORDERHEAD where order_number = '" & lblorder_number.Text & "'"
            objCmd = New OleDbCommand(checkD, objConn)
            checkDel = objCmd.ExecuteScalar()

            If stateDel = checkDel Then

                Dim lblf_id As Label = CType(e.Item.FindControl("lblf_id"), Label)
                strSQL = "DELETE FROM ORDERDETAIL WHERE order_number = '" & lblorder_number.Text & "' AND f_id = '" & lblf_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                BindData()
            Else
                MsgBox("You Can't Delete Order Detail")
            End If
        End If
    End Sub

End Class
