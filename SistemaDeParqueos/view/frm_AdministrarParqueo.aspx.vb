Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class administrarParqueo
    Inherits System.Web.UI.Page

    Public gintParqueoIdentificador As Long
    Public gstrParqueoSelecion As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(connectionString)
        If IsPostBack Then
            Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
            Me.gstrParqueoSelecion = DwnEspacio.SelectedItem.ToString()
            For Each parqueoActual As Parqueo In parqueo
                If Me.gstrParqueoSelecion.Equals("Numero Parqueo: " + parqueoActual.GintIdentificadorSG.ToString()) Then
                    Me.gintParqueoIdentificador = parqueoActual.GintIdentificadorSG
                End If
            Next
        Else
            DwnEspacio.Items.Clear()
            DwnEspacio.Items.Add("Sin Seleccionar")
            Dim parqueo As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueo()
            For Each item As Parqueo In parqueo
                DwnEspacio.Items.Add("Numero Parqueo: " + item.GintIdentificadorSG.ToString)
            Next
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
            Me.gstrParqueoSelecion = DwnEspacio.SelectedItem.ToString()
            For Each parqueoActual As Parqueo In parqueo
                If Me.gstrParqueoSelecion.Equals("Numero Parqueo: " + parqueoActual.GintIdentificadorSG.ToString()) Then
                    Me.gintParqueoIdentificador = parqueoActual.GintIdentificadorSG
                End If
            Next
        End If
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        If (DwnLstEstado.Text.Equals("Habilitado")) Then
            Blnestado = 1
        End If
        parqueoNegocios.insertarParqueo(New Parqueo(0, Blnestado, DwnLstTipos.Text))
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        If (DwnLstEstado.Text.Equals("Habilitado")) Then
            Blnestado = 1
        End If
        parqueoNegocios.actualizarParqueo(New Parqueo(Me.gintParqueoIdentificador, Blnestado, DwnLstTipos.Text))
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        parqueoNegocios.eliminarParqueo(New Parqueo(Me.gintParqueoIdentificador, 0, ""))
    End Sub
End Class