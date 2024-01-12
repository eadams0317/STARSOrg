Imports System.Data.SqlClient
Public Class frmChangeCredentials

    Private objLogin As CLogins
    Private PID As String
    Private oldUser As String
    Private oldPass As String
    Private oldSecLevel As String
    Private Sub frmChangeCredentials(sender As Object, e As EventArgs) Handles Me.Load
        objLogin = New CLogins

        txtNewUser.Text = oldUser
        txtNewPassword.Text = oldPass

        lblPID.Text = PID

        If cboNewSecLevel.Items.Count = 0 Then
            cboNewSecLevel.Items.Add("ADMIN")
            cboNewSecLevel.Items.Add("GUEST")
            cboNewSecLevel.Items.Add("MEMBER")
            cboNewSecLevel.Items.Add("OFFICER")
        End If

        cboNewSecLevel.SelectedItem = "ADMIN"

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If txtNewUser.Text.Length > 0 And txtNewPassword.Text.Length > 0 Then

            Dim params As New ArrayList
            params.Add(New SqlParameter("@PID", PID))
            params.Add(New SqlParameter("@UserID", txtNewUser.Text))
            params.Add(New SqlParameter("@Password", txtNewPassword.Text))

            Select Case cboNewSecLevel.SelectedItem.ToString
                Case "ADMIN"
                    params.Add(New SqlParameter("@SecLevelID", "ADMIN"))
                Case "GUEST"
                    params.Add(New SqlParameter("@SecLevelID", "GUEST"))
                Case "MEMBER"
                    params.Add(New SqlParameter("@SecLevelID", "MEMBR"))
                Case "OFFICER"
                    params.Add(New SqlParameter("@SecLevelID", "OFFIC"))
                Case Else
            End Select

            myDB.ExecSP("sp_updateUser", params)

            MessageBox.Show("Credentials Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) 'message box giving error, clear text boxes
            txtNewUser.Clear()
            txtNewPassword.Clear()

            Me.Close()

        Else

            MessageBox.Show("Please enter data into all fields", "Credential error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If


    End Sub

    Public Function SetCreds(inputPID As String, inputUser As String, inputPass As String, inputSec As String)
        PID = inputPID
        oldUser = inputUser
        oldPass = inputPass
        oldSecLevel = inputSec
    End Function

End Class