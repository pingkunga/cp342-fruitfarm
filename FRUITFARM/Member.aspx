<%@ Page Language="VB" CodeFile="Member.aspx.vb" Inherits="Member" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member</title>
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
    <h1>Member&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        search&nbsp;
        <asp:DropDownList ID="MemTableList" runat="server">
            <asp:ListItem Value="M_ID">Member ID</asp:ListItem>
            <asp:ListItem Value="M_FNAME">FirstName</asp:ListItem>
            <asp:ListItem Value="M_LNAME">LastName</asp:ListItem>
            <asp:ListItem Value="P_ID">Position ID</asp:ListItem>
            <asp:ListItem Value="P_NAME">Position</asp:ListItem>
            <asp:ListItem Value="PROVINCE_ID">Province ID</asp:ListItem>
            <asp:ListItem Value="PROVINCE_NAME">Province</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btn_search" runat="server" Text="Search" />
        </h1>
    <asp:HyperLink ID="HyperLink2" runat="server" Visible="true" NavigateUrl="Memberdetail.aspx">View Personal Detail</asp:HyperLink>
        &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" Visible="true" NavigateUrl="Insertmember.aspx">Add Member</asp:HyperLink>
    <asp:Repeater id="myRepeater" runat="server">
	<HeaderTemplate>
		<table border="0" width="99%">
			<tr>
				<th>Member ID</th>
				<th>FirstName</th>
				<th>LastName</th>
				<th>Position</th>
				<th>Address</th>
				<th>Province</th>
				<th>Telephone</th>
                <th>Email</th>
			</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td align="center"><asp:Label id="lblm_id" runat="server"></asp:Label></td>
			<td><asp:Label id="lblm_fname" runat="server"></asp:Label></td>
			<td><asp:Label id="lblm_lname" runat="server"></asp:Label></td>
			<td align="center"><asp:Label id="lblp_id" runat="server"></asp:Label></td>
			<td align="right"><asp:Label id="lblm_address" runat="server"></asp:Label></td>
			<td align="right"><asp:Label id="lblprovince_id" runat="server"></asp:Label></td>
            <td align="right"><asp:Label id="lblm_tel" runat="server"></asp:Label></td>
            <td align="right"><asp:Label id="lblm_email" runat="server"></asp:Label></td>
			<td align="right"><asp:Hyperlink id="hplEdit" runat="server"></asp:Hyperlink></td>
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