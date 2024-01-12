Imports System.Data.SqlClient
Public Class frmEvent
    Private objEvents As CEvents
    Private blnClearing As Boolean
    Private blnReloading As Boolean
#Region "Toolbar Role"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourses.MouseEnter,
        tsbEvents.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogout.MouseEnter, tsbMembers.MouseEnter,
        tsbRoles.MouseEnter, tsbRSVP.MouseEnter, tsbSemesters.MouseEnter, tsbTutors.MouseEnter, tsbAdmin.MouseEnter
        'need this because each button does not have an image for its image property, but in their background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub
    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourses.MouseLeave,
        tsbEvents.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogout.MouseLeave, tsbMembers.MouseLeave,
        tsbRoles.MouseLeave, tsbRSVP.MouseLeave, tsbSemesters.MouseLeave, tsbTutors.MouseLeave, tsbAdmin.MouseLeave
        'need this because each button does not have an image for its image property, but in their background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourses.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvents.Click
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

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMembers.Click
        'no action needed - already on the MEMBER form
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRoles.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemesters.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) Handles tsbTutors.Click
        intNextAction = ACTION_TUTOR
        Me.Hide()
    End Sub

    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub



#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        grpEdit.Enabled = False
        loadStuff()
    End Sub
    Private Sub loadStuff()
        Dim objReader As SqlDataReader

        If lstEvents.Items.Count = 0 Then
            objReader = objEvents.GetAllEvents
            Try
                While objReader.Read
                    lstEvents.Items.Add(objReader.Item("EventID"))
                End While
                objReader.Close()
            Catch ex As Exception
                MessageBox.Show("Error running database because: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If





        If cboEventType.Items.Count = 0 Then
            Try
                objReader = objEvents.GetAllEventTypes
                While objReader.Read
                    cboEventType.Items.Add(objReader.Item("EventTypeID"))
                End While
                objReader.Close()
            Catch ex As Exception
                MessageBox.Show("Error running database because: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        objReader = objEvents.getAllSemesters
        Try
            While objReader.Read
                cbSemester.Items.Add(objReader.Item("SemesterID"))
            End While
            objReader.Close()
        Catch ex As Exception
            MessageBox.Show("Error running database because: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If objEvents.CurrentObject.EventID.ToString <> "" Then
            lstEvents.SelectedIndex = lstEvents.FindStringExact(objEvents.CurrentObject.EventID)
        End If
    End Sub
    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If chkNew.Checked = True Then
            clean()
            grpEdit.Enabled = True
        Else
            grpEvents.Enabled = True
            grpEdit.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        If Not ValidateTextBoxLength(txtDesc, ErrP) Then
            ErrP.SetError(txtDesc, "This field is needed")
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLocation, ErrP) Then
            ErrP.SetError(txtLocation, "This field can't be empty")
            blnErrors = True
        End If
        If Not ValidateCombo(cboEventType, ErrP) Then
            ErrP.SetError(cboEventType, "You must make a selection here")
            blnErrors = True
        End If
        If Not ValidateCombo(cbSemester, ErrP) Then
            ErrP.SetError(cbSemester, "You must make a selection here")
            blnErrors = True
        End If
        If dtStart.Value < DateTime.Today Then
            ErrP.SetIconAlignment(dtStart, ErrorIconAlignment.MiddleLeft)
            ErrP.SetError(dtStart, "You must enter a valid selection here")
            blnErrors = True
        End If
        If dtEnd.Value < DateTime.Today Then
            ErrP.SetIconAlignment(dtEnd, ErrorIconAlignment.MiddleLeft)
            ErrP.SetError(dtEnd, "You must enter a valid selection here")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objEvents.CurrentObject
            .EventID = txtID.Text
            .EventDescription = txtDesc.Text
            .Location = txtLocation.Text
            .SemesterID = cbSemester.Text
            .EventType = cboEventType.Text
            .StartDate = dtStart.Value
            .EndDate = dtEnd.Value
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objEvents.Save
        Catch ex As Exception
            MessageBox.Show("Unable to save the Event record " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If intResult <> -1 Then
            MessageBox.Show("Event saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lstEvents.Items.Clear()
            loadStuff()
        End If

        Me.Cursor = Cursors.Default
        blnReloading = True
        loadSelectedEvent(objEvents.CurrentObject.EventID.ToString)
        chkNew.Checked = False
        grpEvents.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clean()
    End Sub
    Private Sub clean()
        txtID.Clear()
        txtDesc.Clear()
        cboEventType.SelectedIndex = -1
        txtLocation.Clear()
        cbSemester.SelectedIndex = -1
        dtStart.Value = DateTime.Today
        dtEnd.Value = DateTime.Today
    End Sub
    Private Sub lstEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEvents.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If Not blnReloading Then
            tslStatus.Text = ""
        End If
        If lstEvents.SelectedIndex = -1 Then
            Exit Sub
        End If
        chkNew.Checked = False
        loadSelectedEvent(lstEvents.SelectedItem.ToString)
        grpEdit.Enabled = True
    End Sub
    Private Sub loadSelectedEvent(strSelected As String)
        Try
            objEvents.GetEventByEventID(strSelected)
            With objEvents.CurrentObject
                txtID.Text = .EventID
                txtDesc.Text = .EventDescription
                txtLocation.Text = .Location
                dtStart.Value = .StartDate
                dtEnd.Value = .EndDate
                cboEventType.SelectedItem = .EventType
                cbSemester.SelectedItem = .SemesterID
            End With
        Catch ex As Exception
            MessageBox.Show("Unable to save the Event record " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
