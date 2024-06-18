<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MolDinamics
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxAtomCountLine = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBoxEnergy = New System.Windows.Forms.TextBox()
        Me.CheckBoxAtom = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonNormal = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCenter = New System.Windows.Forms.RadioButton()
        Me.RadioButtonPerif = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxTp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBoxTc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxTcl = New System.Windows.Forms.TextBox()
        Me.ButtonMore = New System.Windows.Forms.Button()
        Me.ButtonLess = New System.Windows.Forms.Button()
        Me.TextBoxE = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxGrid = New System.Windows.Forms.CheckBox()
        Me.RadioButtonRect = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTriangl = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxRows = New System.Windows.Forms.TextBox()
        Me.RadioButton2D = New System.Windows.Forms.RadioButton()
        Me.RadioButton3D = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxM = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxMinDist = New System.Windows.Forms.TextBox()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxDiametr = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxBaseTau = New System.Windows.Forms.TextBox()
        Me.TextBoxEpsilon = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxtau = New System.Windows.Forms.TextBox()
        Me.TextBoxSigma = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxBase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxdtau = New System.Windows.Forms.TextBox()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxAtomCount = New System.Windows.Forms.TextBox()
        Me.ListBoxConfiguration = New System.Windows.Forms.ListBox()
        Me.AxisKinEPotE = New WindowsApplication1.Axis()
        Me.AxisT = New WindowsApplication1.Axis()
        Me.AxisGir = New WindowsApplication1.Axis()
        Me.AxisE = New WindowsApplication1.Axis()
        Me.Axis1 = New WindowsApplication1.Axis()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxAtomCountLine)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TextBoxEnergy)
        Me.GroupBox1.Controls.Add(Me.CheckBoxAtom)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBoxTp)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TextBoxTc)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBoxTcl)
        Me.GroupBox1.Controls.Add(Me.ButtonMore)
        Me.GroupBox1.Controls.Add(Me.ButtonLess)
        Me.GroupBox1.Controls.Add(Me.TextBoxE)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBoxM)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBoxMinDist)
        Me.GroupBox1.Controls.Add(Me.ButtonClear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxDiametr)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBoxBaseTau)
        Me.GroupBox1.Controls.Add(Me.TextBoxEpsilon)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBoxtau)
        Me.GroupBox1.Controls.Add(Me.TextBoxSigma)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBoxBase)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBoxdtau)
        Me.GroupBox1.Controls.Add(Me.ButtonStop)
        Me.GroupBox1.Controls.Add(Me.ButtonStart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBoxAtomCount)
        Me.GroupBox1.Controls.Add(Me.ListBoxConfiguration)
        Me.GroupBox1.Location = New System.Drawing.Point(747, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 513)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'TextBoxAtomCountLine
        '
        Me.TextBoxAtomCountLine.Location = New System.Drawing.Point(130, 181)
        Me.TextBoxAtomCountLine.Name = "TextBoxAtomCountLine"
        Me.TextBoxAtomCountLine.Size = New System.Drawing.Size(27, 20)
        Me.TextBoxAtomCountLine.TabIndex = 68
        Me.TextBoxAtomCountLine.Text = "7"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 272)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "База-энергия"
        '
        'TextBoxEnergy
        '
        Me.TextBoxEnergy.Location = New System.Drawing.Point(95, 270)
        Me.TextBoxEnergy.Name = "TextBoxEnergy"
        Me.TextBoxEnergy.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxEnergy.TabIndex = 66
        Me.TextBoxEnergy.Text = "20"
        '
        'CheckBoxAtom
        '
        Me.CheckBoxAtom.AutoSize = True
        Me.CheckBoxAtom.Location = New System.Drawing.Point(58, 76)
        Me.CheckBoxAtom.Name = "CheckBoxAtom"
        Me.CheckBoxAtom.Size = New System.Drawing.Size(52, 17)
        Me.CheckBoxAtom.TabIndex = 65
        Me.CheckBoxAtom.Text = "Атом"
        Me.CheckBoxAtom.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(163, 267)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 13)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Cp"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButtonNormal)
        Me.GroupBox4.Controls.Add(Me.RadioButtonCenter)
        Me.GroupBox4.Controls.Add(Me.RadioButtonPerif)
        Me.GroupBox4.Location = New System.Drawing.Point(113, 113)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(120, 59)
        Me.GroupBox4.TabIndex = 64
        Me.GroupBox4.TabStop = False
        '
        'RadioButtonNormal
        '
        Me.RadioButtonNormal.AutoSize = True
        Me.RadioButtonNormal.Checked = True
        Me.RadioButtonNormal.Location = New System.Drawing.Point(6, 8)
        Me.RadioButtonNormal.Name = "RadioButtonNormal"
        Me.RadioButtonNormal.Size = New System.Drawing.Size(58, 17)
        Me.RadioButtonNormal.TabIndex = 31
        Me.RadioButtonNormal.TabStop = True
        Me.RadioButtonNormal.Text = "Normal"
        Me.RadioButtonNormal.UseVisualStyleBackColor = True
        '
        'RadioButtonCenter
        '
        Me.RadioButtonCenter.AutoSize = True
        Me.RadioButtonCenter.Location = New System.Drawing.Point(64, 8)
        Me.RadioButtonCenter.Name = "RadioButtonCenter"
        Me.RadioButtonCenter.Size = New System.Drawing.Size(56, 17)
        Me.RadioButtonCenter.TabIndex = 29
        Me.RadioButtonCenter.Text = "Center"
        Me.RadioButtonCenter.UseVisualStyleBackColor = True
        '
        'RadioButtonPerif
        '
        Me.RadioButtonPerif.AutoSize = True
        Me.RadioButtonPerif.Location = New System.Drawing.Point(6, 31)
        Me.RadioButtonPerif.Name = "RadioButtonPerif"
        Me.RadioButtonPerif.Size = New System.Drawing.Size(46, 17)
        Me.RadioButtonPerif.TabIndex = 30
        Me.RadioButtonPerif.Text = "Perif"
        Me.RadioButtonPerif.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(193, 264)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(40, 20)
        Me.TextBox1.TabIndex = 62
        Me.TextBox1.Text = "7"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(165, 241)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Tp,K"
        '
        'TextBoxTp
        '
        Me.TextBoxTp.Location = New System.Drawing.Point(195, 238)
        Me.TextBoxTp.Name = "TextBoxTp"
        Me.TextBoxTp.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxTp.TabIndex = 60
        Me.TextBoxTp.Text = "7"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(163, 213)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Tc,K"
        '
        'TextBoxTc
        '
        Me.TextBoxTc.Location = New System.Drawing.Point(193, 210)
        Me.TextBoxTc.Name = "TextBoxTc"
        Me.TextBoxTc.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxTc.TabIndex = 58
        Me.TextBoxTc.Text = "7"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(163, 180)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "T,K"
        '
        'TextBoxTcl
        '
        Me.TextBoxTcl.Location = New System.Drawing.Point(193, 177)
        Me.TextBoxTcl.Name = "TextBoxTcl"
        Me.TextBoxTcl.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxTcl.TabIndex = 56
        Me.TextBoxTcl.Text = "7"
        '
        'ButtonMore
        '
        Me.ButtonMore.Location = New System.Drawing.Point(60, 453)
        Me.ButtonMore.Name = "ButtonMore"
        Me.ButtonMore.Size = New System.Drawing.Size(37, 23)
        Me.ButtonMore.TabIndex = 55
        Me.ButtonMore.Text = ">"
        Me.ButtonMore.UseVisualStyleBackColor = True
        '
        'ButtonLess
        '
        Me.ButtonLess.Location = New System.Drawing.Point(12, 453)
        Me.ButtonLess.Name = "ButtonLess"
        Me.ButtonLess.Size = New System.Drawing.Size(37, 23)
        Me.ButtonLess.TabIndex = 54
        Me.ButtonLess.Text = "<"
        Me.ButtonLess.UseVisualStyleBackColor = True
        '
        'TextBoxE
        '
        Me.TextBoxE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxE.Enabled = False
        Me.TextBoxE.Location = New System.Drawing.Point(117, 455)
        Me.TextBoxE.Name = "TextBoxE"
        Me.TextBoxE.Size = New System.Drawing.Size(74, 20)
        Me.TextBoxE.TabIndex = 53
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBoxGrid)
        Me.GroupBox3.Controls.Add(Me.RadioButtonRect)
        Me.GroupBox3.Controls.Add(Me.RadioButtonTriangl)
        Me.GroupBox3.Location = New System.Drawing.Point(109, 61)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(118, 46)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        '
        'CheckBoxGrid
        '
        Me.CheckBoxGrid.AutoSize = True
        Me.CheckBoxGrid.Location = New System.Drawing.Point(2, 19)
        Me.CheckBoxGrid.Name = "CheckBoxGrid"
        Me.CheckBoxGrid.Size = New System.Drawing.Size(45, 17)
        Me.CheckBoxGrid.TabIndex = 53
        Me.CheckBoxGrid.Text = "Grid"
        Me.CheckBoxGrid.UseVisualStyleBackColor = True
        '
        'RadioButtonRect
        '
        Me.RadioButtonRect.AutoSize = True
        Me.RadioButtonRect.Checked = True
        Me.RadioButtonRect.Location = New System.Drawing.Point(53, 3)
        Me.RadioButtonRect.Name = "RadioButtonRect"
        Me.RadioButtonRect.Size = New System.Drawing.Size(48, 17)
        Me.RadioButtonRect.TabIndex = 29
        Me.RadioButtonRect.TabStop = True
        Me.RadioButtonRect.Text = "Rect"
        Me.RadioButtonRect.UseVisualStyleBackColor = True
        '
        'RadioButtonTriangl
        '
        Me.RadioButtonTriangl.AutoSize = True
        Me.RadioButtonTriangl.Location = New System.Drawing.Point(53, 26)
        Me.RadioButtonTriangl.Name = "RadioButtonTriangl"
        Me.RadioButtonTriangl.Size = New System.Drawing.Size(63, 17)
        Me.RadioButtonTriangl.TabIndex = 30
        Me.RadioButtonTriangl.Text = "Triangle"
        Me.RadioButtonTriangl.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TextBoxRows)
        Me.GroupBox2.Controls.Add(Me.RadioButton2D)
        Me.GroupBox2.Controls.Add(Me.RadioButton3D)
        Me.GroupBox2.Location = New System.Drawing.Point(107, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 51)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 59
        Me.Label16.Text = "Rows"
        '
        'TextBoxRows
        '
        Me.TextBoxRows.Location = New System.Drawing.Point(50, 28)
        Me.TextBoxRows.Name = "TextBoxRows"
        Me.TextBoxRows.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxRows.TabIndex = 58
        Me.TextBoxRows.Text = "1"
        '
        'RadioButton2D
        '
        Me.RadioButton2D.AutoSize = True
        Me.RadioButton2D.Checked = True
        Me.RadioButton2D.Location = New System.Drawing.Point(6, 10)
        Me.RadioButton2D.Name = "RadioButton2D"
        Me.RadioButton2D.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton2D.TabIndex = 29
        Me.RadioButton2D.TabStop = True
        Me.RadioButton2D.Text = "2D"
        Me.RadioButton2D.UseVisualStyleBackColor = True
        '
        'RadioButton3D
        '
        Me.RadioButton3D.AutoSize = True
        Me.RadioButton3D.Location = New System.Drawing.Point(51, 10)
        Me.RadioButton3D.Name = "RadioButton3D"
        Me.RadioButton3D.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton3D.TabIndex = 30
        Me.RadioButton3D.Text = "3D"
        Me.RadioButton3D.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 351)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "масса, АЕМ"
        '
        'TextBoxM
        '
        Me.TextBoxM.Location = New System.Drawing.Point(95, 348)
        Me.TextBoxM.Name = "TextBoxM"
        Me.TextBoxM.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxM.TabIndex = 49
        Me.TextBoxM.Text = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(45, 328)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "MinDist"
        '
        'TextBoxMinDist
        '
        Me.TextBoxMinDist.Location = New System.Drawing.Point(95, 325)
        Me.TextBoxMinDist.Name = "TextBoxMinDist"
        Me.TextBoxMinDist.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxMinDist.TabIndex = 47
        Me.TextBoxMinDist.Text = "1"
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(6, 72)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(46, 23)
        Me.ButtonClear.TabIndex = 46
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Диаметр/Sigma"
        '
        'TextBoxDiametr
        '
        Me.TextBoxDiametr.Location = New System.Drawing.Point(95, 302)
        Me.TextBoxDiametr.Name = "TextBoxDiametr"
        Me.TextBoxDiametr.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxDiametr.TabIndex = 44
        Me.TextBoxDiametr.Text = "1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 255)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "База-время"
        '
        'TextBoxBaseTau
        '
        Me.TextBoxBaseTau.Location = New System.Drawing.Point(95, 248)
        Me.TextBoxBaseTau.Name = "TextBoxBaseTau"
        Me.TextBoxBaseTau.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxBaseTau.TabIndex = 41
        Me.TextBoxBaseTau.Text = "20"
        '
        'TextBoxEpsilon
        '
        Me.TextBoxEpsilon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxEpsilon.Enabled = False
        Me.TextBoxEpsilon.Location = New System.Drawing.Point(95, 426)
        Me.TextBoxEpsilon.Name = "TextBoxEpsilon"
        Me.TextBoxEpsilon.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxEpsilon.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 429)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Epsilon/k, K"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 407)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Sigma, A "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 379)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "время"
        '
        'TextBoxtau
        '
        Me.TextBoxtau.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBoxtau.Enabled = False
        Me.TextBoxtau.Location = New System.Drawing.Point(95, 379)
        Me.TextBoxtau.Name = "TextBoxtau"
        Me.TextBoxtau.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxtau.TabIndex = 39
        Me.TextBoxtau.Text = "10"
        '
        'TextBoxSigma
        '
        Me.TextBoxSigma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxSigma.Enabled = False
        Me.TextBoxSigma.Location = New System.Drawing.Point(95, 404)
        Me.TextBoxSigma.Name = "TextBoxSigma"
        Me.TextBoxSigma.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxSigma.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "База/Sigma"
        '
        'TextBoxBase
        '
        Me.TextBoxBase.Location = New System.Drawing.Point(95, 225)
        Me.TextBoxBase.Name = "TextBoxBase"
        Me.TextBoxBase.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxBase.TabIndex = 37
        Me.TextBoxBase.Text = "5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "временной шаг"
        '
        'TextBoxdtau
        '
        Me.TextBoxdtau.Location = New System.Drawing.Point(95, 204)
        Me.TextBoxdtau.Name = "TextBoxdtau"
        Me.TextBoxdtau.Size = New System.Drawing.Size(61, 20)
        Me.TextBoxdtau.TabIndex = 35
        Me.TextBoxdtau.Text = "0.01"
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(6, 43)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(46, 23)
        Me.ButtonStop.TabIndex = 34
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Enabled = False
        Me.ButtonStart.Location = New System.Drawing.Point(6, 14)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(46, 23)
        Me.ButtonStart.TabIndex = 33
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Число атомов"
        '
        'TextBoxAtomCount
        '
        Me.TextBoxAtomCount.Location = New System.Drawing.Point(95, 181)
        Me.TextBoxAtomCount.Name = "TextBoxAtomCount"
        Me.TextBoxAtomCount.Size = New System.Drawing.Size(27, 20)
        Me.TextBoxAtomCount.TabIndex = 25
        Me.TextBoxAtomCount.Text = "7"
        '
        'ListBoxConfiguration
        '
        Me.ListBoxConfiguration.FormattingEnabled = True
        Me.ListBoxConfiguration.Items.AddRange(New Object() {"face-centered lattice", "body-centered lattice", "densest packing", "free packing", "random packing"})
        Me.ListBoxConfiguration.Location = New System.Drawing.Point(6, 106)
        Me.ListBoxConfiguration.Name = "ListBoxConfiguration"
        Me.ListBoxConfiguration.Size = New System.Drawing.Size(107, 69)
        Me.ListBoxConfiguration.TabIndex = 22
        '
        'AxisKinEPotE
        '
        Me.AxisKinEPotE.axis_bkcolor = System.Drawing.Color.White
        Me.AxisKinEPotE.axis_color = System.Drawing.Color.Gray
        Me.AxisKinEPotE.Axis_Type = CType(1, Byte)
        Me.AxisKinEPotE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AxisKinEPotE.E_x = 0
        Me.AxisKinEPotE.E_y = 0
        Me.AxisKinEPotE.Location = New System.Drawing.Point(372, 334)
        Me.AxisKinEPotE.Name = "AxisKinEPotE"
        Me.AxisKinEPotE.Pix_color = System.Drawing.Color.Black
        Me.AxisKinEPotE.Pix_Size = 2.0R
        Me.AxisKinEPotE.Pix_type = CType(1, Byte)
        Me.AxisKinEPotE.Size = New System.Drawing.Size(363, 88)
        Me.AxisKinEPotE.TabIndex = 19
        Me.AxisKinEPotE.x_Base = 1.0R
        Me.AxisKinEPotE.x_Base0 = 0.0R
        Me.AxisKinEPotE.x_Name = "X"
        Me.AxisKinEPotE.y_Base = 1.0R
        Me.AxisKinEPotE.y_Base0 = 0.0R
        Me.AxisKinEPotE.y_Name = "Y"
        Me.AxisKinEPotE.z_Base = 1.0R
        Me.AxisKinEPotE.z_Name = "Z"
        '
        'AxisT
        '
        Me.AxisT.axis_bkcolor = System.Drawing.Color.White
        Me.AxisT.axis_color = System.Drawing.Color.Gray
        Me.AxisT.Axis_Type = CType(1, Byte)
        Me.AxisT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AxisT.E_x = 0
        Me.AxisT.E_y = 0
        Me.AxisT.Location = New System.Drawing.Point(372, 428)
        Me.AxisT.Name = "AxisT"
        Me.AxisT.Pix_color = System.Drawing.Color.Black
        Me.AxisT.Pix_Size = 2.0R
        Me.AxisT.Pix_type = CType(1, Byte)
        Me.AxisT.Size = New System.Drawing.Size(363, 66)
        Me.AxisT.TabIndex = 18
        Me.AxisT.x_Base = 1.0R
        Me.AxisT.x_Base0 = 0.0R
        Me.AxisT.x_Name = "X"
        Me.AxisT.y_Base = 1.0R
        Me.AxisT.y_Base0 = 0.0R
        Me.AxisT.y_Name = "Y"
        Me.AxisT.z_Base = 1.0R
        Me.AxisT.z_Name = "Z"
        '
        'AxisGir
        '
        Me.AxisGir.axis_bkcolor = System.Drawing.Color.White
        Me.AxisGir.axis_color = System.Drawing.Color.Gray
        Me.AxisGir.Axis_Type = CType(1, Byte)
        Me.AxisGir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AxisGir.E_x = 0
        Me.AxisGir.E_y = 0
        Me.AxisGir.Location = New System.Drawing.Point(372, 168)
        Me.AxisGir.Name = "AxisGir"
        Me.AxisGir.Pix_color = System.Drawing.Color.Black
        Me.AxisGir.Pix_Size = 2.0R
        Me.AxisGir.Pix_type = CType(1, Byte)
        Me.AxisGir.Size = New System.Drawing.Size(363, 160)
        Me.AxisGir.TabIndex = 17
        Me.AxisGir.x_Base = 1.0R
        Me.AxisGir.x_Base0 = 0.0R
        Me.AxisGir.x_Name = "X"
        Me.AxisGir.y_Base = 1.0R
        Me.AxisGir.y_Base0 = 0.0R
        Me.AxisGir.y_Name = "Y"
        Me.AxisGir.z_Base = 1.0R
        Me.AxisGir.z_Name = "Z"
        '
        'AxisE
        '
        Me.AxisE.axis_bkcolor = System.Drawing.Color.White
        Me.AxisE.axis_color = System.Drawing.Color.Gray
        Me.AxisE.Axis_Type = CType(1, Byte)
        Me.AxisE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AxisE.E_x = 0
        Me.AxisE.E_y = 0
        Me.AxisE.Location = New System.Drawing.Point(372, 2)
        Me.AxisE.Name = "AxisE"
        Me.AxisE.Pix_color = System.Drawing.Color.Black
        Me.AxisE.Pix_Size = 2.0R
        Me.AxisE.Pix_type = CType(1, Byte)
        Me.AxisE.Size = New System.Drawing.Size(363, 160)
        Me.AxisE.TabIndex = 15
        Me.AxisE.x_Base = 1.0R
        Me.AxisE.x_Base0 = 0.0R
        Me.AxisE.x_Name = "X"
        Me.AxisE.y_Base = 1.0R
        Me.AxisE.y_Base0 = 0.0R
        Me.AxisE.y_Name = "Y"
        Me.AxisE.z_Base = 1.0R
        Me.AxisE.z_Name = "Z"
        '
        'Axis1
        '
        Me.Axis1.axis_bkcolor = System.Drawing.Color.White
        Me.Axis1.axis_color = System.Drawing.Color.Gray
        Me.Axis1.Axis_Type = CType(1, Byte)
        Me.Axis1.E_x = 0
        Me.Axis1.E_y = 0
        Me.Axis1.Location = New System.Drawing.Point(3, 2)
        Me.Axis1.Name = "Axis1"
        Me.Axis1.Pix_color = System.Drawing.Color.Black
        Me.Axis1.Pix_Size = 2.0R
        Me.Axis1.Pix_type = CType(1, Byte)
        Me.Axis1.Size = New System.Drawing.Size(363, 362)
        Me.Axis1.TabIndex = 4
        Me.Axis1.x_Base = 1.0R
        Me.Axis1.x_Base0 = 0.0R
        Me.Axis1.x_Name = "X"
        Me.Axis1.y_Base = 1.0R
        Me.Axis1.y_Base0 = 0.0R
        Me.Axis1.y_Name = "Y"
        Me.Axis1.z_Base = 1.0R
        Me.Axis1.z_Name = "Z"
        '
        'MolDinamics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 527)
        Me.Controls.Add(Me.AxisKinEPotE)
        Me.Controls.Add(Me.AxisT)
        Me.Controls.Add(Me.AxisGir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AxisE)
        Me.Controls.Add(Me.Axis1)
        Me.MinimizeBox = False
        Me.Name = "MolDinamics"
        Me.Text = "Molecular Dynamics. Van der Waals clusters"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Axis1 As WindowsApplication1.Axis
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AxisE As WindowsApplication1.Axis
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBaseTau As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEpsilon As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxtau As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSigma As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxdtau As System.Windows.Forms.TextBox
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents RadioButton3D As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2D As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAtomCount As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxConfiguration As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDiametr As System.Windows.Forms.TextBox
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMinDist As System.Windows.Forms.TextBox
    Friend WithEvents AxisGir As WindowsApplication1.Axis
    Friend WithEvents AxisT As WindowsApplication1.Axis
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxM As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonRect As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTriangl As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxGrid As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonMore As System.Windows.Forms.Button
    Friend WithEvents ButtonLess As System.Windows.Forms.Button
    Friend WithEvents TextBoxE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTp As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTcl As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonNormal As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCenter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPerif As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxAtom As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEnergy As System.Windows.Forms.TextBox
    Friend WithEvents AxisKinEPotE As WindowsApplication1.Axis
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRows As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAtomCountLine As System.Windows.Forms.TextBox
End Class
