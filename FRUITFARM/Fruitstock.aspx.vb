Imports System.Data
Imports System.Data.OleDb

Partial Class Fruitstock
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()
        Dim strSQL1 As String = "SELECT * FROM FRUITSTOCK ORDER BY f_id"
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
            Response.Redirect("Fruitstock.aspx")
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
        '*** Fruit ID ***'
        Dim lblf_id As Label = CType(e.Item.FindControl("lblf_id"), Label)
        If Not IsNothing(lblf_id) Then
            lblf_id.Text = e.Item.DataItem("f_id")
        End If

        '*** Fruit ***'
        Dim lblf_name As Label = CType(e.Item.FindControl("lblf_name"), Label)
        If Not IsNothing(lblf_name) Then
            lblf_name.Text = e.Item.DataItem("f_name")
        End If

        '*** Instock ***'
        Dim lblinstock_kg As Label = CType(e.Item.FindControl("lblinstock_kg"), Label)
        If Not IsNothing(lblinstock_kg) Then
            lblinstock_kg.Text = e.Item.DataItem("instock_kg")
        End If

        Dim lblfprice As Label = CType(e.Item.FindControl("lblfprice"), Label)
        If Not IsNothing(lblfprice) Then
            lblfprice.Text = e.Item.DataItem("price_kg")
        End If

        Dim hplEdit As HyperLink = CType(e.Item.FindControl("hplEdit"), HyperLink)
        If Not IsNothing(hplEdit) Then
            hplEdit.Text = "Edit"
            hplEdit.NavigateUrl = "Editfruitstock.aspx?f_id=" & e.Item.DataItem("f_id")
        End If

        Dim lnkDelete As LinkButton = CType(e.Item.FindControl("lnkDelete"), LinkButton)
        If Not IsNothing(lnkDelete) Then
            lnkDelete.Attributes.Add("OnClick", "return confirm('Delete Fruit?');")
        End If

    End Sub

    Sub myRepeater_ItemCommand(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles myRepeater.ItemCommand
        If e.CommandName = "Delete" Then
            Dim strSQL As String
            Dim lblf_id As Label = CType(e.Item.FindControl("lblf_id"), Label)

            Try
                strSQL = "DELETE FROM FRUITSTOCK WHERE f_id = '" & lblf_id.Text & "' "
                objCmd = New OleDbCommand(strSQL, objConn)
                objCmd.ExecuteNonQuery()
                'objCmd.commit()
                Dim strSQL2 As String = "SELECT * FROM FRUITSTOCK ORDER BY f_id"
                BindData(strSQL2)
            Catch ex As Exception
                MsgBox("You can't delete.")
            End Try
            
        End If
    End Sub

    Protected Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Dim strSQL As String = "SELECT * FROM FRUITSTOCK WHERE " & FruitTableList.SelectedValue & " = '" & TextBox1.Text & "' "
        BindData(strSQL)
    End Sub
End Class
