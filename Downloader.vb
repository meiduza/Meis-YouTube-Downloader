Imports System.IO
Imports System.Diagnostics
Imports System.Threading.Tasks

Public Class MainWindow
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define the path to the settings file
        Dim settingsFilePath As String = Path.Combine(Application.StartupPath, "settings.txt")

        ' Check if the settings file exists
        If File.Exists(settingsFilePath) Then
            Try
                Using reader As New StreamReader(settingsFilePath)
                    Dim line As String
                    Do While Not reader.EndOfStream
                        line = reader.ReadLine()
                        If line.StartsWith("[DownloadLocation]") Then
                            TXT_DownloadDirectory.Text = line.Replace("[DownloadLocation]", "").Trim()
                        ElseIf line.StartsWith("[DownloadType]") Then
                            LIST_DownloadType.Text = line.Replace("[DownloadType]", "").Trim()
                        End If
                    Loop
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to load settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub DownloadCompleteHandler(ByVal downloadPath As String)
        ' Populate the TitleSorter DataGridView with the downloaded files' metadata
        PopulateTitleSorter(downloadPath)
    End Sub

    Private Sub PopulateTitleSorter(ByVal targetFolder As String)
        ' Run the file processing on a background thread
        Task.Run(Sub()
                     ' Find the most recently modified subdirectory (artist or uploader folder)
                     Dim subDirectories As String() = Directory.GetDirectories(targetFolder)

                     ' Check if we found any subdirectories
                     If subDirectories.Length = 0 Then
                         Me.Invoke(Sub()
                                       TXT_LogOutput.AppendText("[ERROR] No subdirectories found in: " & targetFolder & Environment.NewLine)
                                   End Sub)
                         Return ' Exit if no subdirectories exist
                     End If

                     ' Sort directories by last write time and select the most recent one
                     Dim recentDirectory As String = subDirectories.OrderByDescending(Function(d) Directory.GetLastWriteTime(d)).First()

                     ' Log the selected directory
                     Me.Invoke(Sub()
                                   TXT_LogOutput.AppendText("Processing folder: " & recentDirectory & Environment.NewLine)
                               End Sub)

                     ' Get all downloaded files from the most recent subdirectory only
                     Dim downloadedFiles As String() = Directory.GetFiles(recentDirectory, "*.*", SearchOption.TopDirectoryOnly)

                     ' Clear the DataGridView before populating it (this needs to happen on the UI thread)
                     Me.Invoke(Sub()
                                   TitleSorter.DGV_Metadata.Rows.Clear() ' Clear old items
                                   TXT_LogOutput.AppendText("Clearing TitleSorter DataGridView..." & Environment.NewLine)
                               End Sub)

                     ' Loop through each downloaded file and extract its initial metadata
                     For Each file As String In downloadedFiles
                         ' Extract metadata from the filename (assuming the filename format is "track_number - title.ext")
                         Dim fileName As String = Path.GetFileNameWithoutExtension(file)
                         Dim parts As String() = fileName.Split(New String() {" - "}, StringSplitOptions.None)

                         ' Default metadata
                         Dim trackNumber As String = "01" ' Default to "01" if no playlist
                         Dim fullTitle As String = fileName ' Default to full filename if split doesn't work
                         Dim artist As String = Path.GetFileName(Path.GetDirectoryName(file)) ' The folder name is the artist (uploader)
                         Dim album As String = "" ' Album can be manually entered
                         Dim genre As String = "" ' Genre can be manually entered

                         ' Handle title extraction and track number for playlists
                         If parts.Length > 1 Then
                             trackNumber = parts(0).Trim() ' The first part is the track number or placeholder (for playlists)
                             fullTitle = String.Join(" - ", parts.Skip(1)).Trim() ' Join all remaining parts to ensure full title is used
                         End If

                         ' Apply override values if checkboxes are selected
                         If CHK_MD_Artist.Checked Then
                             artist = TXT_MD_Artist.Text.Trim()
                         End If
                         If CHK_MD_Album.Checked Then
                             album = TXT_MD_Album.Text.Trim()
                         End If
                         If CHK_MD_Genre.Checked Then
                             genre = TXT_MD_Genre.Text.Trim()
                         End If

                         ' Populate the DataGridView with the extracted or overridden metadata and filename
                         Me.Invoke(Sub()
                                       TitleSorter.DGV_Metadata.Rows.Add(trackNumber, fullTitle, artist, album, genre, file)
                                   End Sub)
                     Next

                     ' Show the TitleSorter form after populating the DataGridView (this needs to happen on the UI thread)
                     Me.Invoke(Sub()
                                   TitleSorter.Show()
                               End Sub)
                 End Sub)
    End Sub





    Private Sub DownloadYouTubeVideo(ByVal url As String, ByVal downloadPath As String, ByVal formatType As String)
        ' Disable the Download button while processing
        Invoke(Sub()
                   BTN_DownloadStart.Enabled = False
               End Sub)

        ' Fetch download type safely from the UI thread
        Dim downloadType As String = ""
        Invoke(Sub()
                   downloadType = LIST_DownloadType.Text
               End Sub)

        ' Ensure the correct subfolder is used based on the format type (Audio or Video)
        Dim targetFolder As String = ""
        If formatType = "Audio" Then
            targetFolder = Path.Combine(downloadPath, "Audio")
        ElseIf formatType = "Video" Then
            targetFolder = Path.Combine(downloadPath, "Video")
        End If

        ' Create the target folder if it doesn't exist
        If Not Directory.Exists(targetFolder) Then
            Directory.CreateDirectory(targetFolder)
        End If

        ' Create a new process to run yt-dlp
        Dim process As New Process()
        Dim startInfo As New ProcessStartInfo()

        ' Set the path to yt-dlp executable
        Dim ytDlpPath As String = Path.Combine(Application.StartupPath, "yt-dlp.exe")
        startInfo.FileName = ytDlpPath

        ' Initialize arguments for yt-dlp based on format type
        If downloadType = "Audio" Then
            If CHK_MD_Artist.Checked = True Then
                Dim MDArtist = TXT_MD_Artist.Text
                startInfo.Arguments = $"-f bestaudio --ignore-errors -o ""{targetFolder}\{MDArtist}\%(playlist_index)s - %(title)s.%(ext)s"" {url}"
            Else
                startInfo.Arguments = $"-f bestaudio --ignore-errors -o ""{targetFolder}\%(uploader)s\%(playlist_index)s - %(title)s.%(ext)s"" {url}"
            End If
        ElseIf downloadType = "Video" Then
            startInfo.Arguments = $"-f bestvideo+bestaudio --merge-output-format mp4 --ignore-errors -o ""{targetFolder}\%(uploader)s\%(title)s.%(ext)s"" {url}"
        Else
            MessageBox.Show("Invalid Download Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Set yt-dlp arguments and configure the process
        startInfo.RedirectStandardOutput = True
        startInfo.RedirectStandardError = True
        startInfo.UseShellExecute = False
        startInfo.CreateNoWindow = True
        process.StartInfo = startInfo

        ' Start the yt-dlp process to download files
        Try
            process.Start()
        Catch ex As Exception
            Invoke(Sub()
                       TXT_LogOutput.AppendText("[ERROR] Failed to start yt-dlp: " & ex.Message & Environment.NewLine)
                       BTN_DownloadStart.Enabled = True ' Re-enable button on failure
                   End Sub)
            Return
        End Try

        ' Read the output incrementally and update the log in real-time
        Dim outputReader As StreamReader = process.StandardOutput
        Dim errorReader As StreamReader = process.StandardError

        Task.Run(Sub()
                     Dim outputLine As String
                     While Not outputReader.EndOfStream
                         outputLine = outputReader.ReadLine()
                         Invoke(Sub()
                                    TXT_LogOutput.AppendText(outputLine & Environment.NewLine)
                                End Sub)
                     End While

                     ' Capture any error output
                     While Not errorReader.EndOfStream
                         Dim errorLine As String = errorReader.ReadLine()
                         Invoke(Sub()
                                    TXT_LogOutput.AppendText("[ERROR] " & errorLine & Environment.NewLine)
                                End Sub)
                     End While

                     process.WaitForExit()

                     ' Only invoke TitleSorter and metadata handling if the format is Audio
                     If formatType = "Audio" Then
                         PopulateTitleSorter(targetFolder)
                     End If

                     ' Re-enable the Download button after everything is done
                     Invoke(Sub()
                                BTN_DownloadStart.Enabled = True
                            End Sub)
                 End Sub)
    End Sub


    Private Sub ConvertToMP3(ByVal downloadPath As String)
        ' Find all downloaded audio files (assuming they're in the Audio folder)
        Dim audioFiles As String() = Directory.GetFiles(downloadPath & "\Audio", "*.*", SearchOption.AllDirectories)

        If audioFiles.Length > 0 Then
            ' Loop through each audio file and convert it to MP3
            For Each audioFile As String In audioFiles
                ' Extract metadata from the filename (assuming the filename format is "track_number - full_title.ext")
                Dim fileName As String = Path.GetFileNameWithoutExtension(audioFile)
                Dim parts As String() = fileName.Split(New String() {" - "}, StringSplitOptions.None)

                ' Default metadata
                Dim trackNumber As String = "01" ' Default to 01 if not part of a playlist
                Dim fullTitle As String = fileName ' Default to full filename if split doesn't work
                Dim artist As String = Path.GetFileName(Path.GetDirectoryName(audioFile)) ' The folder name is the artist (uploader)
                Dim album As String = "" ' Can be set or overridden
                Dim year As String = "" ' Can be set or overridden
                Dim genre As String = "" ' Can be set or overridden

                ' Handle cases where there is no track number (non-playlist)
                If parts.Length > 1 Then
                    trackNumber = parts(0).Trim() ' The first part is the track number or placeholder (for playlists)
                    fullTitle = String.Join(" - ", parts.Skip(1)).Trim() ' Join all remaining parts to ensure full title is used
                End If

                ' Check for metadata overrides
                If CHK_MD_Artist.Checked Then
                    artist = TXT_MD_Artist.Text.Trim() ' Use the override for artist/album artist
                End If
                If CHK_MD_Album.Checked Then
                    album = TXT_MD_Album.Text.Trim() ' Use the override for album title
                End If
                If CHK_MD_Year.Checked Then
                    year = TXT_MD_Year.Text.Trim() ' Use the override for year
                End If
                If CHK_MD_Genre.Checked Then
                    genre = TXT_MD_Genre.Text.Trim() ' Use the override for genre
                End If

                ' Make sure the full title is not empty
                If String.IsNullOrEmpty(fullTitle) Then
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("[ERROR] Title is missing or could not be extracted for file: " & fileName & Environment.NewLine)
                              End Sub)
                    Continue For ' Skip this file if title cannot be extracted
                End If

                ' Create a new process to run ffmpeg
                Dim process As New Process()
                Dim startInfo As New ProcessStartInfo()

                ' Set the path to ffmpeg executable (now bundled in the project)
                Dim ffmpegPath As String = Path.Combine(Application.StartupPath, "ffmpeg.exe")

                ' Check if the ffmpeg file exists
                If Not File.Exists(ffmpegPath) Then
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("FFmpeg not found at: " & ffmpegPath & Environment.NewLine)
                              End Sub)
                    Return
                End If

                ' Prepare the new file name in the format "TrackNumber. ArtistName - SongTitle.mp3"
                Dim outputFile As String = Path.Combine(Path.GetDirectoryName(audioFile), $"{trackNumber.PadLeft(2, "0"c)}. {artist} - {fullTitle}.mp3")

                ' Arguments to convert to MP3 and embed metadata
                startInfo.Arguments = $"-i ""{audioFile}"" -q:a 0 -metadata title=""{fullTitle}"" -metadata artist=""{artist}"" -metadata album_artist=""{artist}"""

                ' Only add metadata fields if they are overridden
                If Not String.IsNullOrEmpty(album) Then
                    startInfo.Arguments &= $" -metadata album=""{album}"""
                End If
                If Not String.IsNullOrEmpty(year) Then
                    startInfo.Arguments &= $" -metadata date=""{year}"""
                End If
                If Not String.IsNullOrEmpty(genre) Then
                    startInfo.Arguments &= $" -metadata genre=""{genre}"""
                End If
                startInfo.Arguments &= $" -metadata track=""{trackNumber}"" ""{outputFile}"""

                ' Set up the process
                startInfo.RedirectStandardOutput = True
                startInfo.RedirectStandardError = True
                startInfo.UseShellExecute = False
                startInfo.CreateNoWindow = True
                startInfo.FileName = ffmpegPath

                process.StartInfo = startInfo

                Try
                    ' Start the ffmpeg process
                    process.Start()
                Catch ex As Exception
                    ' Log any exception during process start
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("[ERROR] Failed to start FFmpeg: " & ex.Message & Environment.NewLine)
                              End Sub)
                    Continue For
                End Try

                ' Read the output from ffmpeg and update the log
                Dim outputReader As StreamReader = process.StandardOutput
                Dim errorReader As StreamReader = process.StandardError
                Dim outputLine As String

                While Not outputReader.EndOfStream
                    outputLine = outputReader.ReadLine()
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText(outputLine & Environment.NewLine)
                              End Sub)
                End While

                ' Capture any errors from ffmpeg
                While Not errorReader.EndOfStream
                    Dim errorLine As String = errorReader.ReadLine()
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("[ERROR] " & errorLine & Environment.NewLine)
                              End Sub)
                End While

                process.WaitForExit()

                ' When conversion is complete, delete the original file
                If File.Exists(outputFile) Then
                    File.Delete(audioFile) ' Remove the original audio file (e.g., .webm)
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("Original file deleted: " & audioFile & Environment.NewLine)
                                  TXT_LogOutput.AppendText("Conversion to MP3 complete for: " & outputFile & Environment.NewLine)
                              End Sub)
                Else
                    Me.Invoke(Sub()
                                  TXT_LogOutput.AppendText("Conversion failed, MP3 file not created for: " & audioFile & Environment.NewLine)
                              End Sub)
                End If
            Next
        Else
            Me.Invoke(Sub()
                          TXT_LogOutput.AppendText("No audio files found to convert!" & Environment.NewLine)
                      End Sub)
        End If

    End Sub

    Private Sub BTN_ChooseDirectory_Click(sender As Object, e As EventArgs) Handles BTN_ChooseDirectory.Click
        Using fbd As New FolderBrowserDialog()
            If fbd.ShowDialog() = DialogResult.OK Then
                TXT_DownloadDirectory.Text = fbd.SelectedPath
            End If
        End Using
    End Sub

    Private Sub BTN_OpenDirectory_Click(sender As Object, e As EventArgs) Handles BTN_OpenDirectory.Click
        If Directory.Exists(TXT_DownloadDirectory.Text) Then
            Process.Start("explorer.exe", TXT_DownloadDirectory.Text)
        Else
            MessageBox.Show("The selected directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BTN_DownloadStart_Click(sender As Object, e As EventArgs) Handles BTN_DownloadStart.Click
        ' Get the URL from the textbox
        Dim url As String = TXT_URLSource.Text

        ' Get the download location from the textbox
        Dim downloadPath As String = TXT_DownloadDirectory.Text

        ' Ensure both URL and download path are provided
        If String.IsNullOrEmpty(url) Or String.IsNullOrEmpty(downloadPath) Then
            MessageBox.Show("Please provide a valid URL and download location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Get the selected format from the dropdown (Audio or Video)
        Dim formatType As String = LIST_DownloadType.SelectedItem.ToString()

        ' Disable the button to prevent multiple downloads at once
        BTN_DownloadStart.Enabled = False

        ' Start the download process in a background thread
        Task.Run(Sub()
                     DownloadYouTubeVideo(url, downloadPath, formatType)
                 End Sub)
    End Sub

    Private Sub BTN_FO_Debug_Click(sender As Object, e As EventArgs) Handles BTN_FO_Debug.Click
        DebugToolbox.Show()
    End Sub

    Private Sub BTN_FO_TitleSorter_Click(sender As Object, e As EventArgs)
        TitleSorter.Show()
    End Sub

    Private Sub BTN_ClearWebms_Click(sender As Object, e As EventArgs) Handles BTN_ClearWebms.Click
        ' Set the target folder (where the files were downloaded)
        Dim targetFolder As String = TXT_DownloadDirectory.Text.Trim() ' Trim any leading/trailing whitespace

        ' Check if the targetFolder is valid
        If String.IsNullOrWhiteSpace(targetFolder) OrElse Not Directory.Exists(targetFolder) Then
            TXT_LogOutput.AppendText("[ERROR] Invalid download directory. Please check the folder path." & Environment.NewLine)
            Return
        End If

        ' Get all .webm files in the target folder and its subdirectories
        Dim webmFiles As String() = Directory.GetFiles(targetFolder, "*.webm", SearchOption.AllDirectories)

        ' Loop through each .webm file and delete it
        For Each webmFile In webmFiles
            Try
                File.Delete(webmFile)
                ' Log success to Output Log
                TXT_LogOutput.AppendText("Deleted: " & webmFile & Environment.NewLine)
            Catch ex As Exception
                ' Log any error during file deletion
                TXT_LogOutput.AppendText("[ERROR] Failed to delete file: " & webmFile & Environment.NewLine & ex.Message & Environment.NewLine)
            End Try
        Next

        ' Notify user when done
        TXT_LogOutput.AppendText("Finished clearing all .webm files." & Environment.NewLine)
    End Sub

    Private Sub BTN_SaveSettings_Click(sender As Object, e As EventArgs) Handles BTN_SaveSettings.Click
        ' Save settings in a simple text file (e.g., settings.txt in application directory)
        Dim settingsFilePath As String = Path.Combine(Application.StartupPath, "settings.txt")

        Try
            Using writer As New StreamWriter(settingsFilePath)
                ' Save the download directory and download type
                writer.WriteLine("[DownloadLocation]" & TXT_DownloadDirectory.Text.Trim())
                writer.WriteLine("[DownloadType]" & LIST_DownloadType.Text.Trim())
            End Using
            MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to save settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class