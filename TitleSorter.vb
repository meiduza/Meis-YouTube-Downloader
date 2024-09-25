Imports System.IO
Imports System.Diagnostics
Imports System.Threading.Tasks



Public Class TitleSorter

    Private Function SanitizeMetadata(ByVal input As String) As String
        ' Remove or replace characters that could cause issues in ffmpeg
        Return input.Replace("""", "").Replace("\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "")
    End Function

    Private Sub BTN_WriteToFiles_Click(sender As Object, e As EventArgs) Handles BTN_WriteToFiles.Click
        ' Log start of metadata writing process in MainWindow
        MainWindow.Invoke(Sub()
                              MainWindow.TXT_LogOutput.AppendText("Starting conversion and metadata writing..." & Environment.NewLine)
                          End Sub)

        ' Loop through each row in the DataGridView
        For Each row As DataGridViewRow In DGV_Metadata.Rows
            If Not row.IsNewRow Then
                ' Extract the updated metadata from the DataGridView
                Dim trackNumber As String = SanitizeMetadata(row.Cells("Track").Value.ToString())
                Dim title As String = SanitizeMetadata(row.Cells("Title").Value.ToString())
                Dim artist As String = SanitizeMetadata(row.Cells("Artist").Value.ToString())
                Dim album As String = SanitizeMetadata(row.Cells("Album").Value.ToString())
                Dim genre As String = SanitizeMetadata(row.Cells("Genre").Value.ToString())
                Dim fileName As String = row.Cells("Filename").Value.ToString()

                ' Log the file being processed
                MainWindow.Invoke(Sub()
                                      MainWindow.TXT_LogOutput.AppendText("Processing file: " & fileName & Environment.NewLine)
                                  End Sub)

                ' Create a new MP3 filename with the desired format: "Track Number. Artist - Title.mp3"
                Dim outputFileName As String = Path.Combine(Path.GetDirectoryName(fileName), $"{trackNumber}. {artist} - {title}.mp3")

                ' Prepare ffmpeg arguments to convert to MP3 and apply metadata
                Dim ffmpegPath As String = Path.Combine(Application.StartupPath, "ffmpeg.exe")
                Dim startInfo As New ProcessStartInfo(ffmpegPath)
                startInfo.Arguments = $"-i ""{fileName}"" -q:a 0 -metadata title=""{title}"" -metadata artist=""{artist}"" -metadata album_artist=""{artist}"" -metadata album=""{album}"" -metadata genre=""{genre}"" -metadata track=""{trackNumber}"" ""{outputFileName}"""
                startInfo.RedirectStandardOutput = True
                startInfo.RedirectStandardError = True
                startInfo.UseShellExecute = False
                startInfo.CreateNoWindow = True

                Dim process As New Process()
                process.StartInfo = startInfo

                Try
                    ' Start the ffmpeg process to convert and write metadata
                    process.Start()
                    Dim outputReader As StreamReader = process.StandardOutput
                    Dim errorReader As StreamReader = process.StandardError

                    ' Read output and errors from ffmpeg
                    While Not outputReader.EndOfStream
                        Dim outputLine As String = outputReader.ReadLine()
                        MainWindow.Invoke(Sub()
                                              MainWindow.TXT_LogOutput.AppendText(outputLine & Environment.NewLine)
                                          End Sub)
                    End While

                    While Not errorReader.EndOfStream
                        Dim errorLine As String = errorReader.ReadLine()
                        MainWindow.Invoke(Sub()
                                              MainWindow.TXT_LogOutput.AppendText("[FFmpeg Error] " & errorLine & Environment.NewLine)
                                          End Sub)
                    End While

                    process.WaitForExit()

                    ' Notify the user that the metadata has been written
                    MainWindow.Invoke(Sub()
                                          MainWindow.TXT_LogOutput.AppendText("Metadata written to file: " & outputFileName & Environment.NewLine)
                                      End Sub)

                Catch ex As Exception
                    ' Log any exception during process start
                    MainWindow.Invoke(Sub()
                                          MainWindow.TXT_LogOutput.AppendText("[ERROR] Failed to write metadata to: " & outputFileName & Environment.NewLine & ex.Message & Environment.NewLine)
                                      End Sub)
                End Try
            End If
        Next

        ' Log completion of metadata writing process
        MainWindow.Invoke(Sub()
                              MainWindow.TXT_LogOutput.AppendText("Finished writing metadata and converting to MP3." & Environment.NewLine)
                          End Sub)

        ' Clear the DataGridView after conversion is complete
        Me.Invoke(Sub()
                      DGV_Metadata.Rows.Clear() ' Clear rows after the process
                  End Sub)

        ' Close the TitleSorter form
        Me.Close()
    End Sub


End Class