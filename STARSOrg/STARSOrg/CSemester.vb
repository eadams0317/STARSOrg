Imports System.Data.SqlClient

Public Class CSemester
    'Represents a single record in the semester table
    Private _mstrSemesterID As String
    Private _mstrSemesterDescription As String
    Private _isNewSemester As Boolean
    'constructor

    Public Sub New()
        _mstrSemesterID = ""
        _mstrSemesterDescription = ""
    End Sub
#Region "Exposed Properties"
    Public Property semesterID As String
        Get
            Return _mstrSemesterID
        End Get
        Set(strVal As String)
            _mstrSemesterID = strVal
        End Set
    End Property

    Public Property semesterDescription
        Get
            Return _mstrSemesterDescription
        End Get
        Set(strVal)
            _mstrSemesterDescription = strVal
        End Set
    End Property

    Public Property IsNewSemester As Boolean
        Get
            Return _isNewSemester
        End Get
        Set(blnVal As Boolean)
            _isNewSemester = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the paramaters for the stored procedures to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID))

            params.Add(New SqlParameter("SemesterDescription", _mstrSemesterDescription))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        'Return -1 If the ID already exists (and we cannot create a new record with duplicate ID)
        If IsNewsemester Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID))
            Dim strResult = myDB.GetSingleValueFromSP("sp_CheckSemesterIDExists", params)
            If Not strResult = 0 Then
                Return -1 'not unique!!
            End If
        End If
        'if not a new semester, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveSemester", GetSaveParameters())
    End Function

    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("sp_getAllSemesters", Nothing)
    End Function
End Class

