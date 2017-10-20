Imports System.Data.SqlClient
Imports Entidad
Public Class SP_Solicitud_Datos
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

    Public Function insertarSolicitud(solicitud As Solicitud) As Solicitud

        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_RegistrarSolicitud"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        'correo se agarra de sesion
        cmdInsert.Parameters.Add(New SqlParameter("@correo", "prueba"))
        cmdInsert.Parameters.Add(New SqlParameter("@hora_i", solicitud.GstrHoraISG))
        cmdInsert.Parameters.Add(New SqlParameter("@hora_f", solicitud.GstrHoraFSG))
        cmdInsert.Parameters.Add(New SqlParameter("@placa", solicitud.GstrPlacaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@modelo", solicitud.GstrModelaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@marca", solicitud.GstrMarcaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@fecha_i", solicitud.GstrFechaISG))
        cmdInsert.Parameters.Add(New SqlParameter("@fecha_f", solicitud.GstrHoraFSG))

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()
        cmdInsert.Connection.Close()

        Return solicitud
    End Function

    Public Function obtenerSolicitud() As LinkedList(Of Solicitud)
        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlSelect As [String] = "PA_VerSolicitud;"

        Dim sqlDataAdapterClient As New SqlDataAdapter()
        sqlDataAdapterClient.SelectCommand = New SqlCommand()
        sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect
        sqlDataAdapterClient.SelectCommand.Connection = connection
        Dim dataSetAttendant As New DataSet()
        sqlDataAdapterClient.Fill(dataSetAttendant, "TSP_Solicitud")
        sqlDataAdapterClient.SelectCommand.Connection.Close()
        Dim dataRowCollection As DataRowCollection = dataSetAttendant.Tables("TSP_Solicitud").Rows
        Dim parqueo As New LinkedList(Of Solicitud)()

        For Each currentRow As DataRow In dataRowCollection
            Dim solicitudActual As New Solicitud()
            solicitudActual.GintIdSolicutudSG = Integer.Parse(currentRow("TN_Idsolicitud_TSP_Solicitud").ToString())
            solicitudActual.GintIdVisitanteSG = Integer.Parse(currentRow("TN_Idvisitante_TSP_Solicitud").ToString())
            solicitudActual.GintIdParqueoSG = Integer.Parse(currentRow("TN_Idparqueo_TSP_Solicitud").ToString())
            solicitudActual.GstrHoraISG = currentRow("TF_Horai_TSP_Solicitud").ToString()
            solicitudActual.GstrHoraFSG = currentRow("TF_Horaf_TSP_Solicitud").ToString()
            solicitudActual.GstrPlacaSG = currentRow("TC_Placa_TSP_Solicitud").ToString()
            solicitudActual.GstrModelaSG = currentRow("TC_Modelo_TSP_Solicitud").ToString()
            solicitudActual.GstrMarcaSG = currentRow("TC_Marca_TSP_Solicitud").ToString()
            solicitudActual.GstrFechaISG = currentRow("TF_Fechai_TSP_Solicitud").ToString()
            solicitudActual.GstrFechaFSG = currentRow("TF_Fechaf_TSP_Solicitud").ToString()
            parqueo.AddLast(solicitudActual)

        Next
        Return parqueo
    End Function
End Class
