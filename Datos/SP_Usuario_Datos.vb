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
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  21-Octubre-2017
    '******************************************************************
    'Declaracion de Varaiables.
    Public gstrconnString As String

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.gstrconnString = gstrconnString
    End Sub

    Public Function insertarOficial(oficial As Oficial) As Boolean
        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_InsertaUsuarios"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@Tipo", oficial.GstrTipoIdSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Identificacion", oficial.GstrIdSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Nombre", oficial.GstrNombreSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Apellidos", oficial.GstrApellidoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Correo", oficial.GstrCorreoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Contrasenia", oficial.GstrContrasennaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Rol", oficial.GstrTipoUsuarioSG))

        cmdInsert.Connection.Open()
        cmdInsert.ExecuteNonQuery()
        cmdInsert.Connection.Close()

        Return True
    End Function

    Public Function insertarAdministrador(administrador As Administrador) As Boolean
        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_InsertaUsuarios"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        Dim result As Integer
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@Tipo", administrador.GstrTipoIdSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Identificacion", administrador.GstrIdSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Nombre", administrador.GstrNombreSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Apellidos", administrador.GstrApellidoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Correo", administrador.GstrCorreoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Contrasenia", administrador.GstrContrasennaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@Rol", administrador.GstrTipoUsuarioSG))

        cmdInsert.Connection.Open()
        result = cmdInsert.ExecuteScalar()
        cmdInsert.Connection.Close()

        Return result
    End Function

    Public Function insertarVisitante(visitante As Visitante) As Boolean
        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlStoredProcedure As [String] = "PA_RegistrarVisitante"
        Dim cmdInsert As New SqlCommand(sqlStoredProcedure, connection)
        Dim result As Integer
        cmdInsert.CommandType = System.Data.CommandType.StoredProcedure

        cmdInsert.Parameters.Add(New SqlParameter("@nombre", visitante.GstrNombreSG))
        cmdInsert.Parameters.Add(New SqlParameter("@apellidos", visitante.GstrApellidoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@correo", visitante.GstrCorreoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@contrasena", visitante.GstrContrasennaSG))
        cmdInsert.Parameters.Add(New SqlParameter("@tel", visitante.gintTelefonoSG))
        cmdInsert.Parameters.Add(New SqlParameter("@ubicacion", visitante.GstrUbicacionSG))
        cmdInsert.Parameters.Add(New SqlParameter("@tipoVisitante", visitante.GstrTipoVisitanteSG))
        cmdInsert.Parameters.Add(New SqlParameter("@tipoId", visitante.GstrTipoIdSG))
        cmdInsert.Parameters.Add(New SqlParameter("@id", visitante.gstrId))
        cmdInsert.Parameters.Add(New SqlParameter("@procedencia", visitante.gstrProcedencia))
        cmdInsert.Connection.Open()
        result = cmdInsert.ExecuteScalar()
        cmdInsert.Connection.Close()

        Return True
    End Function

    Public Function obtenerUsuarios(correo As String, contrasenna As String) As LinkedList(Of Usuario)
        Dim connection As New SqlConnection(Me.gstrconnString)
        Dim sqlSelect As String = "PA_ObtenerUsuarios"
        Dim sqlDataAdapterClient As New SqlDataAdapter()
        sqlDataAdapterClient.SelectCommand = New SqlCommand()
        sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect
        sqlDataAdapterClient.SelectCommand.Connection = connection
        sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure
        sqlDataAdapterClient.SelectCommand.Parameters.Add(New SqlParameter("@correo", correo))
        sqlDataAdapterClient.SelectCommand.Parameters.Add(New SqlParameter("@contrasena", contrasenna))
        Dim dataSetEstudiantes As New DataSet()
        sqlDataAdapterClient.Fill(dataSetEstudiantes, "SP.TSP_Usuario")
        sqlDataAdapterClient.SelectCommand.Connection.Close()
        Dim dataRowCollection As DataRowCollection = dataSetEstudiantes.Tables("SP.TSP_Usuario").Rows
        Dim usuarios As New LinkedList(Of Usuario)()

        For Each currentRow As DataRow In dataRowCollection
            Dim usuarioActual As New Usuario()
            usuarioActual.gstrNombre = currentRow("TC_Nombre_TSP_Usuario").ToString()
            usuarioActual.gstrApellido = currentRow("TC_Apellido_TSP_Usuario").ToString()
            usuarioActual.gstrCorreo = currentRow("TC_Correo_TSP_Usuario").ToString()
            usuarioActual.gstrContrasenna = currentRow("TC_Contrasenna_TSP_Usuario").ToString()
            usuarioActual.gstrTipoUsuario = currentRow("TC_Tipo_TSP_Usuario").ToString()
            usuarios.AddLast(usuarioActual)
        Next
        Return usuarios
    End Function

End Class