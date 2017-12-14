Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.tool.xml

Public Class frm_Reporte
    Inherits System.Web.UI.Page

    Dim cadena As String
    Shared tipoReporte As String = ""
    Dim listaDatos As New LinkedList(Of String)
    Dim listaUsuarios As New LinkedList(Of Usuario)
    Dim urlr As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False
        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_Reporte")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_Reporte", ResolveUrl("~") + "public/js/" + "script.js")
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim usuarioNegocios As New SP_Usuario_Negocios(strconnectionString)
            Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)


            If IsPostBack Then
                Me.cadena = Me.cadena

                Dim contentPlaceHolder As ContentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                Dim updatePanelTipo As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)
                Dim updatePanelFechas As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel3"), UpdatePanel)
                updatePanelFechas.Visible = False
                updatePanelTipo.Visible = True

                If (tipoReporte.Equals("") Or (Not tipoReporte.Equals(DwnLstTipoReporte.SelectedItem.ToString()))) Then
                    DwnLstDatos.Items.Clear()
                    DwnLstDatos.Items.Add("Seleccione una opción")
                End If

                If (DwnLstTipoReporte.SelectedItem.ToString().Equals("Placa")) Then
                    lblTipoEscogido.Text = "Placa:"
                    listaDatos = usuarioNegocios.obtenerPlacas()
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Correo")) Then
                    lblTipoEscogido.Text = "Correo:"
                    listaUsuarios = usuarioNegocios.obtenerCorreoUsuariosVisitantes()
                    If (DwnLstDatos.Items.Count = 1) Then
                        For Each datosUsuario As Usuario In listaUsuarios
                            DwnLstDatos.Items.Add(datosUsuario.GstrCorreoSG)
                        Next
                    End If
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Cedula")) Then
                    lblTipoEscogido.Text = "Cedula:"
                    listaUsuarios = solicitudNegocios.ObtenerCedulasYNombres("v")
                    If (DwnLstDatos.Items.Count = 1) Then
                        For Each datosUsuario As Usuario In listaUsuarios
                            DwnLstDatos.Items.Add(datosUsuario.GstrIdSG + " - " + datosUsuario.GstrNombreSG + " " + datosUsuario.GstrApellidoSG)
                        Next
                    End If
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Oficial")) Then
                    lblTipoEscogido.Text = "Oficial:"
                    listaUsuarios = solicitudNegocios.ObtenerCedulasYNombres("o")
                    If (DwnLstDatos.Items.Count = 1) Then
                        For Each datosUsuario As Usuario In listaUsuarios
                            DwnLstDatos.Items.Add(datosUsuario.GstrIdSG + " - " + datosUsuario.GstrNombreSG + " " + datosUsuario.GstrApellidoSG)
                        Next
                    End If
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Fecha")) Then
                    updatePanelTipo.Visible = False
                    updatePanelFechas.Visible = True
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Institucion")) Then
                    lblTipoEscogido.Text = "Institución:"
                    listaDatos = solicitudNegocios.ObtenerInstituciones()
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Departamento")) Then
                    lblTipoEscogido.Text = "Departamento:"
                    listaDatos = solicitudNegocios.ObtenerDepartamentos()
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Seleccione una opción")) Then
                    updatePanelTipo.Visible = False
                    updatePanelFechas.Visible = False
                End If

                If (DwnLstDatos.Items.Count = 1) Then
                    For Each datos As String In listaDatos
                        DwnLstDatos.Items.Add(datos)
                    Next
                End If

                tipoReporte = DwnLstTipoReporte.SelectedItem.Text
            Else
                Me.cadena = ""
                DwnLstTipoReporte.Items.Add("Seleccione una opción")
                DwnLstTipoReporte.Items.Add("Placa")
                DwnLstTipoReporte.Items.Add("Cedula")
                DwnLstTipoReporte.Items.Add("Oficial")
                DwnLstTipoReporte.Items.Add("Correo")
                DwnLstTipoReporte.Items.Add("Institucion")
                DwnLstTipoReporte.Items.Add("Departamento")
                DwnLstTipoReporte.Items.Add("Fecha")
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        selecciones("reporte")
    End Sub
    Public Sub construyeTabla(solicitudes As LinkedList(Of Solicitud))
        Dim rowCnt As Integer
        Dim rowCtr As Integer
        rowCnt = 1

        For Each solicitudAct As Solicitud In solicitudes
            For rowCtr = 1 To rowCnt
                Dim filaTabla As New TableRow()
                Dim celdaMarca As New TableCell()
                Dim celdaModelo As New TableCell()
                Dim celdaPlaca As New TableCell()
                Dim celdaFechaI As New TableCell()
                Dim celdaHoraI As New TableCell()
                Dim celdaFechaF As New TableCell()
                Dim celdaHoraF As New TableCell()
                Dim celdaEspacioParqueo As New TableCell()

                celdaMarca.Text = solicitudAct.GstrMarcaSG
                celdaModelo.Text = solicitudAct.GstrModeloSG
                celdaPlaca.Text = solicitudAct.GstrPlacaSG
                celdaFechaI.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                celdaHoraI.Text = solicitudAct.GstrHoraISG
                celdaFechaF.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                celdaHoraF.Text = solicitudAct.GstrHoraFSG
                celdaEspacioParqueo.Text = solicitudAct.GintIdParqueoSG

                filaTabla.Cells.Add(celdaMarca)
                filaTabla.Cells.Add(celdaModelo)
                filaTabla.Cells.Add(celdaPlaca)
                filaTabla.Cells.Add(celdaFechaI)
                filaTabla.Cells.Add(celdaHoraI)
                filaTabla.Cells.Add(celdaFechaF)
                filaTabla.Cells.Add(celdaHoraF)
                filaTabla.Cells.Add(celdaEspacioParqueo)
                table.Rows.Add(filaTabla)
            Next
        Next
    End Sub
    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        selecciones("pdf")
        Try
            Dim strHtml As String
            Dim strContent As String = Me.cadena
            Dim solicitudes As LinkedList(Of Solicitud) = selecciones("pdf")
            Dim memStream As New MemoryStream()
            strHtml = "
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <link href='" & urlr & "/public/css/style.css' rel='stylesheet' type='text/css' />
                <link href='" & urlr & "/public/css/bootstrap.css' rel='stylesheet' type='text/css' />
            </head>
            <body>
                <div class='container'>
                    <h3> Reporte de Parqueo</h3>
                    <div class='page w3-4'>
                        <div class='bs-example ' data-example-id='simple-table'>
                            <table BORDER ='1'  class='table'>
                            <tr>
                                <th><strong> Nombre </strong></th>
                                <th><strong> Instituci&oacute;n </strong></th>
                                <th><strong> Placa </strong></th>
                                <th><strong> Fecha Entrada </strong></th>
                                <th><strong> Hora Entrada </strong></th>
                                <th><strong> Fecha Salida </strong></th>
                                <th><strong> Hora Salida </strong></th>
                                <th><strong> Espacio </strong></th>
                            </tr>"

            For Each solicitudAct As Solicitud In solicitudes
                strHtml += "<tr>" + "<td>" + solicitudAct.GstrMarcaSG + "</td>" + "<td>" + solicitudAct.GstrModeloSG + "</td>" + "<td>" + solicitudAct.GstrPlacaSG +
            "</td>" + "<td>" + solicitudAct.GstrFechaISG.Substring(0, 10) + "</td>" + "<td>" + solicitudAct.GstrHoraISG + "</td>" + "<td>" + solicitudAct.GstrFechaFSG.Substring(0, 10) + "</td>" + "<td>" + solicitudAct.GstrHoraFSG + "</td>" + "<td>" + solicitudAct.GintIdParqueoSG.ToString() + "</td>" + "</tr>"
            Next

            strHtml += "</table>" + " </div>" + " </div>" + " </div>" + "<body>" + "</html>" + "<br>"
            strContent = strHtml
            Dim strFileShortName As String = "test" & DateTime.Now.Ticks & ".pdf"
            Dim strFileName As String = HttpContext.Current.Server.MapPath("" & strFileShortName)
            Dim docWorkingDocument As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 1, 1, 0, 0)
            Dim srdDocToString As StringReader = Nothing
            Try
                Dim pdfWrite As PdfWriter
                pdfWrite = PdfWriter.GetInstance(docWorkingDocument, New FileStream(strFileName, FileMode.Create))
                srdDocToString = New StringReader(strHtml)
                docWorkingDocument.Open()
                XMLWorkerHelper.GetInstance().ParseXHtml(pdfWrite, docWorkingDocument, srdDocToString)
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                If Not docWorkingDocument Is Nothing Then
                    docWorkingDocument.Close()
                    docWorkingDocument.Dispose()
                End If
                If Not srdDocToString Is Nothing Then
                    srdDocToString.Close()
                    srdDocToString.Dispose()
                End If
            End Try
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Process.Start(url + "/view/" + strFileShortName)
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "myscript", "window.open('" & strFileShortName & "','_blank','location=0,menubar=0,status=0,titlebar=0,toolbar=0');", True)
        Catch ex As Exception
        End Try
    End Sub
    Public Function selecciones(accion As String) As LinkedList(Of Solicitud)
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        Dim reporteSeleccionado As String
        Dim solicitudNegocios As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        Dim solicitudes As LinkedList(Of Solicitud) = Nothing
        Dim faltanDatos As Boolean = True
        Dim titulo As String = "ERROR"
        Dim tipo As String = "error"
        Dim mensaje As String = ""

        If (DwnLstTipoReporte.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            titulo = "INCOMPLETO"
            mensaje = "Debe seleccionar un tipo de reporte"
            tipo = "warning"
        ElseIf (tbFechaI.Text <> "" AndAlso tbFechaF.Text <> "" AndAlso DwnLstTipoReporte.SelectedItem.ToString().Equals("Fecha")) Then
            If (tbFechaI.Text <= tbFechaF.Text) Then
                solicitudes = solicitudNegocios.obtenerReporte(tbFechaI.Text, tbFechaF.Text)

                If solicitudes.Count.Equals(0) Then
                    titulo = "VACIO"
                    mensaje = "No se encontraron datos para las fecha seleccionadas"
                    tipo = "info"
                Else
                    If accion.Equals("reporte") Then
                        Me.construyeTabla(solicitudes)
                    End If
                    faltanDatos = False
                End If
            Else
                mensaje = "La fecha de salida debe ser mayor a la fecha de ingreso"
            End If
        ElseIf (Not DwnLstDatos.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            reporteSeleccionado = DwnLstTipoReporte.SelectedItem.ToString().ToLower()

            Select Case reporteSeleccionado
                Case "placa"
                    solicitudes = solicitudNegocios.obtenerReportePlaca(DwnLstDatos.SelectedItem.ToString())
                    Exit Select
                Case "cedula"
                    Dim cedula As String() = DwnLstDatos.SelectedItem.ToString().Split(New String() {" "}, StringSplitOptions.None)
                    solicitudes = solicitudNegocios.obtenerReporteCedula(cedula(0))
                    Exit Select
                Case "correo"
                    solicitudes = solicitudNegocios.obtenerReporteCorreo(DwnLstDatos.SelectedItem.ToString())
                    Exit Select
                Case "institucion"
                    solicitudes = solicitudNegocios.obtenerReporteInstitucion(DwnLstDatos.SelectedItem.ToString())
                    Exit Select
                Case "departamento"
                    solicitudes = solicitudNegocios.obtenerReporteDepartamento(DwnLstDatos.SelectedItem.ToString())
                    Exit Select
                Case "oficial"
                    Dim cedula As String() = DwnLstDatos.SelectedItem.ToString().Split(New String() {" "}, StringSplitOptions.None)
                    solicitudes = solicitudNegocios.obtenerReporteOficial(cedula(0))
                    Exit Select
            End Select

            If solicitudes.Count.Equals(0) Then
                titulo = "VACIO"
                mensaje = "No se encontraron datos para realizar el reporte"
                tipo = "info"
            Else
                If accion.Equals("reporte") Then
                    Me.construyeTabla(solicitudes)
                End If
                faltanDatos = False
            End If
        Else
            titulo = "INCOMPLETO"
            mensaje = "Debe completar todos los campos"
            tipo = "warning"
        End If

        If (faltanDatos) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        End If
        Return solicitudes
    End Function

End Class