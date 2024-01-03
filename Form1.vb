Imports System.IO
Imports System.Threading
Imports Executable_Decryptor_UI.PS5_Payload_Sender
Imports PS4_Payload_Sender
Public Class Form1

    Private batScriptFileName As String = "BatScript.bat"
    Public batScriptFilePath As String
    Private Async Function Step1Execute() As Task

        'create command
        'command: socat -u -d -d -d TCP:ps5.ip:9023,reuseaddr OPEN:ra.tar,creat
        Dim psIP As String = CStr(IPTextBOX.Text)
        Dim psPort As String = CStr(PortTxtBOX.Text)
        Dim Mytar As String = "Executable.tar"
        Dim payload As String = "sleirs_dumper.bin"
        'Dim argument As String = $"socat -u -d -d -d TCP:{psIP}:{psPort},reuseaddr OPEN:{Mytar},creat > output.log 2>&1"

        Dim argument As String = $"-u -d -d -d  TCP:{psIP}:{psPort},reuseaddr OPEN:{Mytar},creat"
        CMDView.Clear()
        CMDView.AppendText("*****   Session Started   *****" & Environment.NewLine)
        Application.DoEvents()
        Statlabel.Text = "Please wait..!!"
        'RunSocat(argument)
        'SendPayload(psIP, psPort, payload)
        'Dim task1 As Task = Task.Run(Sub() RunSocat(argument))
        'Dim task2 As Task = Task.Run(Sub() SendPayload(psIP, 9020, payload))

        'Task.WaitAll(task1)
        'Task.WaitAll(task2)
        If Not File.Exists(payload) Then
            CMDView.AppendText("Dumper Payload Missing !!" & Environment.NewLine)

            CMDView.AppendText("*****   Session Ended   *****" & Environment.NewLine)
            Exit Function
        End If
        If File.Exists("OutPut.txt") Then
            File.Delete("OutPut.txt")
        End If
        'SendPayload(psIP, 9020, payload)

        ' Create an instance of PayloadV2
        Dim psender As New PayloadV2()
        ' Connect to PS4
        Dim portnumber As Integer

        If Integer.TryParse(My.Settings.PayloadPort, portnumber) Then
            writelog($"Parsed port number: {portnumber}")
        Else            ' Parsing failed, use a default value
            writelog("Parsing failed. Using default port number.")
            portnumber = 9020
        End If


        Dim isConnected As Boolean = psender.Connect2PS5(psIP, portnumber)

        If isConnected Then
            Try
                Application.DoEvents()
                ' Specify the path to your test.bin payload
                'Dim payloadPath As String = "C:\path\to\test.bin"

                ' Send the payload
                psender.SendPayload(payload)

                ' Disconnect after sending
                psender.DisconnectPayload()

                writelog("Payload sent successfully!")
                My.Settings.PS5IP = psIP
                My.Settings.KLOGPORT = portnumber
                My.Settings.Save()
            Catch ex As Exception

                writelog("Error while sending payload: " & ex.Message)

                Exit Function
            End Try
        Else
            writelog("Error connecting to PS5. Exception: " & psender.PayloadException)
            Statlabel.Text = "Idle.."
            CMDView.AppendText("*****   Session Ended   *****" & Environment.NewLine)
            Exit Function
        End If



        Dim result As Boolean = Await RunSocat(argument)

        If result Then
            writelog("Socat Connection Success !!")
            writelog("Extracting Files !!")
            DecryptAndCheckTar()

        Else
            writelog("Socat connection Timed Out")

            'writelog("Sending Dumper Payload - Aborted !")
        End If
        CMDView.AppendText("*****   Session Ended   *****" & Environment.NewLine)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowInstructions()
        Me.Verlabel.Text = $"Ver:{My.Application.Info.Version.ToString}"
        Me.IPTextBOX.Text = My.Settings.PS5IP.ToString
        Me.PortTxtBOX.Text = My.Settings.KLOGPORT


        '    CMDView.Rtf = "{\rtf " &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs28\cf1 Credits:\par \cell\cell\intbl\fs28\cf1 Tools Created By:\cell\par" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - Dumper by sleirsgoevy\cell\cell\intbl\fs18 - Socat by tech128\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - Make_FSELF by EchoStretch\cell\cell\intbl\fs18 - Itemzflow for wonderful app \cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs28\cf1 Scene Developers:\cell\cell\intbl\fs18 - Theflow0\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - Znullptr\cell\cell\intbl\fs18 - ChendoChap\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - Specter\cell\cell\intbl\fs18 - Sleirsgoevy\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - SiSTRo\cell\cell\intbl\fs18 - Al-Azif\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - PRB-Borg\cell\cell\intbl\fs18 - Leeful\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs28\cf1 Contact Information:\cell\cell\intbl\fs18 Please contact me if I forgot to give any credits.\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - rajeshca911\cell\cell\intbl\fs18 Twitter: @rajeshca911\cell\row" &
        '"\trowd\trgaph70\trleft-70\tcellx2000\tcellx4000\intbl\fs18 - Github: @rajeshca911\cell\cell\intbl\fs18 Discord: Rajesh#7267\cell\row" &
        '"}"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowInstructions()
    End Sub
    Private Sub ShowInstructions()
        CMDView.Rtf = "{\rtf
