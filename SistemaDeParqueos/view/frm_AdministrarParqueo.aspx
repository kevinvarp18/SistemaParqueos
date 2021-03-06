﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_AdministrarParqueo.aspx.vb" Inherits="SistemaDeParqueos.administrarParqueo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="espaciado2">
        <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
            <div class="container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                    <ContentTemplate>
                        <h3>Administrar Parqueo</h3>
                        <asp:Label ID="lblParqueo" runat="server" Text="Parqueo: "></asp:Label>
                        <asp:Label ID="lblNumParqueo" runat="server" Text="" Style="margin-left: 3%;"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                        <asp:DropDownList ID="DwnLstTipos" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                        <asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label>
                        <asp:DropDownList ID="DwnLstEstado" runat="server" AutoPostBack="false"></asp:DropDownList><br />
                        <br />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
                    <ContentTemplate>
                        <asp:Button ID="btnActualizar" runat="server" CssClass="multipleButton" OnClick="btnActualizar_Click" Text="Actualizar" />
                        <asp:Button ID="btnEliminar" runat="server" CssClass="multipleButton" OnClick="btnEliminar_Click" Text="Eliminar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="false">
                    <ContentTemplate>
                        <asp:Button ID="btnCrear" runat="server" CssClass="singleButton" OnClick="btnCrear_Click" Text="Crear" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalConfirmacion" tabindex="-1" role="dialog">
        <div class='modal-dialog' role='document' style="width: 45%;">
            <div class='modal-content'>
                <div class='modal-header'>
                    <h4 class='modal-title' id='myModalLabel'>¿Está seguro de realizar esta acción?</h4>
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
