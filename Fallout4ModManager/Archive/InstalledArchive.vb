Public Class InstalledArchive

    Private _name As String
    Private _active As String

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

    Public Sub New(ByVal Name As String, ByVal Active As Boolean)
        _name = Name
        _active = Active
    End Sub

End Class
