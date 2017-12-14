Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class administrarParqueo
    Inherits System.Web.UI.Page

    Public gintParqueoIdentificador As Long
    Public gstrParqueoSelecion As String
    Public Shared btnAccion As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False

        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_AdministrarParqueo")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
            Dim connectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim contentPlaceHolder As ContentPlaceHolder
            Dim updatePanel2, updatePanel3 As UpdatePanel
            Dim parqueoNegocios As New SP_Parqueo_Negocios(connectionString)
            Dim intIDparqueo, strEstadoP, strtipoParqueo As String
            contentPlaceHolder = DirectCast(Page.Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
            updatePanel2 = DirectCast(contentPlaceHolder.FindControl("UpdatePanel2"), UpdatePanel)
            updatePanel3 = DirectCast(contentPlaceHolder.FindControl("UpdatePanel3"), UpdatePanel)
            Dim idPagina As String = Request.QueryString("id")
            Dim datosSolicitud As String() = idPagina.Split(New String() {";"}, StringSplitOptions.None)
            idPagina = datosSolicitud(0)

            If IsPostBack Then
                Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()

                If (idPagina.Equals("0")) Then
                    updatePanel2.Visible = True
                    updatePanel3.Visible = False
                    intIDparqueo = datosSolicitud(1)
                    Me.gintParqueoIdentificador = Long.Parse(intIDparqueo)
                    lblNumParqueo.Text = Me.gintParqueoIdentificador
                ElseIf (idPagina.Equals("1")) Then
                    updatePanel2.Visible = False
                    updatePanel3.Visible = True
                    Dim parqueosTotales As Integer = parqueoNegocios.obtenerIDMayorParqueo() + 1
                    lblNumParqueo.Text = parqueosTotales
                End If
            Else
                DwnLstTipos.Items.Clear()
                DwnLstEstado.Items.Clear()
                DwnLstTipos.Items.Add("Seleccione una opción")
                DwnLstTipos.Items.Add("Jefatura")
                DwnLstTipos.Items.Add("PIP")
                DwnLstTipos.Items.Add("UPRO")
                DwnLstTipos.Items.Add("OPO")
                DwnLstTipos.Items.Add("SERT")
                DwnLstTipos.Items.Add("UPROV")
                DwnLstTipos.Items.Add("UVISE")
                DwnLstTipos.Items.Add("Visitas")
                DwnLstEstado.Items.Add("Seleccione una opción")
                DwnLstEstado.Items.Add("Habilitado")
                DwnLstEstado.Items.Add("Deshabilitado")

                If (idPagina.Equals("1")) Then
                    updatePanel2.Visible = False
                    updatePanel3.Visible = True
                    Dim parqueosTotales As Integer = parqueoNegocios.obtenerIDMayorParqueo() + 1
                    lblNumParqueo.Text = parqueosTotales
                ElseIf (idPagina.Equals("0")) Then
                    updatePanel2.Visible = True
                    updatePanel3.Visible = False
                    intIDparqueo = datosSolicitud(1)
                    Me.gintParqueoIdentificador = Long.Parse(intIDparqueo)
                    lblNumParqueo.Text = Me.gintParqueoIdentificador
                    If (datosSolicitud(2).Equals("True")) Then
                        strEstadoP = "Habilitado"
                        DwnLstEstado.Items.Remove("Habilitado")
                    Else
                        strEstadoP = "Deshabilitado"
                        DwnLstEstado.Items.Remove("Deshabilitado")
                    End If
                    strtipoParqueo = datosSolicitud(3)
                    DwnLstEstado.SelectedItem.Text = strEstadoP
                    DwnLstTipos.Items.Remove(strtipoParqueo)
                    DwnLstTipos.SelectedItem.Text = strtipoParqueo
                End If
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
    End Sub
    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        btnAccion = 1

        If (DwnLstTipos.SelectedItem.Text.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.Text.Equals("Seleccione una opción")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR','Debe completar todos los campos','error')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        btnAccion = 2

        If (DwnLstTipos.SelectedItem.ToString.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.ToString.Equals("Seleccione una opción")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR','Debe completar todos los campos','error')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        btnAccion = 3

        If (DwnLstTipos.SelectedItem.ToString.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.ToString.Equals("Seleccione una opción")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR','Debe completar todos los campos','error')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)

        Dim titulo As String = "Correcto"
        Dim mensaje As String = ""
        Dim tipo As String = "success"
        Dim Blnestado As Byte = 0

        If (DwnLstEstado.Text.Equals("Habilitado")) Then
            Blnestado = 1
        End If

        If (btnAccion = 1) Then
            parqueoNegocios.insertarParqueo(New Parqueo(0, Blnestado, DwnLstTipos.Text))
            mensaje = "Se ha creado el parqueo exitosamente"
        ElseIf (btnAccion = 2) Then
            parqueoNegocios.actualizarParqueo(New Parqueo(Me.gintParqueoIdentificador, Blnestado, DwnLstTipos.SelectedItem.Text))
            mensaje = "Se ha actualizado el parqueo exitosamente"
        Else
            parqueoNegocios.eliminarParqueo(New Parqueo(Me.gintParqueoIdentificador, 0, ""))
            mensaje = "Se ha eliminado el parqueo exitosamente"
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class