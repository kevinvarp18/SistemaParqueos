Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class loginView
    Inherits System.Web.UI.Page

    Dim connectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "N") Then
            Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)
            Response.BufferOutput = True
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")

        End If

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim usuarios As LinkedList(Of Usuario) = usuarioNegocios.obtenerUsuarios(tbUsuario.Text, tbContrasena.Text)

        If (usuarios.Count > 0) Then
            For Each usuarioActual As Usuario In usuarios
                Session("Correo") = usuarioActual.gstrCorreo
                Session("Usuario") = usuarioActual.gstrTipoUsuario
            Next

            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        Else
            lblMensaje.Text = "Los datos del usuario no existen"
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim strCorreo = tbUsuario.Text
        tbContrasena.Text = "C re mamo"
        Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim usuario_Negocios = New SP_Usuario_Negocios(Me.connectionString)
        Dim blnRespuesta = usuarioNegocios.EnvioMail(strCorreo)
        If (blnRespuesta) Then
            tbContrasena.Text = "Funco"
            'Avisar si funco
        Else
            'Avisar si no funco
            tbContrasena.Text = "C mamo"
        End If
    End Sub
End Class