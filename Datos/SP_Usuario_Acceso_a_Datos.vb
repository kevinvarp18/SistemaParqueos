Public Class SP_Usuario_Acceso_a_Datos
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
End Class
