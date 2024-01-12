Imports System.Data.SqlClient
Public Class frmLogin

    Private objLogin As CLogins
    Private frmChangePassword As frmChangePassword
    Private blnClearing As Boolean
    Private blnReloading As Boolean
    Private RoleReport As frmRoleReport

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modGlobal.LoginSuccessful = 0
        objLogin = New CLogins
        frmChangePassword = New frmChangePassword
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click


        Dim blnErrors As Boolean = True
        If Not ValidateTextBoxLength(txtUser, errP) Then
            blnErrors = False
        End If
        If Not ValidateTextBoxLength(txtPass, errP) Then
            blnErrors = False
        End If
        If Not blnErrors Then
            'if credentials don't match
            MessageBox.Show("Login failed, please fill in both fields", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClearTextboxes()
            Exit Sub
        End If

        Try 'loading the logins obj
            objLogin.GetLoginByUsername(txtUser.Text)

            If objLogin.CurrentObject.PID = "" Then
                MessageBox.Show("Login failed, invalid credentials", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                objLogin.AddAudit("9999999", timestamp:=Now, "False")
                Exit Sub
            End If

            'given user was valid


        Catch ex As Exception

        End Try

        If (objLogin.CurrentObject.Username = txtUser.Text) And (objLogin.CurrentObject.Password = txtPass.Text) Then 'check if the credentials match
            modGlobal.LoginSuccessful = 1
            modGlobal.PantherID = objLogin.CurrentObject.PID
            modGlobal.UserID = objLogin.CurrentObject.Username
            modGlobal.SecurityLevel = objLogin.CurrentObject.SecLevelID
            Me.Close()
            objLogin.AddAudit(objLogin.CurrentObject.PID, timestamp:=Now, "True")
        Else
            MessageBox.Show("Login failed, invalid credentials", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            objLogin.AddAudit(objLogin.CurrentObject.PID, timestamp:=Now, "False")
        End If


    End Sub

    Private Sub btnGuestLogin_Click(sender As Object, e As EventArgs) Handles btnGuestLogin.Click
        modGlobal.LoginSuccessful = 1
        modGlobal.PantherID = "0000001"
        modGlobal.UserID = "guest"
        modGlobal.SecurityLevel = "GUEST"
        Me.Close()
        objLogin.AddAudit("0000001", timestamp:=Now, "True")
    End Sub

    Private Sub ClearTextboxes()
        txtUser.Clear()
        txtPass.Clear()
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        frmChangePassword.ShowDialog()
    End Sub
End Class
