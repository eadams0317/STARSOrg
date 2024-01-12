Imports System.Data.SqlClient
Public Class CMemberRoles
    'Represents the Member Roles table and its associated business rules
    Private _MemberRole As CMemberRole
    'constructor
    Public Sub New()
        'instantiate the CMemberRole object
        _MemberRole = New CMemberRole
    End Sub
    Public ReadOnly Property CurrentObject() As CMemberRole
        Get
            Return _MemberRole
        End Get
    End Property

    Public Sub Clear()
        _MemberRole = New CMemberRole
    End Sub

    Public Sub CreateNewMember()
        Clear()
        _MemberRole.isNewMemberRole = True
    End Sub

    Public Function Save() As Integer
        Return _MemberRole.Save
    End Function
    Public Function GetAllMembers() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllMemberRoles", Nothing)
        Return objDR
    End Function
    Public Function GetMemberRoleByukid(strID As String) As CMemberRole
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("uKid", strID))
        'objDR = myDB.GetDataReaderBySP("sp_getRoleByRoleID", params)
        'Return objDR
        FillObject(myDB.GetDataReaderBySP("sp_getMemberRolesByukid", params))
        Return _MemberRole

    End Function
    Private Function FillObject(objDR As SqlDataReader) As CMemberRole
        If objDR.Read Then
            With _MemberRole
                .ukid = objDR.Item("ukid")
                .PID = objDR.Item("PID")
                .RoleID = objDR.Item("RoleID")
                .SemesterID = objDR.Item("SemesterID")


            End With
        Else 'no record returned 
            'nothing to do here
        End If
        objDR.Close()
        Return _MemberRole
    End Function
End Class
