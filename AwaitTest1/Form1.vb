Public Class Form1

    Private Function ThingOne() As String
        Return "Here comes..."
    End Function

    Private Function ThingTwo() As String
        System.Threading.Thread.Sleep(5000)
        Return vbCrLf & "Slowpoke" & vbCrLf
    End Function

    Private Function ThingThree() As String
        Return "He's here!" & vbCrLf
    End Function

    Private Sub ClearBox()
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.AppendText("=== Blocking Test ===" & vbCrLf)
        ClearBox()
        TextBox2.AppendText("Start T1" & vbCrLf)
        TextBox1.AppendText(ThingOne())
        TextBox2.AppendText("Start T2" & vbCrLf)
        TextBox1.AppendText(ThingTwo())
        TextBox2.AppendText("Start T3" & vbCrLf)
        TextBox1.AppendText(ThingThree())
        TextBox2.AppendText("--- Test Complete ---" & vbCrLf)
    End Sub

    Private Async Function doThingTwo() As Task(Of String)
        Return Await Task.Run(Function()
                                  Return ThingTwo()
                              End Function)
    End Function

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.AppendText("=== Await Test ===" & vbCrLf)
        ClearBox()
        TextBox2.AppendText("Start T1" & vbCrLf)
        TextBox1.AppendText(ThingOne())
        TextBox2.AppendText("Start T2" & vbCrLf)
        TextBox1.AppendText(Await doThingTwo())
        TextBox2.AppendText("Start T3" & vbCrLf)
        TextBox1.AppendText(ThingThree())
        TextBox2.AppendText("--- Test Complete ---" & vbCrLf)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.PerformStep()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.AppendText(".")
        TextBox2.AppendText("Speed-Up Button Click" & vbCrLf)
    End Sub
End Class
