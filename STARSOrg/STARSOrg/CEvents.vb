Imports System.Data.SqlClient
Public Class CEvents
    Private _Event As CEvent
    Public Sub New()
        _Event = New CEvent
    End Sub

    Public ReadOnly Property CurrentObject() As CEvent
        Get
            Return _Event
        End Get
    End Property
    Public Sub clear()
        _Event = New CEvent
    End Sub
    Public Sub CreateNewEvent()
        clear()
        _Event.isNewEvent = True
    End Sub
    Public Function Save()
        Return _Event.Save
    End Function
    Public Function GetAllEvents() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllEvents", Nothing)
        Return objDR
    End Function
    Public Function GetAllEventTypes() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllEventTypes", Nothing)
        Return objDR
    End Function
    Public Function getAllSemesters() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllSemesters", Nothing)
        Return objDR
    End Function
    Public Function GetEventByEventID(strID As String) As CEvent
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("EventID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getAllFromEventByEventID", params))
        Return _Event
    End Function

    Public Function FillObject(sqlDR As SqlDataReader) As CEvent
        Using sqlDR
            If sqlDR.Read Then
                With _Event
                    .EventID = sqlDR.Item("EventID") & ""
                    .EventDescription = sqlDR.Item("EventDescription") & ""
                    .EventType = sqlDR.Item("EventTypeID") & ""
                    .SemesterID = sqlDR.Item("SemesterID") & ""
                    .StartDate = sqlDR.Item("StartDate") & ""
                    .EndDate = sqlDR.Item("EndDate") & ""
                    .Location = sqlDR.Item("Location") & ""
                End With
            End If

        End Using
    End Function

End Class
