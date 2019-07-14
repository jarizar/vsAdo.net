<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="VentaRegistro.aspx.cs" Inherits="App.UI.WebForm.Pages.Venta.VentaRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">
    <div class="container-fluid">

        <div class="box box-primary">
            <div class="box-header">
                <strong>INVOICE TRACK </strong>
            </div>

        </div>

        <asp:HiddenField ID="hdfCodigo" runat="server" />


        <div class="form-group">
            <div class="col-sm-2">
                <asp:Label ID="Label10" runat="server" Text="Track:"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddlTrack" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">---Seleccione---</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="col-sm-2">
                <asp:Label ID="Label1" runat="server" Text="Precio:"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ></asp:TextBox>

            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-2">
                <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-sm-2">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="form-control btn btn-primary" OnClick="btn_Agregar_Click"/>
            </div>
        </div>

        <div  class="form-group"> 
            <div class="col-sm-12">
                <asp:GridView ID="grvPedido" runat="server" CssClass="table" GridLines="None"
                    AutoGenerateColumns="false">
                    <Columns>

                        <%--<asp:BoundField HeaderText="Nombre Track" DataField="TrackName" Visible="true" />
                        <asp:BoundField HeaderText="Nombre Album" DataField="AlbumTitle" />
                        <asp:BoundField HeaderText="Media" DataField="MediaTypeName" />
                        <asp:BoundField HeaderText="Género" DataField="GenreName" />
                        <asp:BoundField HeaderText="Compositor" DataField="Composer" />--%>
                    </Columns>
                </asp:GridView>
            </div>

        </div>

        <br />

        <div class="form-group">

            <div class="col-sm-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Continuar" CssClass="form-control btn btn-primary" />
            </div>
        </div>

    </div>
</asp:Content>
