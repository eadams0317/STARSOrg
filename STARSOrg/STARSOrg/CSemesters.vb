Imports System.Data.SqlClient

Public Class CSemesters

    'Represents the SEMESTER table and its associated business rules
    Private _Semester As CSemester
    'constructor
    Public Sub New()
        'instantiate the CSemester Object
        _Semester = New CSemester
    End Sub

    Public ReadOnly Property CurrentObject() As CSemester
        Get
            Return _Semester
        End Get
    End Property

    Public Sub Clear()
        _Semester = New CSemester
    End Sub

    Public Sub CreateNewSemester()
        'call this when clearing the edit portion of the screen to add a new role
        Clear()
        _Semester.IsNewSemester = True
    End Sub

    Public Function Save() As Integer
        Return _Semester.Save
    End Function

    Public Function GetAllSemesters() As SqlDataReader
        Return myDB.GetDataReaderBySP("sp_getAllSemesters", Nothing)

    End Function

    Public Function GetSemesterByID(strID As String) As CSemester
        Dim params As New ArrayList
        params.Add(New SqlParameter("semesterID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getSemesterBySemesterID", params))
        Return _Semester
    End Function
    Private Function FillObject(sqlDR As SqlDataReader) As CSemester
        Using sqlDR 'similar to with, difference is it disposes after end using
            If sqlDR.Read Then 'found the role record
                With _Semester
                    .semesterID = sqlDR.Item("SemesterID") & ""
                    .semesterDescription = sqlDR.Item("SemesterDescription") & ""
                End With
            Else
                'did not a matching role record
            End If
        End Using
        sqlDR.Close()
        Return _Semester
    End Function
End Class

