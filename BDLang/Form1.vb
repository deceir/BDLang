Imports System.IO
Imports System.Net.Http
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Security.Policy

Public Class BDOLang

    Dim codeUrl = "https://naeu-o-dn.playblackdesert.com/UploadData/ads_files"
    Private _languageCode As String
    Private _fileName As String
    Private _fileFileName As String

    Private Async Function DebugFetchAsync(url As String) As Task
        Dim handler As New HttpClientHandler() With {
        .AllowAutoRedirect = True
    }

        Using client As New HttpClient(handler)
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0")

            Using resp = Await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)
                Dim finalUrl = resp.RequestMessage.RequestUri.ToString()

                MessageBox.Show(
                "Final URL: " & finalUrl & vbCrLf &
                "Status: " & CInt(resp.StatusCode).ToString() & " " & resp.ReasonPhrase
            )

                Dim text = Await resp.Content.ReadAsStringAsync()
                'MessageBox.Show(text.Substring(0, Math.Min(400, text.Length)))
            End Using
        End Using
    End Function

    Private Function ExtractCode(text As String, targetFile As String) As String

        For Each rawLine As String In text.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            Dim line As String = rawLine.Trim()

            If line.Length = 0 Then Continue For

            Dim parts() As String = line.Split(CType(Nothing, Char()), StringSplitOptions.RemoveEmptyEntries)

            If parts.Length >= 2 AndAlso
           String.Equals(parts(0), targetFile, StringComparison.OrdinalIgnoreCase) Then

                Return parts(parts.Length - 1)

            End If

        Next

        Throw New Exception("File not found in manifest.")

    End Function



    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdBtnEng.CheckedChanged
        btnFetch.Enabled = True
    End Sub
    Private Async Function GetFileCodeAsync(manifestUrl As String, targetFile As String) As Task(Of String)

        Using client As New HttpClient()
            Dim body As String = Await client.GetStringAsync(manifestUrl)

            For Each rawLine In body.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)

                Dim line = rawLine.Trim()
                Dim parts() As String = line.Split(CType(Nothing, Char()), StringSplitOptions.RemoveEmptyEntries)

                If parts.Length >= 2 AndAlso
               String.Equals(parts(0), targetFile, StringComparison.OrdinalIgnoreCase) Then

                    Return parts(parts.Length - 1)

                End If
            Next
        End Using

        Throw New Exception("File not found.")

    End Function


    Private Async Sub btnFetch_Click(sender As Object, e As EventArgs) Handles btnFetch.Click
        Dim handler As New HttpClientHandler() With {
        .AllowAutoRedirect = True
    }

        Using client As New HttpClient(handler)
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0")

            Using resp = Await client.GetAsync(codeUrl, HttpCompletionOption.ResponseHeadersRead)
                Dim finalUrl = resp.RequestMessage.RequestUri.ToString()

                '    MessageBox.Show(
                '    "Final URL: " & finalUrl & vbCrLf &
                '    "Status: " & CInt(resp.StatusCode).ToString() & " " & resp.ReasonPhrase
                ')

                Dim text = Await resp.Content.ReadAsStringAsync()

                text = ExtractCode(text, "languagedata_en.loc")
                _languageCode = text
                lblCode.Text = "Current Code: " + text
            End Using
        End Using

        ProgressBar.Value = 20
        lblInfo.Text = "Language code retrieved. Now checking link."

        Using dlg As New OpenFileDialog()
            dlg.Title = "Select your Black Desert loc file. (Default: BlackDesert/Ads/*"
            dlg.Filter = "LOC files (*.loc)|*.loc|All files (*.*)|*.*"
            dlg.CheckFileExists = True
            dlg.Multiselect = False

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                TextBox1.Text = dlg.FileName   ' txtTargetFile is a TextBox on your form
                _fileName = dlg.FileName
                _fileFileName = IO.Path.GetFileName(_fileName)
            End If
        End Using
        Try
            Dim targetPath As String = TextBox1.Text.Trim()
            If String.IsNullOrWhiteSpace(targetPath) OrElse Not File.Exists(targetPath) Then
                MessageBox.Show("Pick a valid target file first.")
                Return
            End If

            ' You said: "starting with having the code"
            Dim code As String = _languageCode.Trim() ' or wherever you stored "369"
            If String.IsNullOrWhiteSpace(code) Then
                MessageBox.Show("No code available.")
                Return
            End If

            ' Build the real download URL using the code (YOU MUST SET THIS CORRECTLY)
            Dim downloadUrl As String = "http://naeu-o-dn.playblackdesert.com/UploadData/ads/languagedata_en/" & code & "/languagedata_en.loc"

            ' Download to temp
            Dim tempPath As String = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") & ".tmp")
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(120)
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0")

                Using resp = Await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead)
                    resp.EnsureSuccessStatusCode()
                    Using inStream = Await resp.Content.ReadAsStreamAsync()
                        Using outStream = File.Create(tempPath)
                            Await inStream.CopyToAsync(outStream)
                        End Using
                    End Using
                End Using
            End Using

            ProgressBar.Value = 70
            lblInfo.Text = "New loc file downloaded. Now overwriting existing..."

            ' Overwrite selected target safely
            ' (File.Replace does atomic-ish replacement and can keep a backup)
            Dim backupPath As String = targetPath & ".bak"

            If File.Exists(targetPath) Then
                File.Replace(tempPath, targetPath, backupPath, ignoreMetadataErrors:=True)
                Try : File.Delete(backupPath) : Catch : End Try
            Else
                File.Move(tempPath, targetPath)
            End If
            MessageBox.Show("Updated: " & Path.GetFileName(targetPath) & " Now complete! You can close this program now.")
            ProgressBar.Value = 100
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If TextBox1.Enabled Then
            TextBox1.Enabled = False
        Else
            TextBox1.Enabled = True
        End If


    End Sub
End Class
