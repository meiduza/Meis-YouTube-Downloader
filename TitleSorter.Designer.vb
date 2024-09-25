<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TitleSorter
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
        Me.DGV_Metadata = New System.Windows.Forms.DataGridView()
        Me.BTN_WriteToFiles = New System.Windows.Forms.Button()
        Me.BTN_CancelMetadata = New System.Windows.Forms.Button()
        Me.Track = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Artist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Album = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Genre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainWindowBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DGV_Metadata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainWindowBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Metadata
        '
        Me.DGV_Metadata.AllowUserToAddRows = False
        Me.DGV_Metadata.AllowUserToDeleteRows = False
        Me.DGV_Metadata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Metadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV_Metadata.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Track, Me.Title, Me.Artist, Me.Album, Me.Genre, Me.Filename})
        Me.DGV_Metadata.Location = New System.Drawing.Point(12, 12)
        Me.DGV_Metadata.Name = "DGV_Metadata"
        Me.DGV_Metadata.Size = New System.Drawing.Size(644, 180)
        Me.DGV_Metadata.TabIndex = 0
        '
        'BTN_WriteToFiles
        '
        Me.BTN_WriteToFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_WriteToFiles.Location = New System.Drawing.Point(12, 198)
        Me.BTN_WriteToFiles.Name = "BTN_WriteToFiles"
        Me.BTN_WriteToFiles.Size = New System.Drawing.Size(75, 23)
        Me.BTN_WriteToFiles.TabIndex = 1
        Me.BTN_WriteToFiles.Text = "Convert"
        Me.BTN_WriteToFiles.UseVisualStyleBackColor = True
        '
        'BTN_CancelMetadata
        '
        Me.BTN_CancelMetadata.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_CancelMetadata.Location = New System.Drawing.Point(581, 198)
        Me.BTN_CancelMetadata.Name = "BTN_CancelMetadata"
        Me.BTN_CancelMetadata.Size = New System.Drawing.Size(75, 23)
        Me.BTN_CancelMetadata.TabIndex = 2
        Me.BTN_CancelMetadata.Text = "Cancel"
        Me.BTN_CancelMetadata.UseVisualStyleBackColor = True
        '
        'Track
        '
        Me.Track.HeaderText = "Track"
        Me.Track.Name = "Track"
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        '
        'Artist
        '
        Me.Artist.HeaderText = "Artist"
        Me.Artist.Name = "Artist"
        '
        'Album
        '
        Me.Album.HeaderText = "Album"
        Me.Album.Name = "Album"
        '
        'Genre
        '
        Me.Genre.HeaderText = "Genre"
        Me.Genre.Name = "Genre"
        '
        'Filename
        '
        Me.Filename.HeaderText = "File"
        Me.Filename.Name = "Filename"
        Me.Filename.ReadOnly = True
        '
        'MainWindowBindingSource
        '
        Me.MainWindowBindingSource.DataSource = GetType(MYD.MainWindow)
        '
        'TitleSorter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 233)
        Me.Controls.Add(Me.BTN_CancelMetadata)
        Me.Controls.Add(Me.BTN_WriteToFiles)
        Me.Controls.Add(Me.DGV_Metadata)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "TitleSorter"
        Me.ShowIcon = False
        Me.Text = "Mei's Metadata Doublechecker"
        CType(Me.DGV_Metadata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainWindowBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_Metadata As DataGridView
    Friend WithEvents MainWindowBindingSource As BindingSource
    Friend WithEvents BTN_WriteToFiles As Button
    Friend WithEvents BTN_CancelMetadata As Button
    Friend WithEvents Track As DataGridViewTextBoxColumn
    Friend WithEvents Title As DataGridViewTextBoxColumn
    Friend WithEvents Artist As DataGridViewTextBoxColumn
    Friend WithEvents Album As DataGridViewTextBoxColumn
    Friend WithEvents Genre As DataGridViewTextBoxColumn
    Friend WithEvents Filename As DataGridViewTextBoxColumn
End Class
