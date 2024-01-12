Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmRepot
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private RSVP As CRSVP

    Private Sub frmRepot_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.rpvRSVPReport.RefreshReport()
    End Sub
    Public Sub display()
        RSVP = New CRSVP
        rpvRSVPReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptRSVP.rdlc"
        ds = New DataSet
        da = RSVP.GetReportData()
        da.Fill(ds)
        rpvRSVPReport.LocalReport.DataSources.Add(New ReportDataSource("dsRSVP", ds.Tables(0)))
        rpvRSVPReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvRSVPReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()

    End Sub
End Class