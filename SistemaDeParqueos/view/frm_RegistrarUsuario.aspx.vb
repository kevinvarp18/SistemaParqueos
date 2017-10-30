Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_RegistrarUsuario
    Inherits System.Web.UI.Page

    Dim connectionString As String
    Dim esVisitante As Boolean = False
    Dim usuarioNegocios As SP_Usuario_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If String.Equals(Session("Usuario"), "a") Then
        Me.connectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Me.usuarioNegocios = New SP_Usuario_Negocios(connectionString)
        ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_RegistrarUsuario", ResolveUrl("~") + "public/js/" + "script.js")

        If IsPostBack Then
            Dim contentPlaceHolder As ContentPlaceHolder
            Dim updatePanel As UpdatePanel
            contentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
            updatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)

            If (DwnLstTipoUsuario.SelectedItem.ToString().Equals("Visitante")) Then
                updatePanel.Visible = True
                esVisitante = True
            Else
                updatePanel.Visible = False
                esVisitante = False
            End If

            If (DwnLstProcedencia.SelectedItem.ToString().Equals("Interno")) Then
                lblProcedencia2.Text = "Nombre Dept:"
            Else
                lblProcedencia2.Text = "Institución:"
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

            DwnLstProcedencia.Items.Add("Seleccione una opción")
            DwnLstProcedencia.Items.Add("Externo")
            DwnLstProcedencia.Items.Add("Interno")
        End If
        'Else
        'Response.BufferOutput = True
        'Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        'End If
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim tbIdentificacion_ As String = Trim(tbIdentificacion.Text)
        Dim tbNombre_ As String = Trim(tbNombre.Text)
        Dim tbApellidos_ As String = Trim(tbApellidos.Text)
        Dim tbEmail_ As String = Trim(tbEmail.Text)
        Dim tbContrasena_ As String = Trim(tbContrasena.Text)
        Dim tbUbicacion_ As String = Trim(tbUbicacion.Text)
        Dim tbInstitucion_ As String = Trim(tbInstitucion.Text)
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")


        If (tbIdentificacion_.Equals("") Or tbNombre_.Equals("") Or tbApellidos_.Equals("") Or tbEmail_.Equals("") Or
        tbContrasena_.Equals("") Or DwnLstTipoIdentificacion.Text.Equals("Seleccione una opción") Or
        DwnLstTipoUsuario.Text.Equals("Seleccione una opción")) Then

            lblMensaje.Text = "Debe completar todos los campos"
        ElseIf (Not email.IsMatch(tbEmail_)) Then
            lblMensaje.Text = "Ingrese un correo electronico valido"

        ElseIf (esVisitante And (tbUbicacion_.Equals("") Or tbInstitucion_.Equals("") Or DwnLstProcedencia.Text.Equals("Seleccione una opción"))) Then
            lblMensaje.Text = "Debe completar todos los campos"
        Else
            lblMensaje.Text = ""

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

            tbIdentificacion_ = ""
            tbNombre_ = ""
            tbApellidos_ = ""
            tbEmail_ = ""
            tbContrasena_ = ""

        End If
    End Sub

    Protected Sub DwnLstTipoUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DwnLstTipoUsuario.SelectedIndexChanged

    End Sub

    Protected Sub DwnLstProcedencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DwnLstProcedencia.SelectedIndexChanged

    End Sub
End Class