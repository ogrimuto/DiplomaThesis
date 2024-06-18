using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormStart : Form
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
            GroupBox1 = new GroupBox();
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            ButtonParameter = new Button();
            ButtonParameter.Click += new EventHandler(ButtonParameter_Click);
            CheckBox10 = new CheckBox();
            CheckBox10.CheckedChanged += new EventHandler(CheckBox10_CheckedChanged);
            ButtonBase = new Button();
            ButtonBase.Click += new EventHandler(ButtonClear_Click);
            CheckBox9 = new CheckBox();
            CheckBox8 = new CheckBox();
            CheckBox7 = new CheckBox();
            CheckBox6 = new CheckBox();
            CheckBox6.CheckedChanged += new EventHandler(CheckBox6_CheckedChanged);
            CheckBox5 = new CheckBox();
            CheckBox5.CheckedChanged += new EventHandler(CheckBox5_CheckedChanged);
            CheckBox4 = new CheckBox();
            CheckBox4.CheckedChanged += new EventHandler(CheckBox4_CheckedChanged);
            CheckBox3 = new CheckBox();
            CheckBox3.CheckedChanged += new EventHandler(CheckBox3_CheckedChanged);
            CheckBox2 = new CheckBox();
            CheckBox2.CheckedChanged += new EventHandler(CheckBox2_CheckedChanged);
            CheckBox1 = new CheckBox();
            CheckBox1.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
            GroupBox2 = new GroupBox();
            ListBox1 = new ListBox();
            ListBox1.MouseDoubleClick += new MouseEventHandler(ListBox1_MouseDoubleClick);
            GroupBox3 = new GroupBox();
            TextBoxEpsilon = new TextBox();
            Label2 = new Label();
            TextBoxSigma = new TextBox();
            Label1 = new Label();
            GroupBox4 = new GroupBox();
            Axis1 = new Axis();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            GroupBox3.SuspendLayout();
            GroupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(Button1);
            GroupBox1.Controls.Add(ButtonParameter);
            GroupBox1.Controls.Add(CheckBox10);
            GroupBox1.Controls.Add(ButtonBase);
            GroupBox1.Controls.Add(CheckBox9);
            GroupBox1.Controls.Add(CheckBox8);
            GroupBox1.Controls.Add(CheckBox7);
            GroupBox1.Controls.Add(CheckBox6);
            GroupBox1.Controls.Add(CheckBox5);
            GroupBox1.Controls.Add(CheckBox4);
            GroupBox1.Controls.Add(CheckBox3);
            GroupBox1.Controls.Add(CheckBox2);
            GroupBox1.Controls.Add(CheckBox1);
            GroupBox1.Location = new Point(14, 18);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(273, 336);
            GroupBox1.TabIndex = 0;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Потенциалы";
            // 
            // Button1
            // 
            Button1.Location = new Point(15, 308);
            Button1.Name = "Button1";
            Button1.Size = new Size(217, 28);
            Button1.TabIndex = 25;
            Button1.Text = "Молекулярная динамика";
            Button1.UseVisualStyleBackColor = true;
            // 
            // ButtonParameter
            // 
            ButtonParameter.Location = new Point(131, 278);
            ButtonParameter.Name = "ButtonParameter";
            ButtonParameter.Size = new Size(101, 28);
            ButtonParameter.TabIndex = 24;
            ButtonParameter.Text = "Параметры";
            ButtonParameter.UseVisualStyleBackColor = true;
            // 
            // CheckBox10
            // 
            CheckBox10.AutoSize = true;
            CheckBox10.Location = new Point(15, 80);
            CheckBox10.Name = "CheckBox10";
            CheckBox10.Size = new Size(148, 17);
            CheckBox10.TabIndex = 23;
            CheckBox10.Text = "Потенциал Штокмайера";
            CheckBox10.UseVisualStyleBackColor = true;
            // 
            // ButtonBase
            // 
            ButtonBase.Location = new Point(15, 278);
            ButtonBase.Name = "ButtonBase";
            ButtonBase.Size = new Size(101, 28);
            ButtonBase.TabIndex = 22;
            ButtonBase.Text = "База";
            ButtonBase.UseVisualStyleBackColor = true;
            // 
            // CheckBox9
            // 
            CheckBox9.AutoSize = true;
            CheckBox9.Location = new Point(15, 241);
            CheckBox9.Name = "CheckBox9";
            CheckBox9.Size = new Size(204, 30);
            CheckBox9.TabIndex = 8;
            CheckBox9.Text = "Многопараметрический потенциал" + '\r' + '\n' + "Бойса-Шевитта";
            CheckBox9.UseVisualStyleBackColor = true;
            // 
            // CheckBox8
            // 
            CheckBox8.AutoSize = true;
            CheckBox8.Location = new Point(15, 218);
            CheckBox8.Name = "CheckBox8";
            CheckBox8.Size = new Size(157, 17);
            CheckBox8.TabIndex = 7;
            CheckBox8.Text = "Потенциал Борна-Майера";
            CheckBox8.UseVisualStyleBackColor = true;
            // 
            // CheckBox7
            // 
            CheckBox7.AutoSize = true;
            CheckBox7.Location = new Point(15, 195);
            CheckBox7.Name = "CheckBox7";
            CheckBox7.Size = new Size(237, 17);
            CheckBox7.TabIndex = 6;
            CheckBox7.Text = "Экранированный кулоновский потенциал";
            CheckBox7.UseVisualStyleBackColor = true;
            // 
            // CheckBox6
            // 
            CheckBox6.AutoSize = true;
            CheckBox6.Location = new Point(15, 172);
            CheckBox6.Name = "CheckBox6";
            CheckBox6.Size = new Size(132, 17);
            CheckBox6.TabIndex = 5;
            CheckBox6.Text = "Потенциал Ридберга";
            CheckBox6.UseVisualStyleBackColor = true;
            // 
            // CheckBox5
            // 
            CheckBox5.AutoSize = true;
            CheckBox5.Location = new Point(15, 149);
            CheckBox5.Name = "CheckBox5";
            CheckBox5.Size = new Size(164, 17);
            CheckBox5.TabIndex = 4;
            CheckBox5.Text = "Потенциал Пешля-Теллера";
            CheckBox5.UseVisualStyleBackColor = true;
            // 
            // CheckBox4
            // 
            CheckBox4.AutoSize = true;
            CheckBox4.Location = new Point(15, 126);
            CheckBox4.Name = "CheckBox4";
            CheckBox4.Size = new Size(117, 17);
            CheckBox4.TabIndex = 3;
            CheckBox4.Text = "Потенциал Морзе";
            CheckBox4.UseVisualStyleBackColor = true;
            // 
            // CheckBox3
            // 
            CheckBox3.AutoSize = true;
            CheckBox3.Location = new Point(15, 103);
            CheckBox3.Name = "CheckBox3";
            CheckBox3.Size = new Size(139, 17);
            CheckBox3.TabIndex = 2;
            CheckBox3.Text = "Потенциал Букингема";
            CheckBox3.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            CheckBox2.AutoSize = true;
            CheckBox2.Location = new Point(15, 59);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(178, 17);
            CheckBox2.TabIndex = 1;
            CheckBox2.Text = "Потенциал Леннарда-Джонса";
            CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.Location = new Point(15, 36);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(183, 17);
            CheckBox1.TabIndex = 0;
            CheckBox1.Text = "Потенциалы с твердой сферой";
            CheckBox1.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(ListBox1);
            GroupBox2.Location = new Point(293, 18);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new Size(129, 326);
            GroupBox2.TabIndex = 1;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Вещество";
            // 
            // ListBox1
            // 
            ListBox1.FormattingEnabled = true;
            ListBox1.Location = new Point(15, 21);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(93, 303);
            ListBox1.TabIndex = 0;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(Axis1);
            GroupBox3.Location = new Point(428, 18);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new Size(412, 423);
            GroupBox3.TabIndex = 2;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "График";
            // 
            // TextBoxEpsilon
            // 
            TextBoxEpsilon.Location = new Point(87, 40);
            TextBoxEpsilon.Name = "TextBoxEpsilon";
            TextBoxEpsilon.Size = new Size(96, 20);
            TextBoxEpsilon.TabIndex = 4;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(14, 47);
            Label2.Name = "Label2";
            Label2.Size = new Size(65, 13);
            Label2.TabIndex = 3;
            Label2.Text = "Epsilon/k, K";
            // 
            // TextBoxSigma
            // 
            TextBoxSigma.Location = new Point(87, 9);
            TextBoxSigma.Name = "TextBoxSigma";
            TextBoxSigma.Size = new Size(94, 20);
            TextBoxSigma.TabIndex = 1;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(14, 16);
            Label1.Name = "Label1";
            Label1.Size = new Size(52, 13);
            Label1.TabIndex = 0;
            Label1.Text = "Sigma, A ";
            // 
            // GroupBox4
            // 
            GroupBox4.Controls.Add(TextBoxEpsilon);
            GroupBox4.Controls.Add(Label1);
            GroupBox4.Controls.Add(Label2);
            GroupBox4.Controls.Add(TextBoxSigma);
            GroupBox4.Location = new Point(12, 360);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Size = new Size(408, 91);
            GroupBox4.TabIndex = 3;
            GroupBox4.TabStop = false;
            GroupBox4.Text = "Итог";
            // 
            // Axis1
            // 
            Axis1.axis_bkcolor = Color.White;
            Axis1.axis_color = Color.Gray;
            Axis1.Axis_Type = 1;
            Axis1.E_x = 0;
            Axis1.E_y = 0;
            Axis1.Location = new Point(6, 19);
            Axis1.Name = "Axis1";
            Axis1.Pix_color = Color.Black;
            Axis1.Pix_Size = 2.0d;
            Axis1.Pix_type = 1;
            Axis1.Size = new Size(400, 398);
            Axis1.TabIndex = 2;
            Axis1.x_Base = 1.0d;
            Axis1.x_Base0 = 0.0d;
            Axis1.x_Name = "X";
            Axis1.y_Base = 1.0d;
            Axis1.y_Base0 = 0.0d;
            Axis1.y_Name = "Y";
            Axis1.z_Base = 1.0d;
            Axis1.z_Name = "Z";
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 463);
            Controls.Add(GroupBox3);
            Controls.Add(GroupBox4);
            Controls.Add(GroupBox2);
            Controls.Add(GroupBox1);
            Name = "FormStart";
            Text = "Полуэмпирические потенциалы";
            WindowState = FormWindowState.Maximized;
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox3.ResumeLayout(false);
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);

        }
        internal GroupBox GroupBox1;
        internal CheckBox CheckBox7;
        internal CheckBox CheckBox5;
        internal CheckBox CheckBox4;
        internal CheckBox CheckBox2;
        internal CheckBox CheckBox1;
        internal GroupBox GroupBox2;
        internal GroupBox GroupBox3;
        internal CheckBox CheckBox8;
        internal ListBox ListBox1;
        internal GroupBox GroupBox4;
        internal Label Label1;
        internal TextBox TextBoxSigma;
        internal CheckBox CheckBox3;
        internal CheckBox CheckBox9;
        internal CheckBox CheckBox6;
        internal Axis Axis1;
        internal TextBox TextBoxEpsilon;
        internal Label Label2;
        internal Button ButtonBase;
        internal CheckBox CheckBox10;
        internal Button ButtonParameter;
        internal Button Button1;

    }
}