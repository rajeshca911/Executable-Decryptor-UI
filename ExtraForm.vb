Imports System.IO
Imports System.Text
Imports Executable_Decryptor_UI.PS5_Payload_Sender

Public Class ExtraForm
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim portnumber As Integer, payload As String = ""
        If Not String.IsNullOrEmpty(Me.PayloadTxtbox.Text) Then
            payload = Me.PayloadTxtbox.Text
        End If

        If Not Integer.TryParse(PayloadportTxtbox.Text, portnumber) Then
            ' Parsing Unsuccessful, use the parsed value

            MessageBox.Show("Portnumber not Changed !! " & vbNewLine & "Invalid Number")
            Exit Sub
        End If
        My.Settings.Payload = payload
        My.Settings.PayloadPort = portnumber
        My.Settings.Save()
        MessageBox.Show("Values Updated!! ")
        showsettingvalues()
    End Sub

    Private Sub ExtraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showsettingvalues

    End Sub

    Private Sub showsettingvalues()
        PayloadportTxtbox.Text = My.Settings.PayloadPort
        PayloadTxtbox.Text = My.Settings.Payload.ToString
        IpTextBox.Text = My.Settings.PS5IP.ToString
        Dim pythonscript As String = My.Settings.PyScript.ToString
        If Not String.IsNullOrEmpty(pythonscript) Then
            TxtPython.Text = pythonscript
        Else
            TxtPython.Text = "make_fself_python3-1.py"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedFolder As String = BrowseFolder()
        If Not String.IsNullOrEmpty(selectedFolder) Then
            statlabel.Text = selectedFolder
            Dim Sd As String = VerifyDirectoryfiles(selectedFolder)
            MessageBox.Show(Sd, "Executables Verification", MessageBoxButtons.OK, MessageBoxIcon.None)
        End If
    End Sub

    Function VerifyDirectoryfiles(folderpath As String) As String
        Dim Rtext As New StringBuilder()

        Dim fileExtensions As String() = {".sprx", ".prx", ".bin"}
        Dim kilobytesToRead As Integer = 2
        ' Check if the directory exists

        Console.WriteLine("directory exists")
        ' Get all files with specified extensions
        For Each fileExtension In fileExtensions
            Dim files = Directory.GetFiles(folderpath, "*" & fileExtension, SearchOption.AllDirectories)
            For Each filePath In files
                ' Read and check the content
                Dim Fname As String = Path.GetFileName(filePath)
                If FileContainsElfString(filePath) Then
                    Rtext.AppendLine(Fname & " - Valid")

                Else
                    Rtext.AppendLine(Fname & " - inValid")

                End If
                'If Execute(filePath) Then
                '    writelog($"File {filePath} has the ELF string in the first 3 letters.")
                'Else
                '    writelog($"File {filePath} does not have the ELF string in the first 3 letters.")
                'End If
            Next
        Next
        ' Form1.CMDView.AppendText("Executables have been decrypted! You may proceed to replace them.")

        Return Rtext.ToString
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fpload As String = BrowseForFile("Binary and ELF Files|*.bin;*.elf|Binary Files (*.bin)|*.bin|ELF Files (*.elf)|*.elf|All Files|*.*")
        If Not String.IsNullOrEmpty(fpload) Then
            Me.statlabel.Text = fpload
            Dim psip As String = Me.IpTextBox.Text
            Dim portnum As Integer = CInt(Me.PayloadportTxtbox.Text)
            Dim psender As New PayloadV2()
            Dim isConnected As Boolean = psender.Connect2PS5(psip, portnum)

            If isConnected Then
                Try
                    Application.DoEvents()
                    ' Specify the path to your test.bin payload
                    'Dim payloadPath As String = "C:\path\to\test.bin"

                    ' Send the payload
                    psender.SendPayload(fpload)

                    ' Disconnect after sending
                    psender.DisconnectPayload()

                    MessageBox.Show("Payload sent successfully!")

                Catch ex As Exception

                    MessageBox.Show("Error while sending payload: " & ex.Message)
                    Exit Sub
                End Try
            Else
                MessageBox.Show("IP Not Found !!" & vbNewLine & $"{psip}:{portnum}", "Host Not Found")
            End If

        End If
        Me.statlabel.Text = "Idle...zzz"
    End Sub

    Function BrowseForFile(Ifilter As String) As String
        Dim openFileDialog As New OpenFileDialog()
        '"Binary and ELF Files|*.bin;*.elf|Binary Files (*.bin)|*.bin|ELF Files (*.elf)|*.elf|All Files|*.*"
        openFileDialog.Filter = Ifilter


        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Return openFileDialog.FileName
        Else

            Return String.Empty
        End If
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dfile As String = BrowseForFile("Binary and ELF Files|*.bin;*.elf|Binary Files (*.bin)|*.bin|ELF Files (*.elf)|*.elf|All Files|*.*")
        If Not String.IsNullOrEmpty(dfile) Then
            PayloadTxtbox.Text = dfile
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dfile As String = BrowseForFile("Python Files (*.py)|*.py|All Files|*.*")
        If Not String.IsNullOrEmpty(dfile) Then
            TxtPython.Text = dfile
        End If
    End Sub
End Class