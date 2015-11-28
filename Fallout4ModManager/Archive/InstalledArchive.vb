Public Class InstalledArchive

    ' Attributes
    Private _name As String
    Private _active As String

    ' ##### PROPERTIES ################################################################################

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

    ' ##### CONSTRUCTOR ###############################################################################

    ' Create new archive object
    Public Sub New(ByVal Name As String, ByVal Active As Boolean)
        Log.Log(String.Format("Initializing archive '{0}' ...", Name))
        _name = Name
        _active = Active
    End Sub

End Class
