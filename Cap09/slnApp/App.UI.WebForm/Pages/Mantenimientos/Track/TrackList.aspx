<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackList.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenthead" runat="server">

<script>
    //Aqui esta el codigo javascript de la pagina TrackList
</script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">

    <form id="form1" runat="server">
    <asp:GridView ID="grvListado" runat="server" CssClass="table"
        GridLines="None">

    </asp:GridView>

    <asp:Button ID="btnBuscar" runat="server" Text="Button" OnClick="btnBuscar_Click" />
    </form>

</asp:Content>
