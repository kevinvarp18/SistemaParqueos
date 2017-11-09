Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports System.IO

Public Class frm_Reporte
    Inherits System.Web.UI.Page
    'Dim cadenaFinal As String = "<div></div>"
    Dim lista As ArrayList = New ArrayList
    Dim str As String = ""



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If String.Equals(Session("Usuario"), "a") Then
                ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_Reporte", ResolveUrl("~") + "public/js/" + "script.js")
                Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
                Dim sn As New SP_Usuario_Negocios(strconnectionString)


            If IsPostBack Then

                Me.lista = Me.lista
                Me.str = Me.str

                Dim contentPlaceHolder As ContentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                Dim updatePanelPlaca As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)
                Dim updatePanelCorreo As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel3"), UpdatePanel)
                Dim updatePanelFecha As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel5"), UpdatePanel)
                Dim updatePanelTabla As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel6"), UpdatePanel)

                If (DwnLstTipoReporte.SelectedItem.ToString().Equals("Placa")) Then
                    updatePanelPlaca.Visible = True
                    updatePanelCorreo.Visible = False
                    updatePanelFecha.Visible = False
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Correo")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = True
                    updatePanelFecha.Visible = False

                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Fecha")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = False
                    updatePanelFecha.Visible = True
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Seleccione una opción")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = False
                    updatePanelFecha.Visible = False
                End If
            Else

                Me.lista = New ArrayList
                Me.str = ""

                DwnLstTipoReporte.Items.Add("Seleccione una opción")
                    DwnLstTipoReporte.Items.Add("Placa")
                    DwnLstTipoReporte.Items.Add("Correo")
                DwnLstTipoReporte.Items.Add("Fecha")

                DwnLstPlaca.Items.Add("Seleccione una opción")
                    Dim placas As LinkedList(Of String) = sn.obtenerPlacas()
                    For Each placa As String In placas
                        DwnLstPlaca.Items.Add(placa)
                    Next

                    DwnLstCorreo.Items.Add("Seleccione una opción")
                    Dim usuariosCorreo As LinkedList(Of Usuario) = sn.obtenerCorreoUsuariosVisitantes()
                    For Each usuarioCorreo As Usuario In usuariosCorreo
                        DwnLstCorreo.Items.Add(usuarioCorreo.GstrCorreoSG)
                    Next


            End If
            Else
                Response.BufferOutput = True
                Response.Redirect("http://localhost:52086/view/frm_index.aspx")
            End If
        End Sub

        Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
            Dim titulo As String = "ERROR"
            Dim mensaje As String = "Ha ocurrido un error"
            Dim tipo As String = "error"
            Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
            Dim solicitudes As LinkedList(Of Solicitud)
            Dim faltanDatos As Boolean = True

            If DwnLstTipoReporte.SelectedItem.ToString().Equals("Seleccione una opción") Then
                titulo = "Incompleto"
                mensaje = "Debe seleccionar un tipo de reporte"
                tipo = "warning"
                faltanDatos = True
            ElseIf tbFechaI.Text <> "" AndAlso tbFechaF.Text <> "" AndAlso DwnLstTipoReporte.SelectedItem.ToString().Equals("Fecha") Then

                If (tbFechaI.Text <= tbFechaF.Text) Then
                    solicitudes = sn.obtenerReporte(tbFechaI.Text, tbFechaF.Text)

                    If solicitudes.Count.Equals(0) Then
                        titulo = "Vacio"
                        mensaje = "No se encontraron datos para las fecha seleccionadas"
                        tipo = "info"
                        faltanDatos = True
                    Else
                        Me.construyeTabla(solicitudes)


                        faltanDatos = False
                    End If
                Else
                    titulo = "ERROR"
                    mensaje = "La fecha de salida debe ser mayor a la fecha de ingreso"
                    tipo = "error"
                    faltanDatos = True
                End If
            ElseIf (Not DwnLstPlaca.SelectedItem.ToString().Equals("Seleccione una opción")) AndAlso DwnLstTipoReporte.SelectedItem.ToString().Equals("Placa") Then
                solicitudes = sn.obtenerReportePlaca(DwnLstPlaca.SelectedItem.ToString())
                If solicitudes.Count.Equals(0) Then
                    titulo = "Vacio"
                    mensaje = "No se encontraron datos para la placa seleccionada"
                    tipo = "info"
                    faltanDatos = True
                Else
                Me.construyeTabla(solicitudes)
                faltanDatos = False
                End If
            ElseIf (Not DwnLstCorreo.SelectedItem.ToString().Equals("Seleccione una opción")) AndAlso DwnLstTipoReporte.SelectedItem.ToString().Equals("Correo") Then
                solicitudes = sn.obtenerReporteCorreo(DwnLstCorreo.SelectedItem.ToString())
                If solicitudes.Count.Equals(0) Then
                    titulo = "Vacio"
                    mensaje = "No se encontraron entradas para el correo seleccionado"
                    tipo = "info"
                    faltanDatos = True
                Else
                    Me.construyeTabla(solicitudes)
                    faltanDatos = False
                End If
            Else
                titulo = "Incompleto"
                mensaje = "Debe completar todos los campos"
                tipo = "warning"
                faltanDatos = True
            End If

        If faltanDatos Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
        End If


        Label1.Text = String.Join("", Me.lista.ToArray()).ToString

    End Sub


    Public Function construyeTabla(solicitudes As LinkedList(Of Solicitud))
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
        nom.Text = "Nombre"
        inst.Text = "Institución"
        pla.Text = "Placa"
        fecha_e.Text = "Fecha Entrada"
        hora_e.Text = "Hora Entrada"
        fecha_s.Text = "Fecha Salida"
        hora_s.Text = "Hora Salida"
        num_p.Text = "Espacio"

        tERow.Cells.Add(nom)
        tERow.Cells.Add(inst)
        tERow.Cells.Add(pla)
        tERow.Cells.Add(fecha_e)
        tERow.Cells.Add(hora_e)
        tERow.Cells.Add(fecha_s)
        tERow.Cells.Add(hora_s)
        tERow.Cells.Add(num_p)
        table.Rows.Add(tERow)


        Me.lista.Add("<div><h1>Reporte de Parqueo</h1></div>  
                   <table BORDER ='1'>")

        Me.str += String.Join(" ", Me.lista.ToArray()).ToString()


        Me.lista.Add("<tr>
                       <th><strong>Nombre</strong></th>
                       <th><strong>Instituci&oacute;n</strong></th>
                       <th><strong>Placa</strong></th>
                       <th><strong>Fecha Entrada</strong></th>
                       <th><strong>Hora Entrada</strong></th>
                       <th><strong>Fecha Salida</strong></th>
                       <th><strong>Hora Salida</strong></th>
                       <th><strong>Espacio</strong></th>
                   </tr>")
        Me.str += String.Join(" ", Me.lista.ToArray()).ToString()

        For Each solicitudAct As Solicitud In solicitudes

            Me.lista.Add("<tr>")
            Me.str += String.Join(" ", Me.lista.ToArray()).ToString()

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
                tCell2.Text = " "
                tCell3.Text = solicitudAct.GstrPlacaSG
                tCell4.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                tCell5.Text = solicitudAct.GstrHoraISG
                tCell6.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                tCell7.Text = solicitudAct.GstrHoraFSG
                tCell8.Text = solicitudAct.GintIdParqueoSG


                Me.lista.Add("<td>" + solicitudAct.GstrMarcaSG + "</td>" +
                             "<td></td>" +
                             "<td>" + solicitudAct.GstrPlacaSG + "</td>" +
                             "<td>" + solicitudAct.GstrFechaISG.Substring(0, 10) + "</td>" +
                             "<td>" + solicitudAct.GstrHoraISG + "</td>" +
                             "<td>" + solicitudAct.GstrFechaFSG.Substring(0, 10) + "</td>" +
                             "<td>" + solicitudAct.GstrHoraFSG + "</td>" +
                             "<td>" + solicitudAct.GintIdParqueoSG.ToString + "</td>")
                Me.str += String.Join(" ", Me.lista.ToArray()).ToString()
                'Me.lista.Add("<td>""" + solicitudAct.GstrMarcaSG + """</td>")


                tRow.Cells.Add(tCell)
                tRow.Cells.Add(tCell2)
                tRow.Cells.Add(tCell3)
                tRow.Cells.Add(tCell4)
                tRow.Cells.Add(tCell5)
                tRow.Cells.Add(tCell6)
                tRow.Cells.Add(tCell7)
                tRow.Cells.Add(tCell8)
                Table.Rows.Add(tRow)
            Next
            Me.lista.Add("</tr>")
            Me.str += String.Join(" ", Me.lista.ToArray()).ToString()
        Next

        Me.lista.Add("</table>")
        Me.str += String.Join(" ", Me.lista.ToArray()).ToString()

    End Function



    Protected Sub btnBuscar_Click2(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' generar el documento.
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            'path para guardar en escritorio
            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\Reporte de parqueo.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()


            ExportarDatosPDF(doc, Me.str)
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception

            'Label1.Text = ex.ToString

        End Try

        'Dim aux = ""

        'For Each li As String In Me.lista
        'aux += """" + li.ToString()
        'Next

        'Label1.Text = Me.lista.ToString

        'Label1.Text = String.Join("", Me.lista.ToArray())

    End Sub



    Public Function ExportarDatosPDF(ByVal document As Document, ByVal str As String)

        Dim fuente As iTextSharp.text.pdf.BaseFont
        fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont

        'Se agrega el PDFTable al documento.
        Dim strContent As String = str
        Dim parsedHtmlElements As List(Of IElement)


        'For Each str As String In Me.lista
        'strContent = strContent + """" + str.ToString()
        'Next

        'mensaje + """,""" + tipo
        'strContent = Me.cadenaFinal


        strContent = "<div><h1> Reporte de Parqueo</h1></div>  
                   <table BORDER ='1' >
                   <tr>
                       <th><strong>Nombre</strong></th>
                       <th><strong>Instituci&oacute;n</strong></th>
                       <th><strong>Placa</strong></th>
                       <th><strong>Fecha Entrada</strong></th>
                       <th><strong>Hora Entrada</strong></th>
                       <th><strong>Fecha Salida</strong></th>
                       <th><strong>Hora Salida</strong></th>
                       <th><strong>Espacio</strong></th>
                   </tr></table>"




        'Me.lista.Add("<div></div>")
        'strContent = str

        'lee el string  y cnviente los elementos a la lista
        parsedHtmlElements = HTMLWorker.ParseToList(New StringReader(strContent), Nothing)

        'toma cada uno de los valores parseados y los agrega al documento pdf

        For Each htmlElement As IElement In parsedHtmlElements
            document.Add(htmlElement)
        Next


    End Function

End Class