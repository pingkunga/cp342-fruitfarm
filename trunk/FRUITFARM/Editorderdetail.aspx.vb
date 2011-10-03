Imports System.Data
Imports System.Data.OleDb

Partial Class Editorderdetail
    Inherits System.Web.UI.Page

    Dim objConn As OleDbConnection
    Dim objCmd As OleDbCommand
    Dim dtReader As OleDbDataReader
    Dim strConnString, strSQL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblUser.Text = "คุณ " + Session("strUser")

        Dim strConnString As String
        strConnString = "Provider=OraOLEDB.Oracle;Data Source=orcl;User Id=admin;Password=oracle;OLEDB.NET=True;"
        objConn = New OleDbConnection(strConnString)
        objConn.Open()

        If Not Page.IsPostBack() Then
            ViewData()
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("strUser") = Nothing
        Response.Redirect("FirstPage.aspx")
    End Sub

    Sub ViewData()
        Dim dtAdapter As OleDbDataAdapter
        Dim dt As New DataTable
        Dim data, d As String
        strSQL = "SELECT order_quantity_kg,order_price FROM ORDERDETAIL WHERE order_number = '" & Request.QueryString("order_number") & "' AND f_id = '" & Request.QueryString("f_id") & "' "
        dtAdapter = New OleDbDataAdapter(strSQL, objConn)
        dtAdapter.Fill(dt)

        d = "SELECT price_kg FROM FRUITSTOCK WHERE f_id = '" & Request.QueryString("f_id") & "' "
        objCmd = New OleDbCommand(d, objConn)
        data = objCmd.ExecuteScalar()

        data = data * dt.Rows(0)("order_quantity_kg")

        If dt.Rows.Count > 0 Then
            Me.txtorder_quantity_kg.Text = dt.Rows(0)("order_quantity_kg")
        End If
        Me.txtorder_price.Text = data
    End Sub

    Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEdit.Click
        Dim checkEdit, checkE As String
        Dim stateEdit As String = "N"

        checkE = "SELECT status FROM ORDERHEAD where order_number = '" & Request.QueryString("order_number") & "'"
        objCmd = New OleDbCommand(checkE, objConn)
        checkEdit = objCmd.ExecuteScalar()

        If stateEdit = checkEdit Then

            strSQL = "UPDATE ORDERDETAIL SET " & _
            " order_quantity_kg = '" & Me.txtorder_quantity_kg.Text & "' " & _
            " ,order_price = '" & Me.txtorder_price.Text & "' " & _
            " WHERE order_number = '" & Request.QueryString("order_number") & "' AND f_id = '" & Request.QueryString("f_id") & "' "

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
                Me.lblStatus.Text = "Update Complete"
                Me.HyperLink1.Visible = True
            Catch ex As Exception
                Me.lblStatus.Visible = True
                Me.lblStatus.Text = "Update Fail (" & ex.Message & ")"
                Me.HyperLink1.Visible = True
            End Try
            Response.Redirect("order.aspx")
        Else
            MsgBox("You Can't Edit Price")
        End If

    End Sub

    Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("order.aspx")

    End Sub

    Sub Page_UnLoad()
        objConn.Close()
        objConn = Nothing
    End Sub

End Class
