<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ImageCount = New System.Windows.Forms.TextBox()
        Me.pbReading = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnChooseTrackFile = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(51, 225)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(336, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Process"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(51, 62)
        Me.Button2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(336, 44)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Choose Image Source Folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(436, 459)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1251, 288)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.Visible = False
        '
        'ImageCount
        '
        Me.ImageCount.Location = New System.Drawing.Point(568, 311)
        Me.ImageCount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ImageCount.Name = "ImageCount"
        Me.ImageCount.Size = New System.Drawing.Size(100, 31)
        Me.ImageCount.TabIndex = 3
        '
        'pbReading
        '
        Me.pbReading.Location = New System.Drawing.Point(51, 352)
        Me.pbReading.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbReading.Name = "pbReading"
        Me.pbReading.Size = New System.Drawing.Size(336, 38)
        Me.pbReading.TabIndex = 4
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(45, 318)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 25)
        Me.lblStatus.TabIndex = 5
        '
        'btnChooseTrackFile
        '
        Me.btnChooseTrackFile.Location = New System.Drawing.Point(51, 126)
        Me.btnChooseTrackFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnChooseTrackFile.Name = "btnChooseTrackFile"
        Me.btnChooseTrackFile.Size = New System.Drawing.Size(336, 42)
        Me.btnChooseTrackFile.TabIndex = 6
        Me.btnChooseTrackFile.Text = "Select GPX Files Save Location"
        Me.btnChooseTrackFile.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 450)
        Me.Controls.Add(Me.btnChooseTrackFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbReading)
        Me.Controls.Add(Me.ImageCount)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "GPXBuilder"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
