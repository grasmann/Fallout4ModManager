Imports System.Net

Public Class CookieAwareWebClient
    Inherits WebClient
    Public Sub New()
        Me.New(New CookieContainer())
    End Sub

    Public Sub New(c As CookieContainer)
        Me.CookieContainer = c
        Me.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.52 Safari/536.5")
    End Sub

    Public Property CookieContainer() As CookieContainer
        Get
            Return m_CookieContainer
        End Get
        Set(value As CookieContainer)
            m_CookieContainer = value
        End Set
    End Property
    Private m_CookieContainer As CookieContainer

    Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
        Dim request As WebRequest = MyBase.GetWebRequest(address)
        If TypeOf request Is HttpWebRequest Then
            TryCast(request, HttpWebRequest).CookieContainer = Me.CookieContainer
        End If
        Return request
    End Function
End Class