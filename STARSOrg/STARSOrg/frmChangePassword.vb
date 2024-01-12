Imports System.Data.SqlClient
Public Class frmChangePassword
    Private objLogin As CLogins
    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        objLogin = New CLogins
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearScreenControls(grpCredentials)
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

#Region "Validation"
        Dim blnErrors As Boolean = True
        If Not ValidateTextBoxLength(txtUsername, errP) Then
            blnErrors = False
        End If
        If Not ValidateTextBoxLength(txtNewPassword, errP) Then
            blnErrors = False
        End If
        If Not ValidateTextBoxLength(txtCurrentPassword, errP) Then
            blnErrors = False
        End If
        If Not ValidateTextBoxLength(txtConfNewPassword, errP) Then
            blnErrors = False
        End If

        If Not blnErrors Then
            MessageBox.Show("Please fill in all fields", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
#End Region

        If txtNewPassword.Text = txtConfNewPassword.Text Then

            'loading the logins obj
            Try
                objLogin.GetLoginByUsername(txtUsername.Text)

                'validate the user exists
                If objLogin.CurrentObject.PID = "" Then
                    MessageBox.Show("Invalid credentials", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            Catch ex As Exception
            End Try

            If objLogin.CurrentObject.Password = txtCurrentPassword.Text Then

                Dim params As New ArrayList
                params.Add(New SqlParameter("@newPassword", txtNewPassword.Text))
                params.Add(New SqlParameter("@ID", objLogin.CurrentObject.PID))
                myDB.ExecSP("sp_updatePassword", params)

                MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) 'message box giving error, clear text boxes
                txtUsername.Clear()
                txtCurrentPassword.Clear()
                txtNewPassword.Clear()
                txtConfNewPassword.Clear()
                Me.Close()

            Else

                MessageBox.Show("Invalid credentials", "Credential error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If



        Else
            MessageBox.Show("Passwords are not the same", "Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'message box giving error, clear text boxes
        End If

    End Sub

End Class