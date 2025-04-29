'Justin Bell
'RCET3371
'Spring 2025
'https://github.com/ju8t1n203/DataLogger

Option Explicit On
'Option Strict On
Imports System.Drawing.Drawing2D
Imports System.IO.Ports
Imports System.Runtime.Remoting.Services
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainForm
    Dim incoming As New Queue(Of Byte)
    Dim ADC(1, 2) As Integer
    Private rollingData As New Queue(Of KeyValuePair(Of DateTime, Integer))()
    Dim currentlog As New List(Of String())

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        COMMTimer.Enabled = True
        ADC1ValueTextBox.Text = "N/A"
    End Sub

    'serial port setup-----------------------------------------------
    Private Sub COMMComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles COMMComboBox.SelectedIndexChanged
        BasicQY.VerifyQ(SerialPort, COMMComboBox)
    End Sub

    Private Sub COMMTimer_Tick(sender As Object, e As EventArgs) Handles COMMTimer.Tick
        Dim comPorts As String() = SerialPort.GetPortNames()

        If comPorts.Length > 0 Then
            For Each port As String In comPorts
                COMMComboBox.Items.Add(port)
            Next
            COMMTimer.Enabled = False
            VerificationTimer.Enabled = True
        End If
    End Sub

    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        BasicQY.RecieveData(SerialPort, incoming)
    End Sub

    Private Sub VerificationTimer_Tick(sender As Object, e As EventArgs) Handles VerificationTimer.Tick
        Static iterration As Boolean = False
        Dim working As Byte = &H0
        Static countinue As Boolean = False

        SampleRateTextBox.Text = $"{1 / (VerificationTimer.Interval * 0.001)}"

        If countinue = False Then
            Try
                working = incoming.Dequeue
            Catch ex As Exception
                working = &H0
            End Try
            'verifies the connected device is the quiet boad
            countinue = BasicQY.QYCheck(working)
        Else
            ConnectionLabel.Text = "Quiet Board is Connected"
            VerificationTimer.Enabled = False
            countinue = False
        End If
    End Sub

    'data handling-------------------------------------------------
    Private Sub TXTimer_Tick(sender As Object, e As EventArgs) Handles TXTimer.Tick
        Dim _bytes(1) As Byte
        _bytes(0) = &H51
        _bytes(1) = &H52

        SerialPort.Write(_bytes, 0, 2)
        ADC = BasicQY.GetAnalog(incoming)

        If ADC(0, 0) > 1 Then
            ADC1ValueTextBox.Text = $"{ADC(0, 0)}"

            FilePathLabel.Text = $"Saving To: {FileStuff.GetFileName}"

            Dim nextRow As String() = New String(4) {}

            nextRow(0) = "$$"
            nextRow(1) = "AN1"
            nextRow(2) = $"{CStr(ADC(0, 1))}"
            nextRow(3) = $"{CStr(ADC(0, 2))}"
            nextRow(4) = $"{DateTime.Now.ToString("mm:ss:ff")}"

            currentlog.Add(nextRow)

            UpdateGraph()

        End If

        'SampleRateTextBox.Text = TXTimer.Interval

    End Sub

    Private Sub SampleRateTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles SampleRateTextBox.TextChanged
        'used to set timer interval on the fly
        'user input is number of ms followed immediately by #
        'e.g. 1000# = 1000 ms
        If SampleRateTextBox.Text.Trim.EndsWith("#") Then 'does textbox end with #
            'yes
            Dim s As String = SampleRateTextBox.Text.Trim.TrimEnd(New Char() {"#"c}) 'get number part
            Dim i As Integer
            If Integer.TryParse(s, i) Then 'if it is an integer set timer1.interval
                TXTimer.Interval = i
                SampleRateTextBox.Text = ""
            Else
                Debug.WriteLine("error nan") 'not a number
            End If
        End If
    End Sub

    'graph-----------------------------------------------------------

    Sub UpdateGraph()
        'get current value from the ADC array
        Dim newValue As Integer = ADC(0, 0)

        'add new data point with the current timestamp
        rollingData.Enqueue(New KeyValuePair(Of DateTime, Integer)(DateTime.Now, newValue))

        'remove data outside the 30 seconds
        While rollingData.Count > 0 AndAlso (DateTime.Now - rollingData.Peek().Key).TotalSeconds > 30
            rollingData.Dequeue()
        End While

        'redraw the graph
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            DrawGraph(g)
        End Using
        PictureBox1.Image = bmp
    End Sub

    Private Sub DrawGraph(g As Graphics)
        Dim points As New List(Of PointF)
        Dim maxValue As Integer = 1023

        'map the rolling data
        For Each kvp In rollingData
            Dim x = (PictureBox1.Width * (kvp.Key - DateTime.Now.AddSeconds(-30)).TotalSeconds) / 30
            Dim y = PictureBox1.Height - (PictureBox1.Height * kvp.Value / maxValue)
            points.Add(New PointF(CSng(x), CSng(y)))
        Next

        If points.Count > 1 Then
            g.DrawLines(Pens.Green, points.ToArray())
        End If
    End Sub

    'buttons-------------------------------------------------------------
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If VerificationTimer.Enabled = False Then
            SaveButton.Enabled = False
            TXTimer.Enabled = True
        Else
            MsgBox("Please Connect to a QY@ Board")
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        SaveButton.Enabled = True
        TXTimer.Enabled = False
        ADC1ValueTextBox.Text = "N/A"
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        FileStuff.SaveToLogFile(currentlog)
        currentlog.Clear()
        SaveButton.Enabled = False
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

End Class
