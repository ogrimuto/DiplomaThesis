using System;
using System.Drawing;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{

    public partial class FormStart
    {
        private int Vts; // потенциалы с твердой сферой
        private int Vlj; // Потенциал Леннарда-Джонса
        private int Vmorze; // Потенциал Морзе
        private int Vpt; // Потенциал Пешля–Теллера
        private int Vbuk; // Потенциал Букингема
        private int Vrid; // Потенциал Ридберга
        private int V;
        private int b; // коэффициент потенциала Ридберга
        private int r;
        private int SigmaNum;
        private int a;
        private int Eb; // глубина потенциальной ямы
        private int alf; // крутизна экспоненциального отталкивания
        private int rm; // значение r в min
        private int sh; // 
        private int ch;

        public FormStart()
        {
            InitializeComponent();
        }


        public string GetConnStr(string sourceName)
        {
            string GetConnStrRet = default;
            GetConnStrRet = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=True;Data Source=" + sourceName;
            return GetConnStrRet;
            // If InStr(CurDir$, "A") > 0 Then
            // ChDrive Mid(App.path, 1, 1)
            // ChDir App.path
            // End If
            // Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\free\Struc.TDN;Persist Security Info=True;Jet OLEDB:Database Password=123
        }
        public void OpenDB()
        {
            string ConnStr;
            ConnStr = GetConnStr("Lenard_D.MDB");
            var Conn = new System.Data.OleDb.OleDbConnection(ConnStr);

            string SQLString = "Select * From Tab1 Where Potencial=" + Module1.PotencialIndex.ToString();
            var ReadUpdate = new clsOleDBReadUpdateDB(ConnStr, SQLString);
            ReadUpdate.stSelect = SQLString;
            var argListBoxDest = ListBox1;
            ReadUpdate.ReadFieldToListBox(ref argListBoxDest, 0);
            ListBox1 = argListBoxDest;

            ReadUpdate.ReadFieldToArray(ref Module1.Sigma, 1);
            ReadUpdate.ReadFieldToArray(ref Module1.Epsilon, 2);
            ReadUpdate.ReadFieldToArray(ref Module1.MM, 3);

            switch (Module1.PotencialIndex)
            {

                case 1:
                    {
                        break;
                    }

                case 2:
                    {
                        break;
                    }
                // Lenard


                case 3:
                    {
                        break;
                    }

                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }


            }





        }
        public void InitAxis()
        {

            Axis1.x_Base = 10d;
            Axis1.y_Base = 700d;
            Axis1.Axis_Type = 2;
            Axis1.x_Name = "r, A";
            Axis1.y_Name = "U, K";
            Axis1.Pix_type = 1;
            Axis1.Pix_Size = 0.004d;
            Axis1.AxisDraw();


        }



        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (r < SigmaNum)
                Vts = V;
            if (Conversions.ToInteger(SigmaNum < r) < a * SigmaNum)
                Vts = -Eb;
            if (r > a * SigmaNum)
                Vts = 0;

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // L-D

            if (CheckBox2.Checked)
            {
                Module1.PotencialIndex = 2;
                OpenDB();

            }
            Module1.selMatterPotencialIndex = 0;
            ListBox1.SelectedIndex = 0;


        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

            Vbuk = (int)Round((Eb / 1d - 6d / alf) * (6d / alf * Exp(alf * (1d - r / (double)rm)) - Pow(rm / (double)r, 6d)));

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

            Vmorze = (int)Round(Eb * (Exp(-2 * alf * (r - rm)) - 2d * Exp(-alf * (r - rm))));

        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

            Vpt = (int)Round(Eb * (Pow(sh, 4d) * (0.5d * alf * rm) / Pow(sh, 2d) * alf - Pow(ch, 4d) * (0.5d * alf * rm) / Pow(ch, 2d) * alf));

        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {

            Vrid = (int)Round(-Eb * (1d + b / (double)rm * (r - rm)) * Exp(-(b / (double)rm) * (r - rm)));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitAxis();
            CheckBox2.Checked = true;
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double r, dr;
            Module1.selMatterPotencialIndex = (byte)ListBox1.SelectedIndex;
            r = 2d;
            dr = Axis1.x_Base / 1000d;
            while (r < Axis1.x_Base)
            {
                r += dr;
                Vlj = (int)Round(4d * Module1.Epsilon[ListBox1.SelectedIndex] * (Pow(Module1.Sigma[ListBox1.SelectedIndex] / r, 12d) - Pow(Module1.Sigma[ListBox1.SelectedIndex] / r, 6d)));
                Axis1.PixDraw(r - 2d, Vlj, Color.Blue, 1);
            }
            TextBoxSigma.Text = Module1.Sigma[ListBox1.SelectedIndex].ToString();
            TextBoxEpsilon.Text = Module1.Epsilon[ListBox1.SelectedIndex].ToString();
            My.MyProject.Forms.MolDinamics.TextBoxM.Text = Module1.MM[ListBox1.SelectedIndex].ToString();
            Axis1.StatToPic();
        }



        private void ButtonClear_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.FormBase.Show();
        }

        private void ButtonParameter_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.FormParameter.Show();
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            My.MyProject.Forms.MolDinamics.ShowDialog();
        }


    }
}