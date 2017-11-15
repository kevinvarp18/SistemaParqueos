<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_Reporte.aspx.vb" Inherits="SistemaDeParqueos.frm_Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <h3>Reporte</h3>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <asp:Label ID="lblTipoReporte" runat="server" style="margin-left: 10%;" Text="Seleccione el tipo de reporte que desea generar"></asp:Label>
                    <asp:DropDownList ID="DwnLstTipoReporte" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="true"></asp:DropDownList><br />
                
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
                        <ContentTemplate>
                            <asp:Label ID="lblPlaca" runat="server" style="margin-left: 10%;" Text="Seleccione la placa"></asp:Label>
                            <asp:DropDownList ID="DwnLstPlaca" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="true"></asp:DropDownList><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
                        <ContentTemplate>
                            <asp:Label ID="lblCorreo" runat="server" style="margin-left: 10%;" Text="Seleccione el correo"></asp:Label>
                            <asp:DropDownList ID="DwnLstCorreo" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="true"></asp:DropDownList><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                     <asp:UpdatePanel ID="UpdatePanel4" runat="server" Visible="false">
                        <ContentTemplate>
                            <asp:Label ID="lblNombre" runat="server" style="margin-left: 10%;" Text="Seleccione el correo"></asp:Label>
                            <asp:DropDownList ID="DwnLstNombre" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="true"></asp:DropDownList><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" Visible="false">
                        <ContentTemplate>
                            <asp:Label ID="lblFecha" runat="server" style="margin-left: 10%;" Text="Seleccione la fecha"></asp:Label>
                            <asp:Label ID="lblDesde" runat="server" style="margin-left: 10%;" Text="Desde:"></asp:Label>
                            <asp:TextBox ID="tbFechaI" type="date" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                            <asp:Label ID="lblHasta" runat="server" style="margin-left: 10%;" Text="Hasta:"></asp:Label>
                            <asp:TextBox ID="tbFechaF" type="date" runat="server" style="margin-left: 2%; width: 13%;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" Visible="true">
                        <ContentTemplate>
                            <asp:Button ID="btnBuscar" runat="server" style="width: 15%; margin-left: 10%;" OnClick="btnBuscar_Click" Text="Buscar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                     <asp:UpdatePanel ID="UpdatePanel8" runat="server" Visible="true">
                        <ContentTemplate>
                            <asp:Button ID="Button1" runat="server" style="width: 15%; margin-left: 10%;" OnClick="btnBuscar_Click2" Text="Exportar" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" Visible="true">
                        <ContentTemplate>
                            <div class="container">
                                <div class="page w3-4">
                                    <div class="bs-example " data-example-id="simple-table">
                                        <asp:Table ID="table" runat="server" CssClass="table">
                                        </asp:Table>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <asp:Label ID="Label1" runat="server" style="margin-left: 10%;" Text=""></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
