Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Usuario") Is Nothing) Then
            Session("Usuario") = "N"
        End If 'Si la session es nula, lo inicia en N.
    End Sub

    Protected Sub cerrarSesion(sender As Object, e As EventArgs)
        Session("Usuario") = "N"
        Response.BufferOutput = True
        Response.Redirect("http://localhost:52086/view/frm_index.aspx")
    End Sub
    'Fin del método mostrarLogin.

End Class