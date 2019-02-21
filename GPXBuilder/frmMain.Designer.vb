<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ImageCount = New System.Windows.Forms.TextBox()
        Me.pbReading = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnChooseTrackFile = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.btnExportTrack = New System.Windows.Forms.Button()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExportWP = New System.Windows.Forms.Button()
        Me.lblFileCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipSuccess = New System.Windows.Forms.ToolTip(Me.components)
        Me.tipError = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 102)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Process"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(26, 32)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(195, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Choose Image Source Folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(25, 290)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(588, 212)
        Me.DataGridView1.TabIndex = 2
        '
        'ImageCount
        '
        Me.ImageCount.Location = New System.Drawing.Point(172, 212)
        Me.ImageCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ImageCount.Name = "ImageCount"
        Me.ImageCount.Size = New System.Drawing.Size(50, 20)
        Me.ImageCount.TabIndex = 3
        '
        'pbReading
        '
        Me.pbReading.Location = New System.Drawing.Point(26, 183)
        Me.pbReading.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.pbReading.Name = "pbReading"
        Me.pbReading.Size = New System.Drawing.Size(195, 20)
        Me.pbReading.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(68, 161)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 5
        '
        'btnChooseTrackFile
        '
        Me.btnChooseTrackFile.Location = New System.Drawing.Point(26, 66)
        Me.btnChooseTrackFile.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnChooseTrackFile.Name = "btnChooseTrackFile"
        Me.btnChooseTrackFile.Size = New System.Drawing.Size(195, 23)
        Me.btnChooseTrackFile.TabIndex = 6
        Me.btnChooseTrackFile.Text = "Select GPX Files Save Location"
        Me.btnChooseTrackFile.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(26, 542)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 33
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(588, 212)
        Me.DataGridView2.TabIndex = 7
        '
        'btnExportTrack
        '
        Me.btnExportTrack.Location = New System.Drawing.Point(634, 317)
        Me.btnExportTrack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnExportTrack.Name = "btnExportTrack"
        Me.btnExportTrack.Size = New System.Drawing.Size(148, 69)
        Me.btnExportTrack.TabIndex = 8
        Me.btnExportTrack.Text = "Export Track File"
        Me.btnExportTrack.UseVisualStyleBackColor = True
        '
        'mnuMain
        '
        Me.mnuMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(3, 1, 0, 1)
        Me.mnuMain.Size = New System.Drawing.Size(797, 24)
        Me.mnuMain.TabIndex = 9
        Me.mnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'btnExportWP
        '
        Me.btnExportWP.Location = New System.Drawing.Point(634, 405)
        Me.btnExportWP.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnExportWP.Name = "btnExportWP"
        Me.btnExportWP.Size = New System.Drawing.Size(148, 72)
        Me.btnExportWP.TabIndex = 10
        Me.btnExportWP.Text = "Export Waypoint File"
        Me.btnExportWP.UseVisualStyleBackColor = True
        '
        'lblFileCount
        '
        Me.lblFileCount.AutoSize = True
        Me.lblFileCount.Location = New System.Drawing.Point(23, 215)
        Me.lblFileCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFileCount.Name = "lblFileCount"
        Me.lblFileCount.Size = New System.Drawing.Size(145, 13)
        Me.lblFileCount.TabIndex = 11
        Me.lblFileCount.Text = "Number of Photos Processed"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 517)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Error Records"
        Me.tipError.SetToolTip(Me.Label1, "Photos that have insufficient data to properly build a .gpx file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 262)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Success Records"
        Me.tipSuccess.SetToolTip(Me.Label2, "Photos that have sufficient data to build a .gpx file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'tipSuccess
        '
        Me.tipSuccess.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tipSuccess.ToolTipTitle = "Photos that have complete location and time data"
        '
        'tipError
        '
        Me.tipError.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tipError.ToolTipTitle = "Photos that have incomplete location and time data"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 777)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFileCount)
        Me.Controls.Add(Me.btnExportWP)
        Me.Controls.Add(Me.btnExportTrack)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btnChooseTrackFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbReading)
        Me.Controls.Add(Me.ImageCount)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.mnuMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuMain
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "GPXBuilder"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ImageCount As TextBox
    Friend WithEvents pbReading As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnChooseTrackFile As Button
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents btnExportTrack As Button
    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnExportWP As Button
    Friend WithEvents lblFileCount As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tipSuccess As ToolTip
    Friend WithEvents tipError As ToolTip
End Class
