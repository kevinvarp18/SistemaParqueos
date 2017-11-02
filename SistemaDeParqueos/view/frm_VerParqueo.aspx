<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_VerParqueo.aspx.vb" Inherits="SistemaDeParqueos.VerParqueo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Ver Parqueo</h3>
                    <asp:Label ID="lblDesde" runat="server" style="margin-left: 10%;" Text="Desde:"></asp:Label>
                    <asp:TextBox ID="tbFechaI" type="date" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" style="margin-left: 10%;" Text="Desde:"></asp:Label>
                    <asp:TextBox ID="tbHoraI" type="time" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" style="margin-left: 10%;" Text="Hasta:"></asp:Label>
                    <asp:TextBox ID="tbHoraF" type="time" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>                    
                    <asp:Button ID="btnBuscarP" runat="server" style="width: 15%; margin-left: 10%;"  Text="Ver" />
                    </div>
                    <div class="container">
                        <div class="page w3-4">
                            <div class="bs-example " data-example-id="simple-table">
                                <asp:Table ID="table" runat="server" CssClass="table">
                                    <%--<asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Jefatura</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>PIP</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>UPRO</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>OPO</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>SERT</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>UPROV</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>UVISE</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Visitas</asp:TableHeaderCell>
                                    </asp:TableHeaderRow
                                    <asp:TableRow>
                                        <asp:TableCell><asp:HyperLink id="hyperlink1" NavigateUrl="#" Text="Espacio 1" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink2" NavigateUrl="#" Text="Espacio 7" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink3" NavigateUrl="#" Text="Espacio 8" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink4" NavigateUrl="#" Text="Espacio 13" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink5" NavigateUrl="#" Text="Espacio 19" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink6" NavigateUrl="#" Text="Espacio 24" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink7" NavigateUrl="#" Text="Espacio 44" runat="server"/> </asp:TableCell>
                                        <asp:TableCell><asp:HyperLink id="hyperlink8" NavigateUrl="#" Text="Espacio 58" runat="server"/> </asp:TableCell>
                                    </asp:TableRow>>--%>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                    </asp:ScriptManager>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
