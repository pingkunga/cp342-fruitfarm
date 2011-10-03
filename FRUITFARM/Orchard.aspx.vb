Imports System.Data
Imports System.Data.OleDb

Partial Class Orchard
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")
        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
        Dim strSQL1 As String = "SELECT * FROM ORCHARD ORDER BY orc_id"
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
            Response.Redirect("Orchard.aspx")
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
        '*** Orchard ID ***'
        Dim lblorc_id As Label = CType(e.Item.FindControl("lblorc_id"), Label)
        If Not IsNothing(lblorc_id) Then
            lblorc_id.Text = e.Item.DataItem("orc_id")
        End If

        '*** Orchard Name ***'
        Dim lblorc_name As Label = CType(e.Item.FindControl("lblorc_name"), Label)
        If Not IsNothing(lblorc_name) Then
            lblorc_name.Text = e.Item.DataItem("orc_name")
        End If

        '*** Address ***'
        Dim lblorc_address As Label = CType(e.Item.FindControl("lblorc_address"), Label)
        If Not IsNothing(lblorc_address) Then
            lblorc_address.Text = e.Item.DataItem("orc_address")
        End If

        '*** Province ***'
        Dim lblprovince_id As Label = CType(e.Item.FindControl("lblprovince_id"), Label)
        If Not IsNothing(lblprovince_id) Then
            lblprovince_id.Text = e.Item.DataItem("province_id")
        End If

        '*** Orchard Tel ***'
        Dim lblorc_tel As Label = CType(e.Item.FindControl("lblorc_tel"), Label)
        If Not IsNothing(lblorc_tel) Then
            lblorc_tel.Text = e.Item.DataItem("orc_tel")
        End If

        '*** Orchard Email ***'
        Dim lblorc_email As Label = CType(e.Item.FindControl("lblorc_email"), Label)
        If Not IsNothing(lblorc_email) Then
            lblorc_email.Text = e.Item.DataItem("orc_email")
        End If

        Dim hplEdit As HyperLink = CType(e.Item.FindControl("hplEdit"), HyperLink)
        If Not IsNothing(hplEdit) Then
            hplEdit.Text = "Edit"
            hplEdit.NavigateUrl = "Editorchard.aspx?orc_id=" & e.Item.DataItem("orc_id")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Orchard?');")
        End If

    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String
            Dim lblorc_id As Label = CType(e.Item.FindControl("lblorc_id"), Label)

            Try
                strSQL = "DELETE FROM ORCHARD WHERE ORC_ID = '" & lblorc_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                Dim strSQL2 As String = "SELECT * FROM ORCHARD ORDER BY orc_id"
                BindData(strSQL2)
            Catch ex As Exception
                MsgBox("You can't delete.")
            End Try
            
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT * FROM ORCHARD O JOIN PROVINCE P ON(O.province_id=P.province_id) WHERE " & OrcTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub

End Class
