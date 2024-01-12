<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCourseReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.rpvCourseReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvCourseReport
        '
        Me.rpvCourseReport.AutoSize = True
        Me.rpvCourseReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpvCourseReport.Location = New System.Drawing.Point(0, 0)
        Me.rpvCourseReport.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rpvCourseReport.Name = "rpvCourseReport"
        Me.rpvCourseReport.ServerReport.BearerToken = Nothing
        Me.rpvCourseReport.Size = New System.Drawing.Size(1098, 683)
        Me.rpvCourseReport.TabIndex = 0
        '
        'frmCourseReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1098, 683)
        Me.Controls.Add(Me.rpvCourseReport)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmCourseReport"
        Me.Text = "frmCourseReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rpvCourseReport As Microsoft.Reporting.WinForms.ReportViewer
End Class