\fs25\cf1 Steps to Decrypt and Sign Executables:\par
\par
\fs23\1. Enter the PS5 IP:\par
\fs20 - Open the application and input the PS5 IP address.\par
\par
\fs23\2. Click 'Inject & Run':\par
\fs20 - Press the 'Inject & Run' button to initiate the process.\par
\fs20 - it will send payload as well so no need to use other payload sender.\par
\par
\fs23\3. Retrieve Executable:\par
\fs20 - The process will generate an 'executable.tar' file in socat folder  ,\par
 'Decrypted Files' Folder in application location which contains all the executables of the game.\par
\par
\fs23\4. Replace Files in Game Dump:\par
\fs20 - Replace the corresponding files in your game dump folder with the generated 'Decrypted Files'.\par
\fs20 - Make sure all executables statuses were '-Decrypted'.\par
\par
\fs23\5. Click 'Sign Executables':\par
\fs20 - Once the replacement is done, click 'Sign Executables'.\par
\par
\fs23\6. Browse the Game Folder:\par
\fs20 - Navigate to the game folder and select it to complete the signing process.\par
\par
\fs23\7. Done:\par
\fs20 - The executable files are now signed and ready for use.\par
}
"
    End Sub
    Private Sub ShowCredits()
        CMDView.Rtf = "{\rtf " &
            "\fs28\cf1 Credits:\par  " &
            "\fs28\cf1 Tools Created By:\par " &
            "\fs18 - Dumper by sleirsgoevy\par " &
            "\fs18 - Socat by tech128\par " &
            "\fs18 - Make_FSELF by EchoStretch,Flatz\par" &
            "\fs18 - LightningMods for wonderful app \par \par " &
    "\fs28\cf1 Scene Developers:\par " &
    "\fs18 - Theflow0\par " &
    "- Znullptr\par " &
    "- ChendoChap\par " &
    "- Specter\par " &
    "- Sleirsgoevy\par " &
    "- SiSTRo\par " &
    "- Al-Azif\par " &
    "- PRB-Borg\par " &
    "- Leeful\par " &
    "- And Many More...\par " &
    "\par " &
    "\fs28\cf1 Contact Information:\par " &
    "\fs18 Please contact me if I forgot to give any credits.\par " &
    "\par " &
    "\fs18 - rajeshca911\par " &
    "\fs18   Twitter: @rajeshca911\par " &
    "\fs18   Github: @rajeshca911\par " &
    "\fs18   Discord: Rajesh#7267\par " &
    "}"

    End Sub

    Private Sub BtnCredits_Click(sender As Object, e As EventArgs) Handles BtnCredits.Click
        ShowCredits()
    End Sub


    Private Sub DecryptAndCheckTar()
        Dim socatFolderPath As String = Path.Combine(appPath, "Socat")
        Dim tarfile As String = Path.Combine(socatFolderPath, "Executable.tar")

        If Not Directory.Exists(destin) Then

            Directory.CreateDirectory(destin)
        End If

        If Not File.Exists(tarfile) Then
            writelog("Executable Archive is not found")
            Exit Sub
        End If
        ExtractTar(tarfile, destin)
        CheckDecryptedFiles()
    End Sub

    Private Async Function BtnRun_ClickAsync(sender As Object, e As EventArgs) As Task Handles BtnRun.Click
        Await Step1Execute()
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        ExtraForm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckAppUpdate()
    End Sub

    Private Sub BtnSignExecutables_Click(sender As Object, e As EventArgs) Handles BtnSignExecutables.Click
        Dim pythonfile As String = My.Settings.PyScript.ToString
        Dim batscript As String = "Make_FSELF_PY3.bat"
        If String.IsNullOrEmpty(pythonfile) Then
            pythonfile = "make_fself_python3-1.py"
        End If
        If Not File.Exists(pythonfile) Then
            MessageBox.Show($"Python Script Missing - '{pythonfile}'")
            Exit Sub
        End If


        Dim GameFolderLocation As String = BrowseFolder()
        If Not String.IsNullOrEmpty(GameFolderLocation) Then
            createbatinGamefolderlocation(GameFolderLocation)

            Me.CMDView.Clear()
            ' Copy the bat script to the game folder location
            'Dim batScriptDestinationPath As String = Path.Combine(GameFolderLocation, batscript)
            'File.Copy(batscript, batScriptDestinationPath, True) ' The third parameter (True) allows overwriting if the file already exists

            ' Copy the python script to the game folder location
            Dim pythonScriptDestinationPath As String = Path.Combine(GameFolderLocation, pythonfile)
            File.Copy(pythonfile, pythonScriptDestinationPath, True)

            writelog($"Scripts copied to: {GameFolderLocation}")
            'writelog($"Running script {batScriptDestinationPath}")

            Dim process As New Process()

            ' Set up process start information
            process.StartInfo.FileName = batScriptFilePath
            process.StartInfo.WorkingDirectory = GameFolderLocation
            'process.StartInfo.RedirectStandardOutput = True
            'process.StartInfo.RedirectStandardError = True
            'process.StartInfo.RedirectStandardInput = True
            'process.StartInfo.UseShellExecute = False
            'process.StartInfo.CreateNoWindow = True

            ' Start the process and capture details
            Try
                process.Start()

                process.WaitForExit()

                '' Get process details
                'Dim exitCode As Integer = process.ExitCode
                'Dim processOutput As String = process.StandardOutput.ReadToEnd()
                'Dim processError As String = process.StandardError.ReadToEnd()

                'writelog($"Output: {processOutput}")
                writelog("Process Executed !!")


            Catch ex As Exception
                MessageBox.Show($"Error starting process: {ex.Message}")
            Finally
                process.Dispose()
            End Try

        End If

    End Sub

    Private Sub createbatinGamefolderlocation(gameFolderLocation As String)
        ' Specify the bat script file name
        ' batScriptFileName As String = "YourBatchScript.bat"

        ' Specify the content of the bat script
        Dim batScriptContent As String =
            "@echo off" & vbCrLf &
            "echo." & vbCrLf &
            "echo PS5 Make Fake Self Script By EchoStretch" & vbCrLf &
            "echo Requires LightningMods_ Updated Make Fself By Flatz" & vbCrLf &
            "echo." & vbCrLf &
            "set ""fself=make_fself_python3-1.py""" & vbCrLf &
            "" & vbCrLf &
            "cd /d ""%~dp0""" & vbCrLf &
            "" & vbCrLf &
            "FOR /R %%i IN (*.sprx *.prx *.elf *.self *eboot.bin) DO (" & vbCrLf &
            "    echo Encrypting %%i..." & vbCrLf &
            "    echo." & vbCrLf &
            "    python %fself% ""%%i"" ""%%i.estemp""" & vbCrLf &
            "    REN ""%%i"" ""%%~nxi.esbak""" & vbCrLf &
            "    echo." & vbCrLf &
            ")" & vbCrLf &
            "" & vbCrLf &
            "echo." & vbCrLf &
            "echo Renaming Temporary Files..." & vbCrLf &
            "" & vbCrLf &
            "FOR /R %%i IN (*.estemp) DO (" & vbCrLf &
            "    REN ""%%i"" ""%%~ni""" & vbCrLf &
            ")" & vbCrLf &
        "exit" & vbCrLf '&
        '"REM Redirect output to a file instead of using pause" & vbCrLf &
        '"echo Batch execution completed. Press any key to exit. > ""batch_complete.txt"""


        batScriptFilePath = Path.Combine(gameFolderLocation, batScriptFileName)


        File.WriteAllText(batScriptFilePath, batScriptContent)

        writelog($"Bat script '{batScriptFileName}' created in '{gameFolderLocation}'")
    End Sub

    Private Sub Verlabel_Click(sender As Object, e As EventArgs) Handles Verlabel.Click
        Process.Start("https://github.com/rajeshca911")
    End Sub




End Class
