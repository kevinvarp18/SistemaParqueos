<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="frm_DatosVisitantesAtrasados.aspx.vb" Inherits="SistemaDeParqueos.frm_DatosVisitantesAtrasados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newsletter wow fadeInUp animated animated" data-wow-delay=".5s" style="visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;">
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                <ContentTemplate>
                    <h3>Datos del usuario atrasado</h3>
                    <center>
                        <asp:Label ID="lblNombreV" runat="server" Text="" style="float:none; margin-left: 0%;"></asp:Label><br><br />
                        <asp:Label ID="lblApellidoV" runat="server" Text="" style="float:none; margin-left: 0%;"></asp:Label><br><br />
                        <asp:Label ID="lblCorreoV" runat="server" Text="" style="float:none; margin-left: 0%;"></asp:Label><br><br />
                        <asp:Label ID="lblTelefonoV" runat="server" Text="" style="float:none; margin-left: 0%;"></asp:Label><br><br />
                        <asp:Label ID="lblUbicacionV" runat="server" Text="" style="float:none; margin-left: 0%;"></asp:Label> 
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
