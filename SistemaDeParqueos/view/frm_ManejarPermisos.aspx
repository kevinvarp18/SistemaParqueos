<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_ManejarPermisos.aspx.vb" Inherits="SistemaDeParqueos.frm_ManejarPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Permisos y Roles</h3>
                    <div class="page w3-4">
                        <div class="bs-example " data-example-id="simple-table">
                            <div class="table-responsive">
                                <asp:Table ID="tabla" runat="server" CssClass="table" Style="margin-left: -5%;">
                                    <asp:TableHeaderRow>
                                        <asp:TableHeaderCell>Permiso</asp:TableHeaderCell>
                                        <asp:TableHeaderCell>Rol</asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <h3>Agregar o Eliminar Permisos a un Rol</h3>
                    <br />
                    <asp:Label ID="lblPermiso" runat="server" Text="Permiso:"></asp:Label>
                    <asp:DropDownList ID="DwnLstPermisos" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                    <asp:Label ID="lblUsuario" runat="server" Text="Rol:"></asp:Label>
                    <asp:DropDownList ID="DwnLstRoles" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                    <asp:Button ID="btnAgregar" runat="server" CssClass="multipleButton" OnClick="btnAgregar_Click" Text="Agregar" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="multipleButton" OnClick="btnEliminar_Click" Text="Eliminar" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="modal fade" id="modalConfirmacion" tabindex="-1" role="dialog">
        <div class='modal-dialog' role='document' style="width: 45%;">
            <div class='modal-content'>
                <div class='modal-header'>
                    <h4 class='modal-title' id='myModalLabel'>¿Está seguro de que desea realizar estos cambios?</h4>
                </div>
                <div class='modal-footer'>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" Visible="true">
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
