Public Class DebugToolbox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainWindow.CHK_MD_Album.Checked = True
        MainWindow.TXT_MD_Album.Text = "aa AA"
        MainWindow.CHK_MD_Artist.Checked = True
        MainWindow.TXT_MD_Artist.Text = "bb BB"
        MainWindow.CHK_MD_Genre.Checked = True
        MainWindow.TXT_MD_Genre.Text = "åäö ÅÄÖ"
        MainWindow.CHK_MD_Year.Checked = True
        MainWindow.TXT_MD_Year.Text = "1234"
        MainWindow.TXT_URLSource.Text = "https://www.youtube.com/playlist?list=PLodT7Gv0JQVMwmE57dymMtK_EOETmqBja"
        MainWindow.TXT_DownloadDirectory.Text = "E:\TEST"
        MainWindow.LIST_DownloadType.Text = "Audio"
    End Sub
End Class