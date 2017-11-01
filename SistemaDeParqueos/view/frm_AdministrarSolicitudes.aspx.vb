Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_AdministrarSolicitudes
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim parqueoNegocios As SP_Parqueo_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Me.parqueoNegocios = New SP_Parqueo_Negocios(Me.strConnectionString)
        If String.Equals(Session("Usuario"), "a") Then

        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If

        Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim solicitudes As LinkedList(Of Solicitud) = sn.obtenerAdSolicitud()
        llenarTabla(solicitudes)
    End Sub

    Public Function llenarTabla(solicitudes As LinkedList(Of Solicitud))
        Dim rowCnt As Integer
        Dim rowCtr As Integer
        rowCnt = 1

        For Each solicitudAct As Solicitud In solicitudes
            For rowCtr = 1 To rowCnt
                Dim filaTabla As New TableRow()
                Dim columnaMarca As New TableCell()
                Dim columnaPlaca As New TableCell()
                Dim columnaFechaI As New TableCell()
                Dim columnaHoraI As New TableCell()
                Dim columnaFechaS As New TableCell()
                Dim columnaHoraS As New TableCell()
                Dim columnaEspaciosD As New TableCell()
                Dim columnaHypLnk As New TableCell()

                columnaMarca.Text = solicitudAct.GstrMarcaSG
                columnaPlaca.Text = solicitudAct.GstrPlacaSG
                columnaFechaI.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                columnaHoraI.Text = solicitudAct.GstrHoraISG
                columnaFechaS.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                columnaHoraS.Text = solicitudAct.GstrHoraFSG

                Dim literalControl As New LiteralControl()
                literalControl.Text = ""
                columnaEspaciosD.Controls.Add(literalControl)
                columnaHypLnk.Controls.Add(literalControl)

                Dim hyperLinkRechazar As New HyperLink()
                hyperLinkRechazar.Text = "(Rechazar)"
                hyperLinkRechazar.NavigateUrl = "#"
                hyperLinkRechazar.Style("color") = "#ff0000"

                Dim hyperLinkAceptar As New HyperLink()
                hyperLinkAceptar.Text = "(Aceptar)"
                hyperLinkAceptar.NavigateUrl = "#"
                hyperLinkAceptar.Style("color") = "#00fe00"

                Dim DwnLstParqueos As New DropDownList()
                DwnLstParqueos.Width = 75%
                If IsPostBack Then
                    Dim parqueo As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueoHabilitado()
                    For Each item As Parqueo In parqueo
                        DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                    Next
                Else
                    DwnLstParqueos.Items.Clear()
                    Dim parqueo As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueo()
                    For Each item As Parqueo In parqueo
                        DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                    Next
                End If
                'la llamada y el fill de este drop hay q hacerlo aqui

                columnaEspaciosD.Controls.Add(DwnLstParqueos)
                columnaHypLnk.Controls.Add(hyperLinkRechazar)
                columnaHypLnk.Controls.Add(hyperLinkAceptar)

                filaTabla.Cells.Add(columnaMarca)
                filaTabla.Cells.Add(columnaPlaca)
                filaTabla.Cells.Add(columnaFechaI)
                filaTabla.Cells.Add(columnaHoraI)
                filaTabla.Cells.Add(columnaFechaS)
                filaTabla.Cells.Add(columnaHoraS)
                filaTabla.Cells.Add(columnaEspaciosD)
                filaTabla.Cells.Add(columnaHypLnk)
                tabla.Rows.Add(filaTabla)
            Next
        Next
    End Function

End Class