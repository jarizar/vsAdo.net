<%@ Page Title="Administración de Track" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackEdit.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 225px;">
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 26px; width: 130px">
            <asp:Label ID="Label2" runat="server" Text="Album"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:DropDownList ID="ddlAlbum" runat="server" Width="203px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px; height: 7px">
            <asp:Label ID="Label3" runat="server" Text="Medio"></asp:Label>
        </td>
        <td style="height: 7px">
            <asp:DropDownList ID="ddlMedio" runat="server" Width="202px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label4" runat="server" Text="Género"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlGenero" runat="server" Width="203px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label5" runat="server" Text="Compositor"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtcompositor" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label6" runat="server" Text="Duración"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDuracion" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label7" runat="server" Text="Peso"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label8" runat="server" Text="Precio"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">&nbsp;</td>
        <td>
            <asp:Button ID="cmdGuardar" runat="server" Text="Guardar" OnClick="cmdGuardar_Click" />
        </td>
    </tr>
</table>
</asp:Content>
