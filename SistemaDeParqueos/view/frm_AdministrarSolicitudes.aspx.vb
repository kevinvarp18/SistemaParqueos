Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_AdministrarSolicitudes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        If String.Equals(Session("Usuario"), "a") Then

        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If

        Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim solicitudes As LinkedList(Of Solicitud) = sn.obtenerAdSolicitud()

        ' Total number of rows.
        Dim rowCnt As Integer
        ' Current row count
        Dim rowCtr As Integer
        ' Total number of cells (columns).
        Dim cellCnt As Integer

        rowCnt = 1
        cellCnt = 8

        For Each solicitudAct As Solicitud In solicitudes

            For rowCtr = 1 To rowCnt
                Dim tRow As New TableRow()
                Dim tCell As New TableCell()
                Dim tCell2 As New TableCell()
                Dim tCell3 As New TableCell()
                Dim tCell4 As New TableCell()
                Dim tCell5 As New TableCell()
                Dim tCell6 As New TableCell()
                Dim tCell7 As New TableCell()
                Dim tCell8 As New TableCell()

                tCell.Text = solicitudAct.GstrMarcaSG
                tCell2.Text = solicitudAct.GstrPlacaSG
                tCell3.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                tCell4.Text = solicitudAct.GstrHoraISG
                tCell5.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                tCell6.Text = solicitudAct.GstrHoraFSG

                Dim s As New LiteralControl()
                s.Text = ""
                tCell7.Controls.Add(s)
                tCell8.Controls.Add(s)
                Dim h As New HyperLink()
                h.Text = "(Rechazar)"
                h.NavigateUrl = "#"
                Dim h2 As New HyperLink()
                h2.Text = "(Aceptar)"
                h2.NavigateUrl = "#"

                Dim d As New DropDownList()
                d.Width = 75%
                If IsPostBack Then
                    Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueoHabilitado()
                    For Each item As Parqueo In parqueo
                        d.Items.Add(item.GintIdentificadorSG.ToString)
                    Next
                Else
                    d.Items.Clear()
                    Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
                    For Each item As Parqueo In parqueo
                        d.Items.Add(item.GintIdentificadorSG.ToString)
                    Next
                End If
                'la llamada y el fill de este drop hay q hacerlo aqui

                tCell7.Controls.Add(d)
                tCell8.Controls.Add(h)
                tCell8.Controls.Add(h2)

                tRow.Cells.Add(tCell)
                tRow.Cells.Add(tCell2)
                tRow.Cells.Add(tCell3)
                tRow.Cells.Add(tCell4)
                tRow.Cells.Add(tCell5)
                tRow.Cells.Add(tCell6)
                tRow.Cells.Add(tCell7)
                tRow.Cells.Add(tCell8)
                table.Rows.Add(tRow)
            Next
        Next

    End Sub

End Class