﻿Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class registrarVisitante
    Inherits System.Web.UI.Page

    Dim connectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "N") Then
            Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_RegistrarVisitante", ResolveUrl("~") + "public/js/" + "script.js")
            Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)

            If Not IsPostBack Then
                DwnLstProcedencia.Items.Add("Seleccione una opción")
                DwnLstProcedencia.Items.Add("Externo")
                DwnLstProcedencia.Items.Add("Interno")

                DwnLstTipoIdentificacion.Items.Add("Seleccione una opción")
                DwnLstTipoIdentificacion.Items.Add("Numero de Cedula")
                DwnLstTipoIdentificacion.Items.Add("Pasaporte")
                DwnLstTipoIdentificacion.Items.Add("Licencia de conducir")

                DwnLstDepartamento.Items.Add("Seleccione una opción")
                DwnLstDepartamento.Items.Add("Jefatura")
                DwnLstDepartamento.Items.Add("PIP")
                DwnLstDepartamento.Items.Add("UPRO")
                DwnLstDepartamento.Items.Add("OPO")
                DwnLstDepartamento.Items.Add("SERT")
                DwnLstDepartamento.Items.Add("UPROV")
                DwnLstDepartamento.Items.Add("UVISE")
            Else
                If (DwnLstProcedencia.SelectedItem.ToString().Equals("Seleccione una opción")) Then
                    UpdatePanel2.Visible = False
                    UpdatePanel3.Visible = False
                ElseIf (DwnLstProcedencia.SelectedItem.ToString().Equals("Interno")) Then
                    UpdatePanel2.Visible = True
                    UpdatePanel3.Visible = False
                Else
                    UpdatePanel2.Visible = False
                    UpdatePanel3.Visible = True
                End If
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
    End Sub
    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim titulo As String = "ERROR"
        Dim mensaje As String
        Dim tipo As String = "error"
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")

        If (tbIdentificacion.Text.Equals("") Or tbNombre.Text.Equals("") Or tbApellidos.Text.Equals("") Or
            tbTelefono.Text.Equals("") Or tbEmail.Text.Equals("") Or tbContrasena.Text.Equals("") Or
            tbUbicacion.Text.Equals("") Or (tbInstitucion.Text.Equals("") And DwnLstDepartamento.SelectedItem.ToString.Equals("Seleccione una opción")) Or
            DwnLstTipoIdentificacion.SelectedItem.ToString().Equals("Seleccione una opción") Or
            DwnLstProcedencia.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            mensaje = "Debe completar todos los campos"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        ElseIf (Not email.IsMatch(tbEmail.Text)) Then
            mensaje = "Ingrese una dirección de correo válida"
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim resultado As Integer
        Dim tipoVisitante, mensaje As String
        Dim titulo As String = "ERROR"
        Dim tipo As String = "error"

        If (DwnLstProcedencia.SelectedItem.ToString().Equals("Externo")) Then
            tipoVisitante = "Externo"
            resultado = Me.usuarioNegocios.insertarVisitante(New Visitante(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text, tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "v", Integer.Parse(tbTelefono.Text), tbUbicacion.Text, tipoVisitante, tbInstitucion.Text))
        Else
            tipoVisitante = "Interno"
            resultado = Me.usuarioNegocios.insertarVisitante(New Visitante(tbIdentificacion.Text, tbNombre.Text, tbApellidos.Text, tbEmail.Text, tbContrasena.Text, DwnLstTipoIdentificacion.SelectedItem.ToString(), "v", Integer.Parse(tbTelefono.Text), tbUbicacion.Text, tipoVisitante, DwnLstDepartamento.SelectedItem.Text))
        End If

        If (resultado = 1) Then
            titulo = "Correcto"
            mensaje = "Se ha registrado el visitante exitosamente"
            tipo = "success"

            tbNombre.Text = ""
            tbApellidos.Text = ""
            tbIdentificacion.Text = ""
            tbTelefono.Text = ""
            tbEmail.Text = ""
            tbContrasena.Text = ""
            tbUbicacion.Text = ""
            tbInstitucion.Text = ""
            DwnLstProcedencia.SelectedIndex = 0
            DwnLstTipoIdentificacion.SelectedIndex = 0
            DwnLstDepartamento.SelectedIndex = 0
        Else
            mensaje = "Ese correo ya existe en el sistema"
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub

End Class