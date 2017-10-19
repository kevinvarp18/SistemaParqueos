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

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub
End Class