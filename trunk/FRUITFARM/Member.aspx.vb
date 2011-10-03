Imports System.Data
Imports System.Data.OleDb

Partial Class Member
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")
        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
        Dim strSQL1 As String = "SELECT * FROM MEMBER ORDER BY m_id"
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
            Response.Redirect("Member.aspx")
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
        '*** Member ID ***'
        Dim lblm_id As Label = CType(e.Item.FindControl("lblm_id"), Label)
        If Not IsNothing(lblm_id) Then
            lblm_id.Text = e.Item.DataItem("m_id")
        End If

        '*** FirstName ***'
        Dim lblm_fname As Label = CType(e.Item.FindControl("lblm_fname"), Label)
        If Not IsNothing(lblm_fname) Then
            lblm_fname.Text = e.Item.DataItem("m_fname")
        End If

        '*** LastName ***'
        Dim lblm_lname As Label = CType(e.Item.FindControl("lblm_lname"), Label)
        If Not IsNothing(lblm_lname) Then
            lblm_lname.Text = e.Item.DataItem("m_lname")
        End If

        '*** Position ***'
        Dim lblp_id As Label = CType(e.Item.FindControl("lblp_id"), Label)
        If Not IsNothing(lblp_id) Then
            lblp_id.Text = e.Item.DataItem("p_id")
        End If

        '*** Address ***'
        Dim lblm_address As Label = CType(e.Item.FindControl("lblm_address"), Label)
        If Not IsNothing(lblm_address) Then
            lblm_address.Text = e.Item.DataItem("m_address")
        End If

        '*** Province ***'
        Dim lblprovince_id As Label = CType(e.Item.FindControl("lblprovince_id"), Label)
        If Not IsNothing(lblprovince_id) Then
            lblprovince_id.Text = e.Item.DataItem("province_id")
        End If

        '*** Tel ***'
        Dim lblm_tel As Label = CType(e.Item.FindControl("lblm_tel"), Label)
        If Not IsNothing(lblm_tel) Then
            lblm_tel.Text = e.Item.DataItem("m_tel")
        End If

        '*** Email ***'
        Dim lblm_email As Label = CType(e.Item.FindControl("lblm_email"), Label)
        If Not IsNothing(lblm_email) Then
            lblm_email.Text = e.Item.DataItem("m_email")
        End If

        Dim hplEdit As HyperLink = CType(e.Item.FindControl("hplEdit"), HyperLink)
        If Not IsNothing(hplEdit) Then
            hplEdit.Text = "Edit"
            hplEdit.NavigateUrl = "Editmember.aspx?m_id=" & e.Item.DataItem("m_id")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Member?');")
        End If

    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String
            Dim lblm_id As Label = CType(e.Item.FindControl("lblm_id"), Label)


            Try
                strSQL = "DELETE FROM MEMBER WHERE m_id = '" & lblm_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                Dim strSQL2 As String = "SELECT * FROM MEMBER ORDER BY m_id"
                BindData(strSQL2)
            Catch ex As Exception
                MsgBox("You can't delete.")
            End Try
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT * FROM MEMBER M JOIN PROVINCE P ON(M.province_id=P.province_id) JOIN POSITION POS ON(POS.p_id=M.p_id) WHERE " & MemTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub

End Class
