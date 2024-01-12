Imports System.Data.SqlClient
Public Class CMemberRole
    'Represents a single record in the Member_Role table
    Private _mintukid As Integer
    Private _mstrPID As String
    Private _mstrRoleID As String
    Private _mstrSemesterID As String
    Private _isNewMemberRole As Boolean
    'constructor
    Public Sub New()
        _mintukid = 0
        _mstrPID = ""
        _mstrRoleID = ""
        _mstrSemesterID = ""
    End Sub

#Region "Exposed Properties"
    Public Property ukid As Integer
        Get
            Return _mintukid
        End Get
        Set(intVal As Integer)
            _mintukid = intVal
        End Set
    End Property
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property
    Public Property RoleID As String
        Get
            Return _mstrRoleID
        End Get
        Set(strVal As String)
            _mstrRoleID = strVal
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
    Public Property isNewMemberRole As Boolean
        Get
            Return _isNewMemberRole
        End Get
        Set(blnVal As Boolean)
            _isNewMemberRole = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create parameters for the stored procedure to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("uKid", _mintukid))
            params.Add(New SqlParameter("pID", _mstrPID))
            params.Add(New SqlParameter("roleID", _mstrRoleID))
            params.Add(New SqlParameter("semesterID", _mstrSemesterID))

            Return params
        End Get
    End Property
#End Region

    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllMemberRoles", Nothing)

    End Function
    Public Function Save() As Integer
        'return -1 if the ID already exists (and we cannot create a new record with duplicate ID)
        If _isNewMemberRole Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("uKid", _mintukid))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckukidExists", params)
            If Not strResult = 0 Then
                Return -1 'not Unique!!
            End If
        End If
        'if not a new member, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveMemberRole", GetSaveParameters())

    End Function
End Class
