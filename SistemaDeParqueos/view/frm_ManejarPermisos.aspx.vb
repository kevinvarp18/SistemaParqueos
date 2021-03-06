﻿Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_ManejarPermisos
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios
    Public Shared btnAccion As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Usuario").Equals("a")) Then
            Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(Me.strConnectionString)
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_ManejarPermisos", ResolveUrl("~") + "public/js/" + "script.js")

            If Not IsPostBack Then
                DwnLstPermisos.Items.Add("Seleccione una opción")
                For Each permiso As Permiso In Me.usuarioNegocios.ObtenerPermisos()
                    DwnLstPermisos.Items.Add(permiso.GstrTipo1.ToString)
                Next

                DwnLstRoles.Items.Add("Seleccione una opción")
                DwnLstRoles.Items.Add("Administrador")
                DwnLstRoles.Items.Add("Oficial de Seguridad")
                DwnLstRoles.Items.Add("Visitante")
            End If
        Else
            Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
            Response.BufferOutput = True
            Response.Redirect(url & Convert.ToString("/view/frm_index.aspx"))
        End If
        llenarTabla()
    End Sub
    Public Sub llenarTabla()
        Dim rowCnt As Integer
        Dim rowCtr As Integer
        Dim contador As Integer
        Dim roles As LinkedList(Of RolYPermiso) = usuarioNegocios.ObtenerRolesYPermisos()
        rowCnt = 1
        contador = 1

        For Each rolActual As RolYPermiso In roles
            For rowCtr = 1 To rowCnt
                Dim filaTabla As New TableRow()
                Dim celdaPermiso As New TableCell()
                Dim celdaRol As New TableCell()

                Dim rol As String = ""

                If String.Equals(rolActual.GstrRol1, "a") Then
                    rol = "Administrador"
                ElseIf String.Equals(rolActual.GstrRol1, "o") Then
                    rol = "Oficial de Seguridad"
                ElseIf String.Equals(rolActual.GstrRol1, "v") Then
                    rol = "Visitante"
                End If

                celdaPermiso.Text = rolActual.GstrPermiso1
                celdaRol.Text = rol

                filaTabla.Cells.Add(celdaPermiso)
                filaTabla.Cells.Add(celdaRol)
                tabla.Rows.Add(filaTabla)

                contador = contador + 1
            Next
        Next
    End Sub
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (DwnLstPermisos.SelectedItem.ToString().Equals("Seleccione una opción") Or DwnLstRoles.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR', 'Debe completar todos los campos', 'error');", True)
        Else
            btnAccion = 1
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim titulo As String = "ERROR"
        Dim mensaje As String
        Dim tipo As String = "error"

        If (DwnLstPermisos.SelectedItem.ToString().Equals("Seleccione una opción") Or DwnLstRoles.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje('ERROR', 'Debe completar todos los campos', 'error');", True)
        Else
            btnAccion = 0
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('show');", True)
        End If
    End Sub
    Public Function establecerPermiso(permiso As String) As Integer
        If (permiso.Equals("frm_AdministrarParqueo")) Then
            Return 4
        ElseIf (permiso.Equals("frm_AdministrarSolicitudes")) Then
            Return 5
        ElseIf (permiso.Equals("frm_BrindarParqueo")) Then
            Return 6
        ElseIf (permiso.Equals("frm_ListaVisitantes")) Then
            Return 7
        ElseIf (permiso.Equals("frm_RegistrarUsuario")) Then
            Return 8
        ElseIf (permiso.Equals("frm_Reporte")) Then
            Return 11
        ElseIf (permiso.Equals("frm_SolicitarParqueo")) Then
            Return 12
        ElseIf (permiso.Equals("frm_VerParqueo")) Then
            Return 13
        ElseIf (permiso.Equals("frm_SolicitudesAtrasadas")) Then
            Return 14
        End If

        Return 0
    End Function
    Public Function establecerRol(rol As String) As String
        If (rol.Equals("Administrador")) Then
            Return "a"
        ElseIf (rol.Equals("Oficial de Seguridad")) Then
            Return "o"
        ElseIf (rol.Equals("Visitante")) Then
            Return "v"
        End If

        Return ""
    End Function

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
    End Sub
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim mensaje As String
        Dim titulo As String = "ERROR"
        Dim tipo As String = "error"

        If (btnAccion = 1) Then
            Dim idPermiso As Integer = 0
            Dim rol As String = ""

            idPermiso = Me.establecerPermiso(DwnLstPermisos.SelectedItem.ToString())
            rol = establecerRol(DwnLstRoles.SelectedItem.ToString())

            If Me.usuarioNegocios.insertarPermisoRol(idPermiso, rol) Then
                titulo = "CORRECTO"
                mensaje = "El usuario " + DwnLstRoles.SelectedItem.ToString() + " ahora tiene permitido acceder a " + DwnLstPermisos.SelectedItem.ToString()
                tipo = "success"
            Else
                mensaje = "La relación entre el permiso y el rol ya existe"
            End If
        ElseIf (btnAccion = 0) Then
            Dim idPermiso As Integer = 0
            Dim rol As String = ""
            idPermiso = Me.establecerPermiso(DwnLstPermisos.SelectedItem.ToString())
            rol = establecerRol(DwnLstRoles.SelectedItem.ToString())

            If Me.usuarioNegocios.eliminarPermisoRol(idPermiso, rol) Then
                titulo = "CORRECTO"
                mensaje = "El permiso se ha eliminado exitosamente para el usuario " + DwnLstRoles.SelectedItem.ToString()
                tipo = "success"
            Else
                mensaje = "No se ha podido eliminar la relación"
            End If
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ScriptManager2", "$('#modalConfirmacion').modal('hide');", True)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class