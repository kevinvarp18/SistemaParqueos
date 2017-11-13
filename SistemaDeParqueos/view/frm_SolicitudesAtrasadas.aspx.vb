Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class frm_SolicitudesAtrasadas
    Inherits System.Web.UI.Page

    Dim strConnectionString As String
    Dim parqueoNegocios As SP_Parqueo_Negocios
    Dim solicitudNegocios As SP_Solicitud_Parqueo_Negocios
    Dim usuarioNegocios As SP_Usuario_Negocios
    Shared marca, placa, horaI, horaF, fechaI, fechaF, idParqueo, correo, accion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim permitido As Boolean = False

        For Each variableSesion As String In Session.Keys
            If (String.Equals(variableSesion, "frm_SolicitudesAtrasadas")) Then
                permitido = True
            End If
        Next

        If (permitido) Then
            Me.strConnectionString = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
            Me.parqueoNegocios = New SP_Parqueo_Negocios(Me.strConnectionString)
            Me.solicitudNegocios = New SP_Solicitud_Parqueo_Negocios(Me.strConnectionString)
            Me.usuarioNegocios = New SP_Usuario_Negocios(Me.strConnectionString)
            'llenarTablaVisitantes()
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Public Sub llenarTablaSolicitudes()

    End Sub

End Class