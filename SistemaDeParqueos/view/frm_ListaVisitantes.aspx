<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_ListaVisitantes.aspx.vb" Inherits="SistemaDeParqueos.frm_ListaVisitantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Lista de Visitantes de hoy</h3>
                    </div>
                    </div>
                    <div class="container">
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <asp:Table ID="table" runat="server" CssClass="table">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Marca</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Placa</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Modelo</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Entrada</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Salida</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Accion</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow>
                                        <asp:TableCell>Otto Mata</asp:TableCell>
                                        <asp:TableCell>Toyota</asp:TableCell>
                                        <asp:TableCell>CEO</asp:TableCell>
                                        <asp:TableCell>40</asp:TableCell>
                                        <asp:TableCell>Nissan Versa</asp:TableCell>
                                        <asp:TableCell>14:00</asp:TableCell>
                                        <asp:TableCell>16:00</asp:TableCell>
                                        <asp:TableCell>Libre</asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink1" NavigateUrl="#" Text="(Marcar Salida)" runat="server"/> </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
