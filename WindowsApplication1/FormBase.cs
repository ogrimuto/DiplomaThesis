using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{
    public partial class FormBase
    {

        public DataTable Table;

        private string St;
        private Label[] G = new Label[15], G1 = new Label[15];
        private Font Font1, Font2;

        private int RowNumber;

        private double T;


        private int NKL; // число компонентов
        private int N; // порядковый номер свойства
        private int NH = 0; // *  NH     - 1,2,3 (РОМБ,КРЕСТ,ПРЯМОУГОЛЬНИК)               *
        private double BU; // критическое давление

        // COMMON/G/G
        private double BE; // COMMON/BE/BE
        private double[] Y = new double[11]; // COMMON/Y/Y(10)
        private double[] Pa = new double[4]; // COMMON/PA/PA(3)
        private double HU; // COMMON/HU/HU
        private double IV; // COMMON/IV/IV
        private double ard, fud; // common/re/ard,fud
        private double C; // COMMON/CC/C

        public FormBase()
        {
            InitializeComponent();
        }


        // Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        // 'convertor
        // Dim Conn As New OleDbConnection
        // Dim Da As OleDbDataAdapter
        // Dim DS As New DataSet


        // Dim ConnStr As String = GetConnStr("Prop.MDB")
        // Conn.ConnectionString = ConnStr
        // Conn.Open()

        // Da = New OleDbDataAdapter("Select * From TablePROP", Conn)

        // Da.Fill(DS)
        // Table = DS.Tables(0)


        // Dim strFileName As String = "Ba.Txt"
        // 'объект FileInfo
        // Dim fi As FileInfo = New FileInfo(strFileName)

        // ' Проверяем наличие файла.
        // If fi.Exists = False Then
        // MsgBox("Файл " + strFileName + " не найден!")
        // Exit Sub
        // End If


        // 'Открываем файл для чтения.
        // Dim sr As StreamReader = fi.OpenText()
        // Dim Index As Integer = 0
        // Dim FieldNum As Integer = 0

        // Dim ss As String
        // For i = 0 To 617

        // ListBox1.Items.Add(Table.Rows(i)("Title"))

        // FieldNum = 4


        // St = sr.ReadLine
        // Table.Rows(i)("Formula") = St
        // For j = 0 To 7
        // St = sr.ReadLine

        // Table.Rows(i)(FieldNum) = Val(Mid(St, 2, 14))
        // ss = Mid(St, 2, 14)
        // Table.Rows(i)(FieldNum + 1) = Val(Mid(St, 18, 14))
        // ss = Mid(St, 17, 14)
        // Table.Rows(i)(FieldNum + 2) = Val(Mid(St, 34, 14))
        // ss = Mid(St, 33, 14)
        // Table.Rows(i)(FieldNum + 3) = Val(Mid(St, 50, 14))
        // ss = Mid(St, 49, 14)
        // FieldNum += 4

        // Next



        // Next

        // Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(Da)

        // Da.Update(DS)
        // sr.Close()

        // End Sub

        private void Form1_Load(object sender, EventArgs e)
        {
            var Conn = new OleDbConnection();
            OleDbDataAdapter Da;
            var DS = new DataSet();

            string ConnStr = GetConnStr("Prop.MDB");
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
            ViewPropStart();
            ListBox1.SelectedIndex = 0;
            NKL = 1;
            LoadMenu();
        }
        public void LoadMenu()
        {
            ToolStripDropDownButton1.DropDownItems.Clear();
            ToolStripDropDownButton1.DropDownItems.Add("Плотность, Кг/М**3");
            ToolStripDropDownButton1.DropDownItems.Add("К-ент динамич. вязк.,Н*С/М**2");
            ToolStripDropDownButton1.DropDownItems.Add("К-ент кинемат. вязк., М**2/С ");
            ToolStripDropDownButton1.DropDownItems.Add("К-ент теплопроводн., Вт/(М*К)");
            ToolStripDropDownButton1.DropDownItems.Add("Изобарн. теплоемк., Дж/(Кг*К) ");
            ToolStripDropDownButton1.DropDownItems.Add("Ид.-газ. теплоемк.Сp,Дж/(Кмоль*К)");
            ToolStripDropDownButton1.DropDownItems.Add("Давл. насыщ. паров,Па");
            ToolStripDropDownButton1.DropDownItems.Add("Температура насыщения,K");
            ToolStripDropDownButton1.DropDownItems.Add("Теплота испарения при Тнас., Дж/кг ");
            ToolStripDropDownButton1.DropDownItems.Add("");
        }
        public void ViewPropStart()
        {
            if (NKL == 1)
            {
                G[0] = Label1;
                G1[0] = Label2;
                for (int i = 1; i <= 14; i++)
                {
                    G[i] = new Label();
                    G[i].Parent = Panel1;
                }

                for (int i = 1; i <= 14; i++)
                {
                    G1[i] = new Label();
                    G1[i].Parent = Panel1;
                }


                G[1].Text = "Молекулярная масса                        ";
                G[2].Text = "Норм. темпер. плавления        K            ";
                G[3].Text = "Нормал. темп. кипения          K            ";
                G[4].Text = "Kритическая температура        К            ";
                G[5].Text = "Критическое давление           Па           ";
                G[6].Text = "Критический обем               М**3/Кмоль   ";
                G[7].Text = "Крит. к-ент сжимаемости                   ";
                G[8].Text = "Фактор ацентричн. Питцера                 ";
                G[9].Text = "Плотн. жидк. при опорн.темп.   Кг/М**3      ";
                G[10].Text = "Опорная температура           К            ";
                G[11].Text = "Дипольный момент             (Н*М**4)**0.5";
                G[12].Text = "Стан. тепл. образ. при 298К   Дж/Кмоль     ";
                G[13].Text = "Tепл. парообр. при T кип.ноp. Дж/Кмоль     ";
                G[14].Text = "Изобарн. потенц. (пpи н.у.)   Дж/Кмоль     ";

                Font1 = Label1.Font;
                Font2 = Label2.Font;
                for (int i = 1; i <= 14; i++)
                {
                    G[i].Left = 5;
                    G[i].Width = G[0].Width;
                    G[i].Top = (int)Round((i - 1) * G[0].Height / 1d);
                    G[i].Font = Font1;


                    G1[i].Left = G[0].Width + 10;
                    G1[i].Width = G1[0].Width;
                    G1[i].Top = (int)Round((i - 1) * G1[0].Height / 1d);
                    G1[i].Font = Font2;
                    G1[i].ForeColor = Label2.ForeColor;


                }
                Module1.selMatterIndex = 0;
                ViewProp();
            }
            else
            {
                NH = 0;
            }
        }
        public string GetConnStr(string sourceName)
        {
            string GetConnStrRet = default;
            GetConnStrRet = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=True;Data Source=" + sourceName + ";Jet OLEDB:Database Password=";
            return GetConnStrRet;
        }

        private void ListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                AddRow();
            }
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddRow();
        }

        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ContextMenuStrip1.Show();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Module1.selMatterIndex = ListBox1.SelectedIndex + 1;
            ViewProp();
        }


        public void ViewProp()
        {


            for (int i = 1; i <= 14; i++)
            {
                if (Module1.F[Module1.selMatterIndex, i] == 0d)
                    G1[i].Text = "";
                else
                    G1[i].Text = Module1.F[Module1.selMatterIndex, i].ToString();

            }

        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            Find();
        }
        public void Find()
        {

            for (int i = 0; i <= 617; i++)
            {
                if (Conversions.ToBoolean(Strings.InStr(Conversions.ToString(Table.Rows[i]["Title"]), Strings.UCase(TextBoxFind.Text)) | Strings.InStr(Conversions.ToString(Table.Rows[i]["Formula"]), Strings.UCase(TextBoxFind.Text))))
                {
                    ListBox1.SelectedIndex = i;
                    Module1.selMatterIndex = i + 1;
                    ViewProp();
                    return;
                }
            }
            Interaction.MsgBox("Строка не найдена.");
        }

        private void TextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                Find();
            }
        }




        // ***********************************************************
        // *     ССPC           ПОДПРОГРАММА                         *
        // ***********************************************************
        // * ОПРЕДЕЛЯЕТ TЕПЛОЕМКОСТЬ ГАЗА И ЖИДКОСТИ                 *
        // ***********************************************************
        // * IP     - 1-ГАЗ, 2-ЖИДКОСТЬ                              *
        // * NOM    - ЧИСЛО КОМПОНЕНТОВ                              *
        // *  Т     - ТЕМПЕРАТУРА ,К                                 *
        // *  Р     - ДАВЛЕНИЕ , ПА                                  * 
        // *  CP    - ТЕПЛОЕМКОСТЬ , ДЖ/КГ/К                         * 
        // *********************************************************** 
        public void CCPC(object IP, object NOM, object T, object P, object CP)
        {
            // DIMENSION(C1(10))
            // COMMON/Y/Y(10)
            // COMMON/F/F(10,32)
            // IF(IP.EQ.1)THEN
            // Call CPGSMC(T, P, NOM, CP)
            // Else
            // SS=0.
            // DO 1 I=1,NOM
            // Call CPLC(I, T, P, C1(I))
            // 1:                      SS = SS + Y(I) * C1(I)
            // CP = SS
            // ENDIF 
        }






        // ***********************************************************
        // *  fpC    ФИЗИЧЕСКИЕ СВОЙСТВА                             *
        // ***********************************************************
        // * C Ч И Т Ы В А Е Т  ЗНАЧЕНИЯ ЗАТРЕБОВАННЫХ СВОЙСТВ       *
        // * В Ы В О Д И Т                                           *
        // ***********************************************************
        public void FPC(object NN, object NKL, object IPP, object IH)
        {
            object[] FU = new object[11], IV = new object[11], C = new object[11], YYX = new object[11];
            // CHARACTER AA*10,G(21)*80,BE(10,2)*49,
            // *  HU*80,OU*8,zn(3)*1,oar*43,ofu*43,HUU*80
            double[] ard = new double[101];
            double[,] fud = new double[101, 4];
            // COMMON/F/F(10,32)
            // COMMON/G/G
            // COMMON/BE/BE
            // COMMON/Y/Y(10)
            // COMMON/PA/PA(3)
            // COMMON/HU/HU
            // COMMON/IV/IV
            // common/re/ard,fud
            // COMMON/CC/C
            // data zn/'*','+','#'/
            for (int I = 1; I <= 10; I++)
                YYX[I] = Y[I];
            // G(19)(1:45)='?????????????????????????????????????????????'
            // G(19)(46:56)='???????????'
            // G(20)(1:45)='? Tемп.K ?Давление Па ?Агр.cост.?            '
            // G(20)(46:56)='          ?'
            // G(21)(1:45)='?????????????????????????????????????????????'
            // G(21)(46:56)='???????????'
            // Continue 

            // If (IPP = 2 And NKL > 1) Then GoTo 500

            // *один компонент*******************************
            // G(1).Text = "Молекулярная масса "
            // G(2).Text = "'Норм. темпер. Плавления, K"
            // G(3).Text = "Нормал. темп. кипения,K"
            // G(4).Text = "Kритическая температура,К"
            // G(5).Text = "Критическое давление,Па"
            // G(6).Text = "Критический объем, М**3/Кмоль"
            // G(7).Text = "Крит. к-ент сжимаемости"
            // G(8).Text = "Фактор ацентричн. Питцера"
            // G(9).Text = "Плотн. жидк. при опорн.темп., Кг/М**3"
            // G(10).Text = "Опорная температура, К"
            // G(11).Text = "Дипольный момент, (Н*М**4)**0.5"
            // G(12).Text = "Стан. тепл. образ. при 298К,  Дж/Кмоль"
            // G(13).Text = "Tепл. парообр. при T кип.ноp.Дж/Кмоль"
            // G(14).Text = "Изобарн. потенц. (пpи н.у.),  Дж/Кмоль"

            if (Operators.ConditionalCompareObjectEqual(NKL, 1, false))
            {
                // Call FILC(3, 0, 21, 79, 113, 32)
                // NH = 0
                // Call b(G, 42, 14, 3, 1)
                // '************распечатка констант**************
                // G(12).Text = ""
                // G(13).Text = ""
                // G(14).Text = ""
                // For ik = 1 To 11
                // G1(ik).Text = "  "
                // If (F(1, ik) > 0) Then G1(ik).Text = F(1, ik).ToString
                // Next
                // If F(1, 19) > 0 Then G1(12).Text = F(1, 19).ToString
                // If (F(1, 3) < 0.001 Or F(1, 5) < 0.001 Or F(1, 4) < 0.001) Then GoTo 9731
                // Call dhc(293.15, 100000, 1, hvb, hv)
                // G1(13).Text = hvb.tostring
                // 9731:
                // If F(1, 18) > 0 Then G(14).Text = F(1, 18).ToString
                // Call B(G, 9, 14, 3, 44)
                // '**********меню*******************************
                // Else
                // '*более 1-го компонента***********************
                // NH = 0
            }
            // 3939:
            // G(1) = "Исходное меню       "
            // ContextMenuStrip1.Items(2) = "Плотность, Кг/М**3"
            // ContextMenuStrip1.Items(3) = "К-ент динамич. вязк.         Н*С/М**2    "
            // ContextMenuStrip1.Items(4) = "К-ент кинемат. вязк.         М**2/С      "
            // ContextMenuStrip1.Items(5) = "К-ент теплопроводн.          Вт/(М*К)    "
            // ContextMenuStrip1.Items(6) = "Изобарн. теплоемк.           Дж/(Кг*К)   "
            // ContextMenuStrip1.Items(7) = "Ид.-газ. теплоемк.СР         Дж/(Кмоль*К)"
            // ContextMenuStrip1.Items(8) = "Давл. насыщ. паров           Па          "
            // ContextMenuStrip1.Items(9) = "Температура насыщ.           K           "
            // ContextMenuStrip1.Items(10) = "Тепл. исп. при Тнас.         Дж/кг       "
            // ContextMenuStrip1.Items(11) = ""
            BU = Module1.F[1, 5];
            // LO = 0

            if (Abs(BU) < 0.1d & Module1.F[1, 12] < 0.01d | Module1.F[1, 12] < 0.01d & Module1.F[1, 20] < 0.01d)
            {
            }
            // HU = " Для продолжения - <Ent>"
            // Call os(22, 2, 70, 14)
            // Call sc(jop)
            // NN = 5
            // GOTO4()
            else if (Module1.F[1, 26] < 0.1d & Abs(Module1.F[1, 12]) < 0.01d)
            {
                // G(1)='Исходное меню        '
                // G(2)='Плотность                    Кг/М**3      '
                // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
                // G(4)='К-ент кинемат. вязк.         М**2/С       '
                // G(5)='Давл. насыщ. паров           Па           '
                // G(6)='Температура насыщ.           K            '
                // G(7)='Тепл. исп. при Тнас.         Дж/кг        '
                // G(8)=' '

                ContextMenuStrip1.Items.Add("Плотность, Кг/М**3");
                ContextMenuStrip1.Items.Add("К-ент динамич. вязк.         Н*С/М**2    ");
                ContextMenuStrip1.Items.Add("К-ент кинемат. вязк.         М**2/С      ");
                ContextMenuStrip1.Items.Add("Давл. насыщ. паров           Па          ");
                ContextMenuStrip1.Items.Add("Температура насыщ.           K           ");
                ContextMenuStrip1.Items.Add("Тепл. исп. при Тнас.         Дж/кг       ");
                ContextMenuStrip1.Items.Add("");

                // LO = 1
            }
            // N = 0 'порядковый номер свойства
            // IO = 6
            // HU = "Выберите нужное свойство"
            // Call OS(22, 2, 50, 14)
            // For J = 1 To 3
            // Pa(J) = -1
            // Next

            // If (NKL = 1) Then
            // If (LO = 1) Then
            // Call SVKM(6, 55, 12, 20, 7, 7, N, 23, 113, 0, 2)
            // 'OFU=G(N)(1:43)
            // If (N > 4) Then N = N + 3
            // lo = 0
            // Else
            // Call SVKM(6, 55, 15, 20, 10, 10, N, 23, 113, 0, 2)
            // 'OFU=G(N)(1:43)
            // End If
            // ILO = 9
            // Else
            // HUU = G(7)
            // G(7)=' '
            // Call SVKM(11, 54, 16, 22, 6, 6, N, 23, 113, 0, 2)
            // OFU=G(N)(1:43)
            // G(7) = HUU
            // ILO = 18
            // End If
            // G(5)='К-ент теплопроводн.          Вт/(М*К)     '
            // G(6)='Изобарн. теплоемк.           Дж/(Кг*К)    '
            // G(7)='Ид.-газ. теплоемк.СР         Дж/(Кмоль*К) '

            // ContextMenuStrip1.Items(5) = "К-ент теплопроводн.          Вт/(М*К)    "
            // ContextMenuStrip1.Items(6) = "Изобарн. теплоемк.           Дж/(Кг*К)   "
            // ContextMenuStrip1.Items(7) = "Ид.-газ. теплоемк.СР         Дж/(Кмоль*К)"





            // If (n = 1) Then
            // NN = 5
            // goto4()
            // End If
            // BU = F(1, 26)
            // NIN = 0
            // IGO = 0
            // HU='Выберите форму представления данных'
            // Call OS(22, 2, 50, 14)
            // 'g(1)=' Число   График '
            // 'G(2)=' '
            // NI = 1 'Число   График 
            // Call SVKM(11, 54, 11, 8, 2, 1, Ni, 23, 113, 0, 2)
            // 'ni=1 число, 2- графика
            // *********графика*****************************************
            // IX = 1
            // ice = 1
            // Continue Do
            // If (ni = 2) Then
            // If (NIN = 8) Then GoTo 5031
            // If (ix = 1) Then
            // IX = 2
            // Call TUDA1(80, 23, 0, 0)
            // Call FILC(2, 1, 21, 78, 113, 32)
            // Call BOX(0, 2, 0, 80, 20, 1)
            // Call box(0, 4, 20, 30, 15, 1)
            // End If
            // IFA = 0
            // 'HU=ofu(1:22)
            // 'HU(23:35)=ofu(30:42)
            // Call OS(3, 22, 35, 116)
            // If (n > 6 And N <> 9) Then
            // kodg = 1
            // goto97()
            // End If
            // If (n = 9) Then
            // kodg = 2
            // goto97()
            // End If
            // If (NIN > 3) Then GoTo 97
            // 'HU='Bыберите аргумент'
            // Call OS(22, 2, 50, 14)
            // ' 	g(1)='Tемпература   Давление  '
            // '	G(2)=' '
            // KODG = 0
            // Call svkM(20, 22, 20, 12, 2, 1, kodg, 23, 113, 0, 2)
            // 97:         'Continue Do
            // If (KODg = 1) Then
            // 'oar='Температура , K         '
            // Else
            // '		oar='Давление    , Па        '
            // End If

            // HU = oar
            // Call OS(20, 34, 25, 116)
            // 'HU='Максимальное значение аргумента'
            // Call OS(22, 2, 50, 14)
            // 44:         'Continue Do
            // If (NIN < 4) Then
            // HU = ""
            // Call VRE(19, 46, 10, 113, KB)
            // '	CALL CKOD(HU(1:10),AMA)
            // End If
            // If (KODg = 1) Then 'Температура 	if(oar(1:1).eq.'Т')THEN
            // If (AMA > 1500) Then

            // If MsgBox("Teмпература превышает 1500 К. Продолжим?", MsgBoxStyle.OkCancel) = False Then Exit Sub
            // 'g(1)='        Извините!'
            // '    			g(2)=' Teмпература превышает '
            // '      			g(3)=' 1500 К.'
            // '      			g(4)=' Bы этого хотите ?'
            // '      			g(5)=' '
            // '                Call dop()
            // '      			g(1)='  Да      Нет   '
            // '      			G(2)=' '


            // NIe = 1
            // 'Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // 'Call ottu1(42, 12, 9, 19)
            // 'IF(NIE.EQ.2)GOTO44
            // End If
            // LO = 1
            // Call CORT(1, AMA, LO) '
            // If (LO = 100) Then Exit Sub ' GOTO44()
            // If (LO = 101) Then
            // NN = 5
            // GOTO4()
            // End If
            // If (N = 8 Or N = 10) Then
            // LO = 2
            // Call CORT(1, AMA, LO)
            // If (LO = 100) Then Exit Sub 'GOTO44
            // If (LO = 101) Then
            // NN = 5
            // GoTo 4
            // End If
            // End If
            // Else
            // LO = 3
            // Call CORT(1, AMA, LO)
            // If (LO = 100) Then Exit Sub 'GOTO44
            // If (LO = 101) Then
            // NN = 5
            // GoTo 4
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call CORT(1, AMA, LO)
            // If (LO = 100) Then Exit Sub 'GOTO44
            // If (LO = 101) Then
            // NN = 5
            // GoTo 4
            // End If
            // End If
            // End If
            // HU='Минимальное  значение аргумента'
            // Call OS(22, 2, 50, 14)
            // 45:         Continue Do
            // IF(NIN.EQ.5.OR.NIN.LT.4)THEN
            // HU=' '
            // 4531:           Call VRE(19, 17, 10, 113, KB)
            // CALL CKOD(HU(1:10),AMI)
            // IF(AMA-AMI.LE.1.E-8)THEN
            // g(1)='        Извините!'
            // g(2)=' Максимальное значение '
            // g(3)=' аргумента должно быть'
            // g(4)=' больше   минимального'
            // g(5)=' '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto4531()
            // End If
            // End If
            // if(oar(1:1).eq.'Т')THEN
            // LO = 1
            // Call CORT(1, AMI, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.8.OR.N.EQ.10)THEN
            // LO = 2
            // Call CORT(1, AMA, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // Else
            // LO = 3
            // Call CORT(1, AMI, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call CORT(1, AMA, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // End If
            // HU='Максимальное значение функции  '
            // Call OS(22, 2, 50, 14)
            // IF(NIN.EQ.6.OR.NIN.LT.4)THEN
            // HU=' '
            // Call VRE(4, 9, 10, 113, KB)
            // CALL CKOD(HU(1:10),FMA)
            // End If
            // HU='Минимальное  значение функции  '
            // Call OS(22, 2, 50, 14)
            // 47	  	IF(NIN.EQ.7.OR.NIN.LT.4)THEN
            // HU=' '
            // 4731:                           Call VRE(18, 9, 10, 113, KB)
            // CALL CKOD(HU(1:10),FMI)
            // IF(FMA-FMI.LE.1.E-8)THEN
            // g(1)='        Извините!'
            // g(2)=' Максимальное значение '
            // g(3)=' функции   должно быть'
            // g(4)=' больше   минимального'
            // g(5)=' '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto4731()
            // End If
            // End If
            // Call filc(22, 0, 23, 79, 14, 32)
            // *текущее значение аргумента
            // 5031:                       ate = ami
            // IF(KODG.EQ.1)THEN
            // t = ate
            // Else
            // P = ATE
            // End If
            // HUU=' '
            // IF(KODg.EQ.2.and.n.ne.9)THEN
            // p = ami
            // hu='Temпература, K'
            // HUU = HU
            // Call OS(4, 55, 15, 113)
            // HU = zn(IO - 5)
            // Call OS(IO, 55, 1, 113)
            // IF(NIN.EQ.8.OR.NIN.LT.4)THEN
            // HU=' '
            // 8943:                               Call VRE(IO, 57, 10, 113, KB)
            // if(hu(1:1).eq.' ')goto8943
            // CALL CKOD(HU(1:10),T)
            // Pa(IO - 5) = t
            // End If
            // ELSE if(n.lt.7)then
            // t = ami
            // hu='Давление,  Па'
            // HUU = HU
            // Call OS(4, 55, 16, 116)
            // HU = ZN(IO - 5)
            // Call OS(IO, 55, 1, 113)
            // IF(NIN.EQ.8.OR.NIN.LT.4)THEN
            // HU=' '
            // 8941:                                   Call VRE(IO, 57, 10, 113, KB)
            // if(hu(1:1).eq.' ')goto8941
            // CALL CKOD(HU(1:10),P)
            // Pa(IO - 5) = P
            // End If
            // End If
            // HU = HUU
            // *шаги
            // ha=30./(ama-ami)
            // hf=15./(fma-fmi)
            // GOTO501()
            // *****!!!!!!!!!!!
            // End If


            // *****************не графика*************
            // IF(NKL.EQ.1)THEN
            // Call FILC(3, 0, 21, 79, 113, 32)
            // Else
            // Call FILC(16, 0, 21, 79, 113, 32)
            // End If
            // DO 4555 I=1,3
            // G(I+15)(1:56)=G(I)(1:56)
            // 4555	G(I)(1:56)=G(I+18)(1:56)
            // IF(NKL.EQ.1)THEN
            // Call B(G, 56, 3, 4, 0)
            // LL = 5
            // Else
            // Call B(G, 56, 3, 14, 0)
            // LL = 15
            // End If
            // DO 4556 I=1,3
            // 4556	G(I)(1:56)=G(I+15)(1:56)
            // HU=OFU(1:20)
            // Call OS(LL, 34, 20, 116)
            // NN = 9
            // L = N
            // *TЕМПЕРАТУРА
            // 6	IF((NN.NE.3.AND.NN.NE.9).OR.N.EQ.9)GOTO33
            // HU='Укажите температуру'
            // Call OS(22, 2, 50, 14)
            // HU=' '
            // 46:                 Call VRE(ILO, 1, 7, 113, KB)
            // AA=HU(1:10)
            // IF(AA(1:5).EQ.'     ')THEN
            // WRITE(0,*)CHAR(7)
            // GOTO6()
            // End If
            // Call CKOD(AA, T)
            // IF(T.gt.1500.)THEN
            // g(1)='        Извините!'
            // g(2)=' Teмпература превышает '
            // g(3)=' 1500 К.'
            // g(4)=' Bы этого хотите ?'
            // g(5)=' '
            // Call dop()
            // g(1)='  Да      Нет   '
            // G(2)=' '
            // NIe = 1
            // Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // Call ottu1(42, 12, 9, 19)
            // IF(NIE.EQ.2)GOTO46
            // End If
            // IF(IPP.EQ.11.AND.T.GT.647.)THEN
            // g(1)='        Извините!'
            // g(2)=' Концентрация воды задана'
            // g(3)=' влажностью. Температура'
            // g(4)=' не должна превышать'
            // g(5)=' критическую - 647 K.  '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto46()
            // End If
            // LO = 1
            // Call CORT(1, T, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.8.OR.N.EQ.10)THEN
            // LO = 2
            // Call CORT(1, T, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // Call FILC(22, 0, 23, 79, 0, 32)
            // 501     IF((N.EQ.8.OR.N.EQ.10).AND.NKL.EQ.1)THEN
            // *        	if(AMA-AME.LE.1.0E-8.OR.FMA-FMI.LE.1.0E-8)GOTO6112
            // Call PVC(1, T, YY)
            // IF(N.EQ.8)GOTO6112
            // PY = YY
            // Call DHC(T, PY, 1, hvb, yy)
            // GOTO6112()
            // End If
            // IF(N.EQ.7.AND.NKL.EQ.1)THEN
            // YY=F(1,12)+F(1,13)*T+F(1,14)*T**2+F(1,15)*T**3
            // *             CALL CCPC(1,1,T,100000.,YY)
            // YY=YY*1000.
            // goto6112()
            // End If
            // IF(NI.EQ.2)GOTO5097
            // *ДАВЛЕНИЕ
            // 33   IF((NN.NE.4.AND.NN.NE.9).AND.N.NE.9)GOTO5097
            // HU='Укажите давление'
            // Call OS(22, 2, 50, 14)
            // 3317    HU=' '
            // Call VRE(ILO, 11, 10, 113, KB)
            // AA=HU(1:10)
            // Call CKOD(AA, P)
            // IF(P.gt.10000000)THEN
            // g(1)='        Извините!'
            // g(2)=' Давление превышает '
            // g(3)=' 10000000 Па.'
            // g(4)=' Bы этого хотите ?'
            // g(5)=' '
            // Call dop()
            // g(1)='  Да      Нет   '
            // G(2)=' '
            // NIe = 1
            // Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // Call ottu1(42, 12, 9, 19)
            // goto3317()
            // End If
            // Call FILC(22, 0, 23, 79, 0, 32)
            // IF(AA(1:5).EQ.'     ')THEN
            // WRITE(0,*)CHAR(7)
            // GOTO33()
            // End If
            // LO = 3
            // Call CORT(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call CORT(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // 5097:                                               Continue Do
            // IF(N.EQ.9.AND.NKL.EQ.1)THEN
            // Call PVV(1, P, YY)
            // GOTO6112()
            // End If
            // IF(NI.EQ.2)GOTO500
            // *ВЛАЖНОСТЬ
            // IF(IPP.EQ.11)THEN
            // Call PVC(IH, T, PVP)
            // If (PVP.GE.P) Then
            // g(1)='        Извините!'
            // g(2)=' При заданной температуре'
            // g(3)=' давление насыщенных'
            // g(4)=' паров воды превышает'
            // g(5)=' давление смеси.  '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto6060()
            // End If
            // *МОЛЬНАЯ ДОЛЯ ВОДЫ
            // PO=C(IH)/100.*PVP/P
            // Y(IH) = PO
            // SCC=0.
            // DO 599 M=1,NKL
            // If (M.NE.IH) Then
            // POP=YYX(M)*(1.-PO)
            // Y(M) = POP
            // End If
            // 599:                                                            Continue Do
            // ENDIF
            // *АГРЕГАТНОЕ СОСТОЯНИЕ 2=ЖИДКОСТЬ 1=ГАЗ
            // 500:                                                    Continue Do
            // IF(N.GT.6.AND.NKL.EQ.1)GOTO34
            // DO 521 M=1,NKL
            // 521:                                                            IV(M) = 0
            // IG = 0
            // IF(NI.EQ.2)IG=IGO
            // Call CONFF(P, T, NKL, IG)
            // IGO = IG
            // IF(NI.EQ.2.AND.IG.GT.2)then
            // yy=0.
            // GOTO6112()
            // End If
            // IF(NI.EQ.2)GOTO34
            // IF(NKL.EQ.1)GOTO734
            // *******ПЕРЕМАРКИРОВКА КОМПОНЕНТОВ****************************
            // DO 644 M=1,NKL
            // MM = M + 2
            // IF(IV(M).EQ.2)THEN
            // IVE = 78
            // ELSE IF(IV(M).EQ.3)THEN
            // IVE = 62
            // Else
            // IVE = 113
            // End If
            // WRITE(HU(1:2),'(I2)')M
            // HU(3:3)='.'
            // HU(4:52)=BE(M,1)(1:49)
            // IF(NKL.NE.1)CALL OS(MM,1,52,IVE)
            // 644:                                                                                Continue Do
            // IF(IG.EQ.1.OR.IG.EQ.2)GOTO734
            // **************************************************************
            // WRITE(0,*)CHAR(7)
            // I1 = 0
            // do 6777 i=1,71,20
            // I1 = I1 + 1
            // 6777	HU(I:i+19)=g(I1)(1:20)
            // Call tuda(24, 15, 5, 55)
            // Call FILC(5, 55, 19, 78, 78, 32)
            // g(1)='  Извините!         '
            // G(2)=' Компоненты должны '
            // G(3)=' быть либо газом,  '
            // G(4)=' либо жидкостью.   '
            // Call b(G, 20, 4, 6, 57)
            // *	call box(0,5,55,24,15,1)
            // I1 = 0
            // do 6717 i=1,71,20
            // I1 = I1 + 1
            // 6717	g(I1)(1:20)=HUU(I:i+19)
            // IF(NI.EQ.1)THEN
            // Call FILC(13, 56, 17, 77, 16, 32)
            // HU=' Газ         '
            // Call OS(14, 57, 13, 113)
            // HU=' Жидкость    '
            // Call OS(15, 57, 13, 78)
            // HU=' Твердое тело'
            // Call OS(16, 57, 13, 62)
            // End If
            // HU=' Для продолжения - <Ent>'
            // Call OS(22, 2, 50, 14)
            // Call sc(koy)
            // Call FILC(22, 0, 23, 79, 0, 32)
            // Call ottu(24, 15, 5, 55)
            // IF(NI.EQ.2)THEN
            // Call OTTU1(80, 23, 0, 0)
            // GOTO5()
            // End If
            // IF(NKL.NE.1)THEN
            // DO 624 M=1,NKL
            // MM = M + 2
            // WRITE(HU(1:2),'(I2)')M
            // HU(3:3)='.'
            // HU(4:52)=BE(M,1)(1:49)
            // IF(IV(M).EQ.1)GOTO624
            // Call OS(MM, 1, 52, 113)
            // 624:                                                                                                        Continue Do
            // End If
            // ILO = ILO - 1
            // GOTO6060()
            // 734	if(ni.eq.2)goto91
            // IF(NKL.NE.1)THEN
            // IF(IG.EQ.1)then
            // HU='Газ  '
            // else IF(IG.EQ.2)then
            // HU='Жидк.'
            // else if(ig.eq.3)then
            // HU='Твер.'
            // yy = 0
            // End If
            // Call OS(ILO, 25, 6, 113)
            // End If
            // 91:                                                                                                         Continue Do
            // 34:                                                                                                         Continue Do
            // *ПЛОТНОСТЬ
            // IF((N.EQ.2.OR.N.EQ.4).AND.NKL.GT.1.AND.IG.EQ.1)THEN
            // Call URSSC(NKL, P, T, ZM, VM, YY, VMO, FU)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.NKL.EQ.1.AND.IG.EQ.1)THEN
            // Call URS1C(NKL, P, T, ZM, VM, YY)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.IG.EQ.2)THEN
            // YY=0.
            // DO 346 LI=1,NKL
            // Call PLOLIC(T, P, LI, PL)
            // 346:                                                                                                                YY = YY + PL * Y(LI)
            // ENDIF
            // PLOT = YY
            // *ДИН. ВЯЗКОСТЬ
            // DO 4141 LI=1,NKL
            // IF(F(li,26).LT.0.1.AND.IG.EQ.2.AND.(N.EQ.4.OR.N.EQ.3))THEN
            // G(1)='        Извините !        '
            // g(2)=' По вязкости жидкости для'
            // g(3)=' вещества'
            // g(3)(15:24)=be(li,1)(1:10)
            // g(4)=' '
            // G(4)(2:26)=BE(li,1)(11:35)
            // g(5)=' данные отсутствуют.'
            // Call dop()
            // G(1)=' Продолжить  Исх. меню  '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.1)GOTO3939
            // NN = 5
            // goto4()
            // End If
            // 4141:                                                                                                               Continue Do
            // *проверка на дебай
            // DO 8191 M=1,NKL
            // IF(IG.EQ.1.AND.F(M,11).LT.-0.1.AND.(N.EQ.4.OR.N.EQ.3))THEN
            // G(1)='        Извините !        '
            // g(2)=' для  вещества'
            // g(2)(16:25)=be(M,1)(1:10)
            // g(3)=' '
            // G(3)(2:26)=BE(M,1)(11:35)
            // g(4)=' данных по дипольнoму'
            // g(5)=' моменту нет.'
            // Call dop()
            // G(1)=' Продолжить  Исх. меню  '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.2)THEN
            // NN = 5
            // GOTO4()
            // End If
            // G(1)='        Примем        '
            // g(2)=' для  вещества'
            // g(2)(16:25)=be(M,1)(1:10)
            // g(3)=' '
            // G(3)(2:26)=BE(M,1)(11:35)
            // g(4)=' значение дипольнoго'
            // g(5)=' момента равное 0 ?'
            // Call dop()
            // G(1)=' Да          Нет        '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.2)GOTO5
            // End If
            // 8191:                                                                                                                       Continue Do
            // IF(N.EQ.4.OR.N.EQ.3)CALL VVZC(IG,NKL,T,P,YY)
            // IF(N.EQ.4)YY=YY/PLOT
            // *ТЕПЛОПРОВОДНОСТЬ
            // IF(N.EQ.5)CALL LLDC(IG,NKL,T,P,YY)
            // *ТЕПЛОЕМКОСТЬ
            // IF(N.EQ.6)CALL CCPC(IG,NKL,T,P,YY)
            // '6112:                                                                                                                                       Continue Do
            // ******графика*****************************************
            // if(ni.eq.2)then
            // if(AMA-AME.LE.1.0E-8.OR.FMA-FMI.LE.1.0E-8)GOTO9444
            // ard(ice) = ate
            // fud(ice, IO - 5) = yy
            // ICE = ICE + 1
            // koa = Int((ate - ami) * ha) + 20
            // kof = 19 - Int((yy - fmi) * hf)
            // if(koa.gt.48.or.koa.lt.22.or.kof.lt.6.or.kof.gt.17)goto9777
            // HU = ZN(IO - 5)
            // Call OS(KOF, KOA, 1, 113)
            // 9777	   ate=ate+1./ha
            // if(kodg.eq.1)then
            // t = ate
            // Else
            // p = ate
            // End If
            // if(ate.ge.ama)goto9444
            // goto501()
            // 9444:                   Continue Do
            // G(1)=' График   '
            // G(2)=' Cвойство '
            // G(3)=' Исх.меню '
            // G(4)=' Мах. арг.'
            // G(5)=' Мin. арг.'
            // G(6)=' Мах. фун.'
            // G(7)=' Мin. фун.'
            // G(8)=' Темп/Давл'
            // G(9)=' '
            // NIN = 0
            // IGO = 0
            // Call filc(22, 0, 23, 78, 14, 32)
            // Call SVKM(9, 64, 16, 10, 8, 8, NiN, 23, 113, 0, 2)
            // HU = huu
            // IF(NIN.GT.3)THEN
            // IF(NIN.EQ.8)IO=IO+1
            // *	     IF(IO.GT.8)IO=6
            // NI = 2
            // ice = 1
            // IF(NIN.LT.8.OR.io.gt.8)THEN
            // DO 6690 IK=1,100
            // FUD(IK,1)=0.
            // FUD(IK,2)=0.
            // 6690		FUD(IK,3)=0.
            // hu=' '
            // Call os(6, 55, 15, 113)
            // Call os(7, 55, 15, 113)
            // Call os(8, 55, 15, 113)
            // *                  WRITE(HU(1:10),'(F10.1)')PA(IO-5)
            // if(n.ne.8.and.n.ne.9)CALL os(6,55,10,113)
            // IO = 6
            // Call FILC(5, 21, 17, 48, 113, 32)
            // End If
            // GOTO6070()
            // ENDIF
            // if(nin.eq.1)then
            // NN = NKL
            // Call vig(ama, ami, fma, fmi, OAR, OFU, NN)
            // if(nn.eq.2.AND.NKL.EQ.1)THEN
            // Call FILC(0, 0, 21, 79, 113, 32)
            // Call BOX(0, 0, 0, 80, 3, 1)
            // HU=BE(1,1)(1:49)
            // Call OS(1, 2, 76, 30)
            // goto5()
            // End If
            // End If
            // if(nin.eq.2)THEN
            // Call OTTU1(80, 23, 0, 0)
            // goto5()
            // End If
            // NN = 5
            // goto4()
            // End If
            // **************************************
            // WRITE(HU(1:10),'(F7.2)')T
            // IF(N.NE.9)CALL OS(ILO,1,7,113)
            // IF(N.lt.7)THEN
            // WRITE(HU(1:10),'(F10.1)')P
            // Call OS(ILO, 11, 10, 113)
            // IF(IG.EQ.1.and.nkl.eq.1)THEN
            // HU='Г'
            // Call OS(ILO, 28, 1, 113)
            // ELSE IF(IG.EQ.2.and.nkl.eq.1)THEN
            // HU='Ж'
            // Call OS(ILO, 28, 1, 113)
            // ELSE  IF(IG.EQ.3.and.nkl.eq.1)THEN
            // HU='Т'
            // Call OS(ILO, 28, 1, 113)
            // End If
            // End If
            // WRITE(HU(1:10),'(E10.4)')YY
            // HU(13:26)=OFU(30:43)
            // Call OS(ILO, 32, 26, 116)
            // 6060	G(1)=' Вещество '
            // G(2)=' Cвойство '
            // G(3)=' Температ.'
            // G(4)=' Давление '
            // G(5)=' Концентр.'
            // G(6)=' Исх.меню '
            // G(7)=' '
            // Call filc(22, 0, 23, 78, 14, 32)
            // NN = 0
            // 7211:                           Call SVKM(9, 64, 14, 10, 6, 6, NN, 23, 113, 0, 2)
            // *	CALL SVCI(2,55,18,11,5,5,NN,IN,OT,JA)
            // if(nn.eq.5.and.nkl.eq.1)goto7211
            // IF(NN.EQ.4.AND.N.GT.6.and.n.ne.9)GOTO7211
            // IF(NN.EQ.3.AND.N.EQ.9)GOTO7211
            // 433:                                        N = L
            // ILO = ILO + 1
            // IF(ILO.GT.20)THEN
            // IF(NKL.EQ.1)THEN
            // Call SCRO(6, 1, 8, 1, 20, 55, 113)
            // Else
            // Call SCRO(6, 1, 18, 1, 20, 55, 113)
            // End If
            // ILO = 20
            // End If
            // IF(NN.EQ.2)GOTO5
            // IF(NN.EQ.3.)THEN
            // WRITE(HU(1:10),'(F10.1)')P
            // IF(N.LT.7)CALL OS(ILO,11,10,113)
            // GOTO6()
            // End If
            // IF(NN.EQ.4)THEN
            // WRITE(HU(1:7),'(F7.2)')T
            // IF(N.NE.9)CALL OS(ILO,1,7,113)
            // GOTO33()
            // End If
            // IF(NN.EQ.5.AND.NKL.NE.1)THEN
            // NN = 15
            // IPP = 2
            // GOTO4()
            // End If
            // IF(NN.EQ.6)NN=5
            // 4:                                                          End


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // расчет()
            // *****************не графика*************
            // If (NKL = 1) Then
            // Call FILC(3, 0, 21, 79, 113, 32)
            // Else
            // Call FILC(16, 0, 21, 79, 113, 32)
            // End If

            // DO 4555 I=1,3
            // G(I+15)(1:56)=G(I)(1:56)
            // 4555	G(I)(1:56)=G(I+18)(1:56)
            // IF(NKL.EQ.1)THEN
            // Call B(G, 56, 3, 4, 0)
            // LL = 5
            // Else
            // Call B(G, 56, 3, 14, 0)
            // LL = 15
            // End If
            // DO 4556 I=1,3
            // 4556	G(I)(1:56)=G(I+15)(1:56)
            // HU=OFU(1:20)
            // Call OS(LL, 34, 20, 116)
            // NN = 9
            // L = N

            // *TЕМПЕРАТУРА
            // 6	IF((NN.NE.3.AND.NN.NE.9).OR.N.EQ.9)GOTO33
            // HU='Укажите температуру'
            // Call OS(22, 2, 50, 14)
            // HU=' '
            // 46:         Call VRE(ILO, 1, 7, 113, KB)
            // AA=HU(1:10)
            // IF(AA(1:5).EQ.'     ')THEN
            // WRITE(0,*)CHAR(7)
            // GOTO6()
            // End If
            // Call CKOD(AA, T)
            // IF(T.gt.1500.)THEN
            // g(1)='        Извините!'
            // g(2)=' Teмпература превышает '
            // g(3)=' 1500 К.'
            // g(4)=' Bы этого хотите ?'
            // g(5)=' '
            // Call dop()
            // g(1)='  Да      Нет   '
            // G(2)=' '
            // NIe = 1
            // Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // Call ottu1(42, 12, 9, 19)
            // IF(NIE.EQ.2)GOTO46
            // End If
            // IF(IPP.EQ.11.AND.T.GT.647.)THEN
            // g(1)='        Извините!'
            // g(2)=' Концентрация воды задана'
            // g(3)=' влажностью. Температура'
            // g(4)=' не должна превышать'
            // g(5)=' критическую - 647 K.  '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto46()
            // End If
            // LO = 1
            // Call CORT(1, T, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.8.OR.N.EQ.10)THEN
            // LO = 2
            // Call CORT(1, T, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // Call FILC(22, 0, 23, 79, 0, 32)
            // 501     IF((N.EQ.8.OR.N.EQ.10).AND.NKL.EQ.1)THEN
            // *        	if(AMA-AME.LE.1.0E-8.OR.FMA-FMI.LE.1.0E-8)GOTO6112
            // Call PVC(1, T, YY)
            // IF(N.EQ.8)GOTO6112
            // PY = YY
            // Call DHC(T, PY, 1, hvb, yy)
            // GOTO6112()
            // End If
            // IF(N.EQ.7.AND.NKL.EQ.1)THEN
            // YY=F(1,12)+F(1,13)*T+F(1,14)*T**2+F(1,15)*T**3
            // *             CALL CCPC(1,1,T,100000.,YY)
            // YY=YY*1000.
            // goto6112()
            // End If
            // IF(NI.EQ.2)GOTO5097
            // *ДАВЛЕНИЕ
            // 33   IF((NN.NE.4.AND.NN.NE.9).AND.N.NE.9)GOTO5097
            // HU='Укажите давление'
            // Call OS(22, 2, 50, 14)
            // 3317    HU=' '
            // Call VRE(ILO, 11, 10, 113, KB)
            // AA=HU(1:10)
            // Call CKOD(AA, P)
            // IF(P.gt.10000000)THEN
            // g(1)='        Извините!'
            // g(2)=' Давление превышает '
            // g(3)=' 10000000 Па.'
            // g(4)=' Bы этого хотите ?'
            // g(5)=' '
            // Call dop()
            // g(1)='  Да      Нет   '
            // G(2)=' '
            // NIe = 1
            // Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // Call ottu1(42, 12, 9, 19)
            // goto3317()
            // End If
            // Call FILC(22, 0, 23, 79, 0, 32)
            // IF(AA(1:5).EQ.'     ')THEN
            // WRITE(0,*)CHAR(7)
            // GOTO33()
            // End If
            // LO = 3
            // Call CORT(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call CORT(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // 5097:                                       Continue Do
            // IF(N.EQ.9.AND.NKL.EQ.1)THEN
            // Call PVV(1, P, YY)
            // GOTO6112()
            // End If
            // IF(NI.EQ.2)GOTO500
            // *ВЛАЖНОСТЬ
            // IF(IPP.EQ.11)THEN
            // Call PVC(IH, T, PVP)
            // If (PVP.GE.P) Then
            // g(1)='        Извините!'
            // g(2)=' При заданной температуре'
            // g(3)=' давление насыщенных'
            // g(4)=' паров воды превышает'
            // g(5)=' давление смеси.  '
            // Call dop()
            // Call SC(N)
            // Call ottu1(42, 12, 9, 19)
            // goto6060()
            // End If
            // *МОЛЬНАЯ ДОЛЯ ВОДЫ
            // PO=C(IH)/100.*PVP/P
            // Y(IH) = PO
            // SCC=0.
            // DO 599 M=1,NKL
            // If (M.NE.IH) Then
            // POP=YYX(M)*(1.-PO)
            // Y(M) = POP
            // End If
            // 599:                                                    Continue Do
            // ENDIF
            // *АГРЕГАТНОЕ СОСТОЯНИЕ 2=ЖИДКОСТЬ 1=ГАЗ
            // 500:                                            Continue Do
            // IF(N.GT.6.AND.NKL.EQ.1)GOTO34
            // DO 521 M=1,NKL
            // 521:                                                    IV(M) = 0
            // IG = 0
            // IF(NI.EQ.2)IG=IGO
            // Call CONFF(P, T, NKL, IG)
            // IGO = IG
            // IF(NI.EQ.2.AND.IG.GT.2)then
            // yy=0.
            // GOTO6112()
            // End If
            // IF(NI.EQ.2)GOTO34
            // IF(NKL.EQ.1)GOTO734
            // *******ПЕРЕМАРКИРОВКА КОМПОНЕНТОВ****************************
            // DO 644 M=1,NKL
            // MM = M + 2
            // IF(IV(M).EQ.2)THEN
            // IVE = 78
            // ELSE IF(IV(M).EQ.3)THEN
            // IVE = 62
            // Else
            // IVE = 113
            // End If
            // WRITE(HU(1:2),'(I2)')M
            // HU(3:3)='.'
            // HU(4:52)=BE(M,1)(1:49)
            // IF(NKL.NE.1)CALL OS(MM,1,52,IVE)
            // 644:                                                                        Continue Do
            // IF(IG.EQ.1.OR.IG.EQ.2)GOTO734
            // **************************************************************
            // WRITE(0,*)CHAR(7)
            // I1 = 0
            // do 6777 i=1,71,20
            // I1 = I1 + 1
            // 6777	HU(I:i+19)=g(I1)(1:20)
            // Call tuda(24, 15, 5, 55)
            // Call FILC(5, 55, 19, 78, 78, 32)
            // g(1)='  Извините!         '
            // G(2)=' Компоненты должны '
            // G(3)=' быть либо газом,  '
            // G(4)=' либо жидкостью.   '
            // Call b(G, 20, 4, 6, 57)
            // *	call box(0,5,55,24,15,1)
            // I1 = 0
            // do 6717 i=1,71,20
            // I1 = I1 + 1
            // 6717	g(I1)(1:20)=HUU(I:i+19)
            // IF(NI.EQ.1)THEN
            // Call FILC(13, 56, 17, 77, 16, 32)
            // HU=' Газ         '
            // Call OS(14, 57, 13, 113)
            // HU=' Жидкость    '
            // Call OS(15, 57, 13, 78)
            // HU=' Твердое тело'
            // Call OS(16, 57, 13, 62)
            // End If
            // HU=' Для продолжения - <Ent>'
            // Call OS(22, 2, 50, 14)
            // Call sc(koy)
            // Call FILC(22, 0, 23, 79, 0, 32)
            // Call ottu(24, 15, 5, 55)
            // IF(NI.EQ.2)THEN
            // Call OTTU1(80, 23, 0, 0)
            // GOTO5()
            // End If
            // IF(NKL.NE.1)THEN
            // DO 624 M=1,NKL
            // MM = M + 2
            // WRITE(HU(1:2),'(I2)')M
            // HU(3:3)='.'
            // HU(4:52)=BE(M,1)(1:49)
            // IF(IV(M).EQ.1)GOTO624
            // Call OS(MM, 1, 52, 113)
            // 624:                                                                                                Continue Do
            // End If
            // ILO = ILO - 1
            // GOTO6060()
            // 734	if(ni.eq.2)goto91
            // IF(NKL.NE.1)THEN
            // IF(IG.EQ.1)then
            // HU='Газ  '
            // else IF(IG.EQ.2)then
            // HU='Жидк.'
            // else if(ig.eq.3)then
            // HU='Твер.'
            // yy = 0
            // End If
            // Call OS(ILO, 25, 6, 113)
            // End If
            // 91:                                                                                                 Continue Do
            // 34:                                                                                                 Continue Do
            // *ПЛОТНОСТЬ
            // IF((N.EQ.2.OR.N.EQ.4).AND.NKL.GT.1.AND.IG.EQ.1)THEN
            // Call URSSC(NKL, P, T, ZM, VM, YY, VMO, FU)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.NKL.EQ.1.AND.IG.EQ.1)THEN
            // Call URS1C(NKL, P, T, ZM, VM, YY)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.IG.EQ.2)THEN
            // YY=0.
            // DO 346 LI=1,NKL
            // Call PLOLIC(T, P, LI, PL)
            // 346:                                                                                                        YY = YY + PL * Y(LI)
            // ENDIF
            // PLOT = YY
            // *ДИН. ВЯЗКОСТЬ
            // DO 4141 LI=1,NKL
            // IF(F(li,26).LT.0.1.AND.IG.EQ.2.AND.(N.EQ.4.OR.N.EQ.3))THEN
            // G(1)='        Извините !        '
            // g(2)=' По вязкости жидкости для'
            // g(3)=' вещества'
            // g(3)(15:24)=be(li,1)(1:10)
            // g(4)=' '
            // G(4)(2:26)=BE(li,1)(11:35)
            // g(5)=' данные отсутствуют.'
            // Call dop()
            // G(1)=' Продолжить  Исх. меню  '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.1)GOTO3939
            // NN = 5
            // goto4()
            // End If
            // 4141:                                                                                                       Continue Do
            // *проверка на дебай
            // DO 8191 M=1,NKL
            // IF(IG.EQ.1.AND.F(M,11).LT.-0.1.AND.(N.EQ.4.OR.N.EQ.3))THEN
            // G(1)='        Извините !        '
            // g(2)=' для  вещества'
            // g(2)(16:25)=be(M,1)(1:10)
            // g(3)=' '
            // G(3)(2:26)=BE(M,1)(11:35)
            // g(4)=' данных по дипольнoму'
            // g(5)=' моменту нет.'
            // Call dop()
            // G(1)=' Продолжить  Исх. меню  '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.2)THEN
            // NN = 5
            // GOTO4()
            // End If
            // G(1)='        Примем        '
            // g(2)=' для  вещества'
            // g(2)(16:25)=be(M,1)(1:10)
            // g(3)=' '
            // G(3)(2:26)=BE(M,1)(11:35)
            // g(4)=' значение дипольнoго'
            // g(5)=' момента равное 0 ?'
            // Call dop()
            // G(1)=' Да          Нет        '
            // G(2)=' '
            // KOD = 0
            // Call SVKM(17, 25, 17, 12, 2, 1, KOD, 23, 113, 0, 2)
            // Call ottu1(42, 12, 9, 19)
            // IF(KOD.EQ.2)GOTO5
            // End If
            // 8191:                                                                                                               Continue Do
            // IF(N.EQ.4.OR.N.EQ.3)CALL VVZC(IG,NKL,T,P,YY)
            // IF(N.EQ.4)YY=YY/PLOT
            // *ТЕПЛОПРОВОДНОСТЬ
            // IF(N.EQ.5)CALL LLDC(IG,NKL,T,P,YY)
            // *ТЕПЛОЕМКОСТЬ
            // IF(N.EQ.6)CALL CCPC(IG,NKL,T,P,YY)
            // 6112:                                                                                                                               Continue Do



        }



        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NKL = (int)Round(NumericUpDown1.Value);
            if (NKL > 1)
            {
                Panel1.Visible = false;
                DataGridView1.Visible = true;
                Label6.Visible = false;
                ButtonAdd.Visible = true;
                ButtonClear.Visible = true;

                DataGridView1.Rows.Clear();
                for (int I = 0, loopTo = NKL - 2; I <= loopTo; I++)
                    DataGridView1.Rows.Add();
            }

            else
            {
                Panel1.Visible = true;
                DataGridView1.Visible = false;
                Label6.Visible = true;
                ButtonAdd.Visible = false;
                ButtonClear.Visible = false;

            }
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            // Индекс свойства в меню


        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (NKL == 1)
            {
                // Call FILC(3, 0, 21, 79, 113, 32)
                // NH = 0
                // Call b(G, 42, 14, 3, 1)
                // '************распечатка констант**************
                // G(12).Text = ""
                // G(13).Text = ""
                // G(14).Text = ""
                // For ik = 1 To 11
                // G1(ik).Text = "  "
                // If (F(1, ik) > 0) Then G1(ik).Text = F(1, ik).ToString
                // Next
                // If F(1, 19) > 0 Then G1(12).Text = F(1, 19).ToString
                // If (F(1, 3) < 0.001 Or F(1, 5) < 0.001 Or F(1, 4) < 0.001) Then GoTo 9731
                // Call dhc(293.15, 100000, 1, hvb, hv)
                // G1(13).Text = hvb.tostring
                // 9731:
                // If F(1, 18) > 0 Then G(14).Text = F(1, 18).ToString
                // Call B(G, 9, 14, 3, 44)
                // '**********меню*******************************
                // Else
                // '*более 1-го компонента***********************
                // NH = 0
            }
            // 3939:
            // G(1) = "Исходное меню       "
            ContextMenuStrip1.Items.Clear();
            ContextMenuStrip1.Items.Add("Плотность, Кг/М**3");
            ContextMenuStrip1.Items.Add("К-ент динамич. вязк.,Н*С/М**2    ");
            ContextMenuStrip1.Items.Add("К-ент кинемат. вязк.,М**2/С      ");
            ContextMenuStrip1.Items.Add("К-ент теплопроводн., Вт/(М*К)    ");
            ContextMenuStrip1.Items.Add("Изобарн. теплоемк.,  Дж/(Кг*К)   ");
            ContextMenuStrip1.Items.Add("Ид.-газ. теплоемк.СР, Дж/(Кмоль*К)");
            ContextMenuStrip1.Items.Add("Давл. насыщ. паров, Па");
            ContextMenuStrip1.Items.Add("Температура насыщ.,K");
            ContextMenuStrip1.Items.Add("Тепл. исп. при Тнас., Дж/кг");
            ContextMenuStrip1.Items.Add("");

            // ContextMenuStrip1.Items(2) = "Плотность, Кг/М**3"
            // ContextMenuStrip1.Items(3) = "К-ент динамич. вязк.         Н*С/М**2    "
            // ContextMenuStrip1.Items(4) = "К-ент кинемат. вязк.         М**2/С      "
            // ContextMenuStrip1.Items(5) = "К-ент теплопроводн.          Вт/(М*К)    "
            // ContextMenuStrip1.Items(6) = "Изобарн. теплоемк.           Дж/(Кг*К)   "
            // ContextMenuStrip1.Items(7) = "Ид.-газ. теплоемк.СР         Дж/(Кмоль*К)"
            // ContextMenuStrip1.Items(8) = "Давл. насыщ. паров           Па          "
            // ContextMenuStrip1.Items(9) = "Температура насыщ.           K           "
            // ContextMenuStrip1.Items(10) = "Тепл. исп. при Тнас.         Дж/кг       "
            // ContextMenuStrip1.Items(11) = ""
            BU = Module1.F[1, 5]; // критическое давление
                                  // LO = 0

            if (Abs(BU) < 0.1d & Module1.F[1, 12] < 0.01d | Module1.F[1, 12] < 0.01d & Module1.F[1, 20] < 0.01d)
            {
            }
            // HU = " Для продолжения - <Ent>"
            // Call os(22, 2, 70, 14)
            // Call sc(jop)
            // NN = 5
            // GOTO4()
            else if (Module1.F[1, 26] < 0.1d & Abs(Module1.F[1, 12]) < 0.01d)
            {
                // G(1)='Исходное меню        '
                // G(2)='Плотность                    Кг/М**3      '
                // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
                // G(4)='К-ент кинемат. вязк.         М**2/С       '
                // G(5)='Давл. насыщ. паров           Па           '
                // G(6)='Температура насыщ.           K            '
                // G(7)='Тепл. исп. при Тнас.         Дж/кг        '
                // G(8)=' '
                ContextMenuStrip1.Items.Clear();
                ContextMenuStrip1.Items.Add("Плотность, Кг/М**3");
                ContextMenuStrip1.Items.Add("К-ент динамич. вязк.         Н*С/М**2    ");
                ContextMenuStrip1.Items.Add("К-ент кинемат. вязк.         М**2/С      ");
                ContextMenuStrip1.Items.Add("Давл. насыщ. паров           Па          ");
                ContextMenuStrip1.Items.Add("Температура насыщ.           K           ");
                ContextMenuStrip1.Items.Add("Тепл. исп. при Тнас.         Дж/кг       ");
                ContextMenuStrip1.Items.Add("");

                // LO = 1
            }
            // N = 0 'порядковый номер свойства
            // IO = 6
            // HU = "Выберите нужное свойство"
            // Call OS(22, 2, 50, 14)
            // For J = 1 To 3
            // Pa(J) = -1
            // Next

            ContextMenuStrip1.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ListBox1.Left = 0;
            ListBox1.Top = TextBoxFind.Height + TextBoxFind.Top + 10;
            ListBox1.Height = DisplayRectangle.Height - (TextBoxFind.Height + TextBoxFind.Top + 10);

            DataGridView1.Top = ListBox1.Top;
            DataGridView1.Left = ListBox1.Width + 10;

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            RowNumber = 0;
            DataGridView1.Rows.Clear();
        }
        public void AddRow()
        {
            if (RowNumber > NKL - 1)
            {
                RowNumber = NKL - 1;
                return;
            }
            DataGridView1[0, RowNumber].Value = ListBox1.SelectedItem;
            RowNumber += 1;
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowNumber = e.RowIndex;
        }

        private void ToolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            Module1.PropIndex = ToolStripDropDownButton1.DropDownItems.IndexOf(e.ClickedItem);

            My.MyProject.Forms.frmPROP.Text = Conversions.ToString(ListBox1.Items[Module1.selMatterIndex - 1]);
            My.MyProject.Forms.frmPROP.DataGridView1.Columns[3].HeaderText = ToolStripDropDownButton1.DropDownItems[Module1.PropIndex].Text;
            My.MyProject.Forms.frmPROP.Axis1.y_Name = ToolStripDropDownButton1.DropDownItems[Module1.PropIndex].Text;
            My.MyProject.Forms.frmPROP.Show();

        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            T = Conversions.ToDouble(DataGridView1[0, 0].Value);
        }

        private void DataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            T = Conversion.Val(DataGridView1[0, 0].Value);
        }



        private void TtttToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}