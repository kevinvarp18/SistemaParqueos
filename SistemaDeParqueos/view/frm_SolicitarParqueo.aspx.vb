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
            If Not IsPostBack Then
            Else
                Dim eventArg As String = Request("__EVENTARGUMENT")
                If eventArg = "MyCustomArgument" Then
                    registrarSolicitud()
                End If
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
    End Sub

    Protected Sub registrarSolicitud()
        Dim titulo As String = "ERROR"
        Dim mensaje As String
        Dim tipo As String = "error"

        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim fechai As DateTime = Convert.ToDateTime(tbFechaE.Text)
        Dim fechaf As DateTime = Convert.ToDateTime(tbFechaS.Text)

        If tbFechaE.Text <> "" AndAlso tbHoraE.Text <> "" AndAlso tbHoraS.Text <> "" AndAlso tbFechaS.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbMarca.Text <> "" AndAlso tbModelo.Text <> "" AndAlso tbMotivo.Text <> "" Then
            solicitudNegocios.insertarSolicitud(Session("Correo"), New Solicitud(0, 0, 0, tbHoraE.Text, tbHoraS.Text, tbPlaca.Text, tbModelo.Text, tbMarca.Text, fechai.ToString("dd/MM/yyyy"), fechaf.ToString("dd/MM/yyyy"), tbMotivo.Text))
            titulo = "Correcto"
            mensaje = "La solicitud se ha enviado exitosamente"
            tipo = "success"
            tbFechaE.Text = ""
            tbFechaS.Text = ""
            tbHoraE.Text = ""
            tbHoraS.Text = ""
            tbPlaca.Text = ""
            tbModelo.Text = ""
            tbMarca.Text = ""
            tbModelo.Text = ""
            tbMotivo.Text = ""
        Else
            mensaje = "Debe completar todos los campos"
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class