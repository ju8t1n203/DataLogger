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
        Me.InputGroupBox.SuspendLayout()
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
        'COMMTimer
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.InputGroupBox)
        Me.Name = "MainForm"
        Me.Text = "Data Logger"
        Me.InputGroupBox.ResumeLayout(False)
        Me.InputGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents InputGroupBox As GroupBox
    Friend WithEvents COMMComboBox As ComboBox
    Friend WithEvents ConnectionLabel As Label
    Friend WithEvents FromLabel As Label
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents COMMTimer As Timer
    Friend WithEvents TxTimer As Timer
End Class
