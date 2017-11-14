Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_ManejarPermisos
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim usuarioNegocios As SP_Usuario_Negocios

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
            Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.usuarioNegocios = New SP_Usuario_Negocios(Me.strConnectionString)
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_ManejarPermisos", ResolveUrl("~") + "public/js/" + "script.js")



            If Not IsPostBack Then
                llenarTabla()

                DwnLstPermisos.Items.Add("Seleccione una opción")

                For Each rol As PermisoYRoles In Me.usuarioNegocios.ObtenerRolesYPermisos()
                    DwnLstPermisos.Items.Add(rol.GstrPermiso.ToString)
                Next

                DwnLstRoles.Items.Add("Seleccione una opción")
                DwnLstRoles.Items.Add("Administrador")
                DwnLstRoles.Items.Add("Oficial de Seguridad")
                DwnLstRoles.Items.Add("Visitante")

            End If


        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Public Sub llenarTabla()
        Dim rowCnt As Integer
        Dim rowCtr As Integer
        Dim contador As Integer
        Dim roles As LinkedList(Of PermisoYRoles) = usuarioNegocios.ObtenerRolesYPermisos()
        rowCnt = 1
        contador = 1

        For Each rolActual As PermisoYRoles In roles
            For rowCtr = 1 To rowCnt
                Dim filaTabla As New TableRow()
                Dim columnaPermiso As New TableCell()
                Dim columnaRol As New TableCell()

                Dim rol As String = ""

                If String.Equals(rolActual.GstrRol, "a") Then
                    rol = "Administrador"
                ElseIf String.Equals(rolActual.GstrRol, "o") Then
                    rol = "Oficial de Seguridad"
                ElseIf String.Equals(rolActual.GstrRol, "v") Then
                    rol = "Visitante"
                End If

                columnaPermiso.Text = rolActual.GstrPermiso
                columnaRol.Text = rol

                filaTabla.Cells.Add(columnaPermiso)
                filaTabla.Cells.Add(columnaRol)
                tabla.Rows.Add(filaTabla)

                contador = contador + 1
            Next
        Next
    End Sub


    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim titulo, mensaje, tipo As String

        If (DwnLstPermisos.SelectedItem.ToString().Equals("Seleccione una opción") Or DwnLstRoles.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"
        Else

            Dim idPermiso As Integer = 0
            Dim rol As String = ""

            If (DwnLstPermisos.SelectedItem.ToString().Equals("frm_AdministrarParqueo")) Then
                idPermiso = 4
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_AdministrarSolicitudes")) Then
                idPermiso = 5
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_BrindarParqueo")) Then
                idPermiso = 6
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_ListaVisitantes")) Then
                idPermiso = 7
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_RegistrarUsuario")) Then
                idPermiso = 8
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_Reporte")) Then
                idPermiso = 11
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_SolicitarParqueo")) Then
                idPermiso = 12
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_VerParqueo")) Then
                idPermiso = 13
            End If

            If (DwnLstRoles.SelectedItem.ToString().Equals("Administrador")) Then
                rol = "a"
            ElseIf (DwnLstRoles.SelectedItem.ToString().Equals("Oficial de Seguridad")) Then
                rol = "o"
            ElseIf (DwnLstRoles.SelectedItem.ToString().Equals("Visitante")) Then
                rol = "v"
            End If


            If Me.usuarioNegocios.insertarPermisoRol(idPermiso, rol) Then
                titulo = "Correcto"
                mensaje = "Se ha insertado exitosamente"
                tipo = "success"
            Else
                titulo = "Advertencia"
                mensaje = "La relación entre el Permiso y el Rol ya existe"
                tipo = "warning"
            End If


        End If

            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim titulo, mensaje, tipo As String

        If (DwnLstPermisos.SelectedItem.ToString().Equals("Seleccione una opción") Or DwnLstRoles.SelectedItem.ToString().Equals("Seleccione una opción")) Then
            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"
        Else

            Dim idPermiso As Integer = 0
            Dim rol As String = ""

            If (DwnLstPermisos.SelectedItem.ToString().Equals("frm_AdministrarParqueo")) Then
                idPermiso = 4
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_AdministrarSolicitudes")) Then
                idPermiso = 5
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_BrindarParqueo")) Then
                idPermiso = 6
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_ListaVisitantes")) Then
                idPermiso = 7
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_RegistrarUsuario")) Then
                idPermiso = 8
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_Reporte")) Then
                idPermiso = 11
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_SolicitarParqueo")) Then
                idPermiso = 12
            ElseIf (DwnLstPermisos.SelectedItem.ToString().Equals("frm_VerParqueo")) Then
                idPermiso = 13
            End If

            If (DwnLstRoles.SelectedItem.ToString().Equals("Administrador")) Then
                rol = "a"
            ElseIf (DwnLstRoles.SelectedItem.ToString().Equals("Oficial de Seguridad")) Then
                rol = "o"
            ElseIf (DwnLstRoles.SelectedItem.ToString().Equals("Visitante")) Then
                rol = "v"
            End If


            If Me.usuarioNegocios.eliminarPermisoRol(idPermiso, rol) Then
                titulo = "Correcto"
                mensaje = "Se ha eliminado exitosamente"
                tipo = "success"
            Else
                titulo = "Error"
                mensaje = "No se ha podido eliminar la relación"
                tipo = "error"
            End If

        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub

End Class