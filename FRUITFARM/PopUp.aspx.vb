Imports System.Web.UI.HtmlControls.HtmlGenericControl

Namespace DotNetJohn

  Public Class PopUp
    Inherits System.Web.UI.Page

    Protected WithEvents control As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents calDate As System.Web.UI.WebControls.Calendar

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      control.Value = Request.QueryString("textbox").ToString()
    End Sub

    Protected Sub Change_Date(sender As System.Object, e As System.EventArgs)
      Dim strScript As String = "<script>window.opener.document.forms(0)." + control.Value + ".value = '"
            Dim en = New System.Globalization.CultureInfo("en-US") 'ค่าเป็น ค.ศ.
            strScript += calDate.SelectedDate.ToString("dd-MMM-yyyy", en)
            strScript += "';self.close()"
            strScript += "</" + "script>"
      RegisterClientScriptBlock("anything",strScript)
    End Sub

  End Class

End Namespace
