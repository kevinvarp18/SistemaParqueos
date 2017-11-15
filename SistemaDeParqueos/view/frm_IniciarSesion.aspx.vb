﻿Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class loginView
    Inherits System.Web.UI.Page

    Dim connectionString, titulo, mensaje, tipo As String
    Dim usuarioNegocios As SP_Usuario_Negocios
    Dim email As Regex
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "N") Then
            Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)
            Response.BufferOutput = True
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If

        email = New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        If (tbUsuario.Text.Equals("") Or tbContrasena.Text.Equals("")) Then
            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        ElseIf (Not email.IsMatch(tbUsuario.Text)) Then
            titulo = "ERROR"
            mensaje = "Ingrese una dirección de correo válida"
            tipo = "error"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        Else
            Dim usuarios As LinkedList(Of Usuario) = usuarioNegocios.obtenerUsuarios(tbUsuario.Text, tbContrasena.Text)
            If (usuarios.Count > 0) Then
                For Each usuarioActual As Usuario In usuarios
                    Session("Correo") = usuarioActual.gstrCorreo
                    Session("Usuario") = usuarioActual.gstrTipoUsuario

                    Dim listaPermisos As New LinkedList(Of Permiso)()
                    listaPermisos = usuarioNegocios.obtenerPermisosPorRol(usuarioActual.gstrTipoUsuario.ToString)

                    If listaPermisos.Count > 0 Then
                        For Each permiso As Permiso In listaPermisos
                            Session(permiso.GstrTipo1.ToString) = permiso.GstrTipo1.ToString
                        Next
                    End If
                Next
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
                Response.BufferOutput = True
                Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
            Else
                titulo = "ERROR"
                mensaje = "Los datos del usuario no existen"
                tipo = "error"
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
            End If 'Verifica si el usuario existe o no.
        End If 'Verifica si los datos se insertaron o no y que sean correctos.


    End Sub
    Protected Sub enviarCorreo()
        If (tbUsuario.Text.Equals("")) Then
            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        ElseIf (Not email.IsMatch(tbUsuario.Text)) Then
            titulo = "ERROR"
            mensaje = "Ingrese una dirección de correo válida"
            tipo = "error"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        Else
            Dim strCorreo = tbUsuario.Text
            Dim connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim usuario_Negocios = New SP_Usuario_Negocios(Me.connectionString)
            Dim blnRespuesta = usuarioNegocios.recuperacionContrasenaMail(strCorreo)
            If (blnRespuesta) Then
                titulo = "Correcto"
                mensaje = "Se ha recuperado su contraseña y enviado a su dirección de correo electrónico"
                tipo = "success"
            Else
                titulo = "ERROR"
                mensaje = "Los datos del usuario no existen"
                tipo = "error"
            End If
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        End If
    End Sub
End Class