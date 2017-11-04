Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_AdministrarSolicitudes
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim parqueoNegocios As SP_Parqueo_Negocios
    Dim solicitudNegocios As SP_Solicitud_Parqueo_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Me.parqueoNegocios = New SP_Parqueo_Negocios(Me.strConnectionString)
        Me.solicitudNegocios = New SP_Solicitud_Parqueo_Negocios(Me.strConnectionString)

        If String.Equals(Session("Usuario"), "a") Then
            llenarTablaSolicitudes()
            Dim idPagina As String
            idPagina = Request.QueryString("id")
            Dim datosSolicitud As String() = idPagina.Split(New String() {";"}, StringSplitOptions.None)
            idPagina = datosSolicitud(0)

            If (idPagina.Equals("1")) Then
                decidirSolicitud(datosSolicitud(1), datosSolicitud(2), datosSolicitud(3), datosSolicitud(4), datosSolicitud(5), datosSolicitud(6), datosSolicitud(7), datosSolicitud(8))
            End If
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If

    End Sub

    Public Sub llenarTablaSolicitudes()
        Dim rowCnt As Integer
        Dim rowCtr As Integer
        Dim contador As Integer
        Dim solicitudes As LinkedList(Of Solicitud) = Me.solicitudNegocios.obtenerAdSolicitud()
        rowCnt = 1
        contador = 1

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
                filaTabla.ID = "filaTabla" + contador.ToString()
                columnaEspaciosD.ID = "columnaParqueo" + contador.ToString()

                Dim DwnLstParqueos As New DropDownList()
                DwnLstParqueos.Width = 75%
                DwnLstParqueos.AutoPostBack = False
                DwnLstParqueos.ID = "DwnLstParqueo" + contador.ToString()
                If IsPostBack Then
                    Dim parqueo As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueo()
                    For Each item As Parqueo In parqueo
                        If item.GintDisponibleSG <> 0 Then
                            DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                        End If
                    Next
                Else
                    DwnLstParqueos.Items.Clear()
                    Dim parqueo As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueo()
                    For Each item As Parqueo In parqueo
                        If item.GintDisponibleSG <> 0 Then
                            DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                        End If
                    Next
                End If
                'la llamada y el fill de este drop hay q hacerlo aqui

                Dim literalControl As New LiteralControl()
                literalControl.Text = ""
                columnaEspaciosD.Controls.Add(literalControl)
                columnaHypLnk.Controls.Add(literalControl)

                Dim lnkBtnRechazar As New HyperLink()
                lnkBtnRechazar.Text = "(Rechazar)"
                lnkBtnRechazar.NavigateUrl = "http://localhost:52086/view/frm_AdministrarSolicitudes.aspx?id=1;" + contador.ToString() + ";" + solicitudAct.GstrMarcaSG + ";" + solicitudAct.GstrPlacaSG + ";" + solicitudAct.GstrHoraISG + ";" + solicitudAct.GstrHoraFSG + ";" + columnaFechaI.Text + ";" + columnaFechaS.Text + ";0"
                lnkBtnRechazar.Style("color") = "#ff0000"

                Dim lnkBtnAceptar As New HyperLink()
                lnkBtnAceptar.Text = "(Aceptar)"
                lnkBtnAceptar.NavigateUrl = "http://localhost:52086/view/frm_AdministrarSolicitudes.aspx?id=1;" + contador.ToString() + ";" + solicitudAct.GstrMarcaSG + ";" + solicitudAct.GstrPlacaSG + ";" + solicitudAct.GstrHoraISG + ";" + solicitudAct.GstrHoraFSG + ";" + columnaFechaI.Text + ";" + columnaFechaS.Text + ";1"
                lnkBtnAceptar.Style("color") = "#00fe00"

                columnaEspaciosD.Controls.Add(DwnLstParqueos)
                columnaHypLnk.Controls.Add(lnkBtnRechazar)
                columnaHypLnk.Controls.Add(lnkBtnAceptar)

                filaTabla.Cells.Add(columnaMarca)
                filaTabla.Cells.Add(columnaPlaca)
                filaTabla.Cells.Add(columnaFechaI)
                filaTabla.Cells.Add(columnaHoraI)
                filaTabla.Cells.Add(columnaFechaS)
                filaTabla.Cells.Add(columnaHoraS)
                filaTabla.Cells.Add(columnaEspaciosD)
                filaTabla.Cells.Add(columnaHypLnk)
                tablaSolicitudes.Rows.Add(filaTabla)

                contador = contador + 1
            Next
        Next
    End Sub

    Public Sub decidirSolicitud(idControl As String, marca As String, placa As String, horaI As String, horaF As String, fechaI As String, fechaF As String, accion As String)
        Dim contentPlaceHolder As ContentPlaceHolder
        contentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        Dim updatePanel As UpdatePanel
        updatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel1"), UpdatePanel)
        Dim tabla As Table
        tabla = DirectCast(updatePanel.FindControl("tabla"), Table)
        Dim fila As TableRow
        fila = tablaSolicitudes.Rows.Item(Integer.Parse(idControl))
        Dim columnaEspacioD As TableCell
        columnaEspacioD = DirectCast(fila.FindControl("columnaParqueo" + idControl), TableCell)
        Dim dwnLstParqueo As DropDownList
        dwnLstParqueo = DirectCast(columnaEspacioD.FindControl("DwnLstParqueo" + idControl), DropDownList)
        Dim idParqueo As String
        idParqueo = dwnLstParqueo.SelectedItem.Value
        Me.solicitudNegocios.decidirSolicitud(marca, placa, horaI, horaF, fechaI, fechaF, idParqueo, accion)
        tablaSolicitudes.Rows.Remove(fila)
    End Sub

    Public Sub llenarTablaParqueos()
        If tbFechaI.Text <> "" AndAlso tbHoraI.Text <> "" AndAlso tbHoraF.Text <> "" Then

            Dim parqueosOcupados As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueoOcupado(tbFechaI.Text, tbHoraI.Text, tbHoraF.Text)
            Dim parqueosTotales As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueoHabilitado()
            Dim cantidadTiposParqueo As LinkedList(Of String) = Me.parqueoNegocios.cantidadTiposParqueo()

            Dim rowCnt As Integer

            rowCnt = 1

            Dim tableHeaderRow As New TableHeaderRow()
            For Each tipos As String In cantidadTiposParqueo
                Dim tableHeaderCell As New TableHeaderCell()
                tableHeaderCell.Text = tipos
                tableHeaderCell.ID = tipos
                tableHeaderRow.Cells.Add(tableHeaderCell)
            Next 'Agrega los tipos de parqueos a la primera fila.
            tablaParqueos.Rows.Add(tableHeaderRow)

            For Each parqueoActual As Parqueo In parqueosTotales
                Dim tableRow As New TableRow()
                For rowCtr = 0 To cantidadTiposParqueo.Count - 1
                    Dim tableCell As New TableCell()
                    Dim tipoParqueo As String
                    tipoParqueo = tablaParqueos.Rows.Item(0).Cells.Item(rowCtr).ID
                    If parqueoActual.GstrTipoSG.Equals(tipoParqueo) Then
                        Dim hyperLink As New HyperLink()
                        Dim ocu = False
                        For Each parqueoOcupado As Parqueo In parqueosOcupados
                            If parqueoActual.GintIdentificadorSG = parqueoOcupado.GintIdentificadorSG Then
                                ocu = True
                            End If
                        Next 'Busca en todos los parqueos ocupados, para ver si el parqueo actual está ocupado.
                        hyperLink.Text = "Espacio " + parqueoActual.GintIdentificadorSG.ToString()
                        hyperLink.NavigateUrl = ""
                        If ocu = True Then
                            hyperLink.Style("color") = "#ff0000"
                        Else
                            hyperLink.Style("color") = "#00fe00"
                        End If
                        tableCell.Controls.Add(hyperLink)
                    End If
                    tableRow.Cells.Add(tableCell)
                Next 'For rowCtr = 0 To rowCnt
                tablaParqueos.Rows.Add(tableRow)
            Next 'For Each parqueosAct As Parqueo In parqueosTotales
        End If
    End Sub

End Class