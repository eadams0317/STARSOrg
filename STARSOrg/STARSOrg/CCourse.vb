Imports System.Data.SqlClient

Public Class CCourse
    Private _mstrCourseID As String
    Private _mstrCourseName As String
    Private _isNewCourse As Boolean

    Public Sub New()
        _mstrCourseID = ""
        _mstrCourseName = ""
    End Sub

#Region "Exposed Properties"
    Public Property CourseID As String
        Get
            Return _mstrCourseID
        End Get
        Set(strVal As String)
            _mstrCourseID = strVal
        End Set
    End Property

    Public Property CourseName
        Get
            Return _mstrCourseName
        End Get
        Set(strVal)
            _mstrCourseName = strVal
        End Set
    End Property

    Public Property IsNewCourse As Boolean
        Get
            Return _isNewCourse
        End Get
        Set(blnVal As Boolean)
            _isNewCourse = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the paramaters for the stored procedures to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("CourseID", _mstrCourseID))
            params.Add(New SqlParameter("CourseName", _mstrCourseName))
            Return params
        End Get
    End Property
#End Region

    Public Function Save() As Integer
        'Return -1 If the ID already exists (and we cannot create a new record with duplicate ID)
        If IsNewCourse Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("CourseID", _mstrCourseID))
            Dim strResult = myDB.GetSingleValueFromSP("sp_CheckCourseIDExists", params)
            If Not strResult = 0 Then
                Return -1 'not unique!!
            End If
        End If
        'if not a new course, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveCourse", GetSaveParameters())
    End Function
    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("sp_getAllCourses", Nothing)
    End Function
End Class
