Imports Entidad

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
        oficial.NombreOficialSG = tbCedula.Text
        oficial.ApellidosOficialSG = tbCedula.Text
        oficial.CorreoOficialSG = tbCedula.Text
        oficial.ContraseniaOficialSG = tbCedula.Text
        oficial.RolOficialSG = tbCedula.Text




    End Sub
End Class