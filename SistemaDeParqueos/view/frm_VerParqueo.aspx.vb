Public Class VerParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

End Class