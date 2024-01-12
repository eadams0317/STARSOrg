Imports System.Data.SqlClient

Public Class frmCourse
    Private objCourses As CCourses
    Private blnClearing As Boolean
    Private blnReloading As Boolean
    Private CourseReport As frmCourseReport

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

    Private Sub frmCourses_Load(sender As Object, e As EventArgs) Handles Me.Load
        objCourses = New CCourses
#Region "Buttons"
        If modGlobal.SecurityLevel = "ADMIN" Then
            tsbMember.Enabled = True
            tsbRole.Enabled = True
            tsbEvent.Enabled = True
            tsbRSVP.Enabled = True
            tsbCourse.Enabled = True
            tsbSemester.Enabled = True
            tsbTutor.Enabled = True
            'tsbAdmin.Enabled = True
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
    End Sub

    Private Sub LoadCourses()
        Dim objReader As SqlDataReader
        lstCourses.Items.Clear()
        Try
            objReader = objCourses.GetAllCourses
            Do While objReader.Read
                lstCourses.Items.Add(objReader.Item("CourseID"))
            Loop
            objReader.Close()
        Catch ex As Exception
            'could have CDB throw the error and trap here

        End Try
        If objCourses.CurrentObject.CourseID <> "" Then
            lstCourses.SelectedIndex = lstCourses.FindStringExact(objCourses.CurrentObject.CourseID)
        End If
    End Sub

    Private Sub frmCourses_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadCourses()
        grpModify.Enabled = False
    End Sub

    Private Sub lstCourses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCourses.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If Not blnReloading Then
            tslStatus.Text = ""
        End If
        If lstCourses.SelectedIndex = -1 Then 'nothing to do
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpModify.Enabled = True
    End Sub

    Private Sub LoadSelectedRecord()
        Try
            objCourses.GetCourseByID(lstCourses.SelectedItem.ToString)
            With objCourses.CurrentObject
                txtCourseID.Text = .CourseID
                txtCourseName.Text = .CourseName
            End With
        Catch ex As Exception
            MessageBox.Show("Error Loading Course Values: " & ex.ToString, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkNew_Click(sender As Object, e As EventArgs) Handles chkNew.Click
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            'tslStatus.Text=""
            txtCourseID.Clear()
            txtCourseName.Clear()
            lstCourses.SelectedIndex = -1
            grpCourses.Enabled = False
            grpModify.Enabled = True
            objCourses.CreateNewCourse()
            txtCourseID.Focus()
        Else
            grpCourses.Enabled = True
            grpModify.Enabled = False
            objCourses.CurrentObject.IsNewCourse = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        'tslStatus.Text=""
        'first do your validation
        '---------add your validation code here-----------
        If Not ValidateTextBoxLength(txtCourseID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtCourseName, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objCourses.CurrentObject
            .CourseID = txtCourseID.Text
            .CourseName = txtCourseID.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objCourses.Save
            If intResult = 1 Then
                'tslStatus.Text = "Course record saved"
            End If
            If intResult = -1 Then
                MessageBox.Show("Course ID must be unique. Unable to save Course record", "program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Course record: " & ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadCourses()
        chkNew.Checked = False
        grpModify.Enabled = True
    End Sub

    Private Sub txtAll_GotFocus(sender As Object, e As EventArgs) Handles txtCourseName.GotFocus, txtCourseID.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtAll_LostFocus(sender As Object, e As EventArgs) Handles txtCourseName.LostFocus, txtCourseID.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        CourseReport = New frmCourseReport
        If lstCourses.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CourseReport.Display()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        'tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstCourses.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else 'disable edit area - nothing was currently selected
            grpModify.Enabled = False
        End If
        blnClearing = False
        objCourses.CurrentObject.IsNewCourse = False
        grpCourses.Enabled = True
    End Sub
End Class