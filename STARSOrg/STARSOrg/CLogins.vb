Imports System.Data.SqlClient
Public Class CLogins
    'Represents the ROLE table and its associated business rules
    Private _Login As CLogin
    Public Sub New()
        'instantiate CLogin object
        _Login = New CLogin
    End Sub

    Public ReadOnly Property CurrentObject() As CLogin
        Get
            Return _Login
        End Get
    End Property
    Public Sub Clear()
        _Login = New CLogin
    End Sub
    Public Sub CreateNewRole()
        'call this when clearing the edit portion of the screen to add a new role
        Clear()
        _Login.IsNewRole = True
    End Sub
    Public Function Save() As Integer
        Return _Login.SaveOrUpdate
    End Function

    Public Function UserAlreadyExists(username As String)
        Dim result As Boolean
        result = False
        Dim params As New ArrayList
        params.Add(New SqlParameter("@username", username))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckUserExists", params)
        If Not strResult = 0 Then
            result = True
        End If

        Return result
    End Function

    Public Function PasswordIsCorrect(username As String, password As String)
        Dim result As Boolean
        result = False
        Dim params As New ArrayList
        params.Add(New SqlParameter("@username", username))
        params.Add(New SqlParameter("@password", password))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckPasswordExists", params)
        If Not strResult = 0 Then
            result = True
        End If

        Return result
    End Function


    Public Function FillObject(sqlDR As SqlDataReader) As CLogin
        Using sqlDR
            If sqlDR.Read Then 'found the role record
                With _Login
                    .PID = sqlDR.Item("PID") & ""
                    .Username = sqlDR.Item("UserID") & ""
                    .Password = sqlDR.Item("Password") & ""
                    .SecLevelID = sqlDR.Item("SecLevelID") & ""
                End With
            Else
                'did not get a matching role record
            End If
        End Using
        sqlDR.Close()
        Return _Login
    End Function

    Public Sub AddAudit(PID As String, timestamp As String, success As String)
        Dim params As New ArrayList
        params.Add(New SqlParameter("@PID", PID))
        params.Add(New SqlParameter("@timestamp", timestamp))
        params.Add(New SqlParameter("@success", success))
        myDB.ExecSP("sp_saveAudit", params)
    End Sub
    Public Function GetAllMembersWithCreds() As SqlDataReader
        Return myDB.GetDataReaderBySP("sp_getAllMembersWithCreds", Nothing)
    End Function

    Public Function GetAllMembersWithoutCreds() As SqlDataReader
        Return myDB.GetDataReaderBySP("sp_getAllMembersWithoutCreds", Nothing)
    End Function

    Public Function GetLoginByPID(PID As String) As SqlDataReader
        Dim params As New ArrayList
        params.Add(New SqlParameter("@PID", PID))
        Return myDB.GetDataReaderBySP("sp_getUserByPID", params)
    End Function

    Public Function GetLoginByUsername(username As String) As SqlDataReader
        Dim params As New ArrayList
        params.Add(New SqlParameter("@username", username))
        FillObject(myDB.GetDataReaderBySP("sp_getUserByUsername", params))
    End Function


    'Public Function GetRoleByID(strID As String) As CLogin
    '    Dim params As New ArrayList
    '    params.Add(New SqlParameter("roleID", strID))
    '    FillObject(myDB.GetDataReaderBySP("sp_getRoleByRoleID", params)) 'video may say get role by ID. do not follow video namin convention
    '    Return _Login
    'End Function
    'Private Function FillObjectFromDB(sqlDR As SqlDataReader) As CLogin
    '    Using sqlDR
    '        If sqlDR.Read Then 'found the role record
    '            With _Login
    '                .RoleID = sqlDR.Item("RoleID") & ""
    '                .RoleDescription = sqlDR.Item("RoleDescription") & ""
    '            End With
    '        Else
    '            'did not get a matching role record
    '        End If
    '    End Using
    '    sqlDR.Close()
    '    Return _Login
    'End Function
    'Private Function FillObjectFromInput(sqlDR As SqlDataReader) As CLogin
    '    Using sqlDR
    '        If sqlDR.Read Then 'found the role record
    '            With _Login
    '                .RoleID = sqlDR.Item("RoleID") & ""
    '                .RoleDescription = sqlDR.Item("RoleDescription") & ""
    '            End With
    '        Else
    '            'did not get a matching role record
    '        End If
    '    End Using
    '    sqlDR.Close()
    '    Return _Login
    'End Function

End Class