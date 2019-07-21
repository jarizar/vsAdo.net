<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Loading.ascx.cs" Inherits="App.UI.WebForm.UserControls.Loading" %>

 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="modalprogressModal">
                <div class="center">
                    <img src="<%=Page.ResolveUrl("~/Content/images/loading.gif")%>" />

                    <div style="text-align:center;">
                        Cargando...
                    </div>
                </div>

            </div>
        </ProgressTemplate>

    </asp:UpdateProgress>
