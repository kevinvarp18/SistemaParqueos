Imports System.Web.Configuration
Imports Entidad
Imports Negocios
Public Class frm_Reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_Reporte", ResolveUrl("~") + "public/js/" + "script.js")
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim sn As New SP_Usuario_Negocios(strconnectionString)

            If IsPostBack Then

                Dim contentPlaceHolder As ContentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                Dim updatePanelPlaca As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)
                Dim updatePanelCorreo As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel3"), UpdatePanel)
                Dim updatePanelInstitucion As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel4"), UpdatePanel)
                Dim updatePanelFecha As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel5"), UpdatePanel)
                Dim updatePanelTabla As UpdatePanel = DirectCast(contentPlaceHolder.FindControl("UpdatePanel6"), UpdatePanel)

                If (DwnLstTipoReporte.SelectedItem.ToString().Equals("Placa")) Then
                    updatePanelPlaca.Visible = True
                    updatePanelCorreo.Visible = False
                    updatePanelInstitucion.Visible = False
                    updatePanelFecha.Visible = False
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Correo")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = True
                    updatePanelInstitucion.Visible = False
                    updatePanelFecha.Visible = False
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Institución")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = False
                    updatePanelInstitucion.Visible = True
                    updatePanelFecha.Visible = False
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Fecha")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = False
                    updatePanelInstitucion.Visible = False
                    updatePanelFecha.Visible = True
                ElseIf (DwnLstTipoReporte.SelectedItem.ToString().Equals("Seleccione una opción")) Then
                    updatePanelPlaca.Visible = False
                    updatePanelCorreo.Visible = False
                    updatePanelInstitucion.Visible = False
                    updatePanelFecha.Visible = False
                End If
            Else
                DwnLstTipoReporte.Items.Add("Seleccione una opción")
                DwnLstTipoReporte.Items.Add("Placa")
                DwnLstTipoReporte.Items.Add("Correo")
                DwnLstTipoReporte.Items.Add("Institución")
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


                DwnLstInstitucion.Items.Add("Seleccione una opción")

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
                tCell2.Text = " "
                tCell3.Text = solicitudAct.GstrPlacaSG
                tCell4.Text = solicitudAct.GstrFechaISG.Substring(0, 10)
                tCell5.Text = solicitudAct.GstrHoraISG
                tCell6.Text = solicitudAct.GstrFechaFSG.Substring(0, 10)
                tCell7.Text = solicitudAct.GstrHoraFSG
                tCell8.Text = solicitudAct.GintIdParqueoSG

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
    End Function
End Class