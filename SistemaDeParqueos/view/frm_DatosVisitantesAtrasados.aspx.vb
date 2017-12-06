Public Class frm_DatosVisitantesAtrasados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idPagina As String = Request.QueryString("id")
        Dim datosSolicitud As String() = idPagina.Split(New String() {";"}, StringSplitOptions.None)
        lblNombreV.Text = "Nombre: " & datosSolicitud(0)
        lblApellidoV.Text = "Apellido: " & datosSolicitud(1)
        lblCorreoV.Text = "Correo: " & datosSolicitud(2)
        lblTelefonoV.Text = "Teléfono: " & datosSolicitud(3)
        lblUbicacionV.Text = "Ubicación: " & datosSolicitud(4)
    End Sub

End Class