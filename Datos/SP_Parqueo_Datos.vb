Imports System.Data.SqlClient
Imports Entidad

Public Class SP_Parqueo_Datos
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
    Public Function insertarParqueo(parqueo As Parqueo) As Parqueo

        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_InsertaParqueo"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@Estado", parqueo.GintDisponibleSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Tipo", parqueo.GstrTipoSG))

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()
        cmdInsert.Connection.Close()

        Return parqueo
    End Function

End Class
