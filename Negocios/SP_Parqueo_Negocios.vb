Imports Datos
Imports Entidad

Public Class SP_Parqueo_Negocios
    '**********************************************************************
    'NOMBRE DEL SISTEMA:  SistemaDeParqueos.
    'NOMBRE DEL PAQUETE:  SistemaDeParqueos.Servicios.
    'DESCRIPCIÓN:
    ' Esta clase maneja la logica de negocios de las entidades del sistema.

    'NOMBRE DEL DESARROLLADOR:                       Dylan Zamora
    '
    'FECHA DE CREACIÓN                               05-Octubre-2017
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  19-Octubre-2017
    '******************************************************************
    'Declaracion de Varaiables.
    Public parqueos_Datos As SP_Parqueo_Datos

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.parqueos_Datos = New SP_Parqueo_Datos(gstrconnString)
    End Sub
    Public Function insertarParqueo(parqueo As Parqueo) As Parqueo
        Return Me.parqueos_Datos.insertarParqueo(parqueo)
    End Function

    Public Function actualizarParqueo(parqueo As Parqueo) As Parqueo
        Return Me.parqueos_Datos.actualizarParqueo(parqueo)
    End Function

    Public Function eliminarParqueo(parqueo As Parqueo) As Parqueo
        Return Me.parqueos_Datos.eliminarParqueo(parqueo)
    End Function

    Public Function obtenerParqueo() As LinkedList(Of Parqueo)
        Return Me.parqueos_Datos.obtenerParqueo()
    End Function

End Class
