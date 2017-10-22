Public Class frm_BrindarAcceso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "o") Then
            DwnLstDepartamento.Items.Add("Seleccione una opción")
            DwnLstDepartamento.Items.Add("Externo")
            DwnLstDepartamento.Items.Add("Interno")
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If

    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click

    End Sub
End Class