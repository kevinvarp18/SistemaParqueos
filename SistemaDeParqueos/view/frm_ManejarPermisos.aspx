<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_ManejarPermisos.aspx.vb" Inherits="SistemaDeParqueos.frm_ManejarPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Permisos y Roles</h3>
                    </div>
                    </div>

                    <div class="container">
                        
                            <div class="bs-example " data-example-id="simple-table">
                                <div class="botonTabla">
                                    <asp:Table ID="tabla" Style="margin-left: 4%;" runat="server" CssClass="table">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell>Permiso</asp:TableHeaderCell>
                                            <asp:TableHeaderCell>Rol</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
                <ContentTemplate>
                    <center>
                    <h2>Agregar o Eliminar Permisos a un Rol</h2>
                    <br/>
                    <asp:DropDownList ID="DwnLstPermisos" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="false"></asp:DropDownList><br />
                    <asp:DropDownList ID="DwnLstRoles" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="false"></asp:DropDownList><br />
                        </center>
                    <asp:Button ID="btnAgregar" runat="server" CssClass="singleTextBox" OnClick="btnAgregar_Click" Text="Agregar" /><br />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="singleTextBox" OnClick="btnEliminar_Click" Text="Eliminar" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
