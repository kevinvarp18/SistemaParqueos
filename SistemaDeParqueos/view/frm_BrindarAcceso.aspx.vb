Public Class frm_BrindarAcceso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "o") Then
            ScriptManager.RegisterClientScriptInclude(Me, Me.GetType(), "frm_BrindarAcceso", ResolveUrl("~") + "public/js/" + "script.js")

            If Not IsPostBack Then
                DwnLstDepartamento.Items.Clear()
                DwnLstDepartamento.Items.Add("Seleccione una opción")
                DwnLstDepartamento.Items.Add("Externo")
                DwnLstDepartamento.Items.Add("Interno")
            End If
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If

    End Sub

    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        Dim titulo, mensaje, tipo As String
        Dim tbSolicitante_ As String = Trim(tbSolicitante.Text)
        Dim tbPlaca_ As String = Trim(tbPlaca.Text)
        Dim tbMarca_ As String = Trim(tbMarca.Text)
        Dim tbModelo_ As String = Trim(tbModelo.Text)
        Dim tbInstitucion_ As String = Trim(tbInstitucion.Text)


        If (tbSolicitante_.Equals("") Or tbPlaca_.Equals("") Or tbMarca_.Equals("") Or tbModelo_.Equals("") Or tbInstitucion_.Equals("")) Then
            titulo = "ERROR"
            mensaje = "Debe completar todos los campos"
            tipo = "error"
        Else
            If tbFechaE.Text <> "" AndAlso tbHoraE.Text <> "" Then
                'Do stuff

                titulo = "Correcto"
                mensaje = "Acceso brindado exitosamente"
                tipo = "success"
            Else
                titulo = "ERROR"
                mensaje = "Debe completar todos los campos"
                tipo = "error"
            End If
        End If

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "ScriptManager2", "muestraMensaje(""" + titulo + """,""" + mensaje + """,""" + tipo + """);", True)
    End Sub
End Class