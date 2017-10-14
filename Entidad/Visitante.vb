Public Class Visitante
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
    'Declaracion de variables.
    Public gintId As Integer
    Public gintTelefono As Integer
    Public gstrUbicacion As String
    Public gstrTipoVisitante As String

    'Constructor Default.
    Public Sub New()
        Me.gintId = 0
        Me.gintTelefono = 0
        Me.gstrUbicacion = ""
        Me.gstrTipoVisitante = ""
    End Sub

    'Constructor sobrecargado.
    Public Sub New(ByVal id As Integer, ByVal telefono As Integer, ByVal ubicacion As String, ByVal tipoVisitante As String)
        Me.gintId = id
        Me.gintTelefono = telefono
        Me.gstrUbicacion = ubicacion
        Me.gstrTipoVisitante = tipoVisitante
    End Sub

    'Set y get.
    Public Property IdSG As Integer
        Get
            Return gintId
        End Get
        Set(value As Integer)
            gintId = value
        End Set
    End Property

    Public Property TelefonoSG As Integer
        Get
            Return gintTelefono
        End Get
        Set(value As Integer)
            gintTelefono = value
        End Set
    End Property

    Public Property UbicacionSG As String
        Get
            Return gstrUbicacion
        End Get
        Set(value As String)
            gstrUbicacion = value
        End Set
    End Property

    Public Property TipoVisitanteSG As String
        Get
            Return gstrTipoVisitante
        End Get
        Set(value As String)
            gstrTipoVisitante = value
        End Set
    End Property
End Class
