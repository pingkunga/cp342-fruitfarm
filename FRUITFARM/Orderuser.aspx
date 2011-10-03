<%@ Page Language="VB" CodeFile="Orderuser.aspx.vb" Inherits="Orderuser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order List</title>
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
          <li><a href="User.aspx">PERSONAL DETAIL</a></li>
          <li class="selected"><a href="Orderuser.aspx">ORDER LIST</a></li>
          <li><a href="Fruitlist.aspx">FRUIT LIST</a></li>
          <li><asp:LinkButton ID="LinkButton1" runat="server" onclientclick="return confirm('Do you want to logout????');">LOGOUT</asp:LinkButton></li>
        </ul>
      </div>
    </div>
    <div id="site_content">


    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Welcome :&nbsp;&nbsp;
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    <h1>Order List&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        search&nbsp;
        <asp:DropDownList ID="OrderTableList" runat="server">
            <asp:ListItem Value="OH.ORDER_NUMBER">Order Number</asp:ListItem>
            <asp:ListItem Value="OH.ORDER_DATE">Order Date</asp:ListItem>
            <asp:ListItem Value="OH.R_DATE">Recieved Date</asp:ListItem>
            <asp:ListItem Value="OD.F_ID">Fruit ID</asp:ListItem>
            <asp:ListItem Value="F.F_NAME">Fruit</asp:ListItem>
            <asp:ListItem Value="OH.STATUS">Status</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <a href="javascript:;" onclick="window.open('popup.aspx?textbox=TextBox1','cal','width=250,height=225,left=270,top=180')">
        <img src="style/SmallCalendar.gif" border="0"></a>
&nbsp;&nbsp;
        <asp:Button ID="btn_search" runat="server" Text="Search" />
        </h1>
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="true" NavigateUrl="Insertorderuser.aspx">Add Order</asp:HyperLink>
        
    <asp:Repeater id="myRepeater" runat="server">
	<HeaderTemplate>
		<table border="0" width="99%">
			<tr>
				<th>Order Number</th>
				<th>Order Date</th>
                <th>Recieved Date</th>
				<th>Customer ID</th>
                <th>Status</th>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td align="center"><asp:Label id="lblorder_number" runat="server"></asp:Label></td>
			<td><asp:Label id="lblorder_date" runat="server"></asp:Label></td>
            <td><asp:Label id="lblr_date" runat="server"></asp:Label></td>
			<td><asp:Label id="lblc_id" runat="server"></asp:Label></td>
            <td align="right"><asp:Label id="lblstatus" runat="server"></asp:Label></td>
            <td align="right"><asp:Hyperlink id="hplDetail" runat="server"></asp:Hyperlink></td>
            <td align="right"><asp:LinkButton id="lnkDelete" CommandName="Delete" runat="server">Delete</asp:LinkButton></td>
		</tr>			
	</ItemTemplate>
	</asp:Repeater>

    </div>
    </div>
    </div>
    
</form>
</body>
</html>