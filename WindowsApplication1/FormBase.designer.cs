using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormBase : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            ListBox1 = new ListBox();
            ListBox1.KeyDown += new KeyEventHandler(ListBox1_KeyDown);
            ListBox1.MouseDoubleClick += new MouseEventHandler(ListBox1_MouseDoubleClick);
            ListBox1.MouseDown += new MouseEventHandler(ListBox1_MouseDown);
            ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
            Label2 = new Label();
            Label1 = new Label();
            ButtonFind = new Button();
            ButtonFind.Click += new EventHandler(ButtonFind_Click);
            TextBoxFind = new TextBox();
            TextBoxFind.KeyDown += new KeyEventHandler(TextBoxFind_KeyDown);
            ContextMenuStrip1 = new ContextMenuStrip(components);
            ContextMenuStrip1.Click += new EventHandler(ContextMenuStrip1_Click);
            ContextMenuStrip1.MouseDown += new MouseEventHandler(ContextMenuStrip1_MouseDown);
            NumericUpDown1 = new NumericUpDown();
            NumericUpDown1.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
            Label3 = new Label();
            ContextMenuStrip2 = new ContextMenuStrip(components);
            Label4 = new Label();
            Panel1 = new Panel();
            DataGridView1 = new DataGridView();
            DataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(DataGridView1_CellMouseClick);
            DataGridView1.KeyDown += new KeyEventHandler(DataGridView1_KeyDown);
            DataGridView1.KeyPress += new KeyPressEventHandler(DataGridView1_KeyPress);
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Label6 = new Label();
            ToolStrip1 = new ToolStrip();
            ToolStripDropDownButton1 = new ToolStripDropDownButton();
            ToolStripDropDownButton1.DropDownItemClicked += new ToolStripItemClickedEventHandler(ToolStripDropDownButton1_DropDownItemClicked);
            TtttToolStripMenuItem = new ToolStripMenuItem();
            TtttToolStripMenuItem.Click += new EventHandler(TtttToolStripMenuItem_Click);
            ButtonClear = new Button();
            ButtonClear.Click += new EventHandler(ButtonClear_Click);
            ButtonAdd = new Button();
            ButtonAdd.Click += new EventHandler(ButtonAdd_Click);
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            ToolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ListBox1
            // 
            ListBox1.BackColor = Color.FromArgb(224, 224, 224);
            ListBox1.Font = new Font("Courier New", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 204);
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 18;
            ListBox1.Location = new Point(9, 73);
            ListBox1.Margin = new Padding(5);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(502, 310);
            ListBox1.TabIndex = 1;
            // 
            // Label2
            // 
            Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label2.ForeColor = Color.Maroon;
            Label2.Location = new Point(284, 12);
            Label2.Margin = new Padding(5, 0, 5, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(108, 23);
            Label2.TabIndex = 4;
            Label2.Text = "Label2";
            Label2.Visible = false;
            // 
            // Label1
            // 
            Label1.Font = new Font("Arial", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
            Label1.Location = new Point(14, 12);
            Label1.Margin = new Padding(5, 0, 5, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(260, 23);
            Label1.TabIndex = 3;
            Label1.Text = "Label1";
            Label1.Visible = false;
            // 
            // ButtonFind
            // 
            ButtonFind.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonFind.Location = new Point(301, 35);
            ButtonFind.Margin = new Padding(5);
            ButtonFind.Name = "ButtonFind";
            ButtonFind.Size = new Size(87, 28);
            ButtonFind.TabIndex = 6;
            ButtonFind.Text = "Найти";
            ButtonFind.UseVisualStyleBackColor = true;
            // 
            // TextBoxFind
            // 
            TextBoxFind.BorderStyle = BorderStyle.FixedSingle;
            TextBoxFind.Location = new Point(114, 35);
            TextBoxFind.Margin = new Padding(5);
            TextBoxFind.Name = "TextBoxFind";
            TextBoxFind.Size = new Size(177, 26);
            TextBoxFind.TabIndex = 7;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size(61, 4);
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Location = new Point(587, 0);
            NumericUpDown1.Margin = new Padding(5);
            NumericUpDown1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(73, 26);
            NumericUpDown1.TabIndex = 10;
            NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Label3
            // 
            Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
            Label3.Location = new Point(418, 5);
            Label3.Margin = new Padding(5, 0, 5, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(159, 20);
            Label3.TabIndex = 11;
            Label3.Text = "Число компонентов";
            // 
            // ContextMenuStrip2
            // 
            ContextMenuStrip2.Name = "ContextMenuStrip2";
            ContextMenuStrip2.Size = new Size(61, 4);
            // 
            // Label4
            // 
            Label4.Font = new Font("Arial", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label4.Location = new Point(5, 36);
            Label4.Margin = new Padding(5, 0, 5, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(99, 25);
            Label4.TabIndex = 12;
            Label4.Text = "Вещество";
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.FromArgb(224, 224, 224);
            Panel1.BorderStyle = BorderStyle.FixedSingle;
            Panel1.Controls.Add(Label1);
            Panel1.Controls.Add(Label2);
            Panel1.Location = new Point(521, 73);
            Panel1.Margin = new Padding(5);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(354, 374);
            Panel1.TabIndex = 5;
            // 
            // DataGridView1
            // 
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            DataGridView1.Location = new Point(15, 137);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.Size = new Size(373, 150);
            DataGridView1.TabIndex = 19;
            // 
            // Column1
            // 
            Column1.HeaderText = "Вещество";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Концентрация";
            Column2.Name = "Column2";
            // 
            // Label6
            // 
            Label6.Font = new Font("Arial", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 204);
            Label6.Location = new Point(517, 33);
            Label6.Margin = new Padding(5, 0, 5, 0);
            Label6.Name = "Label6";
            Label6.Size = new Size(219, 28);
            Label6.TabIndex = 15;
            Label6.Text = "Стандартные свойства";
            // 
            // ToolStrip1
            // 
            ToolStrip1.Items.AddRange(new ToolStripItem[] { ToolStripDropDownButton1 });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Padding = new Padding(0, 0, 2, 0);
            ToolStrip1.Size = new Size(899, 25);
            ToolStrip1.TabIndex = 16;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripDropDownButton1
            // 
            ToolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { TtttToolStripMenuItem });
            ToolStripDropDownButton1.Font = new Font("Tahoma", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            ToolStripDropDownButton1.Image = (Image)resources.GetObject("ToolStripDropDownButton1.Image");
            ToolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            ToolStripDropDownButton1.Name = "ToolStripDropDownButton1";
            ToolStripDropDownButton1.Size = new Size(101, 22);
            ToolStripDropDownButton1.Text = "Свойства";
            // 
            // TtttToolStripMenuItem
            // 
            TtttToolStripMenuItem.Name = "TtttToolStripMenuItem";
            TtttToolStripMenuItem.Size = new Size(96, 22);
            TtttToolStripMenuItem.Text = "tttt";
            // 
            // ButtonClear
            // 
            ButtonClear.Location = new Point(521, 37);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(101, 28);
            ButtonClear.TabIndex = 21;
            ButtonClear.Text = "Очистить";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Visible = false;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new Point(416, 36);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(93, 30);
            ButtonAdd.TabIndex = 20;
            ButtonAdd.Text = "Добавить";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Visible = false;
            // 
            // FormBase
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            ClientSize = new Size(899, 461);
            Controls.Add(DataGridView1);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(ButtonAdd);
            Controls.Add(TextBoxFind);
            Controls.Add(ButtonClear);
            Controls.Add(NumericUpDown1);
            Controls.Add(Label6);
            Controls.Add(Panel1);
            Controls.Add(ButtonFind);
            Controls.Add(ListBox1);
            Controls.Add(ToolStrip1);
            Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "FormBase";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "Физические свойства газов и жидкостей";
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            Load += new EventHandler(Form1_Load);
            Resize += new EventHandler(Form1_Resize);
            ResumeLayout(false);
            PerformLayout();

        }
        internal ListBox ListBox1;
        internal Label Label1;
        internal Label Label2;
        internal Button ButtonFind;
        internal TextBox TextBoxFind;
        internal ContextMenuStrip ContextMenuStrip1;
        internal NumericUpDown NumericUpDown1;
        internal Label Label3;
        internal ContextMenuStrip ContextMenuStrip2;
        internal Label Label4;
        internal Panel Panel1;
        internal Label Label6;
        internal ToolStrip ToolStrip1;
        internal ToolStripDropDownButton ToolStripDropDownButton1;
        internal ToolStripMenuItem TtttToolStripMenuItem;
        internal DataGridView DataGridView1;
        internal Button ButtonClear;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridViewTextBoxColumn Column2;
        internal Button ButtonAdd;

    }
}