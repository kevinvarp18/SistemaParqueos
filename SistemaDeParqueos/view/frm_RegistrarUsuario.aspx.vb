Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_RegistrarUsuario
    Inherits System.Web.UI.Page

    Dim connectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
            Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)

            DwnLstRol.Items.Add("Seleccione una opción")
            DwnLstRol.Items.Add("Administrador")
            DwnLstRol.Items.Add("Oficial de Seguridad")

            DwnLstTipoIdentificacion.Items.Add("Seleccione una opción")
            DwnLstTipoIdentificacion.Items.Add("Numero de Cedula")
            DwnLstTipoIdentificacion.Items.Add("Pasaporte")
            DwnLstTipoIdentificacion.Items.Add("Licencia")
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim resultado As Boolean

        If (DwnLstRol.SelectedItem.ToString().Equals("Administrador")) Then
            resultado = Me.usuarioNegocios.insertarAdministrador(New Administrador(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text,
                                                           tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "a"))
        ElseIf (DwnLstRol.SelectedItem.ToString().Equals("Oficial de Seguridad")) Then
            resultado = Me.usuarioNegocios.insertarOficial(New Oficial(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text,
                                                           tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "o"))
        End If

        If resultado Then
            lblMensaje.Text = "El usuario se ha insertado exitosamente"
        End If


    End Sub
End Class