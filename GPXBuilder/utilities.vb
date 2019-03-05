Imports System.Environment
Imports System.Text
Imports System.IO
Imports System.Net
Imports Microsoft.Win32
Imports VB = Microsoft.VisualBasic
Imports MetadataExtractor
Imports MetadataExtractor.Formats.Exif

Public Class utilities
    Public Shared dtab As DataTable
    'Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer


    Public Shared permalink As String

    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub


    Public Shared Function GetPBTickSize(fileCount As Integer)
        Return fileCount \ 100
    End Function
    Public Shared Sub initGPX()
        Dim strFile As String = frmMain.FolderBrowserDialog1.SelectedPath & "\waypoints.gpx"
        Dim sw As StreamWriter
        Try
            sw = File.CreateText(strFile)
            sw.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            sw.WriteLine("<gpx version=""1.0"">")
            sw.WriteLine("<name>75CentralPhotography Locations</name>")

            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try

    End Sub
    Public Shared Sub initTrack()
        Dim strFile As String = Globals.SaveLocation & "\tracks.gpx"

        Dim sw As StreamWriter

        Try

            sw = File.CreateText(strFile)
            sw.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            sw.WriteLine("<gpx version=""1.0"">")
            ' sw.WriteLine("<name>75CentralPhotography Locations</name>")

            ' sw.WriteLine("<trk><name>75CentralPhotography</name><number>1</number><trkseg>")
            sw.WriteLine("<trk><number>1</number><trkseg>")

            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Sub writeWaypoint(lat As String, lon As String, n As String, fname As String)
        Dim strFile As String = Globals.SaveLocation & "\waypoints.gpx"
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)

            sw.WriteLine("<wpt lat=""" & lat & """ lon=""" & lon & """>")
            sw.WriteLine("<name>" & fname & "</name>")
            sw.WriteLine("</wpt>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Sub writetrack(lat As String, lon As String, n As String, dt As DateTime, fname As String)
        Dim strFile As String = Globals.SaveLocation & "\tracks.gpx"
        Dim dtS As String = dt.ToString("yyyy-MM-ddTHH:mm:ssZ")
        If dtS = "0001-01-01T00:00:00Z" Then
            Return

        End If
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)

            sw.WriteLine("<trkpt lat=""" & lat & """ lon=""" & lon & """>")
            sw.WriteLine("<ele>" & n & "</ele>")
            sw.WriteLine("<name>" & fname & "</name>")
            sw.WriteLine("<time>" & dtS & "</time>")
            sw.WriteLine("</trkpt>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Shared Sub CloseGPX()
        Dim strFile As String = Globals.SaveLocation & "\waypoints.gpx"
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)

            sw.WriteLine("</gpx>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Shared Sub CloseTracks()
        Dim strFile As String = Globals.SaveLocation & "\tracks.gpx"
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)
            sw.WriteLine("</trkseg></trk>")
            sw.WriteLine("</gpx>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub

    Public Sub LogExifErrors(errormessage As String)
        Dim strFile As String = Globals.SaveLocation & "\exiferrors.txt"
        Dim sw As StreamWriter
        Try
            If (Not File.Exists(strFile)) Then
                sw = File.CreateText(strFile)
                sw.WriteLine("Start Error Log for today")
            Else
                sw = File.AppendText(strFile)
            End If
            sw.WriteLine(errormessage)
            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
End Class
