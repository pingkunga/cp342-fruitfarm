<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Fruitlist.aspx.vb" Inherits="Fruitlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fruit List</title>
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
          <li><a href="User.aspx">PERSONAL DETAIL</a></li>
          <li><a href="Orderuser.aspx">ORDER LIST</a></li>
          <li class="selected"><a href="Fruitlist.aspx">FRUIT LIST</a></li>
          <li><asp:LinkButton ID="LinkButton1" runat="server" onclientclick="return confirm('Do you want to logout????');">LOGOUT</asp:LinkButton></li>
        </ul>
      </div>
    </div>
    <div id="site_content">


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Welcome :&nbsp;&nbsp;
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    <h1>Fruit List&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        search&nbsp;
        <asp:DropDownList ID="FruitTableList" runat="server">
            <asp:ListItem Value="F_ID">Fruit Id</asp:ListItem>
            <asp:ListItem Value="F_NAME">Fruit</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btn_search" runat="server" Text="Search" />
        </h1>
        * ราคาผลไม้อาจมีการเปลี่ยนแปลงตามความเหมาะสม
    <asp:Repeater id="myRepeater" runat="server">
	<HeaderTemplate>
		<table border="0" width="99%">
			<tr>
				<th>Fruit ID</th>
				<th>Fruit</th>
                <th>Price/KG</th>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td align="center"><asp:Label id="lblf_id" runat="server"></asp:Label></td>
			<td><asp:Label id="lblf_name" runat="server"></asp:Label></td>
            <td><asp:Label id="lblfprice" runat="server"></asp:Label></td>
		</tr>			
	</ItemTemplate>
	</asp:Repeater>


    </div>
    </div>
    </div>
    
</form>
</body>
</html>