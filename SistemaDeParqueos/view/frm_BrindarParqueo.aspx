<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_BrindarParqueo.aspx.vb" Inherits="SistemaDeParqueos.frm_BrindarAcceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Brindar Parqueo</h3>
                    <asp:Label ID="lblSolicitante" runat="server" Text="Visitante:"></asp:Label>
                    <asp:DropDownList ID="DwnLstSolicitante" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                    <asp:Label ID="lblParqueo" runat="server" Text="Parqueo:"></asp:Label>
                    <asp:DropDownList ID="DwnLstParqueos" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                    <asp:Label ID="lblFechaE" runat="server" Text="Fecha Entrada:"></asp:Label>
                    <asp:TextBox ID="tbFechaE" type="date" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblHoraE" runat="server" Text="Hora Entrada:"></asp:Label>
                    <asp:TextBox ID="tbHoraE" type="time" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblFechaS" runat="server" Text="Fecha Salida:"></asp:Label>
                    <asp:TextBox ID="tbFechaS" type="date" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblHoraS" runat="server" Text="Hora Salida:"></asp:Label>
                    <asp:TextBox ID="tbHoraS" type="time" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblPlaca" runat="server" Text="Placa:"></asp:Label>
                    <asp:TextBox ID="tbPlaca" type="text" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblMarca" runat="server" Text="Marca:"></asp:Label>
                    <asp:TextBox ID="tbMarca" type="text" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                    <asp:TextBox ID="tbModelo" type="text" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label>
                    <asp:TextBox ID="tbMotivo" type="text" runat="server" MaxLength="100"></asp:TextBox><br />
                    <asp:Button ID="btnSolicitar" runat="server" CssClass="singleButton" OnClick="btnSolicitar_Click" Text="Solicitar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="modalConfirmacion" tabindex="-1" role="dialog">
        <div class='modal-dialog' role='document' style="width: 45%;">
            <div class='modal-content'>
                <div class='modal-header'>
                    <h4 class='modal-title' id='myModalLabel'>¿Está seguro de que desea brindar ese espacio del parqueo?</h4>
                </div>
                <div class='modal-footer'>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
                        <ContentTemplate>
                            <asp:Button ID='btnConfirmar' CssClass='btn btn-success' runat="server" Text="Confirmar" OnClick='btnAceptar_Click'></asp:Button>
                            <asp:Button ID='btnCancelar' CssClass='btn btn-danger' runat="server" Text="Cancelar" OnClick='btnCancelar_Click'></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
