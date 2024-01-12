Imports System.Data.SqlClient
Module modDB
    'connection string for LocalDB
    'MIGHT NEED TO CHANGE PATH IF ACCESSED ON DIFFERENT SYSTEM
    'Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\buffalo.cs.fiu.edu\homes\Documents\Windows Programming for IT Majors\STARSOrg\STARSDB.mdf;Integrated Security=True"
    'Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Windows Programming\STARSOrg\STARSDB.mdf;Integrated Security=True"
    'Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Windows Programming\STARSOrg\STARSDB.mdf;Integrated Security=True"
    Public gstrConn As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Windows Programming\STARSOrg\STARSDB.mdf;Integrated Security=True"

    'Database objects
    Public objSQLConn As SqlConnection
    Public objSQLCommand As SqlCommand
End Module
