﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_Reporte.aspx.vb" Inherits="SistemaDeParqueos.frm_Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Reporte</h3>
                    <asp:Label ID="lblDesde" runat="server" style="margin-left: 10%;" Text="Desde:"></asp:Label>
                    <asp:TextBox ID="tbFechaI" type="date" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                    <asp:Label ID="lblHasta" runat="server" style="margin-left: 10%;" Text="Hasta:"></asp:Label>
                    <asp:TextBox ID="tbFechaF" type="date" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" style="width: 15%; margin-left: 10%;" OnClick="btnBuscar_Click" Text="Buscar" />
                    </div>
                    </div>
                    <div class="container">
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <asp:Table ID="table" runat="server" CssClass="table">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Institución</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Placa</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Fecha Entrada</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Entrada</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Salida</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow>
                                        <asp:TableCell>Otto Mata</asp:TableCell>
                                        <asp:TableCell>UCR</asp:TableCell>
                                        <asp:TableCell>ju1236</asp:TableCell>
                                        <asp:TableCell>19/03/2017</asp:TableCell>
                                        <asp:TableCell>7:00</asp:TableCell>
                                        <asp:TableCell>19/03/2017</asp:TableCell>
                                        <asp:TableCell>11:00</asp:TableCell>
                                        <asp:TableCell>23</asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                    </asp:ScriptManager>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>