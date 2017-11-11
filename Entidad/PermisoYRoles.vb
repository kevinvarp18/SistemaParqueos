Public Class PermisoYRoles
    '**********************************************************************
    'NOMBRE DEL SISTEMA:  SistemaDeParqueos.
    'NOMBRE DEL PAQUETE:  SistemaDeParqueos.
    'DESCRIPCIÓN:
    ' Esta clase de las entidades del sistema.

    'NOMBRE DEL DESARROLLADOR:                       Adrian Serrano
    '
    'FECHA DE CREACIÓN                               10-Noviembre-2017
    'FECHA DE ULTIMA ACTUALIZACIÓN:                  10-Noviembre-2017
    '******************************************************************
    'Declaracion Declare variables

    Private permiso As String
    Private rol As String

    'Declaracion Declare constructor sobrecargado
    Public Sub New(permiso As String, rol As String)
        Me.permiso = permiso
        Me.rol = rol
    End Sub

    Public Sub New()
        Me.permiso = ""
        Me.rol = ""
    End Sub

    'Metodos accesores
    Public Property GstrPermiso As String
        Get
            Return permiso
        End Get
        Set(value As String)
            permiso = value
        End Set
    End Property

    Public Property GstrRol As String
        Get
            Return rol
        End Get
        Set(value As String)
            rol = value
        End Set
    End Property







End Class
