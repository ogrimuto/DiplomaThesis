using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FormParameter : Form
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
            ListBox1 = new ListBox();
            ListBox1.MouseDoubleClick += new MouseEventHandler(ListBox1_MouseDoubleClick);
            ListBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
            DataGridView1 = new DataGridView();
            DataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView1_CellContentClick);
            ButtonSave = new Button();
            ButtonCalc = new Button();
            Label1 = new Label();
            Label2 = new Label();
            LabelSigma = new Label();
            Label5 = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ListBox1
            // 
            ListBox1.BackColor = Color.FromArgb(224, 224, 224);
            ListBox1.Font = new Font("Courier New", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 204);
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 18;
            ListBox1.Location = new Point(3, 3);
            ListBox1.Margin = new Padding(5);
            ListBox1.Name = "ListBox1";
            ListBox1.Size = new Size(343, 310);
            ListBox1.TabIndex = 2;
            // 
            // DataGridView1
            // 
            DataGridView1.AccessibleRole = AccessibleRole.Grip;
            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView1.BackgroundColor = Color.FromArgb(224, 224, 224);
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 });
            DataGridView1.Location = new Point(354, 3);
            DataGridView1.MultiSelect = false;
            DataGridView1.Name = "DataGridView1";
            DataGridView1.RowHeadersVisible = false;
            DataGridView1.ScrollBars = ScrollBars.Vertical;
            DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGridView1.Size = new Size(481, 310);
            DataGridView1.TabIndex = 3;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(470, 333);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(101, 28);
            ButtonSave.TabIndex = 26;
            ButtonSave.Text = "Сохранить";
            ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ButtonCalc
            // 
            ButtonCalc.Location = new Point(363, 333);
            ButtonCalc.Name = "ButtonCalc";
            ButtonCalc.Size = new Size(101, 28);
            ButtonCalc.TabIndex = 25;
            ButtonCalc.Text = "Расчет ";
            ButtonCalc.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(597, 341);
            Label1.Name = "Label1";
            Label1.Size = new Size(54, 13);
            Label1.TabIndex = 27;
            Label1.Text = "Epsilon, K";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = Color.FromArgb(255, 224, 192);
            Label2.Location = new Point(664, 341);
            Label2.Name = "Label2";
            Label2.Size = new Size(0, 13);
            Label2.TabIndex = 28;
            // 
            // LabelSigma
            // 
            LabelSigma.AutoSize = true;
            LabelSigma.BackColor = Color.FromArgb(255, 224, 192);
            LabelSigma.Location = new Point(835, 341);
            LabelSigma.Name = "LabelSigma";
            LabelSigma.Size = new Size(0, 13);
            LabelSigma.TabIndex = 29;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(761, 341);
            Label5.Name = "Label5";
            Label5.Size = new Size(49, 13);
            Label5.TabIndex = 31;
            Label5.Text = "Sigma, A";
            // 
            // Column1
            // 
            Column1.HeaderText = "Формула";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Мол. масса";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Дипольный момент";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Vb";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Tb";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Потенциал";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "T, K";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "К-ент дин. вяз. снПуаз";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "К-ент. дин.вяз.(расч)";
            Column9.Name = "Column9";
            // 
            // FormParameter
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 385);
            Controls.Add(Label5);
            Controls.Add(LabelSigma);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(ButtonSave);
            Controls.Add(ButtonCalc);
            Controls.Add(DataGridView1);
            Controls.Add(ListBox1);
            Name = "FormParameter";
            Text = "Параметры";
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            Load += new EventHandler(Form2_Load);
            Resize += new EventHandler(FormParameter_Resize);
            ResumeLayout(false);
            PerformLayout();

        }
        internal ListBox ListBox1;
        internal DataGridView DataGridView1;
        internal Button ButtonSave;
        internal Button ButtonCalc;
        internal Label Label1;
        internal Label Label2;
        internal Label LabelSigma;
        internal Label Label5;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridViewTextBoxColumn Column2;
        internal DataGridViewTextBoxColumn Column3;
        internal DataGridViewTextBoxColumn Column4;
        internal DataGridViewTextBoxColumn Column5;
        internal DataGridViewTextBoxColumn Column6;
        internal DataGridViewTextBoxColumn Column7;
        internal DataGridViewTextBoxColumn Column8;
        internal DataGridViewTextBoxColumn Column9;
    }
}