﻿Imports Datos
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
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  05-Octubre-2017
    '******************************************************************
    'Declaracion de Varaiables.
    Public parqueo_Acceso_a_Datos As SP_Parqueo_Datos

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.parqueo_Acceso_a_Datos = New SP_Parqueo_Datos(gstrconnString)
    End Sub
    Public Function insertarActor(parqueo As Parqueo) As Parqueo
        Return Me.parqueo_Acceso_a_Datos.insertarParqueo(parqueo)
    End Function

End Class
