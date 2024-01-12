Imports System.Data.SqlClient
Public Class CLogin

    'Represents a single record in the role table
    Private _mstrPID As String
    Private _mstrUser As String
    Private _mstrPass As String
    Private _mstrSecLevelID As String
    Private _isNewRole As Boolean

    'constructor
    Public Sub New()
        _mstrPID = ""
        _mstrUser = ""
        _mstrPass = ""
        _mstrSecLevelID = ""
    End Sub

#Region "Exposed Properties"
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property

    Public Property Username As String
        Get
            Return _mstrUser
        End Get
        Set(strVal As String)
            _mstrUser = strVal
        End Set
    End Property

    Public Property Password As String
        Get
            Return _mstrPass
        End Get
        Set(strVal As String)
            _mstrPass = strVal
        End Set
    End Property

    Public Property SecLevelID As String
        Get
            Return _mstrSecLevelID
        End Get
        Set(strVal As String)
            _mstrSecLevelID = strVal
        End Set
    End Property

    Public Property IsNewRole As Boolean
        Get
            Return _isNewRole
        End Get
        Set(blnVal As Boolean)
            _isNewRole = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this properties code will create the parameters for the stored procedure to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("UserID", _mstrUser))
            params.Add(New SqlParameter("Password", _mstrPass))
            params.Add(New SqlParameter("SecLevelID", _mstrSecLevelID))
            Return params
        End Get
    End Property
#End Region

    Public Function SaveOrUpdate() As Integer
        'return -1 if the ID already exists (and we cannot create a new record with duplicate ID)
        If IsNewRole Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("UserID", _mstrUser))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckUserExists", params)
            If Not strResult = 0 Then
                Return -1 'not UNIQUE
            End If
        End If
        'if not a new role, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveOrUpdateUser", GetSaveParameters())
    End Function

    Public Function UserIsInDB() As Integer
        'return 1 if the user has an entry in the DB, 0 if not
        Dim result As Integer = 0

        If IsNewRole Then

            Dim params As New ArrayList
            params.Add(New SqlParameter("UserID", _mstrUser))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckUserExists", params)
            If Not strResult = 0 Then
                Return -1 'not UNIQUE
            End If

        End If

        Return result
    End Function

    'Public Function GetReportData() As SqlDataAdapter
    '    Return myDB.GetDataAdapterBySP("sp_getAllRoles", Nothing)
    'End Function
End Class


