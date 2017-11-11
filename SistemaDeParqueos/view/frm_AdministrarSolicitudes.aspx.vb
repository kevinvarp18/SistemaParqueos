﻿Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_AdministrarSolicitudes
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim parqueoNegocios As SP_Parqueo_Negocios
    Dim solicitudNegocios As SP_Solicitud_Parqueo_Negocios
    Dim usuarioNegocios As SP_Usuario_Negocios
    Shared marca, placa, horaI, horaF, fechaI, fechaF, idParqueo, correo, accion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False

        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_AdministrarSolicitudes")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
            Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.parqueoNegocios = New SP_Parqueo_Negocios(Me.strConnectionString)
            Me.solicitudNegocios = New SP_Solicitud_Parqueo_Negocios(Me.strConnectionString)
            Me.usuarioNegocios = New SP_Usuario_Negocios(Me.strConnectionString)
            llenarTablaSolicitudes()
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
        Dim listaDwnLstParqueos As New LinkedList(Of DropDownList)
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
                Dim columnaEspaciosParqueo As New TableCell()
                Dim columnaHypLnk As New TableCell()

                columnaMarca.Text = solicitudAct.GstrMarcaSG
                columnaPlaca.Text = solicitudAct.GstrPlacaSG
                columnaFechaI.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                columnaHoraI.Text = solicitudAct.GstrHoraISG
                columnaFechaS.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                columnaHoraS.Text = solicitudAct.GstrHoraFSG
                filaTabla.ID = "filaTabla" + contador.ToString()
                columnaEspaciosParqueo.ID = "columnaParqueo" + contador.ToString()
                columnaHypLnk.ID = "columnaHypLnk" + contador.ToString()

                Dim DwnLstParqueos As New DropDownList()
                DwnLstParqueos.Width = 75%
                DwnLstParqueos.AutoPostBack = False
                DwnLstParqueos.Style("padding") = "0px 0px"
                DwnLstParqueos.ID = "DwnLstParqueo" + contador.ToString()
                If IsPostBack Then
                Else
                    DwnLstParqueos.Items.Clear()
                End If

                Dim parqueo As LinkedList(Of Parqueo) = Me.parqueoNegocios.obtenerParqueo()
                For Each item As Parqueo In parqueo
                    If item.GintDisponibleSG <> 0 Then
                        DwnLstParqueos.Items.Add(item.GintIdentificadorSG.ToString)
                    End If
                Next

                Dim literalControl As New LiteralControl()
                literalControl.Text = ""
                columnaEspaciosParqueo.Controls.Add(literalControl)
                columnaHypLnk.Controls.Add(literalControl)

                Dim btnRechazar As Button = New Button
                btnRechazar.CssClass = contador.ToString() + ";" + solicitudAct.GstrMarcaSG + ";" + solicitudAct.GstrPlacaSG + ";" + solicitudAct.GstrHoraISG + ";" + solicitudAct.GstrHoraFSG + ";" + columnaFechaI.Text + ";" + columnaFechaS.Text + ";" + solicitudAct.GstrModeloSG + ";0"
                btnRechazar.Text = "(Rechazar)"
                btnRechazar.Width = 90%
                btnRechazar.Style("color") = "#ff0000"
                AddHandler btnRechazar.Click, AddressOf Me.button_Click

                Dim btnAceptar As Button = New Button
                btnAceptar.CssClass = contador.ToString() + ";" + solicitudAct.GstrMarcaSG + ";" + solicitudAct.GstrPlacaSG + ";" + solicitudAct.GstrHoraISG + ";" + solicitudAct.GstrHoraFSG + ";" + columnaFechaI.Text + ";" + columnaFechaS.Text + ";" + solicitudAct.GstrModeloSG + ";1"
                btnAceptar.Text = "(Aceptar)"
                btnAceptar.Width = 90%
                btnAceptar.Style("color") = "#00fe00"
                AddHandler btnAceptar.Click, AddressOf Me.button_Click

                columnaEspaciosParqueo.Controls.Add(DwnLstParqueos)
                listaDwnLstParqueos.AddLast(DwnLstParqueos)
                columnaHypLnk.Controls.Add(btnRechazar)
                columnaHypLnk.Controls.Add(btnAceptar)

                filaTabla.Cells.Add(columnaMarca)
                filaTabla.Cells.Add(columnaPlaca)
                filaTabla.Cells.Add(columnaFechaI)
                filaTabla.Cells.Add(columnaHoraI)
                filaTabla.Cells.Add(columnaFechaS)
                filaTabla.Cells.Add(columnaHoraS)
                filaTabla.Cells.Add(columnaEspaciosParqueo)
                filaTabla.Cells.Add(columnaHypLnk)
                tablaSolicitudes.Rows.Add(filaTabla)

                contador = contador + 1
            Next
        Next
    End Sub
    Public Sub llenarTablaParqueos()
        If tbFechaI.Text <> "" AndAlso tbHoraI.Text <> "" AndAlso tbHoraF.Text <> "" Then
            Dim parqueosOcupados As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueoOcupado(tbFechaI.Text, tbHoraI.Text, tbHoraF.Text)
            Dim parqueosTotales As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
            Dim cantidadTiposParqueo As LinkedList(Of String) = parqueoNegocios.cantidadTiposParqueo()

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
                        If parqueoActual.GintDisponibleSG = 0 Then
                            ocu = True
                        End If
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
    Protected Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim botonSeleccionado As Button = CType(sender, Button)
        Dim datosSolictud As String() = botonSeleccionado.CssClass.Split(New String() {";"}, StringSplitOptions.None)

        Dim contentPlaceHolder As ContentPlaceHolder
        Dim updatePanel As UpdatePanel
        Dim tabla As Table
        Dim fila As TableRow
        Dim columnaEspacioD As TableCell
        Dim dwnLstParqueo As DropDownList
        Dim idParqueo As String

        contentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
        updatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel1"), UpdatePanel)
        tabla = DirectCast(updatePanel.FindControl("tablaSolicitudes"), Table)
        fila = tablaSolicitudes.Rows.Item(Integer.Parse(datosSolictud(0)))
        columnaEspacioD = DirectCast(fila.FindControl("columnaParqueo" + datosSolictud(0)), TableCell)
        dwnLstParqueo = DirectCast(columnaEspacioD.FindControl("DwnLstParqueo" + datosSolictud(0)), DropDownList)
        idParqueo = dwnLstParqueo.SelectedItem.Value

        marca = datosSolictud(1)
        placa = datosSolictud(2)
        horaI = datosSolictud(3)
        horaF = datosSolictud(4)
        fechaI = datosSolictud(5)
        fechaF = datosSolictud(6)
        Me.idParqueo = idParqueo
        correo = datosSolictud(7)
        accion = datosSolictud(8)

        If (accion.Equals("0")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "abrirModal();", True)
        Else
            decidirSolicitud()
            tablaSolicitudes.Rows.Remove(fila)
        End If
    End Sub
    Public Sub decidirSolicitud()
        Dim titulo, mensaje, tipo, retroalimentacion As String

        If (accion.Equals("0")) Then
            titulo = "Correcto"
            mensaje = "La solicitud se ha rechazado exitosamente"
            tipo = "error"
        Else
            titulo = "Correcto"
            mensaje = "La solicitud se ha aceptado exitosamente"
            tipo = "success"
        End If

        If (accion.Equals("1")) Then
            If (fechaI.Equals(fechaF)) Then
                retroalimentacion = "el día " + fechaI + " de las " + horaI + " a las " + horaF + " en el espacio " + idParqueo + " del parqueo."
            Else
                retroalimentacion = "para los días del " + fechaI + " al " + fechaF + "de " + horaI + "a " + horaF + " en el espacio " + idParqueo + " del parqueo."
            End If
        Else
            retroalimentacion = tbRetroalimentacion.Text
        End If

        Me.usuarioNegocios.envioCorreoSolicitud(Me.correo, retroalimentacion, accion)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        Me.solicitudNegocios.decidirSolicitud(marca, placa, horaI, horaF, fechaI, fechaF, idParqueo, accion)

        tbRetroalimentacion.Text = ""
    End Sub

End Class