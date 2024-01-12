﻿Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmMemberReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Member As CMember

    Private Sub frmMemberReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rvpMemberReport.RefreshReport()
    End Sub
    Public Sub Display()
        Member = New CMember
        rvpMemberReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptMembers.rdlc"
        ds = New DataSet
        da = Member.GetReportData()
        da.Fill(ds)
        rvpMemberReport.LocalReport.DataSources.Add(New ReportDataSource("dsMembers", ds.Tables(0)))
        rvpMemberReport.SetDisplayMode(DisplayMode.PrintLayout)
        rvpMemberReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

End Class