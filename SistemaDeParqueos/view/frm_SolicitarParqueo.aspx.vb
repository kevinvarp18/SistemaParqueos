Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_SolicitarParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False
        ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_SolicitarParqueo", ResolveUrl("~") + "public/js/" + "script.js")

        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_SolicitarParqueo")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        If tbFechaE.Text <> "" AndAlso tbHoraE.Text <> "" AndAlso tbHoraS.Text <> "" AndAlso tbFechaS.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbMarca.Text <> "" AndAlso tbModelo.Text <> "" AndAlso tbMotivo.Text <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR', 'Debe completar todos los campos', 'error');", True)
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim fechai As DateTime = Convert.ToDateTime(tbFechaE.Text)
        Dim fechaf As DateTime = Convert.ToDateTime(tbFechaS.Text)

        solicitudNegocios.insertarSolicitud(Session("Correo"), New Solicitud(0, 0, 0, tbHoraE.Text, tbHoraS.Text, tbPlaca.Text, tbModelo.Text, tbMarca.Text, fechai.ToString("yyyy/MM/dd"), fechaf.ToString("yyyy/MM/dd"), tbMotivo.Text))
        tbFechaE.Text = ""
        tbFechaS.Text = ""
        tbHoraE.Text = ""
        tbHoraS.Text = ""
        tbPlaca.Text = ""
        tbModelo.Text = ""
        tbMarca.Text = ""
        tbModelo.Text = ""
        tbMotivo.Text = ""

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('CORRECTO', 'La solicitud se ha enviado exitosamente', 'success');", True)
    End Sub
End Class