Imports System.IO

Module nslookup2csv

    Sub Main()
        Dim strParams As String() = Environment.GetCommandLineArgs()
        Dim objEncode As Text.Encoding = Text.Encoding.GetEncoding("shift_jis")
        Dim strLines As String()
        Dim strTempLine As String = ""
        Dim strOutputFileName As String = ""

        Try
            Console.WriteLine("--------------------")
            Console.WriteLine("nslookup2csv")
            Console.WriteLine("--------------------")

            ' Parameter check
            If ParamCheck(strParams) = False Then
                Console.WriteLine("Parameter error")
                Exit Sub
            Else

                Console.WriteLine("Target:" & Path.GetFullPath(strParams(1)))

                ' Load log file
                strLines = File.ReadAllLines(strParams(1), objEncode)

                ' Output file name
                strOutputFileName = ".\" & Path.GetFileNameWithoutExtension(strParams(1)) & "_Edited.csv"

                If strLines.Length <> 0 Then
                    File.WriteAllLines(strOutputFileName, SetOutputLines(strLines), objEncode)
                End If
            End If

            Console.WriteLine("Output:" & Path.GetFullPath(strOutputFileName))
            Console.WriteLine("Finish")

        Catch ex As Exception
            Console.WriteLine("Failed")
        Finally
            Console.WriteLine("Press any key to exit")
            Console.ReadKey()
        End Try
    End Sub

    ''' <summary>
    ''' ParamCheck
    ''' </summary>
    ''' <param name="vstrParams">Parameter</param>
    ''' <returns>Result</returns>
    Private Function ParamCheck(ByVal vstrParams As String()) As Boolean
        Try
            If vstrParams.Length <> 2 OrElse File.Exists(vstrParams(1)) = False Then
                Return False
            End If

            If File.Exists(vstrParams(1)) = False Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SetOutputLines(ByVal vstrLines As String()) As String()

        Dim strTempLine As String = ""
        Dim strOutputLines As String()

        ReDim Preserve strOutputLines(vstrLines.Length)

        Try
            Dim j As Integer = 0

            If vstrLines.Length > 0 Then
                strOutputLines(j) = "TARGET IP ADDRESS" & vbTab & "SERVER" & vbTab & "ADDRESS" & vbTab & "NAME" & vbTab & "ADDRESS"
            End If

            For i = 0 To vstrLines.Length - 1

                If vstrLines(i).Contains("NSLOOKUP") = True Then
                    j += 1
                    strOutputLines(j) &= Trim(Mid(vstrLines(i), vstrLines(i).IndexOf("NSLOOKUP") + 9))
                    strOutputLines(j) &= vbTab
                End If


                If vstrLines(i).Contains("サーバー:") = True Then
                    strOutputLines(j) &= Trim(Mid(vstrLines(i), vstrLines(i).IndexOf("サーバー:") + 6))
                    strOutputLines(j) &= vbTab
                End If

                If vstrLines(i).Contains("Address:") = True Then
                    strOutputLines(j) &= Trim(Mid(vstrLines(i), vstrLines(i).IndexOf("Address:") + 9))
                    strOutputLines(j) &= vbTab
                End If

                If vstrLines(i).Contains("名前:") = True Then
                    strOutputLines(j) &= Trim(Mid(vstrLines(i), vstrLines(i).IndexOf("名前:") + 4))
                    strOutputLines(j) &= vbTab
                End If

            Next

            Return strOutputLines

        Catch ex As Exception
            Return strOutputLines
        End Try
    End Function
End Module
