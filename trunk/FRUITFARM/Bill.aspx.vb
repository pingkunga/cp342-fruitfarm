Imports System.Data
Imports System.Data.OleDb

Partial Class Bill
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
        Dim strSQL1 As String = "SELECT DISTINCT * FROM BILLHEAD ORDER BY bill_number"
        BindData(strSQL1)
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
            Response.Redirect("Bill.aspx")
        End Try

        '*** BindData to GridView ***'
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

    Sub myRepeater_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles myRepeater.ItemDataBound
        '*** Bill Number ***'
        Dim lblbill_number As Label = CType(e.Item.FindControl("lblbill_number"), Label)
        If Not IsNothing(lblbill_number) Then
            lblbill_number.Text = e.Item.DataItem("bill_number")
        End If

        '*** Bill Date ***'
        Dim lblbill_date As Label = CType(e.Item.FindControl("lblbill_date"), Label)
        If Not IsNothing(lblbill_date) Then
            lblbill_date.Text = e.Item.DataItem("bill_date")
        End If

        '*** ORD ID ***'
        Dim lblorc_id As Label = CType(e.Item.FindControl("lblorc_id"), Label)
        If Not IsNothing(lblorc_id) Then
            lblorc_id.Text = e.Item.DataItem("orc_id")
        End If

        '*** Member ID ***'
        Dim lblm_id As Label = CType(e.Item.FindControl("lblm_id"), Label)
        If Not IsNothing(lblm_id) Then
            lblm_id.Text = e.Item.DataItem("m_id")
        End If

        Dim lblstatus As Label = CType(e.Item.FindControl("lblstatus"), Label)
        If Not IsNothing(lblstatus) Then
            lblstatus.Text = e.Item.DataItem("status")
        End If

        Dim hplDetail As HyperLink = CType(e.Item.FindControl("hplDetail"), HyperLink)
        If Not IsNothing(hplDetail) Then
            hplDetail.Text = "Detail"
            hplDetail.NavigateUrl = "BillDetail.aspx?bill_number=" & e.Item.DataItem("bill_number")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Bill?');")
        End If

    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String

            Dim lblbill_number As Label = CType(e.Item.FindControl("lblbill_number"), Label)
            strSQL = "DELETE FROM BILLHEAD WHERE bill_number = '" & lblbill_number.Text & "' "
            objCmd = New OleDbCommand(strSQL, objConn)
            objCmd.ExecuteNonQuery()
            'objCmd.commit()
            Dim strSQL2 As String = "SELECT DISTINCT * FROM BILLHEAD ORDER BY bill_number"
            BindData(strSQL2)
        End If

        If e.CommandName = "Accepts" Then

            Dim strSQL2, check, checkVal As String
            Dim lblbill_number As Label = CType(e.Item.FindControl("lblbill_number"), Label)
            Dim number = Int32.Parse(lblbill_number.Text)
            Dim state As String = "N"

            check = "SELECT status FROM BILLHEAD where bill_number = '" & number & "' "
            objCmd = New OleDbCommand(check, objConn)
            checkVal = objCmd.ExecuteScalar()

            If state = checkVal Then

                MsgBox("pass")
                strSQL2 = "SELECT F_ID,BILL_QUANTITY_KG FROM BILLDETAIL WHERE BILL_NUMBER = '" & number & "' "
                'strSQL2 = "SELECT * FROM BILLDETAIL"
                MsgBox(number)

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

                MsgBox("pass2")
                dtAdapter = New OleDbDataAdapter()
                dt = New DataSet()
                dtAdapter.SelectCommand = objCmd
                dtAdapter.Fill(dt, "Query")
                'dtAdapter.Fill(dt)
                MsgBox("pass3")


                'dt.Tables("Query").Rows(1)("F_ID").ToString()
                '---------------------------------------------------------------UPDATE
                'Dim strsql As String
                'Dim intNumRows As Integer
                'strsql = "SELECT COUNT(*) FROM BILLDETAIL WHERE BILL_NUMBER = '" & number & "' "
                'objCmd = New OleDbCommand(strsql, objConn)
                'intNumRows = objCmd.ExecuteScalar()
                'MsgBox("pass4")
                ' Dim i As Integer
                'i = 0
                ' While (i < intNumRows)
                'strsql = "UPDATE TABLE FRUITSTOCK SET INSTOCK_KG = INSTOCK_KG - " &
                ' i = i + 1
                'End While

                For Each rows As DataRow In dt.Tables("Query").Rows
                    strSQL2 = "UPDATE FRUITSTOCK SET INSTOCK_KG = INSTOCK_KG + " & Int32.Parse(rows("BILL_QUANTITY_KG").ToString()) & _
                        " WHERE F_ID = '" & rows("F_ID").ToString() & "' "
                    MsgBox(strSQL2)
                    objCmd = New OleDbCommand
                    With objCmd
                        .Connection = objConn
                        .CommandText = strSQL2
                        .CommandType = CommandType.Text
                    End With
                    Try
                        objCmd.ExecuteNonQuery()
                        MsgBox("pass update")
                    Catch ex As Exception
                        MsgBox("not pass update")
                        MsgBox(ex.Message)
                    End Try
                Next
                '---------------------------------------------------------------UPDATE
                UpdateStatus(number)
                Dim strSQL1 As String = "SELECT DISTINCT * FROM BILLHEAD ORDER BY bill_number"
                BindData(strSQL1)
            End If
        End If
    End Sub

    Sub UpdateStatus(ByVal e As String)
        Dim update As String
        Dim news As String = "Y"

        update = "UPDATE BILLHEAD SET status = '" & news & "' WHERE bill_number = '" & e & "'"
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

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT DISTINCT * FROM BILLHEAD BH JOIN BILLDETAIL BD ON(BH.bill_number=BD.bill_number) JOIN MEMBER M ON(M.m_id=BH.m_id) JOIN ORCHARD O ON(O.orc_id=BH.orc_id) JOIN FRUITSTOCK F ON(F.f_id=BD.f_id) WHERE " & BillTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub

End Class
