Imports System
Imports System.IO

Imports MetadataExtractor
Imports MetadataExtractor.Formats.Exif

Public Class Form1
    ' Public dtab As DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim directory As String
        directory = Me.FolderBrowserDialog1.SelectedPath
        ProcessFiles(directory)
    End Sub
    Private Sub ProcessFiles(directory As String)
        Dim di As New DirectoryInfo(directory)
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        Dim i As Integer = 1
        Dim u As New utilities


        'Dim dtab As 
        ' Public dtab As DataTable
        Globals.dtab.Columns.Add("lat", GetType(System.String))
        Globals.dtab.Columns.Add("lon", GetType(System.String))
        Globals.dtab.Columns.Add("datetake", GetType(System.DateTime))

        utilities.initGPX()
        utilities.initTrack()

        For Each fri In fiArr
            If fri.Extension = ".jpg" Then 'only process jpeg files
                exMeta2(fri.FullName, i)
                ' u.dtab.Rows.Add()
                'utilities.exMeta(fri.FullName, i)
                'Application.DoEvents()
                'i = i + 1

            End If
        Next fri
        fri = Nothing
        SortDataTable()

        For j As Integer = 0 To DataGridView1.Rows.Count - 1
            ' Add the qty value of the current row to total
            u.writetrack(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(2).Value)
        Next



        utilities.CloseGPX()
        utilities.CloseTracks()

        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.FolderBrowserDialog1.ShowDialog()

    End Sub
    Public Sub exMeta2(iPath As String, i As Integer)
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
            'u.writeWaypoint(latitude, Longitude, i.ToString())
            ' u.writetrack(latitude, Longitude, i, datetime)
            Globals.dtab.Rows.Add(latitude, Longitude, datetime)
        Else
            u.LogExifErrors("GPSmissing: " & iPath)
        End If




    End Sub
    Public Sub SortDataTable()
        ' Globals.dtab.DefaultView.Sort = "datetake ASC"
        ' Globals.dtab.DefaultView.ToTable()
        Dim dv As New DataView(Globals.dtab)
        dv.Sort = "datetake ASC"
        DataGridView1.DataSource = dv
    End Sub
End Class
