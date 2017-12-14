<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_VerParqueoOficialSeguridad.aspx.vb" Inherits="SistemaDeParqueos.frm_VerParqueoOficialSeguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="espaciado2">
        <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
            <div class="container">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" Visible="true">
                    <ContentTemplate>
                        <h3>Ver Parqueo</h3>
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <asp:Table ID="table" runat="server" CssClass="table">
                                </asp:Table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
