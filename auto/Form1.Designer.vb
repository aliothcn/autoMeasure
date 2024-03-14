<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.log = New System.Windows.Forms.ListBox()
        Me.result = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.isLoop = New System.Windows.Forms.CheckBox()
        Me.loopTimeValue = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tloop = New System.Windows.Forms.Timer(Me.components)
        Me.modelChange = New System.Windows.Forms.CheckBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.openini = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtpath = New System.Windows.Forms.TextBox()
        CType(Me.loopTimeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(75, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "连接"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(140, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 36)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "开始"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'log
        '
        Me.log.FormattingEnabled = True
        Me.log.ItemHeight = 12
        Me.log.Location = New System.Drawing.Point(9, 108)
        Me.log.Name = "log"
        Me.log.Size = New System.Drawing.Size(317, 412)
        Me.log.TabIndex = 2
        '
        'result
        '
        Me.result.FormattingEnabled = True
        Me.result.ItemHeight = 12
        Me.result.Location = New System.Drawing.Point(338, 12)
        Me.result.Name = "result"
        Me.result.Size = New System.Drawing.Size(504, 508)
        Me.result.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 525)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(411, 109)
        Me.TextBox1.TabIndex = 4
        '
        'Timer1
        '
        '
        'isLoop
        '
        Me.isLoop.AutoSize = True
        Me.isLoop.Location = New System.Drawing.Point(15, 51)
        Me.isLoop.Name = "isLoop"
        Me.isLoop.Size = New System.Drawing.Size(48, 16)
        Me.isLoop.TabIndex = 5
        Me.isLoop.Text = "循环"
        Me.isLoop.UseVisualStyleBackColor = True
        '
        'loopTimeValue
        '
        Me.loopTimeValue.Location = New System.Drawing.Point(68, 50)
        Me.loopTimeValue.Name = "loopTimeValue"
        Me.loopTimeValue.Size = New System.Drawing.Size(66, 21)
        Me.loopTimeValue.TabIndex = 6
        Me.loopTimeValue.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "秒"
        '
        'tloop
        '
        '
        'modelChange
        '
        Me.modelChange.AutoSize = True
        Me.modelChange.Location = New System.Drawing.Point(174, 51)
        Me.modelChange.Name = "modelChange"
        Me.modelChange.Size = New System.Drawing.Size(72, 16)
        Me.modelChange.TabIndex = 8
        Me.modelChange.Text = "模式切换"
        Me.modelChange.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(431, 525)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(411, 109)
        Me.TextBox2.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(10, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(58, 36)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "加载ini"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(205, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(58, 36)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "停止"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'openini
        '
        Me.openini.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "结果保存位置"
        '
        'txtpath
        '
        Me.txtpath.Location = New System.Drawing.Point(95, 80)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.Size = New System.Drawing.Size(168, 21)
        Me.txtpath.TabIndex = 13
        Me.txtpath.Text = "D:\data\"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 657)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.modelChange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.loopTimeValue)
        Me.Controls.Add(Me.isLoop)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.log)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.loopTimeValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents log As ListBox
    Friend WithEvents result As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents isLoop As CheckBox
    Friend WithEvents loopTimeValue As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents tloop As Timer
    Friend WithEvents modelChange As CheckBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents openini As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents txtpath As TextBox
End Class
