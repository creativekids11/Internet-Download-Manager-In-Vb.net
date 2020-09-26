Imports System.Net

Public Class Form1
    Private Sub ExitDMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitDMToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "URL" And TextBox1.ForeColor = Color.Gray Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        Else
            TextBox1.SelectAll()
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" And TextBox1.ForeColor = Color.Black Then
            TextBox1.Text = "URL"
            TextBox1.ForeColor = Color.Gray
        Else
            TextBox1.SelectAll()
        End If
    End Sub

    Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
        If TextBox2.Text = "Filename" And TextBox2.ForeColor = Color.Gray Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
        Else
            TextBox2.SelectAll()
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" And TextBox2.ForeColor = Color.Black Then
            TextBox2.Text = "Filename"
            TextBox2.ForeColor = Color.Gray
        Else
            TextBox2.SelectAll()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "URL" And TextBox1.ForeColor = Color.Gray Then
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    'Downloading
    Private WithEvents HTTPCLIENT As WebClient

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HTTPCLIENT = New WebClient
        Dim Download As String = TextBox1.Text
        Dim USER = Environment.UserName
        Dim SAVE As String = "C:\Users\" & USER & "\Downloads\" & TextBox2.Text ''file.exe
        Try
            HTTPCLIENT.DownloadFileAsync(New Uri(Download), SAVE)
            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            Button2.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information")
            TextBox1.Text = "URL"
            TextBox1.ForeColor = Color.Gray
            TextBox2.Text = "Filename"
            TextBox2.ForeColor = Color.Gray
        End Try
    End Sub

    Private Sub HTTPCLIENT_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles HTTPCLIENT.DownloadProgressChanged
        ProgressBar1.Maximum = e.TotalBytesToReceive
        ProgressBar1.Value = e.BytesReceived
        Label3.Text = "Downloaded: " & e.BytesReceived & " / " & e.TotalBytesToReceive

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = 0
            TextBox1.Text = "URL"
            TextBox1.ForeColor = Color.Gray
            TextBox2.Text = "Filename"
            TextBox2.ForeColor = Color.Gray
            TextBox1.ReadOnly = False
            TextBox2.ReadOnly = False
            Button2.Enabled = True
        End If
    End Sub

    Private Sub DeafaltLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeafaltLocationToolStripMenuItem.Click
        MessageBox.Show("The Defualt Locatio Is Downloads.", "Information")
    End Sub
End Class
