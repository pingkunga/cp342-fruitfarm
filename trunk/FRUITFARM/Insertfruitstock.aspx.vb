Imports System.Data
Imports System.Data.OleDb

Partial Class Insertfruitstock
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim strConnString, strSQL As String

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

        strSQL = "INSERT INTO FRUITSTOCK " & _
        " VALUES " & _
        " ('" & Me.txtf_id.Text & "','" & Me.txtf_name.Text & "','" & Me.txtinstock_kg.Text & "', " & _
        " '" & Me.OrchardList1.SelectedValue & "')"

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
            Me.HyperLink2.Visible = True
        Catch ex As Exception
            Me.lblStatus.Visible = True
            Me.lblStatus.Text = "Add Fail Error (" & ex.Message & ")"
            Me.HyperLink1.Visible = True
            Me.HyperLink2.Visible = True
        End Try
    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Fruitstock.aspx")

    End Sub

End Class
