Imports System.Data
Imports System.Data.OleDb

Partial Class Order
    Inherits System.Web.UI.Page

    Dim dtAdapter As OleDbDataAdapter
    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strsql2 As String
    Dim dt As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")
        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
        Dim strSQL1 As String = "SELECT DISTINCT * FROM ORDERHEAD ORDER BY order_number"
        BindData(strSQL1)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub BindData(ByVal strSQL As String)
        'Dim strSQL As String
        'strSQL = "SELECT * FROM FRUITSTOCK"

        Dim dtReader As OleDbDataReader
        objCmd = New OleDbCommand(strSQL, objConn)
        Try
            dtReader = objCmd.ExecuteReader()
        Catch ex As Exception
            MsgBox("No Record Found!!!")
            Response.Redirect("Order.aspx")
        End Try

        '*** BindData to GridView ***'
        myRepeater.DataSource = dtReader
        myRepeater.DataBind()

        dtReader.Close()
        dtReader = Nothing

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

        '*** Order Date ***'
        Dim lblorder_date As Label = CType(e.Item.FindControl("lblorder_date"), Label)
        If Not IsNothing(lblorder_date) Then
            lblorder_date.Text = e.Item.DataItem("order_date")
        End If

        Dim lblr_date As Label = CType(e.Item.FindControl("lblr_date"), Label)
        If Not IsNothing(lblr_date) Then
            lblr_date.Text = e.Item.DataItem("r_date")
        End If

        '*** Customer ID ***'
        Dim lblc_id As Label = CType(e.Item.FindControl("lblc_id"), Label)
        If Not IsNothing(lblc_id) Then
            lblc_id.Text = e.Item.DataItem("c_id")
        End If

        Dim lblstatus As Label = CType(e.Item.FindControl("lblstatus"), Label)
        If Not IsNothing(lblstatus) Then
            lblstatus.Text = e.Item.DataItem("status")
        End If

        Dim hplDetail As HyperLink = CType(e.Item.FindControl("hplDetail"), HyperLink)
        If Not IsNothing(hplDetail) Then
            hplDetail.Text = "Detail"
            hplDetail.NavigateUrl = "Orderdetail.aspx?order_number=" & e.Item.DataItem("order_number")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Order?');")
        End If

    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String

            Dim lblorder_number As Label = CType(e.Item.FindControl("lblorder_number"), Label)
            strSQL = "DELETE FROM ORDERHEAD WHERE order_number = '" & lblorder_number.Text & "' "
            objCmd = New OleDbCommand(strSQL, objConn)
            objCmd.ExecuteNonQuery()
            'objCmd.commit()
            Dim strSQL2 As String = "SELECT DISTINCT * FROM ORDERHEAD ORDER BY order_number"
            BindData(strSQL2)
        End If

        If e.CommandName = "Accepts" Then

            Dim strSQL2, check, checkVal As String
            Dim lblorder_number As Label = CType(e.Item.FindControl("lblorder_number"), Label)
            Dim number = Int32.Parse(lblorder_number.Text)
            Dim state As String = "N"

            check = "SELECT status FROM ORDERHEAD where order_number = '" & number & "' "
            objCmd = New OleDbCommand(check, objConn)
            checkVal = objCmd.ExecuteScalar()

            If state = checkVal Then

                strSQL2 = "SELECT F_ID,ORDER_QUANTITY_KG FROM ORDERDETAIL WHERE ORDER_NUMBER = '" & number & "' "                

                With objCmd
                    .Connection = objConn
                    .CommandText = strSQL2
                    .CommandType = CommandType.Text
                End With
                Try
                    objCmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                dtAdapter = New OleDbDataAdapter()
                dt = New DataSet()
                dtAdapter.SelectCommand = objCmd
                dtAdapter.Fill(dt, "Query")
                'dtAdapter.Fill(dt)

                For Each rows As DataRow In dt.Tables("Query").Rows
                    strSQL2 = "UPDATE FRUITSTOCK SET INSTOCK_KG = INSTOCK_KG - " & Int32.Parse(rows("ORDER_QUANTITY_KG").ToString()) & _
                        " WHERE F_ID = '" & rows("F_ID").ToString() & "' "

                    objCmd = New OleDbCommand
                    With objCmd
                        .Connection = objConn
                        .CommandText = strSQL2
                        .CommandType = CommandType.Text
                    End With
                    Try
                        objCmd.ExecuteNonQuery()
                        MsgBox("Update stock complete")
                    Catch ex As Exception
                        MsgBox("not pass update")
                        MsgBox(ex.Message)
                    End Try
                Next
                '---------------------------------------------------------------UPDATE
                UpdateStatus(number)
                MsgBox("Update status complete")
                UpdateDate(number)
                MsgBox("Update recieved date complete")
                Dim strSQL1 As String = "SELECT DISTINCT * FROM ORDERHEAD ORDER BY order_number"
                BindData(strSQL1)
            End If
        End If
    End Sub

    Sub UpdateStatus(ByVal e As String)
        Dim update As String
        Dim news As String = "Y"

        update = "UPDATE ORDERHEAD SET status = '" & news & "' WHERE order_number = '" & e & "'"
        With objCmd
            .Connection = objConn
            .CommandText = update
            .CommandType = CommandType.Text
        End With
        Try
            objCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No")
        End Try

    End Sub

    Sub UpdateDate(ByVal e As String)
        Dim en = New System.Globalization.CultureInfo("es-US")
        Dim dateCur As Date = Date.Today
        Dim strDateCur As String = dateCur.ToString("dd-MMM-yyyy", en)
        Dim up As String

        up = "UPDATE ORDERHEAD SET r_date = '" & strDateCur & "' WHERE order_number = '" & e & "' "

        objCmd = New OleDbCommand
        With objCmd
            .Connection = objConn
            .CommandText = up
            .CommandType = CommandType.Text
        End With
        Try
            objCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("No")
        End Try
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT DISTINCT * FROM ORDERHEAD OH JOIN ORDERDETAIL OD ON(OH.order_number=OD.order_number) JOIN CUSTOMER C ON(C.c_id=OH.c_id) JOIN FRUITSTOCK F ON(F.f_id=OD.f_id) WHERE " & OrderTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub

End Class
