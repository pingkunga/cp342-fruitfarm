Imports System.Data
Imports System.Data.OleDb

Partial Class Customer
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
        Dim strSQL1 As String = "SELECT * FROM CUSTOMER ORDER BY c_id"
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
            Response.Redirect("Customer.aspx")
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
        '*** CustomerID ***'
        Dim lblc_id As Label = CType(e.Item.FindControl("lblc_id"), Label)
        If Not IsNothing(lblc_id) Then
            lblc_id.Text = e.Item.DataItem("c_id")
        End If

        '*** FirstName ***'
        Dim lblc_fname As Label = CType(e.Item.FindControl("lblc_fname"), Label)
        If Not IsNothing(lblc_fname) Then
            lblc_fname.Text = e.Item.DataItem("c_fname")
        End If

        '*** LastName ***'
        Dim lblc_lname As Label = CType(e.Item.FindControl("lblc_lname"), Label)
        If Not IsNothing(lblc_lname) Then
            lblc_lname.Text = e.Item.DataItem("c_lname")
        End If

        '*** Address ***'
        Dim lblc_address As Label = CType(e.Item.FindControl("lblc_address"), Label)
        If Not IsNothing(lblc_address) Then
            lblc_address.Text = e.Item.DataItem("c_address")
        End If

        '*** Province ***'
        Dim lblprovince_id As Label = CType(e.Item.FindControl("lblprovince_id"), Label)
        If Not IsNothing(lblprovince_id) Then
            lblprovince_id.Text = e.Item.DataItem("province_id")
        End If

        '*** Tel ***'
        Dim lblc_tel As Label = CType(e.Item.FindControl("lblc_tel"), Label)
        If Not IsNothing(lblc_tel) Then
            lblc_tel.Text = e.Item.DataItem("c_tel")
        End If

        '*** Email ***'
        Dim lblc_email As Label = CType(e.Item.FindControl("lblc_email"), Label)
        If Not IsNothing(lblc_email) Then
            lblc_email.Text = e.Item.DataItem("c_email")
        End If

        Dim hplEdit As HyperLink = CType(e.Item.FindControl("hplEdit"), HyperLink)
        If Not IsNothing(hplEdit) Then
            hplEdit.Text = "Edit"
            hplEdit.NavigateUrl = "Editcustomer.aspx?c_id=" & e.Item.DataItem("c_id")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Customer?');")
        End If
    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String
            Dim lblc_id As Label = CType(e.Item.FindControl("lblc_id"), Label)

            Try
                strSQL = "DELETE FROM CUSTOMER WHERE c_id = '" & lblc_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                Dim strSQL2 As String = "SELECT * FROM CUSTOMER ORDER BY c_id"
                BindData(strSQL2)
            Catch ex As Exception
                MsgBox("You can't delete.")
            End Try        
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT * FROM CUSTOMER C JOIN PROVINCE P ON(C.province_id=P.province_id) WHERE " & CustTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub

End Class
