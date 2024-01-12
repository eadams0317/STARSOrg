<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberReport
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
        Me.rvpMemberReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvpMemberReport
        '
        Me.rvpMemberReport.AutoSize = True
        Me.rvpMemberReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvpMemberReport.Location = New System.Drawing.Point(0, 0)
        Me.rvpMemberReport.Name = "rvpMemberReport"
        Me.rvpMemberReport.ServerReport.BearerToken = Nothing
        Me.rvpMemberReport.Size = New System.Drawing.Size(800, 450)
        Me.rvpMemberReport.TabIndex = 0
        '
        'frmMemberReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.rvpMemberReport)
        Me.Name = "frmMemberReport"
        Me.Text = "frmMemberReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rvpMemberReport As Microsoft.Reporting.WinForms.ReportViewer
End Class
