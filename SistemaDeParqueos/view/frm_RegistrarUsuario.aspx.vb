Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_RegistrarUsuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DwnLstRol.Items.Add("Seleccione una opción")
        DwnLstRol.Items.Add("Administrador")
        DwnLstRol.Items.Add("Oficial de Seguridad")
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim oficial As New Oficial

        oficial.CedulaOficialSG = tbCedula.Text
        oficial.NombreOficialSG = tbNombre.Text
        oficial.ApellidosOficialSG = tbApelidos.Text
        oficial.CorreoOficialSG = tbEmail.Text
        oficial.ContraseniaOficialSG = tbContrasena.Text
        oficial.RolOficialSG = DwnLstRol.Text

        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim usuarioNegocios As New SP_Usuario_Negocios(strconnectionString)

        If usuarioNegocios.insertarOficial(oficial) Then
            lblMensaje.Text = "Se ha insertado correctamente el " + oficial.RolOficialSG
        End If


    End Sub
End Class