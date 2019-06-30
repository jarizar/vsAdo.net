<%@ Page Title="Administración de Track" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackEdit.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="contenthead" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentMain" runat="server">

<form id="form1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList">
    </asp:ValidationSummary>

    <table style="width: 100%; height: 225px;">
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server" Width="243px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                runat="server" ErrorMessage="El campo nombre es requerido"
                ControlToValidate="txtNombre">
                *
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="height: 26px; width: 130px">
            <asp:Label ID="Label2" runat="server" Text="Album"></asp:Label>
        </td>
        <td style="height: 26px">
            <asp:DropDownList ID="ddlAlbum" runat="server" Width="252px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px; height: 7px">
            <asp:Label ID="Label3" runat="server" Text="Medio"></asp:Label>
        </td>
        <td style="height: 7px">
            <asp:DropDownList ID="ddlMedio" runat="server" Width="252px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label4" runat="server" Text="Género"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlGenero" runat="server" Width="252px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label5" runat="server" Text="Compositor"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtcompositor" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                runat="server" ErrorMessage="El campo Compositor es requerido"
                ControlToValidate="txtcompositor">
                 *
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label6" runat="server" Text="Duración"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDuracion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator3"
                runat="server"
                ErrorMessage="El campo duración es requerido"
                display="Dynamic"
                ControlToValidate="txtDuracion">
                *
            </asp:RequiredFieldValidator>

            <asp:RangeValidator ID="RangeValidator1" 
                runat="server" ErrorMessage="la duración debe estar entre 1 a  10 minutos"
                display="Dynamic"
                ControlToValidate="txtDuracion"
                MinimumValue="1" 
                MaximumValue="10" 
                Type="Integer">
                *
            </asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label7" runat="server" Text="Peso"></asp:Label>      
        </td>
        <td>
            <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
             <asp:RangeValidator ID="RangeValidator2" 
                runat="server" ErrorMessage="El peso debe estar entre 1MB a  10MB"
                display="Dynamic"
                ControlToValidate="txtPeso"
                MinimumValue="1" 
                MaximumValue="10" 
                Type="Integer">
                 *
            </asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">
            <asp:Label ID="Label8" runat="server" Text="Precio"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
             <asp:RangeValidator ID="RangeValidator3" 
                runat="server" ErrorMessage="El precio debe estar entre 1 a  100 soles"
                display="Dynamic"
                ControlToValidate="txtPrecio"
                MinimumValue="1" 
                MaximumValue="100" 
                Type="Integer">
                 *
            </asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 130px">&nbsp;</td>
        <td>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="cmdGuardar_Click" 
                CausesValidation="true"/>
        </td>
    </tr>
</table>
   
</form>
        
</asp:Content>
