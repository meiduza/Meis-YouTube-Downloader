<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TXT_LogOutput = New System.Windows.Forms.TextBox()
        Me.LIST_DownloadType = New System.Windows.Forms.ComboBox()
        Me.TXT_URLSource = New System.Windows.Forms.TextBox()
        Me.BTN_DownloadStart = New System.Windows.Forms.Button()
        Me.BOX_PlaylistSetting = New System.Windows.Forms.GroupBox()
        Me.TXT_MD_Genre = New System.Windows.Forms.TextBox()
        Me.TXT_MD_Artist = New System.Windows.Forms.TextBox()
        Me.CHK_MD_Genre = New System.Windows.Forms.CheckBox()
        Me.TXT_MD_Album = New System.Windows.Forms.TextBox()
        Me.CHK_MD_Year = New System.Windows.Forms.CheckBox()
        Me.CHK_MD_Artist = New System.Windows.Forms.CheckBox()
        Me.TXT_MD_Year = New System.Windows.Forms.TextBox()
        Me.CHK_MD_Album = New System.Windows.Forms.CheckBox()
        Me.BOX_BasicDownload = New System.Windows.Forms.GroupBox()
        Me.BTN_OpenDirectory = New System.Windows.Forms.Button()
        Me.BTN_ChooseDirectory = New System.Windows.Forms.Button()
        Me.TXT_DownloadDirectory = New System.Windows.Forms.TextBox()
        Me.LBL_DLLocation = New System.Windows.Forms.Label()
        Me.BOX_OutputLog = New System.Windows.Forms.GroupBox()
        Me.BTN_FO_Debug = New System.Windows.Forms.Button()
        Me.BTN_ClearWebms = New System.Windows.Forms.Button()
        Me.BTN_SaveSettings = New System.Windows.Forms.Button()
        Me.BOX_PlaylistSetting.SuspendLayout()
        Me.BOX_BasicDownload.SuspendLayout()
        Me.BOX_OutputLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXT_LogOutput
        '
        Me.TXT_LogOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_LogOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_LogOutput.Location = New System.Drawing.Point(6, 19)
        Me.TXT_LogOutput.Multiline = True
        Me.TXT_LogOutput.Name = "TXT_LogOutput"
        Me.TXT_LogOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TXT_LogOutput.Size = New System.Drawing.Size(499, 200)
        Me.TXT_LogOutput.TabIndex = 2
        '
        'LIST_DownloadType
        '
        Me.LIST_DownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LIST_DownloadType.FormattingEnabled = True
        Me.LIST_DownloadType.Items.AddRange(New Object() {"Audio", "Video"})
        Me.LIST_DownloadType.Location = New System.Drawing.Point(6, 20)
        Me.LIST_DownloadType.Name = "LIST_DownloadType"
        Me.LIST_DownloadType.Size = New System.Drawing.Size(121, 21)
        Me.LIST_DownloadType.TabIndex = 3
        '
        'TXT_URLSource
        '
        Me.TXT_URLSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_URLSource.Location = New System.Drawing.Point(133, 20)
        Me.TXT_URLSource.Name = "TXT_URLSource"
        Me.TXT_URLSource.Size = New System.Drawing.Size(266, 20)
        Me.TXT_URLSource.TabIndex = 1
        '
        'BTN_DownloadStart
        '
        Me.BTN_DownloadStart.Location = New System.Drawing.Point(405, 19)
        Me.BTN_DownloadStart.Name = "BTN_DownloadStart"
        Me.BTN_DownloadStart.Size = New System.Drawing.Size(94, 23)
        Me.BTN_DownloadStart.TabIndex = 0
        Me.BTN_DownloadStart.Text = "Start Download"
        Me.BTN_DownloadStart.UseVisualStyleBackColor = True
        '
        'BOX_PlaylistSetting
        '
        Me.BOX_PlaylistSetting.Controls.Add(Me.TXT_MD_Genre)
        Me.BOX_PlaylistSetting.Controls.Add(Me.TXT_MD_Artist)
        Me.BOX_PlaylistSetting.Controls.Add(Me.CHK_MD_Genre)
        Me.BOX_PlaylistSetting.Controls.Add(Me.TXT_MD_Album)
        Me.BOX_PlaylistSetting.Controls.Add(Me.CHK_MD_Year)
        Me.BOX_PlaylistSetting.Controls.Add(Me.CHK_MD_Artist)
        Me.BOX_PlaylistSetting.Controls.Add(Me.TXT_MD_Year)
        Me.BOX_PlaylistSetting.Controls.Add(Me.CHK_MD_Album)
        Me.BOX_PlaylistSetting.Location = New System.Drawing.Point(12, 101)
        Me.BOX_PlaylistSetting.Name = "BOX_PlaylistSetting"
        Me.BOX_PlaylistSetting.Size = New System.Drawing.Size(511, 80)
        Me.BOX_PlaylistSetting.TabIndex = 13
        Me.BOX_PlaylistSetting.TabStop = False
        Me.BOX_PlaylistSetting.Text = "Metadata Overrides"
        '
        'TXT_MD_Genre
        '
        Me.TXT_MD_Genre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_MD_Genre.Location = New System.Drawing.Point(326, 45)
        Me.TXT_MD_Genre.Name = "TXT_MD_Genre"
        Me.TXT_MD_Genre.Size = New System.Drawing.Size(173, 20)
        Me.TXT_MD_Genre.TabIndex = 18
        '
        'TXT_MD_Artist
        '
        Me.TXT_MD_Artist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_MD_Artist.Location = New System.Drawing.Point(69, 19)
        Me.TXT_MD_Artist.Name = "TXT_MD_Artist"
        Me.TXT_MD_Artist.Size = New System.Drawing.Size(173, 20)
        Me.TXT_MD_Artist.TabIndex = 8
        '
        'CHK_MD_Genre
        '
        Me.CHK_MD_Genre.AutoSize = True
        Me.CHK_MD_Genre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_MD_Genre.Location = New System.Drawing.Point(265, 48)
        Me.CHK_MD_Genre.Name = "CHK_MD_Genre"
        Me.CHK_MD_Genre.Size = New System.Drawing.Size(55, 17)
        Me.CHK_MD_Genre.TabIndex = 17
        Me.CHK_MD_Genre.Text = "Genre"
        Me.CHK_MD_Genre.UseVisualStyleBackColor = True
        '
        'TXT_MD_Album
        '
        Me.TXT_MD_Album.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_MD_Album.Location = New System.Drawing.Point(326, 19)
        Me.TXT_MD_Album.Name = "TXT_MD_Album"
        Me.TXT_MD_Album.Size = New System.Drawing.Size(173, 20)
        Me.TXT_MD_Album.TabIndex = 11
        '
        'CHK_MD_Year
        '
        Me.CHK_MD_Year.AutoSize = True
        Me.CHK_MD_Year.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_MD_Year.Location = New System.Drawing.Point(15, 48)
        Me.CHK_MD_Year.Name = "CHK_MD_Year"
        Me.CHK_MD_Year.Size = New System.Drawing.Size(48, 17)
        Me.CHK_MD_Year.TabIndex = 12
        Me.CHK_MD_Year.Text = "Year"
        Me.CHK_MD_Year.UseVisualStyleBackColor = True
        '
        'CHK_MD_Artist
        '
        Me.CHK_MD_Artist.AutoSize = True
        Me.CHK_MD_Artist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_MD_Artist.Location = New System.Drawing.Point(14, 22)
        Me.CHK_MD_Artist.Name = "CHK_MD_Artist"
        Me.CHK_MD_Artist.Size = New System.Drawing.Size(49, 17)
        Me.CHK_MD_Artist.TabIndex = 9
        Me.CHK_MD_Artist.Text = "Artist"
        Me.CHK_MD_Artist.UseVisualStyleBackColor = True
        '
        'TXT_MD_Year
        '
        Me.TXT_MD_Year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_MD_Year.Location = New System.Drawing.Point(69, 45)
        Me.TXT_MD_Year.Name = "TXT_MD_Year"
        Me.TXT_MD_Year.Size = New System.Drawing.Size(173, 20)
        Me.TXT_MD_Year.TabIndex = 13
        '
        'CHK_MD_Album
        '
        Me.CHK_MD_Album.AutoSize = True
        Me.CHK_MD_Album.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHK_MD_Album.Location = New System.Drawing.Point(265, 22)
        Me.CHK_MD_Album.Name = "CHK_MD_Album"
        Me.CHK_MD_Album.Size = New System.Drawing.Size(55, 17)
        Me.CHK_MD_Album.TabIndex = 10
        Me.CHK_MD_Album.Text = "Album"
        Me.CHK_MD_Album.UseVisualStyleBackColor = True
        '
        'BOX_BasicDownload
        '
        Me.BOX_BasicDownload.Controls.Add(Me.BTN_OpenDirectory)
        Me.BOX_BasicDownload.Controls.Add(Me.BTN_ChooseDirectory)
        Me.BOX_BasicDownload.Controls.Add(Me.TXT_DownloadDirectory)
        Me.BOX_BasicDownload.Controls.Add(Me.LBL_DLLocation)
        Me.BOX_BasicDownload.Controls.Add(Me.LIST_DownloadType)
        Me.BOX_BasicDownload.Controls.Add(Me.TXT_URLSource)
        Me.BOX_BasicDownload.Controls.Add(Me.BTN_DownloadStart)
        Me.BOX_BasicDownload.Location = New System.Drawing.Point(12, 12)
        Me.BOX_BasicDownload.Name = "BOX_BasicDownload"
        Me.BOX_BasicDownload.Size = New System.Drawing.Size(511, 83)
        Me.BOX_BasicDownload.TabIndex = 15
        Me.BOX_BasicDownload.TabStop = False
        Me.BOX_BasicDownload.Text = "Basic Download Settings"
        '
        'BTN_OpenDirectory
        '
        Me.BTN_OpenDirectory.Location = New System.Drawing.Point(451, 48)
        Me.BTN_OpenDirectory.Name = "BTN_OpenDirectory"
        Me.BTN_OpenDirectory.Size = New System.Drawing.Size(48, 23)
        Me.BTN_OpenDirectory.TabIndex = 15
        Me.BTN_OpenDirectory.Text = "Open"
        Me.BTN_OpenDirectory.UseVisualStyleBackColor = True
        '
        'BTN_ChooseDirectory
        '
        Me.BTN_ChooseDirectory.Location = New System.Drawing.Point(385, 48)
        Me.BTN_ChooseDirectory.Name = "BTN_ChooseDirectory"
        Me.BTN_ChooseDirectory.Size = New System.Drawing.Size(60, 23)
        Me.BTN_ChooseDirectory.TabIndex = 14
        Me.BTN_ChooseDirectory.Text = "Select..."
        Me.BTN_ChooseDirectory.UseVisualStyleBackColor = True
        '
        'TXT_DownloadDirectory
        '
        Me.TXT_DownloadDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_DownloadDirectory.Location = New System.Drawing.Point(108, 49)
        Me.TXT_DownloadDirectory.Name = "TXT_DownloadDirectory"
        Me.TXT_DownloadDirectory.Size = New System.Drawing.Size(271, 20)
        Me.TXT_DownloadDirectory.TabIndex = 13
        '
        'LBL_DLLocation
        '
        Me.LBL_DLLocation.AutoSize = True
        Me.LBL_DLLocation.Location = New System.Drawing.Point(3, 53)
        Me.LBL_DLLocation.Name = "LBL_DLLocation"
        Me.LBL_DLLocation.Size = New System.Drawing.Size(99, 13)
        Me.LBL_DLLocation.TabIndex = 4
        Me.LBL_DLLocation.Text = "Download Location"
        '
        'BOX_OutputLog
        '
        Me.BOX_OutputLog.Controls.Add(Me.TXT_LogOutput)
        Me.BOX_OutputLog.Location = New System.Drawing.Point(12, 187)
        Me.BOX_OutputLog.Name = "BOX_OutputLog"
        Me.BOX_OutputLog.Size = New System.Drawing.Size(511, 225)
        Me.BOX_OutputLog.TabIndex = 14
        Me.BOX_OutputLog.TabStop = False
        Me.BOX_OutputLog.Text = "Output Log"
        '
        'BTN_FO_Debug
        '
        Me.BTN_FO_Debug.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_FO_Debug.Location = New System.Drawing.Point(375, 419)
        Me.BTN_FO_Debug.Name = "BTN_FO_Debug"
        Me.BTN_FO_Debug.Size = New System.Drawing.Size(38, 22)
        Me.BTN_FO_Debug.TabIndex = 17
        Me.BTN_FO_Debug.Text = "Debug"
        Me.BTN_FO_Debug.UseVisualStyleBackColor = True
        '
        'BTN_ClearWebms
        '
        Me.BTN_ClearWebms.Location = New System.Drawing.Point(12, 418)
        Me.BTN_ClearWebms.Name = "BTN_ClearWebms"
        Me.BTN_ClearWebms.Size = New System.Drawing.Size(102, 23)
        Me.BTN_ClearWebms.TabIndex = 3
        Me.BTN_ClearWebms.Text = "Clear .webm's"
        Me.BTN_ClearWebms.UseVisualStyleBackColor = True
        '
        'BTN_SaveSettings
        '
        Me.BTN_SaveSettings.Location = New System.Drawing.Point(419, 418)
        Me.BTN_SaveSettings.Name = "BTN_SaveSettings"
        Me.BTN_SaveSettings.Size = New System.Drawing.Size(105, 23)
        Me.BTN_SaveSettings.TabIndex = 18
        Me.BTN_SaveSettings.Text = "Save Settings"
        Me.BTN_SaveSettings.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 452)
        Me.Controls.Add(Me.BTN_SaveSettings)
        Me.Controls.Add(Me.BTN_ClearWebms)
        Me.Controls.Add(Me.BTN_FO_Debug)
        Me.Controls.Add(Me.BOX_PlaylistSetting)
        Me.Controls.Add(Me.BOX_BasicDownload)
        Me.Controls.Add(Me.BOX_OutputLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MainWindow"
        Me.ShowIcon = False
        Me.Text = "Mei's YouTube Downloader"
        Me.BOX_PlaylistSetting.ResumeLayout(False)
        Me.BOX_PlaylistSetting.PerformLayout()
        Me.BOX_BasicDownload.ResumeLayout(False)
        Me.BOX_BasicDownload.PerformLayout()
        Me.BOX_OutputLog.ResumeLayout(False)
        Me.BOX_OutputLog.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TXT_LogOutput As TextBox
    Friend WithEvents LIST_DownloadType As ComboBox
    Friend WithEvents TXT_URLSource As TextBox
    Friend WithEvents BTN_DownloadStart As Button
    Friend WithEvents BOX_PlaylistSetting As GroupBox
    Friend WithEvents TXT_MD_Artist As TextBox
    Friend WithEvents TXT_MD_Album As TextBox
    Friend WithEvents CHK_MD_Artist As CheckBox
    Friend WithEvents CHK_MD_Album As CheckBox
    Friend WithEvents BOX_BasicDownload As GroupBox
    Friend WithEvents BTN_OpenDirectory As Button
    Friend WithEvents BTN_ChooseDirectory As Button
    Friend WithEvents TXT_DownloadDirectory As TextBox
    Friend WithEvents LBL_DLLocation As Label
    Friend WithEvents BOX_OutputLog As GroupBox
    Friend WithEvents CHK_MD_Year As CheckBox
    Friend WithEvents TXT_MD_Year As TextBox
    Friend WithEvents CHK_MD_Genre As CheckBox
    Friend WithEvents TXT_MD_Genre As TextBox
    Friend WithEvents BTN_FO_Debug As Button
    Friend WithEvents BTN_ClearWebms As Button
    Friend WithEvents BTN_SaveSettings As Button
End Class
