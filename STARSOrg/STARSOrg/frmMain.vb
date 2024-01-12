
Public Class frmMain
    Private RoleInfo As frmRole
    Private LoginPage As frmLogin
    Private Admin As frmAdmin
    Private Course As frmCourse
    Private Semester As frmSemester
    Private Member As frmMember
    Private anEvent As frmEvent
    Private RSVP As frmRSVP

#Region "Toolbars"
    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        Me.Hide()
        Course.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        Me.Hide()
        anEvent.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click

    End Sub

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click

    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        EndProgram()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        Me.Hide()
        Member.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        Me.Hide()
        RoleInfo.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        Me.Hide()
        RSVP.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        Me.Hide()
        Semester.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) Handles tsbTutor.Click

    End Sub

    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        Me.Hide()
        Admin.ShowDialog()
        Me.Show()
        PerformNextAction()
    End Sub
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


#End Region

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        RoleInfo = New frmRole
        LoginPage = New frmLogin
        Admin = New frmAdmin
        Course = New frmCourse
        Semester = New frmSemester
        Member = New frmMember
        anEvent = New frmEvent
        RSVP = New frmRSVP
        'MemberRole = New frmMemberRole



        LoginPage.ShowDialog()

        If modGlobal.LoginSuccessful = 0 Then
            Application.Exit()
        End If

#Region "Buttons"
        If modGlobal.SecurityLevel = "ADMIN" Then
            tsbMember.Enabled = True
            tsbRole.Enabled = True
            tsbEvent.Enabled = True
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = True
            tsbSemester.Enabled = True
            tsbTutor.Enabled = True
            tsbAdmin.Enabled = True
        End If

        If modGlobal.SecurityLevel = "GUEST" Then
            tsbRSVP.Enabled = True
        End If

        If modGlobal.SecurityLevel = "MEMBR" Then
            tsbRSVP.Enabled = True
        End If

        If modGlobal.SecurityLevel = "OFFIC" Then
            tsbCourse.Enabled = True
            tsbSemester.Enabled = True
            tsbRSVP.Enabled = True
            tsbEvent.Enabled = True
            tsbMember.Enabled = True
        End If
#End Region

        Try
            myDB.OpenDB()
        Catch ex As Exception
            MessageBox.Show("Unable to open database. Connection stirng=" & gstrConn, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EndProgram()
        End Try
    End Sub
    Private Sub EndProgram()
        'Close each form except main
        Dim f As Form
        Me.Cursor = Cursors.WaitCursor

        For Each f In Application.OpenForms
                If f.Name <> Me.Name Then
                    If Not f Is Nothing Then
                        f.Close()
                    End If
                End If
            Next

            'close database connection
            If Not objSQLConn Is Nothing Then
                objSQLConn.Close()
                objSQLConn.Dispose()
            End If

        Me.Cursor = Cursors.Default

        Application.Exit()

    End Sub

    Private Sub PerformNextAction()
        'get the next action selected on the child form, then simulate the click of the button
        Select Case intNextAction
            Case ACTION_COURSE
                tsbCourse.PerformClick()
            Case ACTION_EVENT
                tsbEvent.PerformClick()
            Case ACTION_HELP
                tsbHelp.PerformClick()
            Case ACTION_HOME
                tsbHome.PerformClick()
            Case ACTION_LOGOUT
                tsbLogout.PerformClick()
            Case ACTION_MEMBER
                tsbMember.PerformClick()
            Case ACTION_NONE
                tsbHome.PerformClick()
            Case ACTION_ROLE
                tsbRole.PerformClick()
            Case ACTION_RSVP
                tsbRSVP.PerformClick()
            Case ACTION_SEMESTER
                tsbSemester.PerformClick()
            Case ACTION_TUTOR
                tsbTutor.PerformClick()
            Case ACTION_ADMIN
                tsbAdmin.PerformClick()
            Case Else
                'do nothing
        End Select
    End Sub

End Class
