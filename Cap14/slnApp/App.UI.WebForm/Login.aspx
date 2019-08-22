<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="App.UI.WebForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    	<form id="form1" runat="server">        <div>            <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>        </div>        <div>            <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>        </div>        <div>            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>        </div>        <div>            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />        </div>    </form>
</body>
</html>
