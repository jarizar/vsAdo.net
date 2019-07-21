<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackList.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
    <script>
        //Aqui este el código javascript de la página TrackList
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">


        <div class="box box-primary">
            <div class="box-header">
                Búsqueda de canciones
            </div>
            <div class="box-body">
                <div class="form-inline">
                    <div class="form-group">
                        <label>Nombre de la canción:</label>
                        <asp:TextBox ID="txtFiltroPorNombre"
                            runat="server" CssClass="form-control">
                        </asp:TextBox>

                    </div>
                    <asp:Button ID="btnBuscar" runat="server"
                        Text="Buscar" OnClick="btnBuscar_Click"
                        CssClass="btn btn-default" />

                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"
                        CssClass="btn btn-primary"
                        PostBackUrl="~/Pages/Mantenimientos/Track/TrackEdit.aspx"
                        />
                </div>

            </div>
        </div>
        <div class="box box-default">
            <div class="box-body">
                <asp:GridView ID="grvListado" runat="server" CssClass="table"
                    GridLines="None"
                    AutoGenerateColumns="false">
                    <Columns>

                        <asp:HyperLinkField 
                            HeaderText="Nombre Track"
                            DataTextField="TrackName"
                            DataNavigateUrlFormatString="~/Pages/Mantenimientos/Track/TrackEdit.aspx?cod={0}"
                            DataNavigateUrlFields="TrackID"
                            />                       
                        <asp:BoundField
                            HeaderText="Album"
                            DataField="AlbumTitle" />
                        <asp:BoundField
                            HeaderText="Media"
                            DataField="MediaTypeName" />
                        <asp:BoundField
                            HeaderText="Género"
                            DataField="GenreName" />
                        <asp:BoundField
                            HeaderText="Compositor"
                            DataField="Composer" />
                    </Columns>

                </asp:GridView>


            </div>
        </div>



</asp:Content>
