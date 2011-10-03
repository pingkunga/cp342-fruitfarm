Imports System.Data
Imports System.Data.OleDb

Partial Class Billdetail
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        Session("bill") = Request.QueryString("bill_number")

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
        Dim strSQL, paid, total As String

        strSQL = "SELECT BD.bill_number,BD.f_id,FS.f_name,BH.orc_id,O.orc_name,BD.bill_quantity_kg,BD.bill_price FROM BILLDETAIL BD JOIN BILLHEAD BH ON(BD.bill_number=BH.bill_number) " & _
                    " JOIN FRUITSTOCK FS ON(FS.f_id=BD.f_id) JOIN ORCHARD O ON(O.orc_id=BH.orc_id) WHERE BD.bill_number = '" & Session("bill") & "' "

        Try
            total = "SELECT SUM(bill_price) FROM BILLDETAIL WHERE bill_number = '" & Session("bill") & "' "
            objCmd = New OleDbCommand(total, objConn)
            paid = objCmd.ExecuteScalar()
            totalPaid.Text = paid

            Dim dtReader As OleDbDataReader
            objCmd = New OleDbCommand(strSQL, objConn)
            dtReader = objCmd.ExecuteReader()

            '*** BindData to GridView ***'
            myRepeater.DataSource = dtReader
            myRepeater.DataBind()

            dtReader.Close()
            dtReader = Nothing
        Catch ex As Exception
            Response.Redirect("Bill.aspx")
        End Try
    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

    Sub myRepeater_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles myRepeater.ItemDataBound
        '*** Bill Number ***'
        Dim lblbill_number As Label = CType(e.Item.FindControl("lblbill_number"), Label)
        If Not IsNothing(lblbill_number) Then
            lblbill_number.Text = e.Item.DataItem("bill_number")
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

        Dim lblorc_id As Label = CType(e.Item.FindControl("lblorc_id"), Label)
        If Not IsNothing(lblorc_id) Then
            lblorc_id.Text = e.Item.DataItem("orc_id")
        End If

        Dim lblorc_name As Label = CType(e.Item.FindControl("lblorc_name"), Label)
        If Not IsNothing(lblorc_name) Then
            lblorc_name.Text = e.Item.DataItem("orc_name")
        End If

        '*** Quantity ***'
        Dim lblbill_quantity_kg As Label = CType(e.Item.FindControl("lblbill_quantity_kg"), Label)
        If Not IsNothing(lblbill_quantity_kg) Then
            lblbill_quantity_kg.Text = e.Item.DataItem("bill_quantity_kg")
        End If

        '*** Price ***'
        Dim lblbill_price As Label = CType(e.Item.FindControl("lblbill_price"), Label)
        If Not IsNothing(lblbill_price) Then
            lblbill_price.Text = e.Item.DataItem("bill_price")
        End If


        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Bill Detail?');")
        End If
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL, checkDel, checkD As String
            Dim stateDel As String = "N"
            Dim lblbill_number As Label = CType(e.Item.FindControl("lblbill_number"), Label)

            checkD = "SELECT status FROM BILLHEAD where bill_number = '" & lblbill_number.Text & "'"
            objCmd = New OleDbCommand(checkD, objConn)
            checkDel = objCmd.ExecuteScalar()

            If stateDel = checkDel Then

                Dim lblf_id As Label = CType(e.Item.FindControl("lblf_id"), Label)
                strSQL = "DELETE FROM BILLDETAIL WHERE bill_number = '" & lblbill_number.Text & "' AND f_id = '" & lblf_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                BindData()
            Else
                MsgBox("You Can't Delete Bill Detail")
            End If
        End If
    End Sub

End Class
