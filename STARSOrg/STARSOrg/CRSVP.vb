Imports System.Data.SqlClient
Public Class CRSVP
    Private _isNewRSVP As Boolean
    Private _EventID As String
    Private _FName As String
    Private _LName As String
    Private _Email As String
    'constructor

    Public Sub New()
        'instantiate the CRole object
        _EventID = ""
        _FName = ""
        _LName = ""
        _Email = ""
    End Sub
#Region "Exposed Properties"
    Public Property EventID As String
        Get
            Return _EventID
        End Get
        Set(strVal As String)
            _EventID = strVal
        End Set
    End Property

    Public Property FName As String
        Get
            Return _FName
        End Get
        Set(strVal As String)
            _FName = strVal
        End Set
    End Property

    Public Property LName As String
        Get
            Return _LName
        End Get
        Set(strVal As String)
            _LName = strVal
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(strVal As String)
            _Email = strVal
        End Set
    End Property
    Public Property IsNewRSVP As Boolean
        Get
            Return _IsNewRSVP
        End Get
        Set(blnVal As Boolean)
            _isNewRSVP = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the parameters for the stored procedure to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("EventID", _EventID))
            params.Add(New SqlParameter("FName", _FName))
            params.Add(New SqlParameter("LName", _LName))
            params.Add(New SqlParameter("Email", _Email))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer

        Dim params As New ArrayList
        params.Add(New SqlParameter("EventID", _EventID))
        params.Add(New SqlParameter("FName", _FName))
        params.Add(New SqlParameter("LName", _LName))
        params.Add(New SqlParameter("Email", _Email))

        Return myDB.ExecSP("sp_SaveRSVP1", GetSaveParameters())
    End Function
    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllRSVP", Nothing)
    End Function
End Class
