Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_SolicitarParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "v") Then
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim fechai As DateTime = Convert.ToDateTime(tbFechaE.Text)
        Dim fechaf As DateTime = Convert.ToDateTime(tbFechaS.Text)

        If tbFechaE.Text <> "" AndAlso tbHoraE.Text <> "" AndAlso tbHoraS.Text <> "" AndAlso tbFechaS.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbPlaca.Text <> "" AndAlso tbMarca.Text <> "" AndAlso tbModelo.Text <> "" Then
            solicitudNegocios.insertarSolicitud(New Solicitud(0, 0, 0, tbHoraE.Text, tbHoraS.Text, tbPlaca.Text, tbModelo.Text, tbMarca.Text, fechai.ToString("dd/MM/yyyy"), fechaf.ToString("dd/MM/yyyy")))
        End If
        tbHoraE.Text = ""
        tbHoraS.Text = ""
        tbPlaca.Text = ""
        tbModelo.Text = ""
        tbFechaE.Text = ""
        tbFechaS.Text = ""
        tbMarca.Text = "Registro"
    End Sub
End Class