Imports System.IO

Module Logger
    Function SendToLogFile(ByVal StrLine As String, Optional sLogFilePath As String = "") As Boolean
        Try
            Dim strDateTime As String, sFN As String, Mytxt As String


            'dddd, dd MMMM yyyy HH:mm:ss tt
            strDateTime = Format(Now, "dddd, MMM dd yyyy") & " - " & Format(Now, "hh:mm:ss tt")
            'sFN = "Output.txt"
            sFN = "OutPut.txt"
            'fs = CreateObject("Scripting.FileSystemObject")
            Mytxt = strDateTime & vbTab & "-:: " & StrLine
            sLogFilePath = Application.StartupPath & "\" & sFN
            'Dim sw As StreamWriter = File.AppendText(sLogFilePath)

            If Not System.IO.File.Exists(sLogFilePath) Then

                File.Create(sLogFilePath).Dispose()
            End If

            Using writer As New StreamWriter(sLogFilePath, True)
                writer.WriteLine(Mytxt)
            End Using

            SendToLogFile = True
        Catch ex As Exception
            SendToLogFile = False

        End Try
    End Function

End Module
