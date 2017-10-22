Imports System.Data.SqlClient
Imports Entidad

Public Class SP_Usuario_Datos
    '**********************************************************************
    'NOMBRE DEL SISTEMA:  SistemaDeParqueos.
    'NOMBRE DEL PAQUETE:  SistemaDeParqueos.Acceso_a_Datos.
    'DESCRIPCIÓN:
    ' Esta clase maneja las coneciones de las entidades del sistema.

    'NOMBRE DEL DESARROLLADOR:                       Dylan Zamora
    '
    'FECHA DE CREACIÓN                               05-Octubre-2017
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  05-Octubre-2017
    '******************************************************************
    'Declaracion de Varaiables.
    Public gstrconnString As String

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.gstrconnString = gstrconnString
    End Sub

    Public Function insertarOficial(tipoId As Tipoid, oficial As Oficial) As Boolean


        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_InsertaUsuarios"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@Tipo", tipoId.GstrTipoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Cedula", tipoId.GstrIdentificacionSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Nombre", oficial.NombreOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Apellidos", oficial.ApellidosOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Correo", oficial.CorreoOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Contrasenia", oficial.ContraseniaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Rol", oficial.RolOficialSG))

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()
        cmdInsert.Connection.Close()

        Return True
    End Function

End Class