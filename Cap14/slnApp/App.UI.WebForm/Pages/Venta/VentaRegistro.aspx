<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" 
    AutoEventWireup="true" CodeBehind="VentaRegistro.aspx.cs" 
    Inherits="App.UI.WebForm.Pages.Venta.VentaRegistro"
    %>

<%@ Register TagPrefix="uc" TagName="Loading"
    Src="~/UserControls/Loading.ascx"
    %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMain" runat="server">

    <uc:Loading id="loadingID" runat="Server"></uc:Loading>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <span class="text-blue">
                <asp:Literal ID="litMensajeConfirmacion" runat="server"></asp:Literal>
            </span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="click" />
        </Triggers>        
    </asp:UpdatePanel>    

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
                <asp:DropDownList ID="ddlTrack" CssClass="form-control" runat="server"
                    AppendDataBoundItems="true"
                    OnSelectedIndexChanged="ddlTrack_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="0">---Seleccione---</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="col-sm-2">
                <asp:Label ID="Label1" runat="server" Text="Precio:"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:UpdatePanel ID="upAjaxPrecios" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlTrack" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-2">
                <asp:Label ID="Label2" runat="server" Text="Cantidad:"></asp:Label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-sm-6">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar"
                    CssClass="form-control btn btn-primary"
                    OnClick="btnAgregar_Click" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-12">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <span class="text-red">
                            <asp:Literal ID="litMensajeTrack" runat="server">
                            </asp:Literal>
                        </span>

                        <asp:GridView ID="grvPedido" runat="server" CssClass="table" GridLines="None"
                            AutoGenerateColumns="true">
                            <Columns>

                                <%--<asp:BoundField HeaderText="Nombre Track" DataField="TrackName" Visible="true" />
                        <asp:BoundField HeaderText="Nombre Album" DataField="AlbumTitle" />
                        <asp:BoundField HeaderText="Media" DataField="MediaTypeName" />
                        <asp:BoundField HeaderText="Género" DataField="GenreName" />
                        <asp:BoundField HeaderText="Compositor" DataField="Composer" />--%>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAgregar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="click" />
                    </Triggers>
                </asp:UpdatePanel>


            </div>

        </div>

        <br />

        <div class="form-group">

            <div class="col-sm-6">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar"                     
                    CssClass="form-control btn btn-primary" 
                    OnClick="btnGuardar_Click"
                    />
            </div>
        </div>

    </div>
</asp:Content>
