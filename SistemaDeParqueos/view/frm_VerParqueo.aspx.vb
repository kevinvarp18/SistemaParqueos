Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class VerParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnBuscarP_Click(sender As Object, e As EventArgs) Handles btnBuscarP.Click
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        If tbFechaI.Text <> "" AndAlso tbHoraI.Text <> "" AndAlso tbHoraF.Text <> "" Then
            Dim parqueos As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueoOcupado(tbFechaI.Text, tbHoraI.Text, tbHoraF.Text)
            Dim rowCnt As Integer
            Dim rowCtr As Integer
            Dim cellCnt As Integer

            rowCnt = 1
            cellCnt = 7
            Dim tERow As New TableRow()
            Dim nom As New TableHeaderCell()
            Dim inst As New TableHeaderCell()
            Dim pla As New TableHeaderCell()
            Dim fecha_e As New TableHeaderCell()
            Dim hora_e As New TableHeaderCell()
            Dim fecha_s As New TableHeaderCell()
            Dim hora_s As New TableHeaderCell()
            Dim num_p As New TableHeaderCell()
            nom.Text = "Jefatura"
            inst.Text = "PIP"
            pla.Text = "UPRO"
            fecha_e.Text = "OPD"
            hora_e.Text = "SERT"
            fecha_s.Text = "UPROV"
            hora_s.Text = "UVISE"
            num_p.Text = "VISITAS"
        End If
    End Sub
End Class