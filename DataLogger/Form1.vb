'Justin Bell
'RCET3371
'Spring 2025
'https://github.com/ju8t1n203/DataLogger

Option Explicit On
Option Strict On
Imports System.IO.Ports
Imports System.Text

Public Class MainForm
    Dim countinue As Boolean = False
    Dim incoming As New Queue(Of Byte)

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
            TxTimer.Enabled = True
        End If
    End Sub

    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        BasicQY.RecieveData(SerialPort, incoming)
    End Sub

    Private Sub TxTimer_Tick(sender As Object, e As EventArgs) Handles TxTimer.Tick
        Static iterration As Boolean = False
        Dim working As Byte = &H0

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
        End If
    End Sub

End Class
