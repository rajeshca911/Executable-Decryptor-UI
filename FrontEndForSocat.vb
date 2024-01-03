Imports System.IO
Imports System.Threading.Tasks

Module FrontEndForSocat
    Public Async Function RunSocat(arguments As String) As Task(Of Boolean)
        Try
            writelog("socat " & arguments)

            Dim appPath As String = Application.StartupPath
            Dim socatFolderPath As String = Path.Combine(appPath, "Socat")
            Dim exePath As String = Path.Combine(socatFolderPath, "socat.exe")

            If Not File.Exists(exePath) Then
                writelog("socat does not exist")
                Return False
            End If

            writelog("Socat File Path " & exePath)
            writelog("Please be patience.. communicating with playstation")

            ' Run the socat command
            Dim processInfo As New ProcessStartInfo(exePath, arguments)
            processInfo.WorkingDirectory = socatFolderPath
            processInfo.RedirectStandardOutput = True
            processInfo.RedirectStandardError = True
            processInfo.UseShellExecute = False
            processInfo.CreateNoWindow = True

            Dim process As New Process()
            process.StartInfo = processInfo
            process.Start()

            ' Asynchronously read output and error streams
            Dim outputTask = ReadStreamAsync(process.StandardOutput)
            Dim errorTask = ReadStreamAsync(process.StandardError)

            ' Wait for both tasks to complete
            Await Task.WhenAll(outputTask, errorTask)

            ' Get the output and error results
            Dim output As String = outputTask.Result
            Dim errorOutput As String = errorTask.Result

            writelog("Output: " & output)
            writelog("Error: " & errorOutput)
            SendToLogFile("Output: " & output, "Socat.txt")
            SendToLogFile("Error: " & errorOutput, "Socat.txt")

            process.WaitForExit()
            process.Close()
            If errorOutput.Contains("Connection timed out") Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error While Running Socat !!")
            writelog(ex.Message)
            SendToLogFile(ex.Message)
            Return False
        Finally
            Form1.Statlabel.Text = "Process finished"
        End Try
    End Function

    Private Async Function ReadStreamAsync(streamReader As StreamReader) As Task(Of String)
        Application.DoEvents()
        Return Await streamReader.ReadToEndAsync()
    End Function
    Public Sub writelog(logtext As String)
        On Error Resume Next
        Dim ct As Date = Now
        Application.DoEvents()
        Form1.CMDView.AppendText(Now.ToString("hh:MM:ss") & " : " & logtext & vbNewLine)
    End Sub





    Private Sub AppendToRichTextBox(text As String)
        Application.DoEvents()
        ' This method appends the provided text to RichTextBox1 in a thread-safe manner
        If Form1.CMDView.InvokeRequired Then
            Form1.CMDView.Invoke(Sub() AppendToRichTextBox(text))
        Else
            Form1.CMDView.AppendText(text & Environment.NewLine)
        End If
    End Sub
End Module
