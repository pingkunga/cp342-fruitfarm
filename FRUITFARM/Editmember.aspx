<%@ Page Language="VB" CodeFile="Editmember.aspx.vb" Inherits="Editmember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Member</title>
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
          <li><a href="Order.aspx">ORDER LIST</a></li>
          <li><a href="Bill.aspx">BILL LIST</a></li>
          <li><a href="Fruitstock.aspx">FRUITSTOCK</a></li>
          <li><a href="Orchard.aspx">ORCHARD</a></li>
          <li><a href="Customer.aspx">CUSTOMER</a></li>         
          <li class="selected"><a href="Member.aspx">MEMBER</a></li>
          <li><asp:LinkButton ID="LinkButton1" runat="server" onclientclick="return confirm('Do you want to logout????');">LOGOUT</asp:LinkButton></li>
        </ul>
      </div>
    </div>
    <div id="site_content">


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Welcome :&nbsp;&nbsp;
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    <h1>Edit Member</h1>   
    <asp:Panel id="pnlAdd1" runat="server">
    
    <table cellpadding="4%" style="position:relative; font-weight:bold;width: 100%">
            <tr align="left">
                <td>
                    &nbsp; Member ID :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtm_id" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; FirstName :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtm_fname" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; LastName :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtm_lname" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Position :
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="PositionList1" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="P_NAME" DataValueField="P_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        SelectCommand="SELECT * FROM &quot;POSITION&quot; ORDER BY &quot;P_NAME&quot;"></asp:SqlDataSource>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Address :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtm_address" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Province :
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="ProvinceList1" runat="server" DataSourceID="province" 
                        DataTextField="PROVINCE_NAME" DataValueField="PROVINCE_ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="province" runat="server" 
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
                    <asp:TextBox ID="txtm_tel" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td>
                    &nbsp; Email :
                </td>
                <td>
                    &nbsp;
                    <asp:TextBox ID="txtm_email" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr align="left">
                <td></td>
                <td>&nbsp;&nbsp;<asp:Button ID="btnEdit" runat="server" Text="Edit" Width="60px"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px"/>
                </td>
            </tr>
        </table>
        
        </asp:Panel>

    <div style="text-align:center">
    <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="False" NavigateUrl="Member.aspx">View Member</asp:HyperLink>
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
