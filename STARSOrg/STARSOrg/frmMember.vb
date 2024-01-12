Imports System.Data.SqlClient
Public Class frmMember
    Private objMembers As CMembers
    Private blnClearing As Boolean
    Private blnReloading As Boolean

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



#Region "Textboxes"
    Private Sub TxtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtPID.GotFocus, txtFName.GotFocus, txtLName.GotFocus, txtMI.GotFocus, txtEmail.GotFocus, txtPhone.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub
    Private Sub TxtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPID.LostFocus, txtFName.LostFocus, txtLName.LostFocus, txtMI.LostFocus, txtEmail.LostFocus, txtPhone.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region
    Private Sub LoadMembers()
        Dim objDR As SqlDataReader
        lstMembers.Items.Clear()
        picMember.Image = Nothing
        Try
            objDR = objMembers.GetAllMembers()
            'Console.WriteLine(objDR)
            Do While objDR.Read
                If (objDR.Item("PID")) <> "0000001" And (objDR.Item("PID")) <> "9999999" Then
                    lstMembers.Items.Add(objDR.Item("PID"))
                End If
            Loop
            objDR.Close()
        Catch ex As Exception
            'could have CDB throw the error and track it here
        End Try
        If objMembers.CurrentObject.PID <> "" Then
            lstMembers.SelectedIndex = lstMembers.FindStringExact(objMembers.CurrentObject.PID)
        End If
        blnReloading = False
    End Sub
    Private Sub frmMember_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers

        If cboSemester.Items.Count = 0 Then
            cboRole.Items.Add("")
            cboRole.Items.Add("Admin")
            'cboRole.Items.Add("Guest")
            cboRole.Items.Add("Member")
            cboRole.Items.Add("Officer")
            cboRole.Items.Add("Tutor - Paid")
            cboRole.Items.Add("Tutor - Vol")

            cboSemester.Items.Add("")
            cboSemester.Items.Add("fa16")
            cboSemester.Items.Add("fa17")
            cboSemester.Items.Add("fa18")
            cboSemester.Items.Add("sp17")
            cboSemester.Items.Add("su17")
        End If


    End Sub
    Private Sub frmMember_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        LoadMembers()
        grpEdit.Enabled = False
    End Sub

    Private Sub LoadSelectedRecord()
        Try

            objMembers.GetMemberByPID(lstMembers.SelectedItem.ToString)
            With objMembers.CurrentObject
                txtPID.Text = .PID
                txtFName.Text = .FName
                txtLName.Text = .LName
                txtMI.Text = .MI
                txtEmail.Text = .Email
                txtPhone.Text = .Phone
                txtPhotoPath.Text = .PhotoPath
                'picMember.SizeMode = PictureBoxSizeMode.AutoSize
                picMember.Load(.PhotoPath)

            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Member values:" & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            picMember.Image = Nothing
        End Try
    End Sub

    Private Sub lstMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            tslStatus.Text = ""
            Exit Sub
        End If
        If lstMembers.SelectedIndex = -1 Then
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpEdit.Enabled = True
    End Sub
    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            tslStatus.Text = ""
            txtPID.Clear()
            txtFName.Clear()
            txtLName.Clear()
            txtMI.Clear()
            txtEmail.Clear()
            txtPhone.Clear()
            txtPhotoPath.Clear()
            picMember.Image = Nothing
            lstMembers.SelectedIndex = -1
            grpMembers.Enabled = False
            grpEdit.Enabled = True
            txtPID.Focus()
            objMembers.CreateNewMember()

            cboRole.Items.Remove("Officer")
            cboRole.Items.Remove("Admin")


        Else
            grpMembers.Enabled = True
            grpEdit.Enabled = False
            objMembers.CurrentObject.IsNewMember = False

            cboRole.Items.Add("Admin")
            cboRole.Items.Add("Officer")


        End If

    End Sub
    'Private Sub lstMembers_Click(sender As Object, e As EventArgs) Handles lstMembers.Click

    'End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim MemberReport = New frmMemberReport
        If lstMembers.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        MemberReport.Display()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Me.OpenFileDialog1.ShowDialog()
        Dim mp As String
        mp = Me.OpenFileDialog1.FileName
        Try
            Me.picMember.Image = Image.FromFile(mp)
        Catch ex As Exception

        End Try

        txtPhotoPath.Text = mp
    End Sub

    Private Sub btnCancel_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles btnCancel.ContextMenuStripChanged
        blnClearing = True
        tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstMembers.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up form
        Else
            grpEdit.Enabled = False
        End If
        blnClearing = False
        objMembers.CurrentObject.IsNewMember = False
        grpMembers.Enabled = True


    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        tslStatus.Text = ""
        '---- add your validation code here ----
        If Not ValidateTextBoxLength(txtPID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtFName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtMI, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPhone, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPhotoPath, errP) Then
            blnErrors = True
        End If

        'Validates a new member has a role and semester
        If chkNew.Checked = True Then
            If cboRole.SelectedIndex > (-1) And cboSemester.SelectedIndex > (-1) Then
            Else
                MessageBox.Show("New Members must have a Role and Semester", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                blnErrors = True
            End If
        End If

        If blnErrors Then
            Exit Sub
        End If

        With objMembers.CurrentObject
            .PID = txtPID.Text
            .FName = txtFName.Text
            .LName = txtLName.Text
            .MI = txtMI.Text
            .Email = txtEmail.Text
            .Phone = txtPhone.Text
            .PhotoPath = txtPhotoPath.Text

        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objMembers.Save

            If intResult = -1 Then 'role ID was not unique when adding a new record
                MessageBox.Show("RoleID must be unique. Unable to save Role record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"

            Else
                '***'
                tslStatus.Text = "Role record saved"
                MessageBox.Show("Member table updated", "Role record saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If cboSemester.SelectedItem <> "" And cboRole.SelectedItem <> "" Then
                    MessageBox.Show("Member roles table updated", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'add role and semester info to member role
                    Dim params As New ArrayList
                    params.Add(New SqlParameter("@PID", objMembers.CurrentObject.PID))
                    params.Add(New SqlParameter("@RoleID", cboRole.SelectedItem.ToString))
                    params.Add(New SqlParameter("@SemesterID", cboSemester.SelectedItem.ToString))
                    myDB.ExecSP("sp_saveMemberRole", params)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Unable to save Role record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            tslStatus.Text = "Error"
        End Try




        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadMembers() 'reload so that a newly saved record will appear in list

        Try
            picMember.Image = Image.FromFile(txtPhotoPath.Text)
        Catch ex As Exception
            MessageBox.Show("Unable to load picture " & ex.ToString, "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        chkNew.Checked = False
        grpMembers.Enabled = True 'in case it was disabled for a new record
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearScreenControls(grpEdit)

        If lstMembers.SelectedIndex <> -1 Then
            grpEdit.Enabled = True
        End If

        grpEdit.Enabled = False
        chkNew.Checked = False

        picMember.Image = Nothing
        lstMembers.SelectedIndex = -1
    End Sub
End Class