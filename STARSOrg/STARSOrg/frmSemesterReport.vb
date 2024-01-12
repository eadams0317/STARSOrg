Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmSemesterReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Semester As CSemester
    Private Sub frmCourseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvSemesterReport.RefreshReport()
        Me.rpvSemesterReport.RefreshReport()
    End Sub


    Public Sub Display()
        Semester = New CSemester
        rpvSemesterReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "SemestersReport\rptSemestersReport.rdlc"
        ds = New DataSet
        da = Semester.GetReportData
        da.Fill(ds)
        rpvSemesterReport.LocalReport.DataSources.Add(New ReportDataSource("dsSemester", ds.Tables(0)))
        rpvSemesterReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvSemesterReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub
End Class