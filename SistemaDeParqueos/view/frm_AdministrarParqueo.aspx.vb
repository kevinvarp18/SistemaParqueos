﻿Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class administrarParqueo
    Inherits System.Web.UI.Page

    Public gintParqueoIdentificador As Long
    Public gstrParqueoSelecion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
            Dim connectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_AdministrarParqueo", ResolveUrl("~") + "public/js/" + "script.js")

            Dim parqueoNegocios As New SP_Parqueo_Negocios(connectionString)
            If IsPostBack Then
                Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
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
                Dim idPagina As String
                Dim intIDparqueo As String
                Dim strEstadoP As String
                Dim strtipoParqueo As String
                idPagina = Request.QueryString("id")
                Dim datosSolicitud As String() = idPagina.Split(New String() {";"}, StringSplitOptions.None)
                idPagina = datosSolicitud(0)
                If (idPagina.Equals("1")) Then
                    Page.ClientScript.RegisterStartupScript(
                    Page.ClientScript.GetType(), "onLoad", "RegistrarParqueo();", True)
                ElseIf (idPagina.Equals("0")) Then
                    Page.ClientScript.RegisterStartupScript(
                    Page.ClientScript.GetType(), "onLoad", "ActualizarEliminarParqueo();", True)
                    intIDparqueo = datosSolicitud(1)
                    Me.gintParqueoIdentificador = Long.Parse(intIDparqueo)
                    strEstadoP = datosSolicitud(2)
                    If strEstadoP.Equals("True") Then
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
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim titulo, mensaje, tipo As String

        If (DwnLstTipos.SelectedItem.ToString.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.ToString.Equals("Seleccione una opción")) Then

            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"

        Else
            Dim Blnestado As Byte = 0
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
            If (DwnLstEstado.Text.Equals("Habilitado")) Then
                Blnestado = 1
            End If
            parqueoNegocios.insertarParqueo(New Parqueo(0, Blnestado, DwnLstTipos.Text))

            titulo = "Correcto"
            mensaje = "Se ha creado el parqueo exitosamente"
            tipo = "success"
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim titulo, mensaje, tipo As String

        If (DwnLstTipos.SelectedItem.ToString.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.ToString.Equals("Seleccione una opción")) Then

            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"

        Else

            Dim Blnestado As Byte = 0
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
            If (DwnLstEstado.Text.Equals("Habilitado")) Then
                Blnestado = 1
            End If
            parqueoNegocios.actualizarParqueo(New Parqueo(Me.gintParqueoIdentificador, Blnestado, DwnLstTipos.SelectedItem.Text))

            titulo = "Correcto"
            mensaje = "Se ha actualizado el parqueo exitosamente"
            tipo = "success"
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim titulo, mensaje, tipo As String

        If (DwnLstTipos.SelectedItem.ToString.Equals("Seleccione una opción") Or
            DwnLstEstado.SelectedItem.ToString.Equals("Seleccione una opción")) Then

            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"

        Else

            Dim Blnestado As Byte = 0
            Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
            parqueoNegocios.eliminarParqueo(New Parqueo(Me.gintParqueoIdentificador, 0, ""))

            titulo = "Correcto"
            mensaje = "Se ha eliminado el parqueo exitosamente"
            tipo = "success"
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class