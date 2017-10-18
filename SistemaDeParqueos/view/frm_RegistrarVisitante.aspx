<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_RegistrarVisitante.aspx.vb" Inherits="SistemaDeParqueos.registrarVisitante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Registrar Visitante</h3>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="tbNombre" type="text" required="" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:"></asp:Label>
                    <asp:TextBox ID="tbApellidos" type="text" required="" style="width: 29.5%;" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    <asp:TextBox ID="tbTelefono" type="text" required="" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox ID="tbEmail" type="email" required="" runat="server" style="margin-left: 3.1%;"></asp:TextBox><br />
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="tbContrasena" type="password" required="" runat="server" style="width: 28.2%;"></asp:TextBox><br />
                    <asp:Label ID="lblUbicación" runat="server" Text="Ubicación:"></asp:Label>
                    <asp:TextBox ID="tbUbicación" type="text" required="" runat="server" style="width: 29.1%;"></asp:TextBox><br />
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                    <asp:DropDownList ID="DwnLstTipoIdentificacion" runat="server" AutoPostBack="false" style="margin-left: 3.9%;"></asp:DropDownList><br />
                    <asp:Label ID="lblIdentificacion" runat="server" Text="Identificación:"></asp:Label>
                    <asp:TextBox ID="tbIdentificacion" type="text" required="" runat="server" style="width: 27%;"></asp:TextBox><br />
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="singleTextBox" OnClick="btnRegistrar_Click" Text="Registrarse" />
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                    </asp:ScriptManager>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
