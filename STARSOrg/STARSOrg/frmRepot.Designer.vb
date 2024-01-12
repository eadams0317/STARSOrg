<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepot
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
        Me.rpvRSVPReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvRSVPReport
        '
        Me.rpvRSVPReport.AutoSize = True
        Me.rpvRSVPReport.Location = New System.Drawing.Point(0, 0)
        Me.rpvRSVPReport.Name = "rpvRSVPReport"
        Me.rpvRSVPReport.ServerReport.BearerToken = Nothing
        Me.rpvRSVPReport.Size = New System.Drawing.Size(396, 246)
        Me.rpvRSVPReport.TabIndex = 0
        '
        'frmRepot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 357)
        Me.ControlBox = False
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmRepot"
        Me.Text = "RSVP Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvRSVPReport As Microsoft.Reporting.WinForms.ReportViewer
End Class
