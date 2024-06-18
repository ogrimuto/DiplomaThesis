<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStart
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonParameter = New System.Windows.Forms.Button()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.ButtonBase = New System.Windows.Forms.Button()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBoxEpsilon = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxSigma = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Axis1 = New WindowsApplication1.Axis()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ButtonParameter)
        Me.GroupBox1.Controls.Add(Me.CheckBox10)
        Me.GroupBox1.Controls.Add(Me.ButtonBase)
        Me.GroupBox1.Controls.Add(Me.CheckBox9)
        Me.GroupBox1.Controls.Add(Me.CheckBox8)
        Me.GroupBox1.Controls.Add(Me.CheckBox7)
        Me.GroupBox1.Controls.Add(Me.CheckBox6)
        Me.GroupBox1.Controls.Add(Me.CheckBox5)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 336)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Потенциалы"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 28)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Молекулярная динамика"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonParameter
        '
        Me.ButtonParameter.Location = New System.Drawing.Point(131, 278)
        Me.ButtonParameter.Name = "ButtonParameter"
        Me.ButtonParameter.Size = New System.Drawing.Size(101, 28)
        Me.ButtonParameter.TabIndex = 24
        Me.ButtonParameter.Text = "Параметры"
        Me.ButtonParameter.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(15, 80)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(148, 17)
        Me.CheckBox10.TabIndex = 23
        Me.CheckBox10.Text = "Потенциал Штокмайера"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'ButtonBase
        '
        Me.ButtonBase.Location = New System.Drawing.Point(15, 278)
        Me.ButtonBase.Name = "ButtonBase"
        Me.ButtonBase.Size = New System.Drawing.Size(101, 28)
        Me.ButtonBase.TabIndex = 22
        Me.ButtonBase.Text = "База"
        Me.ButtonBase.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(15, 241)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(204, 30)
        Me.CheckBox9.TabIndex = 8
        Me.CheckBox9.Text = "Многопараметрический потенциал" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Бойса-Шевитта"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(15, 218)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(157, 17)
        Me.CheckBox8.TabIndex = 7
        Me.CheckBox8.Text = "Потенциал Борна-Майера"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(15, 195)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(237, 17)
        Me.CheckBox7.TabIndex = 6
        Me.CheckBox7.Text = "Экранированный кулоновский потенциал"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(15, 172)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(132, 17)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "Потенциал Ридберга"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(15, 149)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(164, 17)
        Me.CheckBox5.TabIndex = 4
        Me.CheckBox5.Text = "Потенциал Пешля-Теллера"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(15, 126)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(117, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Потенциал Морзе"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(15, 103)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(139, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Потенциал Букингема"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(15, 59)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(178, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Потенциал Леннарда-Джонса"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 36)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(183, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Потенциалы с твердой сферой"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(293, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(129, 326)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Вещество"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(15, 21)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(93, 303)
        Me.ListBox1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Axis1)
        Me.GroupBox3.Location = New System.Drawing.Point(428, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(412, 423)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "График"
        '
        'TextBoxEpsilon
        '
        Me.TextBoxEpsilon.Location = New System.Drawing.Point(87, 40)
        Me.TextBoxEpsilon.Name = "TextBoxEpsilon"
        Me.TextBoxEpsilon.Size = New System.Drawing.Size(96, 20)
        Me.TextBoxEpsilon.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Epsilon/k, K"
        '
        'TextBoxSigma
        '
        Me.TextBoxSigma.Location = New System.Drawing.Point(87, 9)
        Me.TextBoxSigma.Name = "TextBoxSigma"
        Me.TextBoxSigma.Size = New System.Drawing.Size(94, 20)
        Me.TextBoxSigma.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sigma, A "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBoxEpsilon)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.TextBoxSigma)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 360)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(408, 91)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Итог"
        '
        'Axis1
        '
        Me.Axis1.axis_bkcolor = System.Drawing.Color.White
        Me.Axis1.axis_color = System.Drawing.Color.Gray
        Me.Axis1.Axis_Type = CType(1, Byte)
        Me.Axis1.E_x = 0
        Me.Axis1.E_y = 0
        Me.Axis1.Location = New System.Drawing.Point(6, 19)
        Me.Axis1.Name = "Axis1"
        Me.Axis1.Pix_color = System.Drawing.Color.Black
        Me.Axis1.Pix_Size = 2.0!
        Me.Axis1.Pix_type = CType(1, Byte)
        Me.Axis1.Size = New System.Drawing.Size(400, 398)
        Me.Axis1.TabIndex = 2
        Me.Axis1.x_Base = 1.0!
        Me.Axis1.x_Base0 = 0.0!
        Me.Axis1.x_Name = "X"
        Me.Axis1.y_Base = 1.0!
        Me.Axis1.y_Base0 = 0.0!
        Me.Axis1.y_Name = "Y"
        Me.Axis1.z_Base = 1.0!
        Me.Axis1.z_Name = "Z"
        '
        'FormStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 463)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormStart"
        Me.Text = "Полуэмпирические потенциалы"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSigma As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents Axis1 As WindowsApplication1.Axis
    Friend WithEvents TextBoxEpsilon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonBase As System.Windows.Forms.Button
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonParameter As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
