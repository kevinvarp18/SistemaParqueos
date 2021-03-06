﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_IniciarSesion.aspx.vb" Inherits="SistemaDeParqueos.loginView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="espaciado2">
        <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
            <div class="container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                    <ContentTemplate>
                        <h3>Iniciar Sesión</h3>
                        <asp:Label ID="lblNombre" runat="server" Text="Email:"></asp:Label>
                        <asp:TextBox ID="tbUsuario" type="email" runat="server"></asp:TextBox><br />
                        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                        <asp:TextBox ID="tbContrasena" type="password" runat="server"></asp:TextBox><br />
                        <asp:LinkButton ID="lblRecordar" runat="server" CssClass="recordarContrasena" OnClick="enviarCorreo">¿Olvidaste la contraseña?</asp:LinkButton>
                        <br />
                        <asp:Button ID="btnIngresar" runat="server" CssClass="singleButton" OnClick="btnIngresar_Click" Text="Ingresar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
