Public Class Oficial
    '**********************************************************************
    'NOMBRE DEL SISTEMA:  SistemaDeParqueos.
    'NOMBRE DEL PAQUETE:  SistemaDeParqueos.BizLayer.
    'DESCRIPCIÓN:
    ' Esta clase de las entidades del sistema.

    'NOMBRE DEL DESARROLLADOR:                       Dylan Zamora
    '
    'FECHA DE CREACIÓN                               05-Octubre-2017
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  05-Octubre-2017
    '******************************************************************

    'Declaracion de Variables.
    Private gintIdOficial As Integer
    'Declaracion de constructor sobrecargado.
    Public Sub New()
        Me.gintIdOficial = 0
    End Sub

    'Declaracion de constructor sobrecargado.
    Public Sub New(gintIdOficial As Integer)
        Me.gintIdOficial = gintIdOficial
    End Sub

    'Declaracion de Set y Get.
    Public Property GintIdOficialSG As Integer
        Get
            Return gintIdOficial
        End Get
        Set(value As Integer)
            gintIdOficial = value
        End Set
    End Property
End Class
