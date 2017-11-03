Imports System.Web.Configuration
Imports Entidad
Imports Negocios

Public Class VerParqueo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.Equals(Session("Usuario"), "a") Then
        Else
            Response.BufferOutput = True
            Response.Redirect("http://localhost:52086/view/frm_index.aspx")
        End If
    End Sub

    Protected Sub btnBuscarP_Click(sender As Object, e As EventArgs) Handles btnBuscarP.Click
        Dim strconnectionString As String = WebConfigurationManager.ConnectionStrings("DBOIJ").ToString()
        Dim parqueoNegocios As New SP_Parqueo_Negocios(strconnectionString)
        Dim sn As New SP_Solicitud_Parqueo_Negocios(strconnectionString)
        If tbFechaI.Text <> "" AndAlso tbHoraI.Text <> "" AndAlso tbHoraF.Text <> "" Then

            Dim parqueosOcupados As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueoOcupado(tbFechaI.Text, tbHoraI.Text, tbHoraF.Text)
            Dim parqueosTotales As LinkedList(Of Parqueo) = parqueoNegocios.obtenerParqueoHabilitado()
            Dim cantidadTiposParqueo As LinkedList(Of String) = parqueoNegocios.cantidadTiposParqueo()

            Dim rowCnt As Integer

            rowCnt = 1

            Dim tERow As New TableRow()
            For Each tipos As String In cantidadTiposParqueo
                Dim nom As New TableHeaderCell()
                nom.Text = tipos
                tERow.Cells.Add(nom)
                table.Rows.Add(tERow)
                Dim tRow As New TableRow()
                For Each parqueosAct As Parqueo In parqueosTotales
                    For rowCtr = 1 To rowCnt
                        Dim tCell As New TableCell()
                        If parqueosAct.GstrTipoSG.Equals(nom.Text) Then
                            Dim hyperLink As New HyperLink()
                            Dim ocu = False
                            For Each parqueosOcu As Parqueo In parqueosOcupados
                                If parqueosAct.GintIdentificadorSG = parqueosOcu.GintIdentificadorSG Then
                                    ocu = True
                                End If
                            Next
                            If ocu = True Then
                                hyperLink.Text = "Espacio " + parqueosAct.GintIdentificadorSG.ToString()
                                hyperLink.NavigateUrl = ""
                                hyperLink.Style("color") = "#ff0000"
                                tCell.Controls.Add(hyperLink)
                            Else
                                hyperLink.Text = "Espacio " + parqueosAct.GintIdentificadorSG.ToString()
                                hyperLink.NavigateUrl = ""
                                hyperLink.Style("color") = "#00fe00"
                                tCell.Controls.Add(hyperLink)
                            End If

                        End If
                        tRow.Cells.Add(tCell)

                    Next
                    table.Rows.Add(tRow)
                Next
            Next

        End If

    End Sub

End Class