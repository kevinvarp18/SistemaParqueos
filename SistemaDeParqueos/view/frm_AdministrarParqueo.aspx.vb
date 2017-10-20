Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class administrarParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        If (DwnLstEstado.Text.Equals("Habilitado")) Then
            Blnestado = 1
        End If
        parqueoNegocios.insertarParqueo(New Parqueo(0, Blnestado, DwnLstTipos.Text))
        tbEspacio.Text = "Registro"
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        If (DwnLstEstado.Text.Equals("Habilitado")) Then
            Blnestado = 1
        End If
        parqueoNegocios.actualizarParqueo(New Parqueo(tbEspacio.Text, Blnestado, DwnLstTipos.Text))
        tbEspacio.Text = "Actualizado"
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Blnestado As Byte = 0
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        parqueoNegocios.eliminarParqueo(New Parqueo(tbEspacio.Text, 0, ""))
        tbEspacio.Text = "Eliminado"
    End Sub
End Class