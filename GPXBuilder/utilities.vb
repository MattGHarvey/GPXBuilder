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
    Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

    'Declare two constant  
    Private Const SETDESKWALLPAPER = 20
    Private Const UPDATEINIFILE = &H1
    Public Shared permalink As String
    Public Function getAppDataPath()
        ' Get the path to the Application Data folder
        Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    End Function
    Public Function checkfolderexists(path As String) As Boolean
        path = path & "\75Central"
        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        Return True

    End Function
    Public Function createRandomFilename() As String
        Dim r As New Random
        Return RandomString(r) & ".jpg"

    End Function
    Function RandomString(r As Random)

        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
    Public Function setWallPaper(imagefile As String) As Boolean
        SystemParametersInfo(SETDESKWALLPAPER, 0, imagefile, UPDATEINIFILE)
        Return True
    End Function
    
    Private Function tempPB(url As String) As Bitmap 'for testing only -
        Dim tClient As WebClient = New WebClient

        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url)))
        'Form1.PictureBox1.Image = tImage
        Return tImage



    End Function
    Private Sub ClearAppData(apppath As String)
        Dim directoryName As String = apppath & "\75Central\"
        For Each deleteFile In System.IO.Directory.GetFiles(directoryName, "*.jpg", SearchOption.TopDirectoryOnly)
            File.Delete(deleteFile)
        Next
    End Sub
    Private Sub setBG(url As String)
        Dim tClient As WebClient = New WebClient

        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url)))
        ' Dim sys As New System
        'sys.ChangeBackground(tImage, True)

    End Sub
    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub
    Public Shared Sub exMeta(iPath As String, i As Integer)
        Dim directories As IEnumerable(Of MetadataExtractor.Directory) = ImageMetadataReader.ReadMetadata(iPath)
        Dim directory = directories.OfType(Of ExifSubIfdDirectory)().FirstOrDefault()
        Dim gpsdirectory = directories.OfType(Of GpsDirectory)().FirstOrDefault()
        Dim latitude = Nothing
        Dim datetime = Nothing
        Dim Longitude = Nothing
        Dim u As New utilities()
        If directory IsNot Nothing Then
            If directory.TryGetDateTime(ExifDirectoryBase.TagDateTimeOriginal, datetime) Then
                Console.WriteLine("datetime" & datetime)
            End If
        Else
            u.LogExifErrors("exifmissing: " & iPath)
        End If
        If gpsdirectory IsNot Nothing Then
            gpsdirectory.GetGeoLocation()
            latitude = gpsdirectory.GetGeoLocation.Latitude
            Longitude = gpsdirectory.GetGeoLocation.Longitude
            '  If directory.TryGetDateTime(GpsDirectory.TagLatitude, latitude) Then
            Console.WriteLine("Coordinates:" & latitude & "," & Longitude)
            u.writeWaypoint(latitude, Longitude, i.ToString())
            u.writetrack(latitude, Longitude, i, datetime)

        Else
            u.LogExifErrors("GPSmissing: " & iPath)
        End If




    End Sub

    Public Shared Sub initGPX()
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\waypoints2.gpx"
        Dim sw As StreamWriter
        Try
            'If (Not File.Exists(strFile)) Then
            sw = File.CreateText(strFile)
            sw.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            sw.WriteLine("<gpx version=""1.0"">")
            sw.WriteLine("<name>75CentralPhotography Locations</name>")



            ' Else
            '  sw = File.AppendText(strFile)
            '  End If

            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try

    End Sub
    Public Shared Sub initTrack()
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\tracks2.gpx"
        Dim sw As StreamWriter
        Try
            'If (Not File.Exists(strFile)) Then
            sw = File.CreateText(strFile)
            sw.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            sw.WriteLine("<gpx version=""1.0"">")
            sw.WriteLine("<name>75CentralPhotography Locations</name>")

            sw.WriteLine("<trk><name>75CentralPhotography</name><number>1</number><trkseg>")

            ' Else
            '  sw = File.AppendText(strFile)
            '  End If

            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Sub writeWaypoint(lat As String, lon As String, n As String)
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\waypoints2.gpx"
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)

            sw.WriteLine("<wpt lat=""" & lat & """ lon=""" & lon & """>")
            sw.WriteLine("<name>" & n & "</name>")
            sw.WriteLine("</wpt>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Sub writetrack(lat As String, lon As String, n As String, dt As DateTime)
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\tracks2.gpx"
        Dim dtS As String = dt.ToString("yyyy-MM-ddTHH:mm:ssZ")
        If dtS = "0001-01-01T00:00:00Z" Then
            Return

        End If
        Dim sw As StreamWriter
        Try
            sw = File.AppendText(strFile)

            sw.WriteLine("<trkpt lat=""" & lat & """ lon=""" & lon & """>")
            sw.WriteLine("<ele>" & n & "</ele>")
            sw.WriteLine("<time>" & dtS & "</time>")
            sw.WriteLine("</trkpt>")



            sw.Close()
        Catch ex As IOException
            Dim error1 As Boolean = True
        End Try
    End Sub
    Public Shared Sub CloseGPX()
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\waypoints2.gpx"
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
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\tracks2.gpx"
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
        Dim strFile As String = Form1.FolderBrowserDialog1.SelectedPath & "\exiferrors_2.txt"
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
