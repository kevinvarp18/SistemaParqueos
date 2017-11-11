<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_SolicitudesAtrasadas.aspx.vb" Inherits="SistemaDeParqueos.frm_SolicitudesAtrasadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Solicitudes Atrasadas</h3>
                    <div class="container">
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <div class="botonTabla">
                                    <asp:Table ID="tablaSolicitudes" Style="text-align: center;" runat="server" CssClass="table">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Placa</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Fecha Entrada</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Hora Entrada</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Hora Salida</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Extension Tiempo</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Acción</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
