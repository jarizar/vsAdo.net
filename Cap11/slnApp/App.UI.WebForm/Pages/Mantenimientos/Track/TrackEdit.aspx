<%@ Page Title="Administración de Tack" Language="C#"
    MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="TrackEdit.aspx.cs" Inherits="App.UI.WebForm.Pages.Mantenimientos.Track.TrackEdit" %>

<asp:Content ID="Asp1" ContentPlaceHolderID="contentHead" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="contentMain" runat="server">

    <div class="form-horizontal">
        <asp:HiddenField ID="hdfCodigo" runat="server" />


        <div class="box box-primary">
            <div class="box-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label">Nombre:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ErrorMessage="El campo es requerido" ControlToValidate="txtNombre">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Album:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlAlbum" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Medio:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlMedio" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Genero:</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Compositor:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCompositor" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo es requerido"
                            ControlToValidate="txtCompositor" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Duración:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo es requerido"
                            ControlToValidate="txtDuracion" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Rango entre 1 y 10000000"
                            ControlToValidate="txtDuracion" MinimumValue="1" MaximumValue="10000000" Type="Integer" Display="Dynamic">
                        </asp:RangeValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Peso:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="El campo es requerido" Display="Dynamic"
                            ControlToValidate="txtPeso">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Rango entre 1Mb y 10MB"
                            ControlToValidate="txtPeso" MinimumValue="1" MaximumValue="10000000" Type="Integer" Display="Dynamic">
                        </asp:RangeValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Precio:</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo es requerido"
                            ControlToValidate="txtPrecio" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click"
                    CausesValidation="true" />
            </div>
            <!-- /.box-footer -->
        </div>

    </div>


</asp:Content>
