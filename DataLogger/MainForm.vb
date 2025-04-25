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

Public Class MainForm
    Dim countinue As Boolean = False
    Dim incoming As New Queue(Of Byte)
    Dim ADC(1) As Integer

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        COMMTimer.Enabled = True
    End Sub

    'serial port setup-----------------------------------------------
    Private Sub COMMComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles COMMComboBox.SelectedIndexChanged
        BasicQY.VerifyQ(countinue, SerialPort, COMMComboBox)
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
        End If
    End Sub

    'data handling-------------------------------------------------
    Private Sub TXTimer_Tick(sender As Object, e As EventArgs) Handles TXTimer.Tick
        Dim _bytes(1) As Byte
        _bytes(0) = &H51
        _bytes(1) = &H52

        SerialPort.Write(_bytes, 0, 2)
        ADC = BasicQY.GetAnalog(incoming)
        ADC1ValueTextBox.Text = $"{ADC(0)}"
    End Sub

    Private Sub SampleRateTextBox_Validated(sender As Object, e As EventArgs) Handles SampleRateTextBox.Validated
        Dim sampleRate As Integer

        Try
            sampleRate = CInt(1 / (SampleRateTextBox.Text))
            If sampleRate < 101 And sampleRate > 0 Then
                TXTimer.Interval = sampleRate
            End If
        Catch ex As Exception
            MsgBox("Enter an integer value 1-100")
        End Try

        TXTimer.Enabled = True

    End Sub

    Private Sub SampleRateTextBox_Click(sender As Object, e As EventArgs) Handles SampleRateTextBox.Click
        TXTimer.Enabled = False
    End Sub

    'buttons-------------------------------------------------------------
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If countinue = True Then
            SaveButton.Enabled = False
            TXTimer.Enabled = True
        Else
            MsgBox("Please Connect to a QY@ Board")
        End If
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        SaveButton.Enabled = True
        TXTimer.Enabled = False
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

End Class