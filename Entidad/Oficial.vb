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
    Private CedulaOficial As String
    Private NombreOficial As String
    Private ApellidosOficial As String
    Private CorreoOficial As String
    Private ContraseniaOficial As String
    Private RolOficial As String


    'Declaracion de constructor sobrecargado.
    Public Sub New()
        Me.gintIdOficial = 0
        Me.CedulaOficial = ""
        Me.NombreOficial = ""
        Me.ApellidosOficial = ""
        Me.CorreoOficial = ""
        Me.ContraseniaOficial = ""
        Me.RolOficial = ""
    End Sub

    'Declaracion de constructor sobrecargado.
    Public Sub New(gintIdOficial As Integer,
                   CedulaOficial As String,
                   NombreOficial As String,
                   ApellidosOficial As Integer,
                   CorreoOficial As Integer,
                   ContraseniaOficial As String,
                   RolOficial As String)

        Me.gintIdOficial = gintIdOficial
        Me.CedulaOficial = CedulaOficial
        Me.NombreOficial = NombreOficial
        Me.ApellidosOficial = ApellidosOficial
        Me.CorreoOficial = CorreoOficial
        Me.ContraseniaOficial = ContraseniaOficial
        Me.RolOficial = RolOficial
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

    Public Property CedulaOficialSG As String
        Get
            Return CedulaOficial
        End Get
        Set(value As String)
            CedulaOficial = value
        End Set
    End Property

    Public Property NombreOficialSG As String
        Get
            Return NombreOficial
        End Get
        Set(value As String)
            NombreOficial = value
        End Set
    End Property

    Public Property ApellidosOficialSG As String
        Get
            Return ApellidosOficial
        End Get
        Set(value As String)
            ApellidosOficial = value
        End Set
    End Property

    Public Property CorreoOficialSG As String
        Get
            Return CorreoOficial
        End Get
        Set(value As String)
            CorreoOficial = value
        End Set
    End Property

    Public Property ContraseniaOficialSG As String
        Get
            Return ContraseniaOficial
        End Get
        Set(value As String)
            ContraseniaOficial = value
        End Set
    End Property

    Public Property RolOficialSG As String
        Get
            Return RolOficial
        End Get
        Set(value As String)
            RolOficial = value
        End Set
    End Property
End Class
