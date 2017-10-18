Imports Datos

Public Class SP_Solicitud_Parqueo_Negocios
    '**********************************************************************
    'NOMBRE DEL SISTEMA:  SistemaDeParqueos.
    'NOMBRE DEL PAQUETE:  SistemaDeParqueos.Servicios.
    'DESCRIPCIÓN:
    ' Esta clase maneja la logica de negocios de las entidades del sistema.

    'NOMBRE DEL DESARROLLADOR:                       Dylan Zamora
    '
    'FECHA DE CREACIÓN                               05-Octubre-2017
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  05-Octubre-2017
    '******************************************************************
    'Declaracion de Varaiables.
    Public parqueo_Acceso_a_Datos As SP_Solicitud_Datos

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.parqueo_Acceso_a_Datos = New SP_Solicitud_Datos(gstrconnString)
    End Sub
End Class
