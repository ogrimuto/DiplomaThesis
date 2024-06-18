using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MolDinamics : Form
    {

        // Форма переопределяет dispose для очистки списка компонентов.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Является обязательной для конструктора форм Windows Forms
        private System.ComponentModel.IContainer components;

        // Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
        // Для ее изменения используйте конструктор форм Windows Form.  
        // Не изменяйте ее в редакторе исходного кода.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Timer1 = new Timer(components);
            Timer1.Tick += new EventHandler(Timer1_Tick);
            GroupBox1 = new GroupBox();
            TextBoxAtomCountLine = new TextBox();
            Label15 = new Label();
            TextBoxEnergy = new TextBox();
            CheckBoxAtom = new CheckBox();
            CheckBoxAtom.CheckedChanged += new EventHandler(CheckBoxAtom_CheckedChanged);
            Label14 = new Label();
            GroupBox4 = new GroupBox();
            RadioButtonNormal = new RadioButton();
            RadioButtonNormal.CheckedChanged += new EventHandler(RadioButtonNormal_CheckedChanged);
            RadioButtonCenter = new RadioButton();
            RadioButtonCenter.CheckedChanged += new EventHandler(RadioButtonCenter_CheckedChanged);
            RadioButtonPerif = new RadioButton();
            RadioButtonPerif.CheckedChanged += new EventHandler(RadioButtonPerif_CheckedChanged);
            TextBox1 = new TextBox();
            Label13 = new Label();
            TextBoxTp = new TextBox();
            Label12 = new Label();
            TextBoxTc = new TextBox();
            Label11 = new Label();
            TextBoxTcl = new TextBox();
            ButtonMore = new Button();
            ButtonMore.Click += new EventHandler(ButtonMore_Click);
            ButtonLess = new Button();
            ButtonLess.Click += new EventHandler(ButtonLess_Click);
            TextBoxE = new TextBox();
            GroupBox3 = new GroupBox();
            CheckBoxGrid = new CheckBox();
            CheckBoxGrid.CheckedChanged += new EventHandler(CheckBoxGrid_CheckedChanged_1);
            RadioButtonRect = new RadioButton();
            RadioButtonRect.CheckedChanged += new EventHandler(RadioButtonRect_CheckedChanged);
            RadioButtonTriangl = new RadioButton();
            RadioButtonTriangl.CheckedChanged += new EventHandler(RadioButtonTriangl_CheckedChanged);
            GroupBox2 = new GroupBox();
            Label16 = new Label();
            TextBoxRows = new TextBox();
            RadioButton2D = new RadioButton();
            RadioButton2D.CheckedChanged += new EventHandler(RadioButton2D_CheckedChanged);
            RadioButton3D = new RadioButton();
            RadioButton3D.CheckedChanged += new EventHandler(RadioButton3D_CheckedChanged);
            Label10 = new Label();
            TextBoxM = new TextBox();
            Label9 = new Label();
            TextBoxMinDist = new TextBox();
            ButtonClear = new Button();
            ButtonClear.Click += new EventHandler(ButtonClear_Click);
            Label2 = new Label();
            TextBoxDiametr = new TextBox();
            Label8 = new Label();
            TextBoxBaseTau = new TextBox();
            TextBoxEpsilon = new TextBox();
            Label7 = new Label();
            Label6 = new Label();
            Label5 = new Label();
            TextBoxtau = new TextBox();
            TextBoxSigma = new TextBox();
            Label3 = new Label();
            TextBoxBase = new TextBox();
            Label4 = new Label();
            TextBoxdtau = new TextBox();
            ButtonStop = new Button();
            ButtonStop.Click += new EventHandler(ButtonStop_Click);
            ButtonStart = new Button();
            ButtonStart.Click += new EventHandler(ButtonStart_Click);
            Label1 = new Label();
            TextBoxAtomCount = new TextBox();
            ListBoxConfiguration = new ListBox();
            ListBoxConfiguration.MouseClick += new MouseEventHandler(ListBoxConfiguration_MouseClick);
            ListBoxConfiguration.SelectedIndexChanged += new EventHandler(ListBoxConfiguration_SelectedIndexChanged);
            ListBoxConfiguration.TabStopChanged += new EventHandler(ListBoxConfiguration_TabStopChanged);
            AxisKinEPotE = new Axis();
            AxisT = new Axis();
            AxisGir = new Axis();
            AxisE = new Axis();
            Axis1 = new Axis();
            GroupBox1.SuspendLayout();
            GroupBox4.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Timer1
            // 
            Timer1.Interval = 1;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(TextBoxAtomCountLine);
            GroupBox1.Controls.Add(Label15);
            GroupBox1.Controls.Add(TextBoxEnergy);
            GroupBox1.Controls.Add(CheckBoxAtom);
            GroupBox1.Controls.Add(Label14);
            GroupBox1.Controls.Add(GroupBox4);
            GroupBox1.Controls.Add(TextBox1);
            GroupBox1.Controls.Add(Label13);
            GroupBox1.Controls.Add(TextBoxTp);
            GroupBox1.Controls.Add(Label12);
            GroupBox1.Controls.Add(TextBoxTc);
            GroupBox1.Controls.Add(Label11);
            GroupBox1.Controls.Add(TextBoxTcl);
            GroupBox1.Controls.Add(ButtonMore);
            GroupBox1.Controls.Add(ButtonLess);
            GroupBox1.Controls.Add(TextBoxE);
            GroupBox1.Controls.Add(GroupBox3);
            GroupBox1.Controls.Add(GroupBox2);
            GroupBox1.Controls.Add(Label10);
            GroupBox1.Controls.Add(TextBoxM);
            GroupBox1.Controls.Add(Label9);
            GroupBox1.Controls.Add(TextBoxMinDist);
            GroupBox1.Controls.Add(ButtonClear);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(TextBoxDiametr);
            GroupBox1.Controls.Add(Label8);
            GroupBox1.Controls.Add(TextBoxBaseTau);
            GroupBox1.Controls.Add(TextBoxEpsilon);
            GroupBox1.Controls.Add(Label7);
            GroupBox1.Controls.Add(Label6);
            GroupBox1.Controls.Add(Label5);
            GroupBox1.Controls.Add(TextBoxtau);
            GroupBox1.Controls.Add(TextBoxSigma);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Controls.Add(TextBoxBase);
            GroupBox1.Controls.Add(Label4);
            GroupBox1.Controls.Add(TextBoxdtau);
            GroupBox1.Controls.Add(ButtonStop);
            GroupBox1.Controls.Add(ButtonStart);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Controls.Add(TextBoxAtomCount);
            GroupBox1.Controls.Add(ListBoxConfiguration);
            GroupBox1.Location = new Point(747, 2);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(239, 513);
            GroupBox1.TabIndex = 16;
            GroupBox1.TabStop = false;
            // 
            // TextBoxAtomCountLine
            // 
            TextBoxAtomCountLine.Location = new Point(130, 181);
            TextBoxAtomCountLine.Name = "TextBoxAtomCountLine";
            TextBoxAtomCountLine.Size = new Size(27, 20);
            TextBoxAtomCountLine.TabIndex = 68;
            TextBoxAtomCountLine.Text = "7";
            // 
            // Label15
            // 
            Label15.AutoSize = true;
            Label15.Location = new Point(13, 272);
            Label15.Name = "Label15";
            Label15.Size = new Size(76, 13);
            Label15.TabIndex = 67;
            Label15.Text = "База-энергия";
            // 
            // TextBoxEnergy
            // 
            TextBoxEnergy.Location = new Point(95, 270);
            TextBoxEnergy.Name = "TextBoxEnergy";
            TextBoxEnergy.Size = new Size(61, 20);
            TextBoxEnergy.TabIndex = 66;
            TextBoxEnergy.Text = "20";
            // 
            // CheckBoxAtom
            // 
            CheckBoxAtom.AutoSize = true;
            CheckBoxAtom.Location = new Point(58, 76);
            CheckBoxAtom.Name = "CheckBoxAtom";
            CheckBoxAtom.Size = new Size(52, 17);
            CheckBoxAtom.TabIndex = 65;
            CheckBoxAtom.Text = "Атом";
            CheckBoxAtom.UseVisualStyleBackColor = true;
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.Location = new Point(163, 267);
            Label14.Name = "Label14";
            Label14.Size = new Size(20, 13);
            Label14.TabIndex = 63;
            Label14.Text = "Cp";
            // 
            // GroupBox4
            // 
            GroupBox4.Controls.Add(RadioButtonNormal);
            GroupBox4.Controls.Add(RadioButtonCenter);
            GroupBox4.Controls.Add(RadioButtonPerif);
            GroupBox4.Location = new Point(113, 113);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Size = new Size(120, 59);
            GroupBox4.TabIndex = 64;
            GroupBox4.TabStop = false;
            // 
            // RadioButtonNormal
            // 
            RadioButtonNormal.AutoSize = true;
            RadioButtonNormal.Checked = true;
            RadioButtonNormal.Location = new Point(6, 8);
            RadioButtonNormal.Name = "RadioButtonNormal";
            RadioButtonNormal.Size = new Size(58, 17);
            RadioButtonNormal.TabIndex = 31;
            RadioButtonNormal.TabStop = true;
            RadioButtonNormal.Text = "Normal";
            RadioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // RadioButtonCenter
            // 
            RadioButtonCenter.AutoSize = true;
            RadioButtonCenter.Location = new Point(64, 8);
            RadioButtonCenter.Name = "RadioButtonCenter";
            RadioButtonCenter.Size = new Size(56, 17);
            RadioButtonCenter.TabIndex = 29;
            RadioButtonCenter.Text = "Center";
            RadioButtonCenter.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPerif
            // 
            RadioButtonPerif.AutoSize = true;
            RadioButtonPerif.Location = new Point(6, 31);
            RadioButtonPerif.Name = "RadioButtonPerif";
            RadioButtonPerif.Size = new Size(46, 17);
            RadioButtonPerif.TabIndex = 30;
            RadioButtonPerif.Text = "Perif";
            RadioButtonPerif.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            TextBox1.Location = new Point(193, 264);
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new Size(40, 20);
            TextBox1.TabIndex = 62;
            TextBox1.Text = "7";
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.Location = new Point(165, 241);
            Label13.Name = "Label13";
            Label13.Size = new Size(30, 13);
            Label13.TabIndex = 61;
            Label13.Text = "Tp,K";
            // 
            // TextBoxTp
            // 
            TextBoxTp.Location = new Point(195, 238);
            TextBoxTp.Name = "TextBoxTp";
            TextBoxTp.Size = new Size(40, 20);
            TextBoxTp.TabIndex = 60;
            TextBoxTp.Text = "7";
            // 
            // Label12
            // 
            Label12.AutoSize = true;
            Label12.Location = new Point(163, 213);
            Label12.Name = "Label12";
            Label12.Size = new Size(30, 13);
            Label12.TabIndex = 59;
            Label12.Text = "Tc,K";
            // 
            // TextBoxTc
            // 
            TextBoxTc.Location = new Point(193, 210);
            TextBoxTc.Name = "TextBoxTc";
            TextBoxTc.Size = new Size(40, 20);
            TextBoxTc.TabIndex = 58;
            TextBoxTc.Text = "7";
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Location = new Point(163, 180);
            Label11.Name = "Label11";
            Label11.Size = new Size(24, 13);
            Label11.TabIndex = 57;
            Label11.Text = "T,K";
            // 
            // TextBoxTcl
            // 
            TextBoxTcl.Location = new Point(193, 177);
            TextBoxTcl.Name = "TextBoxTcl";
            TextBoxTcl.Size = new Size(40, 20);
            TextBoxTcl.TabIndex = 56;
            TextBoxTcl.Text = "7";
            // 
            // ButtonMore
            // 
            ButtonMore.Location = new Point(60, 453);
            ButtonMore.Name = "ButtonMore";
            ButtonMore.Size = new Size(37, 23);
            ButtonMore.TabIndex = 55;
            ButtonMore.Text = ">";
            ButtonMore.UseVisualStyleBackColor = true;
            // 
            // ButtonLess
            // 
            ButtonLess.Location = new Point(12, 453);
            ButtonLess.Name = "ButtonLess";
            ButtonLess.Size = new Size(37, 23);
            ButtonLess.TabIndex = 54;
            ButtonLess.Text = "<";
            ButtonLess.UseVisualStyleBackColor = true;
            // 
            // TextBoxE
            // 
            TextBoxE.BackColor = Color.FromArgb(255, 224, 192);
            TextBoxE.Enabled = false;
            TextBoxE.Location = new Point(117, 455);
            TextBoxE.Name = "TextBoxE";
            TextBoxE.Size = new Size(74, 20);
            TextBoxE.TabIndex = 53;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(CheckBoxGrid);
            GroupBox3.Controls.Add(RadioButtonRect);
            GroupBox3.Controls.Add(RadioButtonTriangl);
            GroupBox3.Location = new Point(109, 61);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(118, 46);
            GroupBox3.TabIndex = 52;
            GroupBox3.TabStop = false;
            // 
            // CheckBoxGrid
            // 
            CheckBoxGrid.AutoSize = true;
            CheckBoxGrid.Location = new Point(2, 19);
            CheckBoxGrid.Name = "CheckBoxGrid";
            CheckBoxGrid.Size = new Size(45, 17);
            CheckBoxGrid.TabIndex = 53;
            CheckBoxGrid.Text = "Grid";
            CheckBoxGrid.UseVisualStyleBackColor = true;
            // 
            // RadioButtonRect
            // 
            RadioButtonRect.AutoSize = true;
            RadioButtonRect.Checked = true;
            RadioButtonRect.Location = new Point(53, 3);
            RadioButtonRect.Name = "RadioButtonRect";
            RadioButtonRect.Size = new Size(48, 17);
            RadioButtonRect.TabIndex = 29;
            RadioButtonRect.TabStop = true;
            RadioButtonRect.Text = "Rect";
            RadioButtonRect.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTriangl
            // 
            RadioButtonTriangl.AutoSize = true;
            RadioButtonTriangl.Location = new Point(53, 26);
            RadioButtonTriangl.Name = "RadioButtonTriangl";
            RadioButtonTriangl.Size = new Size(63, 17);
            RadioButtonTriangl.TabIndex = 30;
            RadioButtonTriangl.Text = "Triangle";
            RadioButtonTriangl.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(Label16);
            GroupBox2.Controls.Add(TextBoxRows);
            GroupBox2.Controls.Add(RadioButton2D);
            GroupBox2.Controls.Add(RadioButton3D);
            GroupBox2.Location = new Point(107, 7);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(126, 51);
            GroupBox2.TabIndex = 51;
            GroupBox2.TabStop = false;
            // 
            // Label16
            // 
            Label16.AutoSize = true;
            Label16.Location = new Point(9, 31);
            Label16.Name = "Label16";
            Label16.Size = new Size(34, 13);
            Label16.TabIndex = 59;
            Label16.Text = "Rows";
            // 
            // TextBoxRows
            // 
            TextBoxRows.Location = new Point(50, 28);
            TextBoxRows.Name = "TextBoxRows";
            TextBoxRows.Size = new Size(40, 20);
            TextBoxRows.TabIndex = 58;
            TextBoxRows.Text = "1";
            // 
            // RadioButton2D
            // 
            RadioButton2D.AutoSize = true;
            RadioButton2D.Checked = true;
            RadioButton2D.Location = new Point(6, 10);
            RadioButton2D.Name = "RadioButton2D";
            RadioButton2D.Size = new Size(39, 17);
            RadioButton2D.TabIndex = 29;
            RadioButton2D.TabStop = true;
            RadioButton2D.Text = "2D";
            RadioButton2D.UseVisualStyleBackColor = true;
            // 
            // RadioButton3D
            // 
            RadioButton3D.AutoSize = true;
            RadioButton3D.Location = new Point(51, 10);
            RadioButton3D.Name = "RadioButton3D";
            RadioButton3D.Size = new Size(39, 17);
            RadioButton3D.TabIndex = 30;
            RadioButton3D.Text = "3D";
            RadioButton3D.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Location = new Point(25, 351);
            Label10.Name = "Label10";
            Label10.Size = new Size(68, 13);
            Label10.TabIndex = 50;
            Label10.Text = "масса, АЕМ";
            // 
            // TextBoxM
            // 
            TextBoxM.Location = new Point(95, 348);
            TextBoxM.Name = "TextBoxM";
            TextBoxM.Size = new Size(61, 20);
            TextBoxM.TabIndex = 49;
            TextBoxM.Text = "1";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Location = new Point(45, 328);
            Label9.Name = "Label9";
            Label9.Size = new Size(42, 13);
            Label9.TabIndex = 48;
            Label9.Text = "MinDist";
            // 
            // TextBoxMinDist
            // 
            TextBoxMinDist.Location = new Point(95, 325);
            TextBoxMinDist.Name = "TextBoxMinDist";
            TextBoxMinDist.Size = new Size(61, 20);
            TextBoxMinDist.TabIndex = 47;
            TextBoxMinDist.Text = "1";
            // 
            // ButtonClear
            // 
            ButtonClear.Location = new Point(6, 72);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(46, 23);
            ButtonClear.TabIndex = 46;
            ButtonClear.Text = "Clear";
            ButtonClear.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(6, 309);
            Label2.Name = "Label2";
            Label2.Size = new Size(87, 13);
            Label2.TabIndex = 45;
            Label2.Text = "Диаметр/Sigma";
            // 
            // TextBoxDiametr
            // 
            TextBoxDiametr.Location = new Point(95, 302);
            TextBoxDiametr.Name = "TextBoxDiametr";
            TextBoxDiametr.Size = new Size(61, 20);
            TextBoxDiametr.TabIndex = 44;
            TextBoxDiametr.Text = "1";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new Point(22, 255);
            Label8.Name = "Label8";
            Label8.Size = new Size(67, 13);
            Label8.TabIndex = 42;
            Label8.Text = "База-время";
            // 
            // TextBoxBaseTau
            // 
            TextBoxBaseTau.Location = new Point(95, 248);
            TextBoxBaseTau.Name = "TextBoxBaseTau";
            TextBoxBaseTau.Size = new Size(61, 20);
            TextBoxBaseTau.TabIndex = 41;
            TextBoxBaseTau.Text = "20";
            // 
            // TextBoxEpsilon
            // 
            TextBoxEpsilon.BackColor = Color.FromArgb(255, 224, 192);
            TextBoxEpsilon.Enabled = false;
            TextBoxEpsilon.Location = new Point(95, 426);
            TextBoxEpsilon.Name = "TextBoxEpsilon";
            TextBoxEpsilon.Size = new Size(61, 20);
            TextBoxEpsilon.TabIndex = 28;
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(10, 429);
            Label7.Name = "Label7";
            Label7.Size = new Size(65, 13);
            Label7.TabIndex = 27;
            Label7.Text = "Epsilon/k, K";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(10, 407);
            Label6.Name = "Label6";
            Label6.Size = new Size(52, 13);
            Label6.TabIndex = 21;
            Label6.Text = "Sigma, A ";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(10, 379);
            Label5.Name = "Label5";
            Label5.Size = new Size(39, 13);
            Label5.TabIndex = 40;
            Label5.Text = "время";
            // 
            // TextBoxtau
            // 
            TextBoxtau.BackColor = Color.FromArgb(255, 192, 128);
            TextBoxtau.Enabled = false;
            TextBoxtau.Location = new Point(95, 379);
            TextBoxtau.Name = "TextBoxtau";
            TextBoxtau.Size = new Size(61, 20);
            TextBoxtau.TabIndex = 39;
            TextBoxtau.Text = "10";
            // 
            // TextBoxSigma
            // 
            TextBoxSigma.BackColor = Color.FromArgb(255, 224, 192);
            TextBoxSigma.Enabled = false;
            TextBoxSigma.Location = new Point(95, 404);
            TextBoxSigma.Name = "TextBoxSigma";
            TextBoxSigma.Size = new Size(61, 20);
            TextBoxSigma.TabIndex = 23;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(22, 232);
            Label3.Name = "Label3";
            Label3.Size = new Size(66, 13);
            Label3.TabIndex = 38;
            Label3.Text = "База/Sigma";
            // 
            // TextBoxBase
            // 
            TextBoxBase.Location = new Point(95, 225);
            TextBoxBase.Name = "TextBoxBase";
            TextBoxBase.Size = new Size(61, 20);
            TextBoxBase.TabIndex = 37;
            TextBoxBase.Text = "5";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(2, 207);
            Label4.Name = "Label4";
            Label4.Size = new Size(85, 13);
            Label4.TabIndex = 36;
            Label4.Text = "временной шаг";
            // 
            // TextBoxdtau
            // 
            TextBoxdtau.Location = new Point(95, 204);
            TextBoxdtau.Name = "TextBoxdtau";
            TextBoxdtau.Size = new Size(61, 20);
            TextBoxdtau.TabIndex = 35;
            TextBoxdtau.Text = "0.01";
            // 
            // ButtonStop
            // 
            ButtonStop.Location = new Point(6, 43);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(46, 23);
            ButtonStop.TabIndex = 34;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            // 
            // ButtonStart
            // 
            ButtonStart.Enabled = false;
            ButtonStart.Location = new Point(6, 14);
            ButtonStart.Name = "ButtonStart";
            ButtonStart.Size = new Size(46, 23);
            ButtonStart.TabIndex = 33;
            ButtonStart.Text = "Start";
            ButtonStart.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(8, 184);
            Label1.Name = "Label1";
            Label1.Size = new Size(79, 13);
            Label1.TabIndex = 26;
            Label1.Text = "Число атомов";
            // 
            // TextBoxAtomCount
            // 
            TextBoxAtomCount.Location = new Point(95, 181);
            TextBoxAtomCount.Name = "TextBoxAtomCount";
            TextBoxAtomCount.Size = new Size(27, 20);
            TextBoxAtomCount.TabIndex = 25;
            TextBoxAtomCount.Text = "7";
            // 
            // ListBoxConfiguration
            // 
            ListBoxConfiguration.FormattingEnabled = true;
            ListBoxConfiguration.Items.AddRange(new object[] { "face-centered lattice", "body-centered lattice", "densest packing", "free packing", "random packing" });
            ListBoxConfiguration.Location = new Point(6, 106);
            ListBoxConfiguration.Name = "ListBoxConfiguration";
            ListBoxConfiguration.Size = new Size(107, 69);
            ListBoxConfiguration.TabIndex = 22;
            // 
            // AxisKinEPotE
            // 
            AxisKinEPotE.axis_bkcolor = Color.White;
            AxisKinEPotE.axis_color = Color.Gray;
            AxisKinEPotE.Axis_Type = 1;
            AxisKinEPotE.BackColor = Color.FromArgb(255, 224, 192);
            AxisKinEPotE.E_x = 0;
            AxisKinEPotE.E_y = 0;
            AxisKinEPotE.Location = new Point(372, 334);
            AxisKinEPotE.Name = "AxisKinEPotE";
            AxisKinEPotE.Pix_color = Color.Black;
            AxisKinEPotE.Pix_Size = 2.0d;
            AxisKinEPotE.Pix_type = 1;
            AxisKinEPotE.Size = new Size(363, 88);
            AxisKinEPotE.TabIndex = 19;
            AxisKinEPotE.x_Base = 1.0d;
            AxisKinEPotE.x_Base0 = 0.0d;
            AxisKinEPotE.x_Name = "X";
            AxisKinEPotE.y_Base = 1.0d;
            AxisKinEPotE.y_Base0 = 0.0d;
            AxisKinEPotE.y_Name = "Y";
            AxisKinEPotE.z_Base = 1.0d;
            AxisKinEPotE.z_Name = "Z";
            // 
            // AxisT
            // 
            AxisT.axis_bkcolor = Color.White;
            AxisT.axis_color = Color.Gray;
            AxisT.Axis_Type = 1;
            AxisT.BackColor = Color.FromArgb(255, 224, 192);
            AxisT.E_x = 0;
            AxisT.E_y = 0;
            AxisT.Location = new Point(372, 428);
            AxisT.Name = "AxisT";
            AxisT.Pix_color = Color.Black;
            AxisT.Pix_Size = 2.0d;
            AxisT.Pix_type = 1;
            AxisT.Size = new Size(363, 66);
            AxisT.TabIndex = 18;
            AxisT.x_Base = 1.0d;
            AxisT.x_Base0 = 0.0d;
            AxisT.x_Name = "X";
            AxisT.y_Base = 1.0d;
            AxisT.y_Base0 = 0.0d;
            AxisT.y_Name = "Y";
            AxisT.z_Base = 1.0d;
            AxisT.z_Name = "Z";
            // 
            // AxisGir
            // 
            AxisGir.axis_bkcolor = Color.White;
            AxisGir.axis_color = Color.Gray;
            AxisGir.Axis_Type = 1;
            AxisGir.BackColor = Color.FromArgb(255, 224, 192);
            AxisGir.E_x = 0;
            AxisGir.E_y = 0;
            AxisGir.Location = new Point(372, 168);
            AxisGir.Name = "AxisGir";
            AxisGir.Pix_color = Color.Black;
            AxisGir.Pix_Size = 2.0d;
            AxisGir.Pix_type = 1;
            AxisGir.Size = new Size(363, 160);
            AxisGir.TabIndex = 17;
            AxisGir.x_Base = 1.0d;
            AxisGir.x_Base0 = 0.0d;
            AxisGir.x_Name = "X";
            AxisGir.y_Base = 1.0d;
            AxisGir.y_Base0 = 0.0d;
            AxisGir.y_Name = "Y";
            AxisGir.z_Base = 1.0d;
            AxisGir.z_Name = "Z";
            // 
            // AxisE
            // 
            AxisE.axis_bkcolor = Color.White;
            AxisE.axis_color = Color.Gray;
            AxisE.Axis_Type = 1;
            AxisE.BackColor = Color.FromArgb(255, 224, 192);
            AxisE.E_x = 0;
            AxisE.E_y = 0;
            AxisE.Location = new Point(372, 2);
            AxisE.Name = "AxisE";
            AxisE.Pix_color = Color.Black;
            AxisE.Pix_Size = 2.0d;
            AxisE.Pix_type = 1;
            AxisE.Size = new Size(363, 160);
            AxisE.TabIndex = 15;
            AxisE.x_Base = 1.0d;
            AxisE.x_Base0 = 0.0d;
            AxisE.x_Name = "X";
            AxisE.y_Base = 1.0d;
            AxisE.y_Base0 = 0.0d;
            AxisE.y_Name = "Y";
            AxisE.z_Base = 1.0d;
            AxisE.z_Name = "Z";
            // 
            // Axis1
            // 
            Axis1.axis_bkcolor = Color.White;
            Axis1.axis_color = Color.Gray;
            Axis1.Axis_Type = 1;
            Axis1.E_x = 0;
            Axis1.E_y = 0;
            Axis1.Location = new Point(3, 2);
            Axis1.Name = "Axis1";
            Axis1.Pix_color = Color.Black;
            Axis1.Pix_Size = 2.0d;
            Axis1.Pix_type = 1;
            Axis1.Size = new Size(363, 362);
            Axis1.TabIndex = 4;
            Axis1.x_Base = 1.0d;
            Axis1.x_Base0 = 0.0d;
            Axis1.x_Name = "X";
            Axis1.y_Base = 1.0d;
            Axis1.y_Base0 = 0.0d;
            Axis1.y_Name = "Y";
            Axis1.z_Base = 1.0d;
            Axis1.z_Name = "Z";
            // 
            // MolDinamics
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 527);
            Controls.Add(AxisKinEPotE);
            Controls.Add(AxisT);
            Controls.Add(AxisGir);
            Controls.Add(GroupBox1);
            Controls.Add(AxisE);
            Controls.Add(Axis1);
            MinimizeBox = false;
            Name = "MolDinamics";
            Text = "Molecular Dynamics. Van der Waals clusters";
            WindowState = FormWindowState.Maximized;
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            Load += new EventHandler(MolDinamics_Load);
            Resize += new EventHandler(MolDinamics_Resize);
            ResumeLayout(false);

        }
        internal Axis Axis1;
        internal Timer Timer1;
        internal Axis AxisE;
        internal GroupBox GroupBox1;
        internal Label Label8;
        internal TextBox TextBoxBaseTau;
        internal TextBox TextBoxEpsilon;
        internal Label Label7;
        internal Label Label6;
        internal Label Label5;
        internal TextBox TextBoxtau;
        internal TextBox TextBoxSigma;
        internal Label Label3;
        internal TextBox TextBoxBase;
        internal Label Label4;
        internal TextBox TextBoxdtau;
        internal Button ButtonStop;
        internal Button ButtonStart;
        internal RadioButton RadioButton3D;
        internal RadioButton RadioButton2D;
        internal Label Label1;
        internal TextBox TextBoxAtomCount;
        internal ListBox ListBoxConfiguration;
        internal Label Label2;
        internal TextBox TextBoxDiametr;
        internal Button ButtonClear;
        internal Label Label9;
        internal TextBox TextBoxMinDist;
        internal Axis AxisGir;
        internal Axis AxisT;
        internal Label Label10;
        internal TextBox TextBoxM;
        internal GroupBox GroupBox2;
        internal GroupBox GroupBox3;
        internal RadioButton RadioButtonRect;
        internal RadioButton RadioButtonTriangl;
        internal CheckBox CheckBoxGrid;
        internal Button ButtonMore;
        internal Button ButtonLess;
        internal TextBox TextBoxE;
        internal Label Label14;
        internal TextBox TextBox1;
        internal Label Label13;
        internal TextBox TextBoxTp;
        internal Label Label12;
        internal TextBox TextBoxTc;
        internal Label Label11;
        internal TextBox TextBoxTcl;
        internal GroupBox GroupBox4;
        internal RadioButton RadioButtonNormal;
        internal RadioButton RadioButtonCenter;
        internal RadioButton RadioButtonPerif;
        internal CheckBox CheckBoxAtom;
        internal Label Label15;
        internal TextBox TextBoxEnergy;
        internal Axis AxisKinEPotE;
        internal Label Label16;
        internal TextBox TextBoxRows;
        internal TextBox TextBoxAtomCountLine;
    }
}