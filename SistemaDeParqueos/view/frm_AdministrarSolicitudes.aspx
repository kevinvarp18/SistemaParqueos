﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_AdministrarSolicitudes.aspx.vb" Inherits="SistemaDeParqueos.frm_AdministrarSolicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Administrar Solicitudes</h3>
                    <asp:HyperLink ID="lblParqueoModal" class="new-gri" data-toggle="modal" Style="text-decoration: underline; color: #000000; margin-left: 84%; font-size: 1.5em; font-family: 'Cabin', sans-serif;" data-target="#myModal1" NavigateUrl="#" Text="Ver Parqueo" runat="server" />
                    <div class="container">
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <asp:Table ID="tablaSolicitudes" runat="server" CssClass="table">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Placa</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Fecha Entrada</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Entrada</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Hora Salida</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Acción</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content modal-info">
                <div class="top-bar w3agile-1" id="home">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="container">
                        <div class="row">
                            <nav class="navbar navbar-default">
                                <div class="navbar-header wow fadeInLeft animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInLeft;">
                                    <a href="frm_index.aspx" style="margin-left: 30%;">
                                        <img src="../public/images/placa.png" alt=" " /></a>
                                </div>
                                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1 wow fadeInRight animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInRight;">
                                    <br />
                                    <br />
                                    <h1>Ver Parqueo</h1>
                                    <div class="clearfix"></div>
                                </div>
                            </nav>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
                        <div class="container">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Style="margin-left: 2%;" Text="Fecha:"></asp:Label>
                                    <asp:TextBox ID="tbFechaI" type="date" required="" runat="server" Style="width: 13%;"></asp:TextBox>
                                    <asp:Label ID="lblDesde" runat="server" Style="margin-left: 13%;" Text="Desde:"></asp:Label>
                                    <asp:TextBox ID="tbHoraI" TextMode="Time" required="" runat="server" Style="margin-left: 2%; width: 13%;"></asp:TextBox>
                                    <asp:Label ID="lblHasta" runat="server" Style="margin-left: 11%;" Text="Hasta:"></asp:Label>
                                    <asp:TextBox ID="tbHoraF" TextMode="Time" required="" runat="server" Style="width: 13%;"></asp:TextBox>
                                    <asp:Button ID="btnBuscarP" runat="server" Style="margin-left: 40%; margin-top: 2%; width: 15%;" Text="Ver" OnClick="llenarTablaParqueos" />
                                    <div class="page w3-4">
                                        <div class="bs-example " data-example-id="simple-table">
                                            <asp:Table ID="tablaParqueos" runat="server" Style="margin-left: -3%;" CssClass="table">
                                            </asp:Table>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <footer>
                    <p class="copy-right wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">Organismo de Investigaci&oacute;n Judicial - Poder Judicial - San Jos&eacute; - Costa Rica- Copyright ©</p>
                    <br />
                    <br />
                </footer>
            </div>
        </div>
    </div>
</asp:Content>
