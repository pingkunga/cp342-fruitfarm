<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Insertbill.aspx.vb" Inherits="Insertbill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Bill</title>
    <meta name="description" content="website description" />
    <meta name="keywords" content="website keywords, website keywords" />
    <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
    <link rel="stylesheet" type="text/css" href="style/style.css" title="style" />
    <script language=JavaScript src="style/pc.js"></script>
</head>
<body>
 
    <form id="form1" runat="server">

    <div>
        <div id="main">
    <div id="header">
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="index.html">fruit<span class="logo_colour">farm</span></a></h1>
          <h2>Group3. ComSwu21. Create Website.</h2>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li><a href="Order.aspx">ORDER LIST</a></li>
          <li class="selected"><a href="Bill.aspx">BILL LIST</a></li>
          <li><a href="Fruitstock.aspx">FRUITSTOCK</a></li>
          <li><a href="Orchard.aspx">ORCHARD</a></li>
          <li><a href="Customer.aspx">CUSTOMER</a></li>       
          <li><a href="Member.aspx">MEMBER</a></li>
          <li><asp:LinkButton ID="LinkButton1" runat="server" onclientclick="return confirm('Do you want to logout????');">LOGOUT</asp:LinkButton></li>
        </ul>
      </div>
    </div>
    <div id="site_content">


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Welcome :&nbsp;&nbsp;
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    <asp:Panel id="pnlAdd1" runat="server">  
    <h1>Add Bill</h1>
    <table cellpadding="4%" style="position:relative; font-weight:bold;width: 95%">
            <tr align="left">
                <td style="width:25%">
                    &nbsp; Date :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtbill_date" runat="server" Width="100px"></asp:TextBox>
                    <a href="javascript:;" onclick="window.open('popup.aspx?textbox=txtbill_date','cal','width=250,height=225,left=270,top=180')">
                    <img src="style/SmallCalendar.gif" border="0"></a>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Orchard :
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="OrchardList1" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="ORC_NAME" DataValueField="ORC_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT * FROM &quot;ORCHARD&quot;"></asp:SqlDataSource>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Member Purchase :
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="MemberList1" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="M_FNAME" DataValueField="M_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT * FROM &quot;MEMBER&quot; ORDER BY &quot;M_FNAME&quot;"></asp:SqlDataSource>
                </td>
            </tr>
            <tr align="left">
                <td class="style2"></td>
                <td>&nbsp;&nbsp;<asp:Button ID="btnInsert" runat="server" Text="Insert" Width="60px" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px"/></td>
            </tr>
        </table>
            
        </asp:Panel>
 

    <div style="text-align:center">
    <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" NavigateUrl="Insertbill.aspx">Back to Add Bill List Page</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink2" runat="server" Visible="False" NavigateUrl="Bill.aspx">View Bill List</asp:HyperLink>
    </div>


    </div>
    </div>
    </div>
    <div id="content_footer"></div>
    <div id="footer">
      Copyright &copy; colour_green | <a href="http://validator.w3.org/check?uri=referer">HTML5</a> | <a href="http://jigsaw.w3.org/css-validator/check/referer">CSS</a> | <a href="http://www.html5webtemplates.co.uk">design from HTML5webtemplates.co.uk</a>
    </div>
    <div style="text-align: center; font-size: 0.75em;">Design downloaded from <a href="http://www.freewebtemplates.com/">free website templates</a>.</div>
    

</form>
</body>
</html>