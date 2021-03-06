﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_AdministrarSolicitudes.aspx.vb" Inherits="SistemaDeParqueos.frm_AdministrarSolicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="espaciado2">
        <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
            <div class="container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                    <ContentTemplate>
                        <h3>Administrar Solicitudes</h3>
                        <asp:HyperLink ID="lblParqueoModal" class="new-gri" data-toggle="modal" CssClass="parqueoModal" data-target="#modalParqueo" NavigateUrl="#" Text="Ver Parqueo" runat="server" />
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <div class="botonTabla">
                                    <div class="table-responsive">
                                        <asp:Table ID="tablaSolicitudes" runat="server" CssClass="table">
                                            <asp:TableHeaderRow>
                                                <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Placa</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Fecha Entrada</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Hora Entrada</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Fecha Salida</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Hora Salida</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Motivo</asp:TableHeaderCell>
                                                <asp:TableHeaderCell>Espacio</asp:TableHeaderCell>
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
    </div>

    <div class="modal fade" id="modalParqueo" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content modal-info">
                <div class="modal-header" style="border-bottom: 10px solid #000; background: #000;">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <div class="container">
                        <div class="row">
                            <nav class="navbar navbar-default">
                                <div class="navbar-header wow fadeInLeft animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInLeft;">
                                    <a>
                                        <img src="../public/images/placa.png" alt=" " /></a>
                                </div>
                                <h1>Ver Parqueo</h1>
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
                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                                    <asp:TextBox ID="tbFechaI" type="date" required="" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="lblDesde" runat="server" Text="Desde:"></asp:Label>
                                    <asp:TextBox ID="tbHoraI" TextMode="Time" required="" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="lblHasta" runat="server" Text="Hasta:"></asp:Label>
                                    <asp:TextBox ID="tbHoraF" TextMode="Time" required="" runat="server"></asp:TextBox><br />
                                    <asp:Button ID="btnBuscarP" runat="server" Text="Ver" CssClass="singleButton" OnClick="btnBuscarP_Click" />
                                    <div class="page w3-4">
                                        <div class="bs-example " data-example-id="simple-table">
                                            <div class="table-responsive">
                                                <asp:Table ID="tablaParqueos" runat="server" CssClass="table">
                                                </asp:Table>
                                            </div>
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
                </footer>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalRetroalimentacion" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content modal-info">
                <div class="top-bar w3agile-1" id="home">
                    <div class="modal-header" style="border-bottom: 10px solid #000; background: #000;">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <div class="container">
                            <div class="row">
                                <nav class="navbar navbar-default">
                                    <div class="navbar-header wow fadeInLeft animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInLeft;">
                                        <a>
                                            <img src="../public/images/placa.png" alt=" " /></a>
                                    </div>
                                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1 wow fadeInRight animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInRight;">
                                        <h1 style="margin-left: 29%;">Retroalimentación</h1>
                                        <div class="clearfix"></div>
                                    </div>
                                </nav>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
                        <div class="container">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="true">
                                <ContentTemplate>
                                    <asp:TextBox ID="tbRetroalimentacion" type="text" required="" runat="server" TextMode="MultiLine" Style="margin-left: 23%; resize: none; height: 200px; width: 50%;"></asp:TextBox><br />
                                    <asp:Button ID="btnEnviar" runat="server" Style="margin-left: 40%; margin-top: 4%; width: 15%;" Text="Enviar" OnClick="decidirSolicitud" />
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
