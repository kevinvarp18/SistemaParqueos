Public Class registrarVisitante
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DwnLstDepartamento.Items.Add("Seleccione una opción")
        DwnLstDepartamento.Items.Add("Externo")
        DwnLstDepartamento.Items.Add("Interno")
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

    End Sub

    Protected Sub DwnLstDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DwnLstDepartamento.SelectedIndexChanged

    End Sub
End Class