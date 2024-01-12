Imports System.Data.SqlClient
Public Class CMembers
    'Represents the Member table and its associated business rules
    Private _Member As CMember
    'constructor
    Public Sub New()
        'instantiate the CMember object
        _Member = New CMember
    End Sub
    Public ReadOnly Property CurrentObject() As CMember
        Get
            Return _Member
        End Get
    End Property

    Public Sub Clear()
        _Member = New CMember
    End Sub

    Public Sub CreateNewMember()
        Clear()
        _Member.IsNewMember = True
    End Sub

    Public Function Save() As Integer
        Return _Member.Save
    End Function

    Public Function GetAllMembers() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllMembers", Nothing)
        Return objDR
    End Function

    Public Function GetMemberByPID(strID As String) As CMember
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("pID", strID))
        'objDR = myDB.GetDataReaderBySP("sp_getRoleByRoleID", params)
        'Return objDR
        FillObject(myDB.GetDataReaderBySP("sp_getMemberByPID", params))
        Return _Member

    End Function

    Private Function FillObject(objDR As SqlDataReader) As CMember
        If objDR.Read Then
            With _Member
                .PID = objDR.Item("PID")
                .FName = objDR.Item("FName")
                .LName = objDR.Item("LName")
                .MI = objDR.Item("MI")
                .Email = objDR.Item("Email")
                .Phone = objDR.Item("Phone")
                .PhotoPath = objDR.Item("PhotoPath")
            End With
        Else 'no record returned 
            'nothing to do here
        End If
        objDR.Close()
        Return _Member
    End Function
End Class


