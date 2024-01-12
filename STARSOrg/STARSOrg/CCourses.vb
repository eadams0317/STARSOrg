Imports System.Data.SqlClient
Public Class CCourses
    Private _Course As CCourse

    Public Sub New()
        _Course = New CCourse
    End Sub

    Public ReadOnly Property CurrentObject() As CCourse
        Get
            Return _Course
        End Get
    End Property

    Public Sub Clear()
        _Course = New CCourse
    End Sub

    Public Sub CreateNewCourse()
        'call this when clearing the edit portion of the screen to add a new course
        Clear()
        _Course.IsNewCourse = True
    End Sub

    Public Function Save() As Integer
        Return _Course.Save
    End Function

    Public Function GetAllCourses() As SqlDataReader
        Return myDB.GetDataReaderBySP("sp_getAllCourses", Nothing)
    End Function

    Public Function GetCourseByID(strID As String) As CCourse
        Dim params As New ArrayList
        params.Add(New SqlParameter("courseID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getCourseByCourseID", params))
        Return _Course
    End Function

    Private Function FillObject(sqlDR As SqlDataReader) As CCourse
        Using sqlDR 'similar to with, difference is it disposes after end using
            If sqlDR.Read Then 'found the course record
                With _Course
                    .CourseID = sqlDR.Item("CourseID") & ""
                    .CourseName = sqlDR.Item("CourseName") & ""
                End With
            Else
                'did not a matching course record
            End If
        End Using
        sqlDR.Close()
        Return _Course
    End Function
End Class
