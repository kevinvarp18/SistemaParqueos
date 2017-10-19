Public Class frm_BrindarAcceso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DwnLstDepartamento.Items.Add("Seleccione una opción")
        DwnLstDepartamento.Items.Add("Externo")
        DwnLstDepartamento.Items.Add("Interno")
    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click

    End Sub
End Class