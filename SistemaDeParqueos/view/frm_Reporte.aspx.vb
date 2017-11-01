Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_Reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)

        Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)

        If tbFechaI.Text <> "" AndAlso tbFechaF.Text <> "" Then
            Dim fecha_i As String
            Dim fecha_f As String
            ' fecha_i = tbFechaI.ToString("dd/MM/yyyy") ' hay q arreglar estas dos para ver xq no me deja pasar esto como string
            'fecha_f = tbFechaF.ToString("dd/MM/yyyy")
            fecha_i = tbFechaI.Text ' hay q arreglar estas dos para ver xq no me deja pasar esto como string
            fecha_f = tbFechaF.Text

            lblDesde.Text = fecha_i + " " + fecha_f

            Dim solicitudes As LinkedList(Of Solicitud) = sn.obtenerReporte(fecha_i, fecha_f)
            ' Total number of rows.
            Dim rowCnt As Integer
            ' Current row count
            Dim rowCtr As Integer
            ' Total number of cells (columns).
            Dim cellCnt As Integer

            rowCnt = 1
            cellCnt = 7

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

                    tCell.Text = solicitudAct.GstrMarcaSG
                    tCell2.Text = " "
                    tCell3.Text = solicitudAct.GstrPlacaSG
                    tCell4.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                    tCell5.Text = solicitudAct.GstrHoraISG
                    tCell5.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                    tCell6.Text = solicitudAct.GstrHoraFSG
                    tCell7.Text = solicitudAct.GintIdParqueoSG

                    tRow.Cells.Add(tCell)
                    tRow.Cells.Add(tCell2)
                    tRow.Cells.Add(tCell3)
                    tRow.Cells.Add(tCell4)
                    tRow.Cells.Add(tCell5)
                    tRow.Cells.Add(tCell6)
                    tRow.Cells.Add(tCell7)
                    table.Rows.Add(tRow)
                Next
            Next
        End If

    End Sub
End Class