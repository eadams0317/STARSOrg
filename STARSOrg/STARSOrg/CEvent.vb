Imports System.Data.SqlClient
Public Class CEvent
    Private _mintEventID As Integer
    Private _mstrEventTypeID As String
    Private _mstrLocation As String
    Private _mstrEventDescription As String
    Private _mstrSemesterID As String
    Private _mdtStartDate As DateTime
    Private _mdtEndDate As DateTime
    Private _isNewEvent As Boolean

    Public Sub New()
        _mintEventID = 0
        _mstrEventDescription = ""
        _mstrEventTypeID = ""
        _mstrLocation = ""
        _mstrSemesterID = ""
        _mdtStartDate = DateTime.Today
        _mdtEndDate = DateTime.Today
    End Sub

#Region "Exposed Properties"
    Public Property EventID As Integer
        Get
            Return _mintEventID
        End Get
        Set(strVal As Integer)
            _mintEventID = strVal
        End Set
    End Property

    Public Property EventDescription As String
        Get
            Return _mstrEventDescription
        End Get
        Set(strVal As String)
            _mstrEventDescription = strVal
        End Set
    End Property
    Public Property Location As String
        Get
            Return _mstrLocation
        End Get
        Set(strVal As String)
            _mstrLocation = strVal
        End Set
    End Property

    Public Property EventType As String
        Get
            Return _mstrEventTypeID
        End Get
        Set(strVal As String)
            _mstrEventTypeID = strVal
        End Set
    End Property
    Public Property IsNewEvent As Boolean
        Get
            Return _isNewEvent
        End Get
        Set(blnVal As Boolean)
            _isNewEvent = blnVal
        End Set
    End Property
    Public Property SemesterID As String
        Get
            Return _mstrSemesterID
        End Get
        Set(strVal As String)
            _mstrSemesterID = strVal
        End Set
    End Property
    Public Property StartDate As DateTime
        Get
            Return _mdtStartDate
        End Get
        Set(strVal As DateTime)
            _mdtStartDate = strVal
        End Set
    End Property
    Public Property EndDate As DateTime
        Get
            Return _mdtEndDate
        End Get
        Set(strVal As DateTime)
            _mdtEndDate = strVal
        End Set
    End Property

#End Region

    Public Function Save() As Integer
        If IsNewEvent Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("EventID", _mintEventID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckEventIDExists", params)
        End If
        Return myDB.ExecSp("sp_SaveEventsss", GetSaveParameters())
    End Function
    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the parameters for the stored procedure to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("EventID", _mintEventID))
            params.Add(New SqlParameter("EventDescription", _mstrEventDescription)) '1
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID)) '2
            params.Add(New SqlParameter("EventTypeID", _mstrEventTypeID)) '3
            params.Add(New SqlParameter("StartDate", _mdtStartDate)) '4
            params.Add(New SqlParameter("EndDate", _mdtEndDate)) '5
            params.Add(New SqlParameter("Location", _mstrLocation)) '6
            Return params
        End Get
    End Property
End Class
