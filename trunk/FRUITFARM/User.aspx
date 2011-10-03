<%@ Page Language="VB" CodeFile="User.aspx.vb" Inherits="User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Detail</title>
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
          <li class="selected"><a href="User.aspx">PERSONAL DETAIL</a></li>
          <li><a href="Orderuser.aspx">ORDER LIST</a></li>
          <li><a href="Fruitlist.aspx">FRUIT LIST</a></li>
          <li><asp:LinkButton ID="LinkButton1" runat="server" onclientclick="return confirm('Do you want to logout????');">LOGOUT</asp:LinkButton></li>
        </ul>
      </div>
    </div>
    <div id="site_content">

    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Welcome :&nbsp;&nbsp;
        <asp:Label ID="lblUser" runat="server"></asp:Label>
    <h1>Personal Detail</h1>

    <asp:Repeater id="myRepeater" runat="server">

    <ItemTemplate>
    <table width="99%" cellpadding="4%" border="0" style="position:relative;">
        <tr>
			<td align="left" style="width:25%">Customer ID :</td>
            <td align="left"><%# Container.DataItem("c_id")%></td>
        <tr/>
        <tr>
			<td align="left">Password :</td>
            <td align="left"><%# Container.DataItem("c_password")%></td>
        <tr/>
        <tr>
			<td align="left">FirstName :</td>
            <td align="left"><%# Container.DataItem("c_fname")%></td>
        <tr/>
        <tr>
			<td align="left">LastName :</td>
            <td align="left"><%# Container.DataItem("c_lname")%></td>
        <tr/>
        <tr>
			<td align="left">Address :</td>
            <td align="left"><%# Container.DataItem("c_address")%></td>
        <tr/>
        <tr>
			<td align="left">Province ID :</td>
            <td align="left"><%# Container.DataItem("province_id")%></td>
        <tr/>
        <tr>
			<td align="left">Telephone :</td>
            <td align="left"><%# Container.DataItem("c_tel")%></td>
        <tr/>
        <tr>
			<td align="left">Email :</td>
            <td align="left"><%# Container.DataItem("c_email")%></td>
        <tr/>
    <table />
    </ItemTemplate>
	</asp:Repeater> 
   
    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="60px"/>
       
    
    </div>
    </div>
    </div>
   
</form>
</body>
</html>