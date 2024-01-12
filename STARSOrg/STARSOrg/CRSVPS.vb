Imports System.Data.SqlClient
Public Class CRSVPS
    Private _CRSVPs As CRSVP
    Private _mintEventID As Integer
    Private _mstrEmail As String
    Private _mstrFirstName As String
    Private _mstrLastName As String

    Public Sub New() 'constructor class
        _CRSVPs = New CRSVP
    End Sub

    Public ReadOnly Property CurrentObject() As CRSVP 'getter
        Get
            Return _CRSVPs
        End Get
    End Property
    'getters/setters for each value in the class
    Public Property EventID As Integer
        Get
            Return _mintEventID
        End Get
        Set(intVal As Integer)
            _mintEventID = intVal
        End Set
    End Property
    Public Sub Clear()
        _CRSVPs = New CRSVP
    End Sub

    Public Sub CreateNewEvent()
        'Call this when clearing the edit portion of the scree to add a new role
        Clear()
        _CRSVPs.IsNewRSVP = True
    End Sub

    Public Function Save() As Integer
        Return _CRSVPs.Save
    End Function
    ' "get" all functions'
    Public Function GetAllERSVPs() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllRSVP", Nothing)
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
    Public Function GetRSVPByEventID(strID As String) As CRSVP
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("EventID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getRSVPByEventID", params))
        Return _CRSVPs
    End Function

    Private Function FillObject(SqlDR As SqlDataReader) As CRSVP
        'fills out the values for each of the table columns per the fields in the form
        Using SqlDR
            If SqlDR.Read Then ' if a record was found
                With _CRSVPs
                    '.EventID = SqlDR.Item("EventID") & ""
                    .Email = SqlDR.Item("Email") & ""
                    .EventID = SqlDR.Item("EventID") & ""
                    .FName = SqlDR.Item("FName") & ""
                    .LName = SqlDR.Item("LName") & ""
                End With
            Else
                With _CRSVPs
                    .Email = ""
                    .EventID = ""
                    .FName = ""
                    .LName = ""
                End With
            End If
        End Using
        SqlDR.Close()
        Return _CRSVPs
    End Function
End Class
