Imports System.Data.SqlClient
Public Class frmRSVP
    Private objRSVP As CRSVPS
    Private objEvents As CEvents
    Private blnClearing As Boolean
    Private blnReloading As Boolean
    Private RSVPReport As frmRepot

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
        'no action needed - already on the RSVP form
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
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub



#End Region


    Private Sub frmRSVP_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
        objRSVP = New CRSVPS
    End Sub

    Private Sub frmRSVP_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        clearScreenControls(Me)
        loadThings()
        'grpEdit.Enabled = False

    End Sub
    Private Sub loadThings()
        Dim objReader As SqlDataReader
        txtEmail.Clear()
        txtFName.Clear()
        txtLName.Clear()


        If cboEvent.Items.Count = 0 Then
            Try
                objReader = objEvents.GetAllEvents
                Do While objReader.Read
                    cboEvent.Items.Add(objReader.Item("EventID"))
                Loop
                objReader.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        lstRSVP.Items.Clear()

        Try
            objReader = objRSVP.GetAllERSVPs
            Do While objReader.Read
                    lstRSVP.Items.Add(objReader.Item("EventID"))
                Loop
                objReader.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



    End Sub

    Private Sub loadselectedrsvp()
        txtEmail.Text = ""
        txtFName.Text = ""
        txtLName.Text = ""

        Try
            objRSVP.GetRSVPByEventID(cboEvent.SelectedItem.ToString)

            With objRSVP.CurrentObject
                txtEmail.Text = .Email
                txtFName.Text = .FName
                txtLName.Text = .LName
            End With
        Catch ex As Exception
            MessageBox.Show("" & ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        grpEdit.Enabled = True
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnerror As Boolean
        tslStatus.Text = ""
        If Not validateTextBoxLength(txtEmail, ErrP) Then
            ErrP.SetError(txtEmail, "This field can't be empty")
            blnerror = True
        End If
        If Not validateTextBoxLength(txtFName, ErrP) Then
            ErrP.SetError(txtFName, "This field can't be empty")
            blnerror = True
        End If
        If Not validateTextBoxLength(txtLName, ErrP) Then
            ErrP.SetError(txtLName, "This field can't be empty")
            blnerror = True
        End If
        If blnerror Then
            Exit Sub
        End If
        With objRSVP.CurrentObject
            .EventID = cboEvent.Text
            .Email = txtEmail.Text
            .FName = txtFName.Text
            .LName = txtLName.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objRSVP.Save
            If intResult = -1 Then
            Else
                tslStatus.Text = "Record saved"
            End If
        Catch ex As Exception
            MessageBox.Show("" & ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default

        loadThings()
    End Sub
    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs)
        grpEdit.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        'chkNew.Checked = False
        ErrP.Clear()
        'grpEdit.Enabled = False
        blnClearing = False
        objRSVP.CurrentObject.IsNewRSVP = False
        loadThings()

    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim RSVPReport As New frmRepot
        If lstRSVP.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        RSVPReport.display()
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub cboEvent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent.SelectedIndexChanged
    '    If blnClearing Then
    '        Exit Sub
    '    End If
    '    If Not blnReloading Then
    '        tslStatus.Text = ""
    '    End If
    '    If cboEvent.SelectedIndex = -1 Then
    '        Exit Sub
    '    End If
    '    'chkNew.Checked = False
    '    loadselectedrsvp()
    '    grpEdit.Enabled = True
    'End Sub

    'Private Sub loadSelectedEvent(strSelected As String)
    '    Try
    '        objEvents.GetEventByEventID(strSelected)
    '        With objRSVP.CurrentObject
    '            cboEvent.SelectedItem = .EventID
    '            txtEmail.Text = .Email
    '            txtFName.Text = .FName
    '            txtLName.Text = .LName
    '        End With

    '    Catch ex As Exception
    '        MessageBox.Show("Unable to save the Event record " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
