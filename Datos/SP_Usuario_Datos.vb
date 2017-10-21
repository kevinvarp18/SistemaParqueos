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

    Public Function insertarOficial(oficial As Oficial) As Boolean

        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_InsertaOficial"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@Cedula", oficial.CedulaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Nombre", oficial.CedulaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Apellidos", oficial.CedulaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Correo", oficial.CedulaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Contrasenia", oficial.CedulaOficialSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Rol", oficial.CedulaOficialSG))

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()
        cmdInsert.Connection.Close()

        Return True
    End Function

End Class