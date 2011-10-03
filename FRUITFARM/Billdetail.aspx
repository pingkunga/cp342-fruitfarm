﻿<%@ Page Language="VB" CodeFile="Billdetail.aspx.vb" Inherits="Billdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Detail</title>
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
    <h1>Bill Detail</h1> 
    <asp:HyperLink ID="HyperLink2" runat="server" Visible="true" NavigateUrl="Insertbilldetail.aspx">Add Bill Detail</asp:HyperLink>    
    &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="true" NavigateUrl="Bill.aspx">Back</asp:HyperLink>
    
    <asp:Repeater id="myRepeater" runat="server">
	<HeaderTemplate>
		<table border="0" width="99%">
			<tr>
				<th>Bill Number</th>
				<th>Fruit ID</th>
                <th>Fruit</th>
                <th>Orchard ID</th>
                <th>Orchard</th>
				<th>Quantity(KG)</th>
				<th>Price</th>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td align="center"><asp:Label id="lblbill_number" runat="server"></asp:Label></td>
			<td><asp:Label id="lblf_id" runat="server"></asp:Label></td>
            <td><asp:Label id="lblf_name" runat="server"></asp:Label></td>
            <td><asp:Label id="lblorc_id" runat="server"></asp:Label></td>
            <td><asp:Label id="lblorc_name" runat="server"></asp:Label></td>
			<td><asp:Label id="lblbill_quantity_kg" runat="server"></asp:Label></td>
			<td align="right"><asp:Label id="lblbill_price" runat="server"></asp:Label></td>
            <td align="right"><asp:LinkButton id="lnkDelete" CommandName="Delete" runat="server">Delete</asp:LinkButton></td>
		</tr>		       
	</ItemTemplate>
	</asp:Repeater>
    <table>
        <tr>
            <td>TOTAL PAID :</td>
            <td><asp:Label ID="totalPaid" runat="server" Text=""></asp:Label> Bath</td>
        </tr>
    </table>

    </div>
    </div>
    </div>
    
</form>
</body>
</html>