Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class registrarVisitante
    Inherits System.Web.UI.Page

    Dim connectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
            Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)

            DwnLstDepartamento.Items.Add("Seleccione una opción")
            DwnLstDepartamento.Items.Add("Externo")
            DwnLstDepartamento.Items.Add("Interno")
            DwnLstTipoIdentificacion.Items.Add("Seleccione una opción")
            DwnLstTipoIdentificacion.Items.Add("Cédula")
            DwnLstTipoIdentificacion.Items.Add("Pasaporte")
            DwnLstTipoIdentificacion.Items.Add("Licencia de conducir")
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim tipoVisitante As String
        If (DwnLstDepartamento.SelectedItem.ToString().Equals("Externo")) Then
            tipoVisitante = "Externo"
        Else
            tipoVisitante = "Interno"
        End If
        Me.usuarioNegocios.insertarVisitante(New Visitante(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text,
                                                           tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "v",
                                                           Integer.Parse(tbTelefono.Text), tbUbicacion.Text, tipoVisitante, tbInstitucion.Text))
        lblMensaje.Text = "El usuario se ha registrado exitosamente"

    End Sub

End Class