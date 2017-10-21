Imports Datos
Imports Entidad

Public Class SP_Usuario_Negocios
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
    Public usuario_Acceso_a_Datos As SP_Usuario_Datos

    'Declaracion de constrcutor.
    Public Sub New(gstrconnString As String)
        Me.usuario_Acceso_a_Datos = New SP_Usuario_Datos(gstrconnString)
    End Sub

    Public Function insertarOficial(oficial As Oficial) As Boolean
        Return Me.usuario_Acceso_a_Datos.insertarOficial(oficial)
    End Function


End Class