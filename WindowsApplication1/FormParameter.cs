using System;
using System.Data;
using System.Data.OleDb;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{
    public partial class FormParameter
    {
        private OleDbConnection Conn = new OleDbConnection();
        private OleDbDataAdapter Da;
        private DataSet DS = new DataSet();
        private DataTable Table;
        private int NKL;

        public FormParameter()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string ConnStr = Module1.GetConnStr("Prop.MDB");
            Conn.ConnectionString = ConnStr;
            Conn.Open();

            Da = new OleDbDataAdapter("Select * From TablePROP", Conn);

            Da.Fill(DS);
            Table = DS.Tables[0];

            for (int i = 0; i <= 617; i++)
            {

                ListBox1.Items.Add(Table.Rows[i]["Title"]);

                for (int j = 4, loopTo = Table.Columns.Count - 1; j <= loopTo; j++)
                    Module1.F[i, j - 3] = Conversions.ToDouble(Table.Rows[i][j]);

            }

            // For i = 0 To 617
            // For j = 4 To Table.Columns.Count - 1
            // F(i, j - 3) = Table.Rows(i)(j)
            // Next
            // Next

            double T0;
            double OM;
            double AL;

            for (int j = 0; j <= 617; j++)
            {

                if (Module1.F[j, 27] < 1d)
                    Module1.F[j, 27] = Module1.F[j, 2];
                if (Module1.F[j, 28] < 1d)
                    Module1.F[j, 28] = Module1.F[j, 4];
                if (Abs(Module1.F[j, 8]) < 0.001d & Module1.F[j, 3] > 0.1d & Module1.F[j, 4] > 0.1d & Module1.F[j, 5] > 0d)
                {
                    T0 = Module1.F[j, 3] / Module1.F[j, 4];
                    // ФАКТОР АЦЕНТРИЧНОСТИ ПО ЛИ-КЕСЛЕРУ	
                    OM = (-Log(Module1.F[j, 5] / 1.01325d) - 5.92714d + 6.09648d / T0 + 1.28862d * Log(T0) - 0.169347d * Pow(T0, 6d)) / (15.2518d - 15.6875d / T0 - 13.4721d * Log(T0) + 0.43577d * Pow(T0, 6d));

                    Module1.F[j, 8] = OM;
                }
                Module1.F[j, 16] = Round(Module1.F[j, 16] + 273.15d, 2);
                Module1.F[j, 17] = Round(Module1.F[j, 17] + 273.15d, 2);
                Module1.F[j, 25] = j;
                Module1.F[j, 5] = Module1.F[j, 5] * 100000d;
                if (Module1.F[j, 11] > -0.1d)
                    Module1.F[j, 11] = Module1.F[j, 11] / 3.162E+24d;
                Module1.F[j, 18] = Module1.F[j, 18] * 1000d;
                Module1.F[j, 19] = Module1.F[j, 19] * 1000d;
                double TT;
                if (Module1.F[j, 6] < 0.0001d & Module1.F[j, 4] > 0.001d & Module1.F[j, 5] > 0.001d)
                {
                    TT = Module1.F[j, 3] / Module1.F[j, 4];
                    // ридель критический объем
                    AL = 0.9076d * (1d + TT * Log(Module1.F[j, 5] / 100000d) / (1d - TT));
                    Module1.F[j, 6] = 8314d * Module1.F[j, 4] / Module1.F[j, 5] / (3.72d + 0.26d * (AL - 7d));
                }
                else
                {
                    Module1.F[j, 6] = Module1.F[j, 6] / 1000d;
                }
                if (Module1.F[j, 7] < 0.0001d & Module1.F[j, 4] > 0.001d)
                {
                    Module1.F[j, 7] = Module1.F[j, 6] * Module1.F[j, 5] / 8314d / Module1.F[j, 4];
                }
                Module1.F[j, 9] = Module1.F[j, 9] * 1000d;

            }

            Module1.selMatterIndex = 1;
            // ViewPropStart()
            ListBox1.SelectedIndex = 0;
            NKL = 1;
        }

        private void FormParameter_Resize(object sender, EventArgs e)
        {
            ListBox1.Top = 0;
            ListBox1.Left = 0;
            ListBox1.Height = DisplayRectangle.Height;
            DataGridView1.Top = 0;
            DataGridView1.Left = ListBox1.Width;
            DataGridView1.Width = DisplayRectangle.Width - ListBox1.Width;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // отразить выбранный параметр

            Module1.selMatterIndex = ListBox1.SelectedIndex + 1;

            DataGridView1.Rows.Add();
            DataGridView1[0, DataGridView1.RowCount - 1].Value = ListBox1.Items[ListBox1.SelectedIndex];
            DataGridView1[1, DataGridView1.RowCount - 1].Value = Module1.F[Module1.selMatterIndex, 1];
            DataGridView1[2, DataGridView1.RowCount - 1].Value = Module1.F[Module1.selMatterIndex, 11];
            DataGridView1[5, DataGridView1.RowCount - 1].Value = Module1.PotencialIndex.ToString();
            DataGridView1[4, DataGridView1.RowCount - 1].Value = Module1.F[Module1.selMatterIndex, 3];


        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}