Imports System.Data.SqlClient
Public Class frmAdmin

    Private objLogins As CLogins
    Private frmChangeCredentials As frmChangeCredentials

#Region "Toolbar Role"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter,
        tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogout.MouseEnter, tsbMember.MouseEnter,
        tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbAdmin.MouseEnter
        'need this because each button does not have an image for its image property, but in their background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub
    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave,
        tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogout.MouseLeave, tsbMember.MouseLeave,
        tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave, tsbTutor.MouseLeave, tsbAdmin.MouseLeave
        'need this because each button does not have an image for its image property, but in their background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        intNextAction = ACTION_EVENT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) Handles tsbTutor.Click
        intNextAction = ACTION_TUTOR
        Me.Hide()
    End Sub

    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        'no action needed - already on the ROLE form
    End Sub



#End Region

    'TASKS

    'LOAD ALL USERS INTO LIST
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load
        objLogins = New CLogins
        frmChangeCredentials = New frmChangeCredentials
    End Sub

    Private Sub frmAdmin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadUsers()

        If cboSecLevel.Items.Count = 0 Then
            cboSecLevel.Items.Add("ADMIN")
            cboSecLevel.Items.Add("GUEST")
            cboSecLevel.Items.Add("MEMBER")
            cboSecLevel.Items.Add("OFFICER")
        End If
    End Sub

    Private Sub LoadUsers()
        Dim objReader As SqlDataReader
        lstUsers.Items.Clear()
        lstUsersNoCredentials.Items.Clear()

        Try
            objReader = objLogins.GetAllMembersWithCreds
            Do While objReader.Read
                lstUsers.Items.Add(objReader.Item("PID"))
            Loop
            objReader.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap it here
        End Try

        Try
            objReader = objLogins.GetAllMembersWithoutCreds
            Do While objReader.Read
                If objReader.Item("PID") <> 9999999 Then
                    lstUsersNoCredentials.Items.Add(objReader.Item("PID"))
                End If
            Loop
            objReader.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap it here
        End Try

    End Sub

    Private Sub btnAssignCredentials_Click(sender As Object, e As EventArgs) Handles btnAssignCredentials.Click
        'Assigns Credentials to Member who doesnt have

        If lstUsersNoCredentials.SelectedItem Then

            If txtUser.Text.Length > 0 And txtPass.Text.Length > 0 Then

                Dim params As New ArrayList
                params.Add(New SqlParameter("@PID", lstUsersNoCredentials.SelectedItem.ToString))
                params.Add(New SqlParameter("@UserID", txtUser.Text.ToString))
                params.Add(New SqlParameter("@Password", txtPass.Text.ToString))

                Select Case cboSecLevel.SelectedItem.ToString
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


                myDB.ExecSP("sp_saveUser", params)

                MessageBox.Show("Credentials Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) 'message box giving error, clear text boxes
                txtUser.Clear()
                txtPass.Clear()

            Else

                MessageBox.Show("Please enter data into all fields", "Credential error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Else
            MessageBox.Show("Please select a User to Assign", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'message box giving error, clear text boxes
        End If

        LoadUsers()

    End Sub

    Private Sub btnChangeCredentials_Click(sender As Object, e As EventArgs) Handles btnChangeCredentials.Click
        'Updates Credentials to Existing User
        If lstUsers.SelectedItem Then
            frmChangeCredentials.SetCreds(objLogins.CurrentObject.PID, objLogins.CurrentObject.Username, objLogins.CurrentObject.Password, objLogins.CurrentObject.SecLevelID)
            frmChangeCredentials.ShowDialog()

            UpdateList()
        Else
            MessageBox.Show("Please select a User to Change", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error) 'message box giving error, clear text boxes
        End If

    End Sub

    Private Sub lstUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstUsers.SelectedIndexChanged
        UpdateList()
    End Sub

    Public Sub UpdateList()
        If lstUsers.SelectedItem Then
            objLogins.FillObject(objLogins.GetLoginByPID(lstUsers.SelectedItem))


            lblPIDCred.Text = objLogins.CurrentObject.PID
            lblUserCred.Text = objLogins.CurrentObject.Username
            lblPassCred.Text = objLogins.CurrentObject.Password
            lblSecLevCred.Text = objLogins.CurrentObject.SecLevelID

            lblSecLevCred.Refresh()
            lblPIDCred.Refresh()
            lblPassCred.Refresh()
            lblUserCred.Refresh()

            If (objLogins.CurrentObject.PID = 1) Then
                btnChangeCredentials.Enabled = False
            Else
                btnChangeCredentials.Enabled = True
            End If

        Else
        End If
    End Sub
End Class