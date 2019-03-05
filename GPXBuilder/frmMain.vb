Imports System
Imports System.IO

Imports MetadataExtractor
Imports MetadataExtractor.Formats.Exif

Public Class frmMain

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim directory As String
        Dim result As Integer
        directory = Me.FolderBrowserDialog1.SelectedPath
        If (directory.Trim() = "") Then
            result = MsgBox("Please choose a source folder of .jpg images to analyze", MsgBoxStyle.Critical, "Error")
            Return
        End If
        ProcessFiles(directory)
    End Sub
    Private Sub ProcessFiles(directory As String)
        Dim di As New DirectoryInfo(directory)
        Globals.dtab.Reset()
        Globals.dtabError.Reset()

        Dim fiArr As FileInfo() = di.GetFiles("*.jpg") 'we only want *.jpg files
        Dim fri As FileInfo
        Dim i As Integer = 1
        Dim u As New utilities
        Dim pbStepSize As Integer
        Dim result As Integer
        Dim pbStepCount As Integer = 1
        Me.btnExportTrack.Enabled = False
        Me.btnExportWP.Enabled = False
        Globals.SaveLocation = FolderBrowserDialog2.SelectedPath
        If Globals.SaveLocation.Trim = "" Then
            result = MsgBox("No save location was selected! Do you want to save GPX files to the source image folder?", 4, "Hmmm...")
            Globals.SaveLocation = FolderBrowserDialog1.SelectedPath
        End If
        If result = DialogResult.No Then 'TODO: Add code to use selected path or default path
            Me.FolderBrowserDialog2.ShowDialog()
            Globals.SaveLocation = FolderBrowserDialog2.SelectedPath
            'Return
        End If

        Globals.dtab.Columns.Add("Latitude", GetType(System.String))
        Globals.dtab.Columns.Add("Longitude", GetType(System.String))
        Globals.dtab.Columns.Add("Date", GetType(System.DateTime))
        Globals.dtab.Columns.Add("Filename", GetType(System.String))
        Globals.dtabError.Columns.Add("Latitude", GetType(System.String))
        Globals.dtabError.Columns.Add("Longitude", GetType(System.String))
        Globals.dtabError.Columns.Add("Date", GetType(System.DateTime))
        Globals.dtabError.Columns.Add("Filename", GetType(System.String))
        Me.lblStatus.Text = "Initializing Output Files"
        ' utilities.initGPX()
        'utilities.initTrack()
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
        If Me.DataGridView1.Rows.Count > 1 Then
            Me.btnExportTrack.Enabled = True

        End If
        If Me.DataGridView2.Rows.Count > 1 Then
            Me.btnExportWP.Enabled = True

        End If
        'Removed below to allow view of Datagrids prior to saving. Saving is now user-actionable
        'pbStepCount = 1 
        'Me.lblStatus.Text = "Writing GPX files"
        'For j As Integer = 0 To DataGridView1.Rows.Count - 1

        '    Me.ImageCount.Text = j + 1
        '    Application.DoEvents()

        '    u.writetrack(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(2).Value, DataGridView1.Rows(j).Cells(3).Value)
        '    u.writeWaypoint(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(3).Value)

        '    pbStepCount = pbStepCount + 1
        '    If pbStepCount = pbStepSize Then
        '        Me.pbReading.Increment(-1)
        '        pbStepCount = 1

        '    End If
        'Next



        'utilities.CloseGPX()
        'utilities.CloseTracks()

        'Application.Exit()
    End Sub
    Private Sub WriteTrackFile()
        Dim u As New utilities
        utilities.initTrack()
        For j As Integer = 0 To DataGridView1.Rows.Count - 1

            Application.DoEvents()
            u.writetrack(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(2).Value, DataGridView1.Rows(j).Cells(3).Value)

        Next
        utilities.CloseTracks()
    End Sub
    Private Sub WriteWaypointFile()
        Dim u As New utilities
        utilities.initGPX()

        For j As Integer = 0 To DataGridView1.Rows.Count - 1

            Application.DoEvents()
            u.writeWaypoint(DataGridView1.Rows(j).Cells(0).Value, DataGridView1.Rows(j).Cells(1).Value, j, DataGridView1.Rows(j).Cells(3).Value)

        Next
        utilities.CloseGPX()

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
        Dim filename As String = ""
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

            If (latitude <> "0" And Longitude <> "0" And datetime > "12/12/1900") Then
                Globals.dtab.Rows.Add(latitude, Longitude, datetime, filename)
            Else
                Globals.dtabError.Rows.Add(latitude, Longitude, datetime, filename)
            End If
        Else
            Globals.dtabError.Rows.Add(latitude, Longitude, datetime, filename)
        End If




    End Sub
    Public Sub SortDataTable()

        Dim dv As New DataView(Globals.dtab)
        dv.Sort = "Date ASC"
        DataGridView1.DataSource = dv
        Dim dvE As New DataView(Globals.dtabError)
        dvE.Sort = "Date ASC"
        DataGridView2.DataSource = dvE

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblStatus.Text = "Waiting to Start"
        Me.btnExportTrack.Enabled = False
        Me.btnExportWP.Enabled = False



    End Sub

    Private Sub btnChooseTrackFile_Click(sender As Object, e As EventArgs) Handles btnChooseTrackFile.Click
        Me.FolderBrowserDialog2.ShowDialog()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString

        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)

        If DataGridView1.RowHeadersWidth < CInt((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = CInt((size.Width + 20))
        End If

        Dim b As Brush = SystemBrushes.ControlText


        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15,
                                  e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) _
                                                            / 2))
    End Sub
    Private Sub DataGridView2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString

        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)

        If DataGridView2.RowHeadersWidth < CInt((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = CInt((size.Width + 20))
        End If

        Dim b As Brush = SystemBrushes.ControlText


        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15,
                                  e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) _
                                                            / 2))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnExportTrack.Click
        Me.Cursor = Cursors.WaitCursor

        WriteTrackFile()
        Me.Cursor = Cursors.Default
        MsgBox("Track file has been exported to " & Globals.SaveLocation, vbOKOnly, "Export Complete")


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()

    End Sub

    Private Sub btnExportWP_Click(sender As Object, e As EventArgs) Handles btnExportWP.Click
        WriteWaypointFile()
        MsgBox("Waypoint file has been exported to " & Globals.SaveLocation, vbOKOnly, "Export Complete")

    End Sub
End Class
