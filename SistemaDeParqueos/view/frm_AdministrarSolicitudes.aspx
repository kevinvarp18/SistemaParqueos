<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_AdministrarSolicitudes.aspx.vb" Inherits="SistemaDeParqueos.frm_AdministrarSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Administrar Solicitudes</h3>
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
                                        <asp:TableHeaderCell>Acción</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                    <asp:TableRow>
                                        <asp:TableCell>Otto Mata</asp:TableCell>
                                        <asp:TableCell>UCR</asp:TableCell>
                                        <asp:TableCell>ju1236</asp:TableCell>
                                        <asp:TableCell>19/03/2017</asp:TableCell>
                                        <asp:TableCell>7:00</asp:TableCell>
                                        <asp:TableCell>19/03/2017</asp:TableCell>
                                        <asp:TableCell>11:00</asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="tbEspacio" type="number" style="width:50%;" required="" runat="server"></asp:TextBox><br />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:HyperLink id="hyperlink1" NavigateUrl="#" Text="(Rechazar)" runat="server"/>
                                            <asp:HyperLink id="hyperlink2" NavigateUrl="#" Text="(Aceptar)" runat="server"/> 
                                        </asp:TableCell>
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
