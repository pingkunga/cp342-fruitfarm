<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <meta name="description" content="website description" />
    <meta name="keywords" content="website keywords, website keywords" />
    <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
    <link rel="stylesheet" type="text/css" href="style/style.css" title="style" />
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
          <li class="selected"><a href="Register.aspx">REGISTER</a></li>
          <li><a href="LogCustomer.aspx">CUSTOMER</a></li>
          <li><a href="LogAdmin.aspx">ADMIN</a></li>
          <li><a href="Contact.aspx">CONTACT US</a></li>
        </ul>
      </div>
    </div>
    <div id="site_content">
    <h1>Register Customer</h1>   
    <asp:Panel id="pnlAdd1" runat="server">
    
    <table cellpadding="4%" style="position:relative; font-weight:bold;width: 100%">
            <tr align="left">
                <td>
                    &nbsp; FirstName :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_fname" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; LastName :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_lname" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Password :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_password" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Address :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_address" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Province :
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="PROVINCE_NAME" DataValueField="PROVINCE_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        SelectCommand="SELECT * FROM &quot;PROVINCE&quot; ORDER BY &quot;PROVINCE_NAME&quot;"></asp:SqlDataSource>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Telephone :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_tel" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Email :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtc_email" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td></td>
                <td>&nbsp;&nbsp;<asp:Button ID="btnInsert" runat="server" Text="Register" 
                        Width="60px"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px"/>
                </td>
            </tr>
        </table>
        </asp:panel>
        
        <div style="text-align:center">
    <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" NavigateUrl="FirstPage.aspx">Back to First Page</asp:HyperLink><br />
    <asp:HyperLink ID="HyperLink2" runat="server" Visible="False" NavigateUrl="LogCustomer.aspx">Login</asp:HyperLink>
    </div>
    </div>
    <div id="content_footer"></div>
    <div id="footer">
      Copyright &copy; colour_green | <a href="http://validator.w3.org/check?uri=referer">HTML5</a> | <a href="http://jigsaw.w3.org/css-validator/check/referer">CSS</a> | <a href="http://www.html5webtemplates.co.uk">design from HTML5webtemplates.co.uk</a>
    </div>
    <div style="text-align: center; font-size: 0.75em;">Design downloaded from <a href="http://www.freewebtemplates.com/">free website templates</a>.</div>
    </div>
    </form>
</body>
</html>
