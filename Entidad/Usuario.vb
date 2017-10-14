Public Class Usuario
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

    'Declaracionde Variables.
    Private gintId As Integer
    Private gstrNombre As String
    Private gstrApellido As String
    Private gstrCorreo As String
    Private gstrContrasenna As String
    Private gstrTipoUsuario As String

    'Declarion de constructor default.
    Public Sub New()
        Me.gintId = 0
        Me.gstrNombre = ""
        Me.gstrApellido = ""
        Me.gstrCorreo = ""
        Me.gstrContrasenna = ""
        Me.gstrTipoUsuario = ""
    End Sub

    'Declaraccion Constructor Sobrecargado.
    Public Sub New(gintId As Integer, gstrNombre As String, gstrApellido As String, gstrCorreo As String, gstrContrasenna As String, gstrTipoUsuario As String)
        Me.gintId = gintId
        Me.gstrNombre = gstrNombre
        Me.gstrApellido = gstrApellido
        Me.gstrCorreo = gstrCorreo
        Me.gstrContrasenna = gstrContrasenna
        Me.gstrTipoUsuario = gstrTipoUsuario
    End Sub

    'Set y Get.
    Public Property GintIdSG As Integer
        Get
            Return gintId
        End Get
        Set(value As Integer)
            gintId = value
        End Set
    End Property

    Public Property GstrNombreSG As String
        Get
            Return gstrNombre
        End Get
        Set(value As String)
            gstrNombre = value
        End Set
    End Property

    Public Property GstrApellidoSG As String
        Get
            Return gstrApellido
        End Get
        Set(value As String)
            gstrApellido = value
        End Set
    End Property

    Public Property GstrCorreoSG As String
        Get
            Return gstrCorreo
        End Get
        Set(value As String)
            gstrCorreo = value
        End Set
    End Property

    Public Property GstrContrasennaSG As String
        Get
            Return gstrContrasenna
        End Get
        Set(value As String)
            gstrContrasenna = value
        End Set
    End Property

    Public Property GstrTipoUsuarioSG As String
        Get
            Return gstrTipoUsuario
        End Get
        Set(value As String)
            gstrTipoUsuario = value
        End Set
    End Property
End Class
