<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSemesterReport
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
        Me.rpvSemesterReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvSemesterReport
        '
        Me.rpvSemesterReport.Location = New System.Drawing.Point(0, 0)
        Me.rpvSemesterReport.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rpvSemesterReport.Name = "rpvSemesterReport"
        Me.rpvSemesterReport.ServerReport.BearerToken = Nothing
        Me.rpvSemesterReport.Size = New System.Drawing.Size(1151, 652)
        Me.rpvSemesterReport.TabIndex = 0
        '
        'frmSemesterReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1151, 652)
        Me.Controls.Add(Me.rpvSemesterReport)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmSemesterReport"
        Me.Text = "frmSemesterReport"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvSemesterReport As Microsoft.Reporting.WinForms.ReportViewer
End Class
