﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarAtencionPaciente.aspx.cs" Inherits="App.UI.Clinica.GestionarAtencionPaciente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="content-header">
        <div class="text-center">
            <h1>GESTIONAR ATENCIÓN MÉDICA</h1>
            <asp:Label ID="lblFechaAtencion" runat="server" Font-Bold="true"></asp:Label>
        </div>
    </section>
    <section class="content invoice">
        <!-- LISTA DE LAS CITAS MÉDICAS QUE FUERON REGISTRADAS PARA EL DÍA ACTUAL -->
        <asp:DataList ID="dlAtencionMedica" runat="server" CssClass="table table-striped" RepeatColumns="1" OnItemCommand="dlAtencionMedica_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td rowspan="2">
                            <asp:Image ID="imgPaciente" runat="server" Height="200px" Width="200px" ImageUrl="~/img/avatar5.png" />
                        </td>
                        <td>
                            <strong>&nbsp;&nbsp;ID Cita:</strong>
                            <asp:Label ID="lblIdCita" runat="server" Text='<%#Eval("idCita") %>' Font-Size="Medium"></asp:Label><br />
                            <asp:HiddenField ID="hdIdCita" runat="server" Value='<%#Eval("idCita") %>' Visible="false" />
                            <strong>&nbsp;&nbsp;Nombres:</strong>
                            <asp:Label ID="lblNombres" runat="server" Text='<%#Eval("nombres") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Apellido Paterno:</strong>
                            <asp:Label ID="lblApellidoPaterno" runat="server" Text='<%#Eval("apPaterno") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Apellido Materno:</strong>
                            <asp:Label ID="lblApellidoMaterno" runat="server" Text='<%#Eval("apMaterno") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Edad:</strong>
                            <asp:Label ID="lblEdad" runat="server" Text='<%#Eval("edad") %>' Font-Size="Medium"></asp:Label><br />
                            <strong>&nbsp;&nbsp;Sexo:</strong>
                            <asp:Label ID="lblSexo" runat="server" Text='<%#(Eval("sexo").ToString() == "M"?"Masculino":"Femenino") %>'></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;<asp:Button ID="btnAtencion" runat="server" CssClass="btn btn-primary" Text="Realizar Atención" CommandName="Registrar" />
                        </td>
                        <td>&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" CommandName="Cancelar" OnClientClick="return confirm('¿Esta seguro que desea cancelar la Cita?')" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>&nbsp;&nbsp;&nbsp;Hora de Atención: </label>
                            <asp:Label ID="lblHora" runat="server" Text='<%#Eval("hora") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>