<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.InputGroupBox = New System.Windows.Forms.GroupBox()
        Me.COMMComboBox = New System.Windows.Forms.ComboBox()
        Me.ConnectionLabel = New System.Windows.Forms.Label()
        Me.FromLabel = New System.Windows.Forms.Label()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.COMMTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TxTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.StToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SampleRateTextBox = New System.Windows.Forms.TextBox()
        Me.SampleRateLabel = New System.Windows.Forms.Label()
        Me.InputGroupBox.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'InputGroupBox
        '
        Me.InputGroupBox.Controls.Add(Me.COMMComboBox)
        Me.InputGroupBox.Controls.Add(Me.ConnectionLabel)
        Me.InputGroupBox.Controls.Add(Me.FromLabel)
        Me.InputGroupBox.Location = New System.Drawing.Point(12, 355)
        Me.InputGroupBox.Name = "InputGroupBox"
        Me.InputGroupBox.Size = New System.Drawing.Size(148, 83)
        Me.InputGroupBox.TabIndex = 0
        Me.InputGroupBox.TabStop = False
        Me.InputGroupBox.Text = "Input"
        '
        'COMMComboBox
        '
        Me.COMMComboBox.FormattingEnabled = True
        Me.COMMComboBox.Location = New System.Drawing.Point(45, 24)
        Me.COMMComboBox.Name = "COMMComboBox"
        Me.COMMComboBox.Size = New System.Drawing.Size(88, 21)
        Me.COMMComboBox.TabIndex = 1
        '
        'ConnectionLabel
        '
        Me.ConnectionLabel.AutoSize = True
        Me.ConnectionLabel.Location = New System.Drawing.Point(6, 53)
        Me.ConnectionLabel.Name = "ConnectionLabel"
        Me.ConnectionLabel.Size = New System.Drawing.Size(127, 13)
        Me.ConnectionLabel.TabIndex = 2
        Me.ConnectionLabel.Text = "Connect to a Quiet Board"
        '
        'FromLabel
        '
        Me.FromLabel.AutoSize = True
        Me.FromLabel.Location = New System.Drawing.Point(6, 27)
        Me.FromLabel.Name = "FromLabel"
        Me.FromLabel.Size = New System.Drawing.Size(33, 13)
        Me.FromLabel.TabIndex = 1
        Me.FromLabel.Text = "From:"
        '
        'SerialPort
        '
        '
        'COMMTimer
        '
        '
        'TxTimer
        '
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(559, 367)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(125, 71)
        Me.ExitButton.TabIndex = 1
        Me.ExitButton.Text = "E&xit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(166, 367)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(125, 71)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "St&art"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(297, 367)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(125, 71)
        Me.StopButton.TabIndex = 3
        Me.StopButton.Text = "Sto&p"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(428, 367)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(125, 71)
        Me.SaveButton.TabIndex = 4
        Me.SaveButton.Text = "Sa&ve"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(698, 25)
        Me.TopMenuStrip.TabIndex = 5
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'StToolStripMenuItem
        '
        Me.StToolStripMenuItem.Name = "StToolStripMenuItem"
        Me.StToolStripMenuItem.Size = New System.Drawing.Size(34, 21)
        Me.StToolStripMenuItem.Text = "St"
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'SampleRateTextBox
        '
        Me.SampleRateTextBox.Location = New System.Drawing.Point(643, 28)
        Me.SampleRateTextBox.Name = "SampleRateTextBox"
        Me.SampleRateTextBox.Size = New System.Drawing.Size(43, 20)
        Me.SampleRateTextBox.TabIndex = 7
        '
        'SampleRateLabel
        '
        Me.SampleRateLabel.AutoSize = True
        Me.SampleRateLabel.Location = New System.Drawing.Point(528, 31)
        Me.SampleRateLabel.Name = "SampleRateLabel"
        Me.SampleRateLabel.Size = New System.Drawing.Size(109, 13)
        Me.SampleRateLabel.TabIndex = 8
        Me.SampleRateLabel.Text = "Samples Per Second:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 450)
        Me.Controls.Add(Me.SampleRateLabel)
        Me.Controls.Add(Me.SampleRateTextBox)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.InputGroupBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "MainForm"
        Me.Text = "Data Logger"
        Me.InputGroupBox.ResumeLayout(False)
        Me.InputGroupBox.PerformLayout()
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InputGroupBox As GroupBox
    Friend WithEvents COMMComboBox As ComboBox
    Friend WithEvents ConnectionLabel As Label
    Friend WithEvents FromLabel As Label
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents COMMTimer As Timer
    Friend WithEvents TxTimer As Timer
    Friend WithEvents ExitButton As Button
    Friend WithEvents StartButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents StToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents ContextMenuStrip As ContextMenuStrip
    Friend WithEvents SampleRateTextBox As TextBox
    Friend WithEvents SampleRateLabel As Label
End Class
