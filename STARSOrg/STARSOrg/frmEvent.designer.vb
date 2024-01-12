<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvent))
        Me.grpEventType = New System.Windows.Forms.GroupBox()
        Me.cboEventType = New System.Windows.Forms.ComboBox()
        Me.grpEdit = New System.Windows.Forms.GroupBox()
        Me.cbSemester = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpEvents = New System.Windows.Forms.GroupBox()
        Me.lstEvents = New System.Windows.Forms.ListBox()
        Me.grpNewEvent = New System.Windows.Forms.GroupBox()
        Me.chkNew = New System.Windows.Forms.CheckBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHome = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMembers = New System.Windows.Forms.ToolStripButton()
        Me.tsbRoles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEvents = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRSVP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCourses = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSemesters = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbTutors = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLogout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAdmin = New System.Windows.Forms.ToolStripButton()
        Me.tslStatus = New System.Windows.Forms.StatusStrip()
        Me.ErrP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.grpEventType.SuspendLayout()
        Me.grpEdit.SuspendLayout()
        Me.grpEvents.SuspendLayout()
        Me.grpNewEvent.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.ErrP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator7
        '
        ToolStripSeparator7.AutoSize = False
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New System.Drawing.Size(10, 51)
        '
        'grpEventType
        '
        Me.grpEventType.Controls.Add(Me.cboEventType)
        Me.grpEventType.Location = New System.Drawing.Point(147, 185)
        Me.grpEventType.Margin = New System.Windows.Forms.Padding(2)
        Me.grpEventType.Name = "grpEventType"
        Me.grpEventType.Padding = New System.Windows.Forms.Padding(2)
        Me.grpEventType.Size = New System.Drawing.Size(230, 77)
        Me.grpEventType.TabIndex = 29
        Me.grpEventType.TabStop = False
        Me.grpEventType.Text = "Event Type"
        '
        'cboEventType
        '
        Me.cboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEventType.FormattingEnabled = True
        Me.cboEventType.Location = New System.Drawing.Point(7, 29)
        Me.cboEventType.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEventType.Name = "cboEventType"
        Me.cboEventType.Size = New System.Drawing.Size(194, 21)
        Me.cboEventType.TabIndex = 14
        '
        'grpEdit
        '
        Me.grpEdit.Controls.Add(Me.cbSemester)
        Me.grpEdit.Controls.Add(Me.Label3)
        Me.grpEdit.Controls.Add(Me.dtEnd)
        Me.grpEdit.Controls.Add(Me.txtLocation)
        Me.grpEdit.Controls.Add(Me.Label7)
        Me.grpEdit.Controls.Add(Me.dtStart)
        Me.grpEdit.Controls.Add(Me.Label6)
        Me.grpEdit.Controls.Add(Me.Label5)
        Me.grpEdit.Controls.Add(Me.btnCancel)
        Me.grpEdit.Controls.Add(Me.btnSave)
        Me.grpEdit.Controls.Add(Me.txtDesc)
        Me.grpEdit.Controls.Add(Me.txtID)
        Me.grpEdit.Controls.Add(Me.Label4)
        Me.grpEdit.Controls.Add(Me.Label2)
        Me.grpEdit.Location = New System.Drawing.Point(400, 112)
        Me.grpEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.grpEdit.Name = "grpEdit"
        Me.grpEdit.Padding = New System.Windows.Forms.Padding(2)
        Me.grpEdit.Size = New System.Drawing.Size(302, 296)
        Me.grpEdit.TabIndex = 27
        Me.grpEdit.TabStop = False
        Me.grpEdit.Text = "Edit Event"
        '
        'cbSemester
        '
        Me.cbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSemester.FormattingEnabled = True
        Me.cbSemester.Location = New System.Drawing.Point(84, 106)
        Me.cbSemester.Margin = New System.Windows.Forms.Padding(2)
        Me.cbSemester.Name = "cbSemester"
        Me.cbSemester.Size = New System.Drawing.Size(194, 21)
        Me.cbSemester.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 19)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Location"
        '
        'dtEnd
        '
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEnd.Location = New System.Drawing.Point(84, 84)
        Me.dtEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(85, 20)
        Me.dtEnd.TabIndex = 14
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(84, 38)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLocation.MaxLength = 15
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(197, 20)
        Me.txtLocation.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(7, 83)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 19)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "End Date"
        '
        'dtStart
        '
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(84, 61)
        Me.dtStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(85, 20)
        Me.dtStart.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Start Date"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(4, 105)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Semester"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(225, 252)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 19)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(85, 255)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 19)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(84, 144)
        Me.txtDesc.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDesc.MaxLength = 100
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(197, 85)
        Me.txtDesc.TabIndex = 4
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(84, 15)
        Me.txtID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtID.MaxLength = 15
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(197, 20)
        Me.txtID.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 144)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 19)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Description"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Event ID"
        '
        'grpEvents
        '
        Me.grpEvents.Controls.Add(Me.lstEvents)
        Me.grpEvents.Location = New System.Drawing.Point(147, 266)
        Me.grpEvents.Margin = New System.Windows.Forms.Padding(2)
        Me.grpEvents.Name = "grpEvents"
        Me.grpEvents.Padding = New System.Windows.Forms.Padding(2)
        Me.grpEvents.Size = New System.Drawing.Size(230, 142)
        Me.grpEvents.TabIndex = 23
        Me.grpEvents.TabStop = False
        Me.grpEvents.Text = "Event"
        '
        'lstEvents
        '
        Me.lstEvents.FormattingEnabled = True
        Me.lstEvents.Location = New System.Drawing.Point(4, 17)
        Me.lstEvents.Margin = New System.Windows.Forms.Padding(2)
        Me.lstEvents.Name = "lstEvents"
        Me.lstEvents.Size = New System.Drawing.Size(212, 121)
        Me.lstEvents.TabIndex = 0
        '
        'grpNewEvent
        '
        Me.grpNewEvent.Controls.Add(Me.chkNew)
        Me.grpNewEvent.Location = New System.Drawing.Point(147, 112)
        Me.grpNewEvent.Margin = New System.Windows.Forms.Padding(2)
        Me.grpNewEvent.Name = "grpNewEvent"
        Me.grpNewEvent.Padding = New System.Windows.Forms.Padding(2)
        Me.grpNewEvent.Size = New System.Drawing.Size(230, 58)
        Me.grpNewEvent.TabIndex = 26
        Me.grpNewEvent.TabStop = False
        Me.grpNewEvent.Text = "New Event"
        '
        'chkNew
        '
        Me.chkNew.AutoSize = True
        Me.chkNew.Location = New System.Drawing.Point(7, 20)
        Me.chkNew.Margin = New System.Windows.Forms.Padding(2)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(113, 17)
        Me.chkNew.TabIndex = 0
        Me.chkNew.Text = "Create New Event"
        Me.chkNew.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.tsbHome, Me.ToolStripSeparator4, Me.tsbMembers, ToolStripSeparator7, Me.tsbRoles, Me.ToolStripSeparator1, Me.tsbEvents, Me.ToolStripSeparator5, Me.tsbRSVP, Me.ToolStripSeparator10, Me.tsbCourses, Me.ToolStripSeparator6, Me.tsbSemesters, Me.ToolStripSeparator8, Me.tsbTutors, Me.ToolStripSeparator2, Me.tsbLogout, Me.ToolStripSeparator12, Me.tsbHelp, Me.ToolStripSeparator13, Me.ToolStripSeparator9, Me.tsbAdmin})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(800, 51)
        Me.ToolStrip2.TabIndex = 24
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 51)
        '
        'tsbHome
        '
        Me.tsbHome.AutoSize = False
        Me.tsbHome.BackgroundImage = CType(resources.GetObject("tsbHome.BackgroundImage"), System.Drawing.Image)
        Me.tsbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHome.Name = "tsbHome"
        Me.tsbHome.Size = New System.Drawing.Size(48, 48)
        Me.tsbHome.Text = "HOME"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 51)
        '
        'tsbMembers
        '
        Me.tsbMembers.AutoSize = False
        Me.tsbMembers.BackgroundImage = CType(resources.GetObject("tsbMembers.BackgroundImage"), System.Drawing.Image)
        Me.tsbMembers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMembers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMembers.Name = "tsbMembers"
        Me.tsbMembers.Size = New System.Drawing.Size(48, 48)
        Me.tsbMembers.Text = "MEMBERS"
        '
        'tsbRoles
        '
        Me.tsbRoles.AutoSize = False
        Me.tsbRoles.BackgroundImage = CType(resources.GetObject("tsbRoles.BackgroundImage"), System.Drawing.Image)
        Me.tsbRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRoles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRoles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRoles.Name = "tsbRoles"
        Me.tsbRoles.Size = New System.Drawing.Size(48, 48)
        Me.tsbRoles.Text = "ROLES"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(10, 51)
        '
        'tsbEvents
        '
        Me.tsbEvents.AutoSize = False
        Me.tsbEvents.BackgroundImage = CType(resources.GetObject("tsbEvents.BackgroundImage"), System.Drawing.Image)
        Me.tsbEvents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEvents.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEvents.Name = "tsbEvents"
        Me.tsbEvents.Size = New System.Drawing.Size(48, 48)
        Me.tsbEvents.Text = "EVENTS"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 51)
        '
        'tsbRSVP
        '
        Me.tsbRSVP.AutoSize = False
        Me.tsbRSVP.BackgroundImage = CType(resources.GetObject("tsbRSVP.BackgroundImage"), System.Drawing.Image)
        Me.tsbRSVP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRSVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRSVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRSVP.Name = "tsbRSVP"
        Me.tsbRSVP.Size = New System.Drawing.Size(48, 48)
        Me.tsbRSVP.Text = "RSVP"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 51)
        '
        'tsbCourses
        '
        Me.tsbCourses.AutoSize = False
        Me.tsbCourses.BackgroundImage = CType(resources.GetObject("tsbCourses.BackgroundImage"), System.Drawing.Image)
        Me.tsbCourses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbCourses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCourses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCourses.Name = "tsbCourses"
        Me.tsbCourses.Size = New System.Drawing.Size(48, 48)
        Me.tsbCourses.Text = "COURSES"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(10, 51)
        '
        'tsbSemesters
        '
        Me.tsbSemesters.AutoSize = False
        Me.tsbSemesters.BackgroundImage = CType(resources.GetObject("tsbSemesters.BackgroundImage"), System.Drawing.Image)
        Me.tsbSemesters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbSemesters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSemesters.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSemesters.Name = "tsbSemesters"
        Me.tsbSemesters.Size = New System.Drawing.Size(48, 48)
        Me.tsbSemesters.Text = "SEMESTERS"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(10, 51)
        '
        'tsbTutors
        '
        Me.tsbTutors.AutoSize = False
        Me.tsbTutors.BackgroundImage = CType(resources.GetObject("tsbTutors.BackgroundImage"), System.Drawing.Image)
        Me.tsbTutors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbTutors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbTutors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTutors.Name = "tsbTutors"
        Me.tsbTutors.Size = New System.Drawing.Size(48, 48)
        Me.tsbTutors.Text = "TUTORS"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 51)
        '
        'tsbLogout
        '
        Me.tsbLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbLogout.AutoSize = False
        Me.tsbLogout.BackgroundImage = CType(resources.GetObject("tsbLogout.BackgroundImage"), System.Drawing.Image)
        Me.tsbLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogout.Name = "tsbLogout"
        Me.tsbLogout.Size = New System.Drawing.Size(48, 48)
        Me.tsbLogout.Text = "LOGOUT"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator12.AutoSize = False
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(10, 51)
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.AutoSize = False
        Me.tsbHelp.BackgroundImage = CType(resources.GetObject("tsbHelp.BackgroundImage"), System.Drawing.Image)
        Me.tsbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(48, 48)
        Me.tsbHelp.Text = "HELP"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.AutoSize = False
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(10, 51)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator9.AutoSize = False
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(10, 51)
        '
        'tsbAdmin
        '
        Me.tsbAdmin.AutoSize = False
        Me.tsbAdmin.BackgroundImage = Global.STARSOrg.My.Resources.Resources.admin
        Me.tsbAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdmin.Name = "tsbAdmin"
        Me.tsbAdmin.Size = New System.Drawing.Size(48, 48)
        Me.tsbAdmin.Text = "ADMIN"
        '
        'tslStatus
        '
        Me.tslStatus.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tslStatus.Location = New System.Drawing.Point(0, 428)
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.tslStatus.Size = New System.Drawing.Size(800, 22)
        Me.tslStatus.TabIndex = 28
        Me.tslStatus.Text = "StatusStrip1"
        '
        'ErrP
        '
        Me.ErrP.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(776, 39)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "EVENTS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpEventType)
        Me.Controls.Add(Me.grpEdit)
        Me.Controls.Add(Me.grpEvents)
        Me.Controls.Add(Me.grpNewEvent)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.tslStatus)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmEvent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.grpEventType.ResumeLayout(False)
        Me.grpEdit.ResumeLayout(False)
        Me.grpEdit.PerformLayout()
        Me.grpEvents.ResumeLayout(False)
        Me.grpNewEvent.ResumeLayout(False)
        Me.grpNewEvent.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.ErrP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpEventType As GroupBox
    Friend WithEvents cboEventType As ComboBox
    Friend WithEvents grpEdit As GroupBox
    Friend WithEvents cbSemester As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtEnd As DateTimePicker
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtStart As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grpEvents As GroupBox
    Friend WithEvents lstEvents As ListBox
    Friend WithEvents grpNewEvent As GroupBox
    Friend WithEvents chkNew As CheckBox
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbHome As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbMembers As ToolStripButton
    Friend WithEvents tsbRoles As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbEvents As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbRSVP As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsbCourses As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbSemesters As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsbTutors As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbHelp As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents tsbLogout As ToolStripButton
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tslStatus As StatusStrip
    Friend WithEvents ErrP As ErrorProvider
    Friend WithEvents tsbAdmin As ToolStripButton
    Friend WithEvents Label1 As Label
End Class
