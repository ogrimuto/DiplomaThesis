using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmPROP : Form
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
            DataGridView1 = new DataGridView();
            DataGridView1.CellClick += new DataGridViewCellEventHandler(DataGridView1_CellClick);
            DataGridView1.CellEnter += new DataGridViewCellEventHandler(DataGridView1_CellEnter);
            DataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(DataGridView1_CellMouseClick);
            DataGridView1.KeyDown += new KeyEventHandler(DataGridView1_KeyDown);
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            MenuStrip1 = new MenuStrip();
            ToolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            ГрафикToolStripMenuItem = new ToolStripMenuItem();
            ГрафикToolStripMenuItem.Click += new EventHandler(ГрафикToolStripMenuItem_Click);
            Panel1 = new Panel();
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            Label4 = new Label();
            NumericUpDown1 = new NumericUpDown();
            Label1 = new Label();
            TextBoxMinFun = new TextBox();
            TextBoxMaxFun = new TextBox();
            Label5 = new Label();
            Label3 = new Label();
            RadioButton2 = new RadioButton();
            RadioButtonT = new RadioButton();
            Label2 = new Label();
            TextBoxMinArg = new TextBox();
            TextBoxMaxArg = new TextBox();
            Label6 = new Label();
            Label7 = new Label();
            Axis1 = new Axis();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            MenuStrip1.SuspendLayout();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // DataGridView1
            // 
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            DataGridView1.Location = new Point(8, 27);
            DataGridView1.MultiSelect = false;
            DataGridView1.Name = "DataGridView1";
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.ScrollBars = ScrollBars.Vertical;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGridView1.Size = new Size(296, 142);
            DataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Температура, К";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Давление, Па";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Агрегатное состояние";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Свойство";
            Column4.Name = "Column4";
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem1, ГрафикToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(702, 24);
            MenuStrip1.TabIndex = 3;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size(54, 20);
            ToolStripMenuItem1.Text = "Расчет";
            // 
            // ГрафикToolStripMenuItem
            // 
            ГрафикToolStripMenuItem.Name = "ГрафикToolStripMenuItem";
            ГрафикToolStripMenuItem.Size = new Size(57, 20);
            ГрафикToolStripMenuItem.Text = "График";
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.FromArgb(255, 192, 128);
            Panel1.Controls.Add(Label7);
            Panel1.Controls.Add(Label6);
            Panel1.Controls.Add(Button1);
            Panel1.Controls.Add(Label4);
            Panel1.Controls.Add(NumericUpDown1);
            Panel1.Controls.Add(Label1);
            Panel1.Controls.Add(TextBoxMinFun);
            Panel1.Controls.Add(TextBoxMaxFun);
            Panel1.Controls.Add(Label5);
            Panel1.Controls.Add(Label3);
            Panel1.Controls.Add(RadioButton2);
            Panel1.Controls.Add(RadioButtonT);
            Panel1.Controls.Add(Label2);
            Panel1.Controls.Add(TextBoxMinArg);
            Panel1.Controls.Add(TextBoxMaxArg);
            Panel1.Location = new Point(0, 179);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(304, 233);
            Panel1.TabIndex = 4;
            // 
            // Button1
            // 
            Button1.Location = new Point(109, 188);
            Button1.Name = "Button1";
            Button1.Size = new Size(75, 23);
            Button1.TabIndex = 14;
            Button1.Text = "Построить";
            Button1.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label4.Location = new Point(76, 21);
            Label4.Name = "Label4";
            Label4.Size = new Size(61, 13);
            Label4.TabIndex = 13;
            Label4.Text = "Тип осей";
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Location = new Point(24, 19);
            NumericUpDown1.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(46, 20);
            NumericUpDown1.TabIndex = 12;
            NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label1.Location = new Point(22, 159);
            Label1.Name = "Label1";
            Label1.Size = new Size(60, 13);
            Label1.TabIndex = 11;
            Label1.Text = "Функция";
            // 
            // TextBoxMinFun
            // 
            TextBoxMinFun.Location = new Point(109, 152);
            TextBoxMinFun.Name = "TextBoxMinFun";
            TextBoxMinFun.Size = new Size(88, 20);
            TextBoxMinFun.TabIndex = 10;
            // 
            // TextBoxMaxFun
            // 
            TextBoxMaxFun.Location = new Point(203, 152);
            TextBoxMaxFun.Name = "TextBoxMaxFun";
            TextBoxMaxFun.Size = new Size(92, 20);
            TextBoxMaxFun.TabIndex = 9;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            Label5.Location = new Point(108, 110);
            Label5.Name = "Label5";
            Label5.Size = new Size(90, 13);
            Label5.TabIndex = 8;
            Label5.Text = "Минимальное    ";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label3.Location = new Point(183, 21);
            Label3.Name = "Label3";
            Label3.Size = new Size(63, 13);
            Label3.TabIndex = 6;
            Label3.Text = "Аргумент";
            // 
            // RadioButton2
            // 
            RadioButton2.AutoSize = true;
            RadioButton2.Location = new Point(186, 60);
            RadioButton2.Name = "RadioButton2";
            RadioButton2.Size = new Size(76, 17);
            RadioButton2.TabIndex = 5;
            RadioButton2.Text = "Давление";
            RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButtonT
            // 
            RadioButtonT.AutoSize = true;
            RadioButtonT.Checked = true;
            RadioButtonT.Location = new Point(186, 37);
            RadioButtonT.Name = "RadioButtonT";
            RadioButtonT.Size = new Size(92, 17);
            RadioButtonT.TabIndex = 4;
            RadioButtonT.TabStop = true;
            RadioButtonT.Text = "Температура";
            RadioButtonT.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label2.Location = new Point(19, 133);
            Label2.Name = "Label2";
            Label2.Size = new Size(63, 13);
            Label2.TabIndex = 3;
            Label2.Text = "Аргумент";
            // 
            // TextBoxMinArg
            // 
            TextBoxMinArg.Location = new Point(109, 126);
            TextBoxMinArg.Name = "TextBoxMinArg";
            TextBoxMinArg.Size = new Size(88, 20);
            TextBoxMinArg.TabIndex = 2;
            // 
            // TextBoxMaxArg
            // 
            TextBoxMaxArg.Location = new Point(203, 126);
            TextBoxMaxArg.Name = "TextBoxMaxArg";
            TextBoxMaxArg.Size = new Size(92, 20);
            TextBoxMaxArg.TabIndex = 0;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label6.Location = new Point(92, 86);
            Label6.Name = "Label6";
            Label6.Size = new Size(92, 13);
            Label6.TabIndex = 15;
            Label6.Text = "Масштаб осей";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            Label7.Location = new Point(204, 110);
            Label7.Name = "Label7";
            Label7.Size = new Size(84, 13);
            Label7.TabIndex = 16;
            Label7.Text = "Максимальное";
            // 
            // Axis1
            // 
            Axis1.axis_bkcolor = Color.White;
            Axis1.axis_color = Color.Gray;
            Axis1.Axis_Type = 1;
            Axis1.E_x = 0;
            Axis1.E_y = 0;
            Axis1.Location = new Point(341, 42);
            Axis1.Name = "Axis1";
            Axis1.Pix_color = Color.Black;
            Axis1.Pix_Size = 2.0d;
            Axis1.Pix_type = 1;
            Axis1.Size = new Size(187, 137);
            Axis1.TabIndex = 5;
            Axis1.x_Base = 1.0d;

            Axis1.x_Name = "X";
            Axis1.y_Base = 1.0d;
            Axis1.y_Name = "Y";
            // 
            // frmPROP
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 424);
            Controls.Add(Axis1);
            Controls.Add(Panel1);
            Controls.Add(DataGridView1);
            Controls.Add(MenuStrip1);
            MainMenuStrip = MenuStrip1;
            Name = "frmPROP";
            Text = "Form2";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            Load += new EventHandler(frmPROP_Load);
            Resize += new EventHandler(frmPROP_Resize);
            ResumeLayout(false);
            PerformLayout();

        }
        internal DataGridView DataGridView1;
        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem ToolStripMenuItem1;
        internal ToolStripMenuItem ГрафикToolStripMenuItem;
        internal Panel Panel1;
        internal Label Label2;
        internal TextBox TextBoxMinArg;
        internal TextBox TextBoxMaxArg;
        internal RadioButton RadioButton2;
        internal RadioButton RadioButtonT;
        internal Label Label5;
        internal Label Label3;
        internal Label Label1;
        internal TextBox TextBoxMinFun;
        internal TextBox TextBoxMaxFun;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridViewTextBoxColumn Column2;
        internal DataGridViewTextBoxColumn Column3;
        internal DataGridViewTextBoxColumn Column4;
        internal Axis Axis1;
        internal Label Label4;
        internal NumericUpDown NumericUpDown1;
        internal Button Button1;
        internal Label Label6;
        internal Label Label7;
    }
}