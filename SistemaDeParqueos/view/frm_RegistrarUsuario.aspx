﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_RegistrarUsuario.aspx.vb" Inherits="SistemaDeParqueos.frm_RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Registrar Usuario</h3>
                    <asp:Label ID="lblUsuario" runat="server" Text="Tipo Usuario:"></asp:Label>
                    <asp:DropDownList ID="DwnLstTipoUsuario" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DwnLstTipoUsuario_SelectedIndexChanged" Style="margin-left: 4.7%; width: 27%;"></asp:DropDownList><br />
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo Identificacion:"></asp:Label>
                    <asp:DropDownList ID="DwnLstTipoIdentificacion" runat="server" AutoPostBack="false" Style="width: 27%;"></asp:DropDownList><br />
                    <asp:Label ID="lblIdentificacion" runat="server" Text="Identificacion:"></asp:Label>
                    <asp:TextBox ID="tbIdentificacion" type="text" runat="server" Style="margin-left: 4%; width: 27%;"></asp:TextBox><br />
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="tbNombre" type="text" runat="server" Style="margin-left: 7.1%; width: 27%;"></asp:TextBox><br />
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:"></asp:Label>
                    <asp:TextBox ID="tbApellidos" type="text" runat="server" Style="margin-left: 6.5%; width: 27%;"></asp:TextBox><br />
                    <asp:Label ID="lblEmail" runat="server" Text="Correo:"></asp:Label>
                    <asp:TextBox ID="tbEmail" type="email" runat="server" Style="margin-left: 7.7%; width: 27%;"></asp:TextBox><br />
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="tbContrasena" type="password" runat="server" Style="margin-left: 4.9%; width: 27%;"></asp:TextBox><br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
                        <ContentTemplate>
                            <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación:"></asp:Label>
                            <asp:TextBox ID="tbUbicacion" type="text" required="" runat="server" Style="margin-left: 5.9%; width: 27%;"></asp:TextBox><br />
                            <asp:Label ID="lblProcedencia1" runat="server" Text="Procedencia:"></asp:Label>
                            <asp:DropDownList ID="DwnLstProcedencia" runat="server" Style="margin-left: 4.3%; width: 27%;" AutoPostBack="true"></asp:DropDownList><br />
                            <asp:Label ID="lblProcedencia2" runat="server" Text="Nombre Dept:"></asp:Label>
                            <asp:TextBox ID="tbInstitucion" type="text" required="" runat="server" Style="margin-left: 4%; width: 27%;"></asp:TextBox><br />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <br/>
                        <asp:Label ID="lblMensaje" runat="server" Text="" style="color:red"></asp:Label>
                    <br/>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="true">
                <ContentTemplate>
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="singleTextBox" OnClick="btnRegistrar_Click" Text="Registrar" /><br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
