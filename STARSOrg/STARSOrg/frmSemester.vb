Imports System.Data.SqlClient
Public Class frmSemester

    Private objSemesters As CSemesters
    Private blnClearing As Boolean
    Private blnReloading As Boolean
    Private SemesterReport As frmSemesterReport

#Region "Toolbar Role"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter,
        tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbLogOut.MouseEnter, tsbMember.MouseEnter,
        tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbAdmin.MouseEnter
        'need this because each button does not have an image for its image property, but in their background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub
    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave,
        tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbLogOut.MouseLeave, tsbMember.MouseLeave,
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

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogOut.Click
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

    Private Sub frmCourses_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSemesters = New CSemesters
    End Sub

    Private Sub LoadSemesters()
        Dim objReader As SqlDataReader
        lstSemesters.Items.Clear()
        Try
            objReader = objSemesters.GetAllSemesters
            Do While objReader.Read
                lstSemesters.Items.Add(objReader.Item("SemesterID"))
            Loop
            objReader.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap here

        End Try
        If objSemesters.CurrentObject.semesterID <> "" Then
            lstSemesters.SelectedIndex = lstSemesters.FindStringExact(objSemesters.CurrentObject.semesterID)
        End If
    End Sub

    Private Sub frmSemesters_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadSemesters()
        grpModify.Enabled = False
    End Sub

    Private Sub lstSemesters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSemesters.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If Not blnReloading Then
            'tslStatus.Text = ""
        End If
        If lstSemesters.SelectedIndex = -1 Then 'nothing to do
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpModify.Enabled = True
    End Sub

    Private Sub LoadSelectedRecord()
        Try
            objSemesters.GetSemesterByID(lstSemesters.SelectedItem.ToString)
            With objSemesters.CurrentObject
                txtSemesterID.Text = .semesterID
                txtSemesterDescription.Text = .semesterDescription
            End With
        Catch ex As Exception
            MessageBox.Show("Error Loading Semester Values: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkNew_Click(sender As Object, e As EventArgs) Handles chkNew.Click
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            'tslStatus.Text=""
            txtSemesterID.Clear()
            txtSemesterDescription.Clear()
            lstSemesters.SelectedIndex = -1
            grpSemesters.Enabled = False
            grpModify.Enabled = True
            objSemesters.CreateNewSemester()
            txtSemesterID.Focus()
        Else
            grpSemesters.Enabled = True
            grpModify.Enabled = False
            objSemesters.CurrentObject.IsNewSemester = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        'tslStatus.Text=""
        'first do your validation
        '---------add your validation code here-----------
        If Not ValidateTextBoxLength(txtSemesterID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtSemesterDescription, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objSemesters.CurrentObject
            .semesterID = txtSemesterID.Text
            .semesterDescription = txtSemesterDescription.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objSemesters.Save
            If intResult = 1 Then
                'tslStatus.Text = "Semester record saved"
            End If
            If intResult = -1 Then
                MessageBox.Show("Semester ID must be unique. Unable to save semester record", "program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save semester record: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadSemesters()
        chkNew.Checked = False
        grpModify.Enabled = True
    End Sub

    Private Sub txtAll_GotFocus(sender As Object, e As EventArgs) Handles txtSemesterID.GotFocus, txtSemesterDescription.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtAll_LostFocus(sender As Object, e As EventArgs) Handles txtSemesterID.LostFocus, txtSemesterDescription.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        SemesterReport = New frmSemesterReport
        If lstSemesters.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        SemesterReport.Display()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        'tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstSemesters.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else 'disable edit area - nothing was currently selected
            grpModify.Enabled = False
        End If
        blnClearing = False
        objSemesters.CurrentObject.IsNewSemester = False
        grpSemesters.Enabled = True
    End Sub
End Class