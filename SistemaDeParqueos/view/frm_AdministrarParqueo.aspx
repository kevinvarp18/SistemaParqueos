﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_AdministrarParqueo.aspx.vb" Inherits="SistemaDeParqueos.administrarParqueo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Administrar Parqueo</h3>
                    <div>
                        <div>
                            <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                            <asp:DropDownList ID="DwnLstTipos" runat="server" style="margin-left: 8.4%;" AutoPostBack="false"></asp:DropDownList><br />
                            <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                            <asp:DropDownList ID="DwnLstEstado" runat="server" style="margin-left: 7%;" AutoPostBack="false"></asp:DropDownList> <br />                                                
                        </div>
                    <div id="DivActualizaElimina" style="visibility:hidden;"> 
                        <asp:Button ID="btnActualizar" runat="server" style="margin-left: 28%;" CssClass="multipleTextBox" OnClick="btnActualizar_Click" Text="Actualizar" />
                        <asp:Button ID="btnEliminar" runat="server"  CssClass="multipleTextBox" OnClick="btnEliminar_Click" Text="Eliminar" />
                    </div>
                        <div id="DivRegistrar" style="visibility:hidden;">
                            <asp:Button ID="btnCrear" runat="server" CssClass="multipleTextBox" style="margin-top: -50%;margin-left: 40%;" OnClick="btnCrear_Click" Text="Crear" />
                        </div>      
                    </div>                                  
                    <br />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
