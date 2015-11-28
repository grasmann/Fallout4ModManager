Public Class InstalledPlugin

    Private _name As String
    Private _active As Boolean
    Private _readonly As Boolean

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Active As Boolean
        Get
            Return _active
        End Get
    End Property

    Public ReadOnly Property Read_Only As Boolean
        Get
            Return _readonly
        End Get
    End Property

    ' ##### INIT ###############################################################################################

    Public Sub New(ByVal Name As String, ByVal Active As Boolean, ByRef Read_Only As Boolean)
        Log.Log(String.Format("Initializing plugin '{0}' ...", Name))
        _name = Name
        _active = Active
        _readonly = Read_Only
    End Sub

End Class
