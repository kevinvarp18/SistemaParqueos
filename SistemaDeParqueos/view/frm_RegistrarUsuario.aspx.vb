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

            If IsPostBack Then
                Dim contentPlaceHolder As ContentPlaceHolder
                Dim updatePanel As UpdatePanel
                contentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                updatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)

                If (DwnLstTipoUsuario.SelectedItem.ToString().Equals("Visitante")) Then
                    updatePanel.Visible = True
                Else
                    updatePanel.Visible = False
                End If
            Else
                DwnLstTipoUsuario.Items.Add("Seleccione una opción")
                DwnLstTipoUsuario.Items.Add("Visitante")
                DwnLstTipoUsuario.Items.Add("Administrador")
                DwnLstTipoUsuario.Items.Add("Oficial de Seguridad")
                DwnLstTipoIdentificacion.Items.Add("Seleccione una opción")
                DwnLstTipoIdentificacion.Items.Add("Numero de Cedula")
                DwnLstTipoIdentificacion.Items.Add("Pasaporte")
                DwnLstTipoIdentificacion.Items.Add("Licencia")
            End If
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim resultado As Boolean = True
        Dim titulo As String
        Dim mensaje As String
        Dim tipo As String

        If (DwnLstTipoUsuario.SelectedItem.ToString().Equals("Administrador")) Then
            resultado = Me.usuarioNegocios.insertarAdministrador(New Administrador(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text, tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "a"))
        ElseIf (DwnLstTipoUsuario.SelectedItem.ToString().Equals("Oficial de Seguridad")) Then
            resultado = Me.usuarioNegocios.insertarOficial(New Oficial(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text,
            tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "o"))
        End If

        If resultado Then
            titulo = "Correcto"
            mensaje = "Se ha registrado el usuario correctamente"
            tipo = "success"
        Else
            titulo = "Error"
            mensaje = "No se pudo registrar el usuario"
            tipo = "error"
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)

    End Sub

    Protected Sub DwnLstTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DwnLstTipoUsuario.SelectedIndexChanged

    End Sub
End Class