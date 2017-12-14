Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_BrindarAcceso
    Inherits System.Web.UI.Page

    Public gstrUsuarioSelecion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False

        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_BrindarParqueo")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
            Dim connectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_BrindarAcceso", ResolveUrl("~") + "public/js/" + "script.js")

            Dim usuariosNegocios As New SP_Usuario_Negocios(connectionString)
            Dim parqueoNegocios As New SP_Parqueo_Negocios(connectionString)

            If IsPostBack Then
                Dim correos As LinkedList(Of Usuario) = usuariosNegocios.obtenerCorreoUsuariosVisitantes()
                Me.gstrUsuarioSelecion = DwnLstSolicitante.SelectedItem.ToString()
                For Each usuarioActual As Usuario In correos
                    If Me.gstrUsuarioSelecion.Equals("Correo Usuario: " + usuarioActual.gstrCorreo.ToString()) Then
                        Me.gstrUsuarioSelecion = usuarioActual.gstrCorreo
                    End If
                Next
            Else
                DwnLstSolicitante.Items.Clear()
                DwnLstSolicitante.Items.Add("Seleccione una opción")
                Dim correos As LinkedList(Of Usuario) = usuariosNegocios.obtenerCorreoUsuariosVisitantes()
                For Each usuarioActual As Usuario In correos
                    DwnLstSolicitante.Items.Add("Correo Usuario: " + usuarioActual.gstrCorreo.ToString())
                Next

                Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
                For Each item As Parqueo In parqueo
                    If item.GintDisponibleSG <> 0 Then
                        DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                    End If
                Next
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If

    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Dim titulo As String = "ERROR"
        Dim tipo As String = "error"
        Dim mensaje As String = "Debe completar todos los campos"

        If (tbPlaca.Text.Equals("") Or tbMarca.Text.Equals("") Or tbModelo.Text.Equals("") Or tbMotivo.Text.Equals("") Or tbFechaE.Text.Equals("") Or tbFechaS.Text.Equals("") Or tbHoraE.Text.Equals("") Or tbHoraS.Text.Equals("")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim mensaje, titulo, tipo As String

        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim fechai As DateTime = Convert.ToDateTime(tbFechaE.Text)
        Dim fechaf As DateTime = Convert.ToDateTime(tbFechaS.Text)
        Dim correo As String

        If (DwnLstSolicitante.SelectedItem.Text.Equals("Seleccione una opción")) Then
            correo = Session("Correo")
        Else
            correo = gstrUsuarioSelecion
        End If

        solicitudNegocios.brindarAcceso(correo, New Solicitud(0, 0, Integer.Parse(DwnLstParqueos.SelectedItem.Text), tbHoraE.Text, tbHoraS.Text, tbPlaca.Text, tbModelo.Text, tbMarca.Text, fechai.ToString("yyyy/MM/dd"), fechaf.ToString("yyyy/MM/dd"), tbMotivo.Text))
        titulo = "Correcto"
        mensaje = "Acceso brindado exitosamente"
        tipo = "success"

        tbHoraE.Text = ""
        tbHoraS.Text = ""
        tbPlaca.Text = ""
        tbModelo.Text = ""
        tbFechaE.Text = ""
        tbFechaS.Text = ""
        tbMarca.Text = ""
        tbMotivo.Text = ""

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class