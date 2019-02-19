Imports System
Imports System.IO

Imports MetadataExtractor
Imports MetadataExtractor.Formats.Exif

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim directory As String
        Dim result As Integer
        directory = Me.FolderBrowserDialog1.SelectedPath
        If (directory.Trim() = "") Then
            result = MsgBox("Please choose a source folder of .jpg images to analyze", MsgBoxStyle.Critical, "Oh noes")
            Return
        End If
        ProcessFiles(directory)
    End Sub
    Private Sub ProcessFiles(directory As String)
        Dim di As New DirectoryInfo(directory)

        Dim fiArr As FileInfo() = di.GetFiles("*.jpg") 'we only want *.jpg files
        Dim fri As FileInfo
        Dim i As Integer = 1
        Dim u As New utilities
        Dim pbStepSize As Integer
        Dim result As Integer
        Dim pbStepCount As Integer = 1
        Globals.SaveLocation = FolderBrowserDialog2.SelectedPath
        If Globals.SaveLocation.Trim = "" Then
            result = MsgBox("No save location was selected! Do you want to save GPX files to the source image folder?", 4, "Hmmm...")
        End If
        If result = DialogResult.No Then 'TODO: Add code to use selected path or default path

            Return
        End If

        Globals.dtab.Columns.Add("lat", GetType(System.String))
        Globals.dtab.Columns.Add("lon", GetType(System.String))
        Globals.dtab.Columns.Add("datetake", GetType(System.DateTime))
        Globals.dtab.Columns.Add("Filename", GetType(System.String))
        Me.lblStatus.Text = "Initializing Output Files"
        utilities.initGPX()
        utilities.initTrack()
        pbStepSize = utilities.GetPBTickSize(fiArr.Count)
        Me.lblStatus.Text = "Reading GPS Data"
        For Each fri In fiArr
            ' If fri.Extension = ".jpg" Then 'only process jpeg files
            exMeta2(fri.FullName, i)

            Me.ImageCount.Text = i
            Application.DoEvents()
            i = i + 1
            pbStepCount = pbStepCount + 1
            If pbStepCount = pbStepSize Then
                Me.pbReading.Increment(1)
                pbStepCount = 1

            End If

            '  End If
        Next fri
        fri = Nothing
        SortDataTable()
        pbStepCount = 1
        Me.lblStatus.Text = "Writing GPX files"
        For j As Integer = 0 To DataGridView1.Rows.Count - 1
            ' Add the qty value of the current row to total
            Me.ImageCount.Text = j + 1
            Application.DoEvents()

            u.writetrack(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(2).Value, DataGridView1.Rows(j).Cells(3).Value)
            u.writeWaypoint(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(3).Value)

            pbStepCount = pbStepCount + 1
            If pbStepCount = pbStepSize Then
                Me.pbReading.Increment(-1)
                pbStepCount = 1

            End If
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
        Dim filename As String
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

            Console.WriteLine("Coordinates:" & latitude & "," & Longitude)
            filename = Path.GetFileName(iPath)

            Globals.dtab.Rows.Add(latitude, Longitude, datetime, filename)
        Else
            u.LogExifErrors("GPSmissing: " & iPath)
        End If




    End Sub
    Public Sub SortDataTable()

        Dim dv As New DataView(Globals.dtab)
        dv.Sort = "datetake ASC"
        DataGridView1.DataSource = dv
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblStatus.Text = "Waiting to Start"

    End Sub

    Private Sub btnChooseTrackFile_Click(sender As Object, e As EventArgs) Handles btnChooseTrackFile.Click
        Me.FolderBrowserDialog2.ShowDialog()

    End Sub
End Class
