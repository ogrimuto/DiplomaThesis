using System;
using System.Drawing;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{

    public partial class frmPROP
    {
        private double MinArg, MaxArg, MinFun, MaxFun;
        private int RowGridIndex = 0;
        private double PropValue;
        private int eKeyCode;
        private double DefValue;
        private double DeltaT;
        private double DeltaP;
        private bool AxisOk;

        public frmPROP()
        {
            InitializeComponent();
        }
        private void frmPROP_Load(object sender, EventArgs e)
        {
            DataGridView1.Rows.Add();
            switch (Module1.PropIndex)
            {
                case 0:
                    {
                        break;
                    }
                // G(2)='Плотность                    Кг/М**3      '
                case 1:
                    {
                        break;
                    }
                // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
                case 2:
                    {
                        break;
                    }
                // G(4)='К-ент кинемат. вязк.         М**2/С       '
                case 3:
                    {
                        break;
                    }
                // G(5)='К-ент теплопроводн.          Вт/(М*К)     '
                case 4:
                    {
                        break;
                    }
                // G(6)='Изобарн. теплоемк.           Дж/(Кг*К)    '
                case 5:
                    {
                        break;
                    }
                // G(7)='Ид.-газ. теплоемк.СР         Дж/(Кмоль*К) '
                case 6:
                    {
                        // Давл. насыщ. паров           Па   
                        DataGridView1[0, RowGridIndex].Selected = true;
                        DataGridView1[0, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 4].ToString();
                        DataGridView1[1, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 5].ToString();
                        DataGridView1[3, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 5].ToString();
                        DataGridView1[2, RowGridIndex].Value = "Крит.";

                        TextBoxMinArg.Text = "373";
                        TextBoxMaxArg.Text = Module1.F[Module1.selMatterIndex, 4].ToString();
                        TextBoxMinFun.Text = "100000";
                        TextBoxMaxFun.Text = Module1.F[Module1.selMatterIndex, 5].ToString();
                        break;
                    }


                case 7:
                    {
                        // Температура насыщ.           K            '
                        DataGridView1.Rows.Add();
                        DataGridView1[0, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 4].ToString();
                        DataGridView1[1, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 5].ToString();
                        DataGridView1[3, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 5].ToString();
                        DataGridView1[2, RowGridIndex].Value = "Крит.";
                        break;
                    }

                case 8:
                    {
                        break;
                    }
                    // G(10)='Тепл. исп. при Тнас.         Дж/кг        '

            }
            for (int i = 0; i <= 8; i++)
                DataGridView1.Rows.Add();

        }

        private void frmPROP_Resize(object sender, EventArgs e)
        {
            DataGridView1.Width = (int)Round(DisplayRectangle.Width / 2d);
            DataGridView1.Top = MenuStrip1.Height;
            DataGridView1.Height = (int)Round(DisplayRectangle.Height / 2d - MenuStrip1.Height);
            Axis1.Width = (int)Round(DisplayRectangle.Width / 2d);
            Axis1.Left = (int)Round(DisplayRectangle.Width / 2d);
            Axis1.Top = DataGridView1.Top;
            Axis1.Height = DisplayRectangle.Height - MenuStrip1.Height;
            Panel1.Left = 0;
            Panel1.Width = (int)Round(DisplayRectangle.Width / 2d);
            Panel1.Top = DataGridView1.Top + DataGridView1.Height;
            Panel1.Height = (int)Round(DisplayRectangle.Height / 2d);

        }

        private void ГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawPropAxis();
        }
        public void DrawPropAxis()
        {

            Axis1.Axis_Type = (byte)Round(Conversion.Val(NumericUpDown1.Value));

            Axis1.x_Base = Conversion.Val(TextBoxMaxArg.Text);
            Axis1.y_Base = Conversion.Val(TextBoxMaxFun.Text);

            Axis1.x_Base0 = Conversion.Val(TextBoxMinArg.Text);
            Axis1.y_Base0 = Conversion.Val(TextBoxMinFun.Text);

            AxisOk = false;
            if (Axis1.x_Base <= Axis1.x_Base0 | Axis1.y_Base <= Axis1.y_Base0)
            {

                Interaction.MsgBox("Минимальное значение должно быть меньше максимального");
                AxisOk = true;
                return;


            }


            if (RadioButtonT.Checked)
                Axis1.x_Name = "Температура, К";
            else
                Axis1.x_Name = "Давление, Па";



            Axis1.AxisDraw();



        }



        // ************************************************************
        // *   cort                                                   *
        // ************************************************************
        // * ВЫЧИСЛЯЕТ ДАВЛЕНИЕ НАСЫЩЕНИЯ ПО ЗАДАННОЙ ТЕМПЕРАТУРЕ     *
        // ************************************************************
        public void cort(int n, double t)
        {
            var ino = default(byte);
            var pp = default(double);
            if (t < Module1.F[n, 2])
            {
                Interaction.MsgBox("Tемпература не должна быть  ниже  Т замерзания");
                ino = 10;
            }
            else if (t > Module1.F[n, 4])
            {
                Interaction.MsgBox("Tемпература не должна быть выше критической");
                ino = 10;
            }
            else if (Module1.F[n, 2] > 0.01d)
            {
                PVC(n, t, ref pp);
                if (pp <= Module1.F[n, 2])
                {
                    Interaction.MsgBox("Давление не должно быть ниже Pнас.при Т замерзания. Требуется доролнительная проверка");
                    ino = 10;
                }
            }
            else if (pp > Module1.F[n, 5])
            {
                Interaction.MsgBox("Давление не должно быть выше критического. . Требуется дополнительная проверка");
                ino = 10;
            }
            if (ino == 10)
            {
                PropValue = 0d;
            }
            else
            {
                PropValue = pp;
            }

        }
        // ***********************************************************
        // *  fpC    ФИЗИЧЕСКИЕ СВОЙСТВА                             *
        // ***********************************************************
        // * C Ч И Т Ы В А Е Т  ЗНАЧЕНИЯ ЗАТРЕБОВАННЫХ СВОЙСТВ       *
        // * В Ы В О Д И Т                                           *
        // ***********************************************************
        public void FPC(object NN, object NKL, object IPP, object IH)
        {
            // Dim(FU(10), IV(10), C(10), YYX(10))
            // '	CHARACTER AA*10,G(21)*80,BE(10,2)*49,
            // *  HU*80,OU*8,zn(3)*1,oar*43,ofu*43,HUU*80
            // real*8 ard(100),fud(100,3)
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
            // DO 1190 I=1,10
            // 1190:       YYX(I) = Y(I)
            // G(19)(1:45)='?????????????????????????????????????????????'
            // G(19)(46:56)='???????????'
            // G(20)(1:45)='? Tемп.K ?Давление Па ?Агр.cост.?            '
            // G(20)(46:56)='          ?'
            // G(21)(1:45)='?????????????????????????????????????????????'
            // G(21)(46:56)='???????????'
            // 5:          Continue Do
            // IF(IPp.EQ.2.AND.NKL.GT.1)GOTO500
            // *один компонент*******************************
            // G(1)='Молекулярная масса                        '
            // G(2)='Норм. темпер. Плавления, K            '
            // G(3)='Нормал. темп. кипения        K            '
            // G(4)='Kритическая температура      К            '
            // G(5)='Критическое давление         Па           '
            // G(6)='Критический об"ем            М**3/Кмоль   '
            // G(7)='Крит. к-ент сжимаемости                   '
            // G(8)='Фактор ацентричн. Питцера                 '
            // G(9)='Плотн. жидк. при опорн.темп. Кг/М**3      '
            // G(10)='Опорная температура          К            '
            // G(11)='Дипольный момент             (Н*М**4)**0.5'
            // G(12)='Стан. тепл. образ. при 298К  Дж/Кмоль     '
            // G(13)='Tепл. парообр. при T кип.ноp.Дж/Кмоль     '
            // G(14)='Изобарн. потенц. (пpи н.у.)  Дж/Кмоль     '

            // IF(NKL.EQ.1)THEN
            // Call FILC(3, 0, 21, 79, 113, 32)
            // NH = 0
            // Call b(g, 42, 14, 3, 1)
            // ************распечатка констант**************
            // g(12)=' '
            // g(13)=' '
            // g(14)=' '
            // do 451 ik=1,11
            // g(ik)=' '
            // 451	   if(f(1,ik).gt.0.)write(G(IK)(1:9),'(e9.3)')f(1,ik)
            // if(f(1,19).gt.0.)write(G(12)(1:9),'(e9.3)')f(1,19)
            // if(f(1,3).lt.0.001.or.f(1,5).lt.0.001.or.
            // *	   f(1,4).lt.0.001)goto9731
            // call dhc(293.15,100000.,1,hvb,hv)
            // write(G(13)(1:9),'(e9.3)')hvb
            // 9731	   if(f(1,18).gt.0.)write(G(14)(1:9),'(e9.3)')f(1,18)
            // Call B(G, 9, 14, 3, 44)
            // **********меню*******************************
            // Else
            // *более 1-го компонента***********************
            // NH = 0
            // End If
            // 3939:                               Continue Do
            // G(1)='Исходное меню        '
            // G(2)='Плотность                    Кг/М**3      '
            // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
            // G(4)='К-ент кинемат. вязк.         М**2/С       '
            // G(5)='К-ент теплопроводн.          Вт/(М*К)     '
            // G(6)='Изобарн. теплоемк.           Дж/(Кг*К)    '
            // G(7)='Ид.-газ. теплоемк.СР         Дж/(Кмоль*К) '
            // G(8)='Давл. насыщ. паров           Па           '
            // G(9)='Температура насыщ.           K            '
            // G(10)='Тепл. исп. при Тнас.         Дж/кг        '
            // G(11)=' '
            // BU = F(1, 5)
            // LO = 0

            // IF((ABS(BU).LT.0.1.and.F(1,12).LT.0.01).OR.
            // *(F(1,12).LT.0.01.and.F(1,20).LT.0.01)) THEN
            // hu=' Для продолжения - <Ent>'
            // Call os(22, 2, 70, 14)
            // Call sc(jop)
            // NN = 5
            // GOTO4()
            // ELSE IF(F(1,26).GT.0.1.AND.abs(F(1,12)).LT.0.01)THEN
            // G(1)='Исходное меню        '
            // G(2)='Плотность                    Кг/М**3      '
            // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
            // G(4)='К-ент кинемат. вязк.         М**2/С       '
            // G(5)='Давл. насыщ. паров           Па           '
            // G(6)='Температура насыщ.           K            '
            // G(7)='Тепл. исп. при Тнас.         Дж/кг        '
            // G(8)=' '
            // LO = 1
            // End If
            // N = 0
            // io = 6
            // HU='Выберите нужное свойство'
            // Call OS(22, 2, 50, 14)
            // DO 3050 J=1,3
            // 3050    PA(J)=-1.
            // IF(NKL.EQ.1)THEN
            // IF(LO.EQ.1)THEN
            // Call SVKM(6, 55, 12, 20, 7, 7, N, 23, 113, 0, 2)
            // OFU=G(N)(1:43)
            // IF(N.GT.4)N=N+3
            // lo = 0
            // Else
            // Call SVKM(6, 55, 15, 20, 10, 10, N, 23, 113, 0, 2)
            // OFU=G(N)(1:43)
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
            // if(n.eq.1)then
            // nn = 5
            // goto4()
            // End If
            // BU = F(1, 26)
            // NIN = 0
            // IGO = 0
            // HU='Выберите форму представления данных'
            // Call OS(22, 2, 50, 14)
            // g(1)=' Число   График '
            // G(2)=' '
            // NI = 1
            // Call SVKM(11, 54, 11, 8, 2, 1, Ni, 23, 113, 0, 2)
            // *********графика*****************************************
            // IX = 1
            // ice = 1
            // 6070:                                       Continue Do
            // if(ni.eq.2)then
            // IF(NIN.EQ.8)GOTO5031
            // IF(ix.EQ.1)THEN
            // IX = 2
            // Call TUDA1(80, 23, 0, 0)
            // Call FILC(2, 1, 21, 78, 113, 32)
            // Call BOX(0, 2, 0, 80, 20, 1)
            // Call box(0, 4, 20, 30, 15, 1)
            // End If
            // IFA = 0
            // HU=ofu(1:22)
            // HU(23:35)=ofu(30:42)
            // Call OS(3, 22, 35, 116)
            // if(n.gt.6.AND.N.NE.9)THEN
            // kodg = 1
            // goto97()
            // End If
            // if(n.EQ.9)then
            // kodg = 2
            // goto97()
            // End If
            // IF(NIN.GT.3)GOTO97
            // HU='Bыберите аргумент'
            // Call OS(22, 2, 50, 14)
            // g(1)='Tемпература   Давление  '
            // G(2)=' '
            // KODG = 0
            // Call svkM(20, 22, 20, 12, 2, 1, kodg, 23, 113, 0, 2)
            // 97:                                                     Continue Do
            // IF(KODg.EQ.1)THEN
            // oar='Температура , K         '
            // Else
            // oar='Давление    , Па        '
            // End If
            // HU = oar
            // Call OS(20, 34, 25, 116)
            // HU='Максимальное значение аргумента'
            // Call OS(22, 2, 50, 14)
            // 44:                                                     Continue Do
            // IF(NIN.LE.4)THEN
            // HU=' '
            // Call VRE(19, 46, 10, 113, KB)
            // CALL CKOD(HU(1:10),AMA)'строка в число
            // End If
            // AMA = Val(DataGridView1.Rows(DefRow)(0))

            // If (RadioButton1.Checked) Then 'аргумент темперaтура
            // If (AMA > 1500) Then

            // If MsgBox("Teмпература превышает 1500 К. Продолжим?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub

            // End If ' 	g(1)='        Извините!'
            // 'g(2)=' Teмпература превышает '
            // '		g(3)=' 1500 К.'
            // '		g(4)=' Bы этого хотите ?'
            // '		g(5)=' '
            // '     Call dop()
            // '		g(1)='  Да      Нет   '
            // '		G(2)=' '
            // '     NIe = 1
            // '     Call SVKM(17, 34, 17, 8, 2, 1, Nie, 23, 113, 0, 1)
            // '     Call ottu1(42, 12, 9, 19)
            // '		IF(NIE.EQ.2)GOTO44
            // '     End If


            // LO = 1
            // Call cort(selMatterIndex, AMA, LO) 'давление насыщения
            // 'IF(LO.EQ.100)GOTO44
            // 'IF(LO.EQ.101)THEN
            // '             NN = 5
            // '             GOTO4()
            // '         End If
            // 'IF(N.EQ.8.OR.N.EQ.10)THEN
            // '             LO = 2
            // '             Call CORT(1, AMA, LO)
            // '			IF(LO.EQ.100)GOTO44
            // '			IF(LO.EQ.101)THEN
            // '                     NN = 5
            // '                     GOTO4()
            // '                 End If
            // '             End If
            // '         Else
            // '             LO = 3
            // '             Call CORT(1, AMA, LO)
            // 'IF(LO.EQ.100)GOTO44
            // 'IF(LO.EQ.101)THEN
            // '                     NN = 5
            // '                     GOTO4()
            // '                 End If
            // 'IF(N.EQ.9.OR.N.EQ.10)THEN
            // '                     LO = 4
            // '                     Call CORT(1, AMA, LO)
            // '			IF(LO.EQ.100)GOTO44
            // '			IF(LO.EQ.101)THEN
            // '                             NN = 5
            // '                             GOTO4()
            // '                         End If
            // '                     End If
            // '                 End If



            // 'HU='Минимальное  значение аргумента'
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
            // Call SC(n)
            // Call ottu1(42, 12, 9, 19)
            // goto4531()
            // End If
            // End If
            // if(oar(1:1).eq.'Т')THEN
            // LO = 1
            // Call cort(1, AMI, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.8.OR.N.EQ.10)THEN
            // LO = 2
            // Call cort(1, AMA, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // Else
            // LO = 3
            // Call cort(1, AMI, LO)
            // IF(LO.EQ.100)GOTO45
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call cort(1, AMA, LO)
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
            // Call SC(n)
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
            // hu = zn(IO - 5)
            // Call OS(IO, 55, 1, 113)
            // IF(NIN.EQ.8.OR.NIN.LT.4)THEN
            // HU=' '
            // 8943:                               Call VRE(IO, 57, 10, 113, KB)
            // if(hu(1:1).eq.' ')goto8943
            // CALL CKOD(HU(1:10),T)
            // pa(IO - 5) = t
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
            // pa(IO - 5) = P
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
            // L = n
            // *TЕМПЕРАТУРА
            // 6	IF((NN.NE.3.AND.NN.NE.9).OR.N.EQ.9)GOTO33
            // HU='Укажите температуру'
            // Call OS(22, 2, 50, 14)
            // HU=' '
            // 46:                                         Call VRE(ILO, 1, 7, 113, KB)
            // AA=HU(1:10)
            // IF(AA(1:5).EQ.'     ')THEN
            // WRITE(0,*)CHAR(7)
            // GOTO6()
            // End If
            // Call CKOD(AA, t)
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
            // Call SC(n)
            // Call ottu1(42, 12, 9, 19)
            // goto46()
            // End If
            // LO = 1
            // Call cort(1, t, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.8.OR.N.EQ.10)THEN
            // LO = 2
            // Call cort(1, t, LO)
            // IF(LO.EQ.100)GOTO46
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // Call FILC(22, 0, 23, 79, 0, 32)
            // 501     IF((N.EQ.8.OR.N.EQ.10).AND.NKL.EQ.1)THEN
            // *        	if(AMA-AME.LE.1.0E-8.OR.FMA-FMI.LE.1.0E-8)GOTO6112
            // Call PVC(1, t, YY)
            // IF(N.EQ.8)GOTO6112
            // PY = YY
            // Call DHC(t, PY, 1, hvb, yy)
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
            // Call cort(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // IF(N.EQ.9.OR.N.EQ.10)THEN
            // LO = 4
            // Call cort(1, P, LO)
            // IF(LO.EQ.100)GOTO33
            // IF(LO.EQ.101)THEN
            // NN = 5
            // GOTO4()
            // End If
            // End If
            // 5097:                                                                       Continue Do
            // IF(N.EQ.9.AND.NKL.EQ.1)THEN
            // Call PVV(1, P, YY)
            // GOTO6112()
            // End If
            // IF(NI.EQ.2)GOTO500
            // *ВЛАЖНОСТЬ
            // IF(IPP.EQ.11)THEN
            // Call PVC(IH, t, PVP)
            // If (PVP.GE.P) Then
            // g(1)='        Извините!'
            // g(2)=' При заданной температуре'
            // g(3)=' давление насыщенных'
            // g(4)=' паров воды превышает'
            // g(5)=' давление смеси.  '
            // Call dop()
            // Call SC(n)
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
            // 599:                                                                                    Continue Do
            // ENDIF
            // *АГРЕГАТНОЕ СОСТОЯНИЕ 2=ЖИДКОСТЬ 1=ГАЗ
            // 500:                                                                            Continue Do
            // IF(N.GT.6.AND.NKL.EQ.1)GOTO34
            // DO 521 M=1,NKL
            // 521:                                                                                    IV(M) = 0
            // IG = 0
            // IF(NI.EQ.2)IG=IGO
            // Call CONFF(P, t, NKL, IG)
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
            // 644:                                                                                                        Continue Do
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
            // Call b(g, 20, 4, 6, 57)
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
            // 624:                                                                                                                                Continue Do
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
            // 91:                                                                                                                                 Continue Do
            // 34:                                                                                                                                 Continue Do
            // *ПЛОТНОСТЬ
            // IF((N.EQ.2.OR.N.EQ.4).AND.NKL.GT.1.AND.IG.EQ.1)THEN
            // Call URSSC(NKL, P, t, ZM, VM, YY, VMO, FU)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.NKL.EQ.1.AND.IG.EQ.1)THEN
            // Call URS1C(NKL, P, t, ZM, VM, YY)
            // ELSE IF((N.EQ.2.OR.N.EQ.4).AND.IG.EQ.2)THEN
            // YY=0.
            // DO 346 LI=1,NKL
            // Call PLOLIC(t, P, LI, PL)
            // 346:                                                                                                                                        YY = YY + PL * Y(LI)
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
            // 4141:                                                                                                                                       Continue Do
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
            // 8191:                                                                                                                                               Continue Do
            // IF(N.EQ.4.OR.N.EQ.3)CALL VVZC(IG,NKL,T,P,YY)
            // IF(N.EQ.4)YY=YY/PLOT
            // *ТЕПЛОПРОВОДНОСТЬ
            // IF(N.EQ.5)CALL LLDC(IG,NKL,T,P,YY)
            // *ТЕПЛОЕМКОСТЬ
            // IF(N.EQ.6)CALL CCPC(IG,NKL,T,P,YY)
            // 6112:                                                                                                                                                               Continue Do
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
            // 9444:                                                                                                                                                                               Continue Do
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
            // hu = huu
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
            // 7211:                                                                                                                                                                                       Call SVKM(9, 64, 14, 10, 6, 6, NN, 23, 113, 0, 2)
            // *	CALL SVCI(2,55,18,11,5,5,NN,IN,OT,JA)
            // if(nn.eq.5.and.nkl.eq.1)goto7211
            // IF(NN.EQ.4.AND.N.GT.6.and.n.ne.9)GOTO7211
            // IF(NN.EQ.3.AND.N.EQ.9)GOTO7211
            // 433:                                                                                                                                                                                                    n = L
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
            // 4:                                                                                                                                                                                                                      End





        }


        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            CalcProp(); // табличный расчет

        }

        public void CalcProp() // табличный расчет
        {
            // NKL - число компоннтов
            int N = default, NKL = default, IG = default;
            double ZM = default, VM = default, yy = default;

            Module1.T = Conversion.Val(DataGridView1[0, RowGridIndex].Value);
            double p = Conversion.Val(DataGridView1[1, RowGridIndex].Value);

            switch (Module1.PropIndex)
            {
                case 0:
                    {
                        // Плотность                    Кг/М**3      '

                        if ((N == 2 | N == 4) & NKL > 1 & IG == 1)
                        {
                        }
                        // Call URSSC(NKL, P, T, ZM, VM, YY, VMO, FU)
                        else if ((N == 2 | N == 4) & NKL == 1 & IG == 1)
                        {
                            object argVM = VM;
                            object argROG = yy;
                            URS1C(NKL, p, Module1.T, ZM, ref argVM, ref argROG);
                            VM = Conversions.ToDouble(argVM);
                            yy = Conversions.ToDouble(argROG);
                        }
                        else if ((N == 2 | N == 4) & IG == 2)
                        {
                            yy = 0d;
                            for (int LI = 1, loopTo = NKL; LI <= loopTo; LI++)
                            {
                                // Call PLOLIC(T, P, LI, PL)
                                // yy = yy + PL * Y(LI)
                            }
                        }
                        // PLOT = YY
                        DataGridView1[3, RowGridIndex].Value = PropValue.ToString();
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
                case 2:
                    {
                        break;
                    }
                // G(4)='К-ент кинемат. вязк.         М**2/С       '
                case 3:
                    {
                        break;
                    }
                // G(5)='К-ент теплопроводн.          Вт/(М*К)     '
                case 4:
                    {
                        break;
                    }
                // G(6)='Изобарн. теплоемк.           Дж/(Кг*К)    '
                case 5:
                    {
                        break;
                    }
                // G(7)='Ид.-газ. теплоемк.СР         Дж/(Кмоль*К) '
                case 6:
                    {
                        // Давл. насыщ. паров           Па           '
                        Module1.T = Conversion.Val(DataGridView1[0, RowGridIndex].Value);
                        if (Module1.T < 1d)
                        {
                            clear1_3();
                            return;
                        }
                        cort(Module1.selMatterIndex, Module1.T);

                        DataGridView1[1, RowGridIndex].Value = PropValue.ToString();
                        DataGridView1[2, RowGridIndex].Value = "Насыщ.";
                        DataGridView1[3, RowGridIndex].Value = PropValue.ToString();
                        break;
                    }

                case 7:
                    {
                        // G(9)='Температура насыщ.           K            '

                        cort(Module1.selMatterIndex, Module1.T);
                        DataGridView1[0, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 4].ToString();
                        DataGridView1[1, RowGridIndex].Value = PropValue.ToString();
                        DataGridView1[2, RowGridIndex].Value = "Насыщ.";
                        DataGridView1[3, RowGridIndex].Value = PropValue.ToString();
                        break;
                    }

                case 8:
                    {
                        break;
                    }
                    // G(10)='Тепл. исп. при Тнас.         Дж/кг        '

            }




        }
        public void clear1_3()
        {

            DataGridView1[1, RowGridIndex].Value = "";
            DataGridView1[2, RowGridIndex].Value = "";
            DataGridView1[3, RowGridIndex].Value = "";



        }

        public void CalcPropG() // график
        {
            // If AxisOk = False Then Exit Sub
            var pp = default(double);
            switch (Module1.PropIndex)
            {
                case 0:
                    {
                        break;
                    }
                // G(2)='Плотность                    Кг/М**3      '
                case 1:
                    {
                        break;
                    }
                // G(3)='К-ент динамич. вязк.         Н*С/М**2     '
                case 2:
                    {
                        break;
                    }
                // G(4)='К-ент кинемат. вязк.         М**2/С       '
                case 3:
                    {
                        break;
                    }
                // G(5)='К-ент теплопроводн.          Вт/(М*К)     '
                case 4:
                    {
                        break;
                    }
                // G(6)='Изобарн. теплоемк.           Дж/(Кг*К)    '
                case 5:
                    {
                        break;
                    }
                // G(7)='Ид.-газ. теплоемк.СР         Дж/(Кмоль*К) '
                case 6:
                    {
                        // Давл. насыщ. паров           Па           '
                        DeltaT = (Axis1.x_Base - Axis1.x_Base0) / 100d;
                        DefValue = Axis1.x_Base0 + DeltaT;
                        Axis1.Pix_Size = 0.002d;
                        while (DefValue <= Axis1.x_Base)
                        {

                            DefValue += DeltaT;
                            Module1.T = DefValue;
                            PVC(Module1.selMatterIndex, Module1.T, ref pp);
                            Axis1.PixDraw(Module1.T, pp, Color.Blue, 0);
                        }

                        break;
                    }

                case 7:
                    {
                        // G(9)='Температура насыщ.           K            '

                        cort(Module1.selMatterIndex, Module1.T);
                        DataGridView1[0, RowGridIndex].Value = Module1.F[Module1.selMatterIndex, 4].ToString();
                        DataGridView1[1, RowGridIndex].Value = PropValue.ToString();
                        DataGridView1[2, RowGridIndex].Value = "Насыщ.";
                        DataGridView1[3, RowGridIndex].Value = PropValue.ToString();
                        break;
                    }

                case 8:
                    {
                        break;
                    }
                    // G(10)='Тепл. исп. при Тнас.         Дж/кг        '

            }




        }


        // ************************************************************
        // * PVC   ПОДПРОГРАММА                                       *
        // ************************************************************
        // * ВЫЧИСЛЯЕТ ДАВЛЕНИЕ НАСЫЩЕНИЯ ПО ЗАДАННОЙ ТЕМПЕРАТУРЕ     *
        // ************************************************************
        // * NU - ПОРЯДКОВЫЙ НОМЕР КОМПОНЕНТА                         *
        // * Т  - ТЕМПЕРАТУРА , K                                     *
        // * PVP- ДАВЛЕНИЕ НАСЫЩЕНИЯ, Па                              *
        // ************************************************************
        public void PVC(int N, double T, ref double PVP)
        {
            string st = Conversions.ToString(DataGridView1[0, RowGridIndex].Value);

            // If (Abs(T - F(N, 4)) < 1) Then 'меньше критического
            // PVP = F(N, 5) 'критическое давление
            // Exit Sub
            // End If
            // *ДЛЯ ВОДЫ
            // *	IF(ABS(F(N,1)-18.01).LT.0.1)THEN
            // *	  CALL PVH2OC(T,PVP)
            // *	  GOTO12
            // *	ENDIF
            if (T < Module1.F[N, 28] & T > Module1.F[N, 27] & Module1.F[N, 21] > 0.0001d)
            {
                // * УРАВНЕНИЕ АНТУАНА
                if (Abs(Module1.F[N, 20] - 1d) < 0.5d)
                {
                    // ***********УРАВНЕНИЕ 1-коэффициенты отсутствуют
                    double xx = 1d - T / Module1.F[N, 4];
                    double LnPvpPc = 1d / (1d - xx) * (Module1.F[N, 21] * xx + Module1.F[N, 22] * Pow(xx, 1.5d) + Module1.F[N, 23] * Pow(xx, 3d) + Module1.F[N, 24] * Pow(xx, 6d)) + Log(Module1.F[N, 5] / 100000d);
                    // ***********УРАВНЕНИЕ 2
                    PVP = Exp(LnPvpPc) * Module1.F[N, 5] * 100000d;
                }

                else if (Abs(Module1.F[N, 20] - 2d) < 0.5d)
                {

                    double Pvp1 = 1d;
                    double A1;

                    double A2 = Module1.F[N, 21] - Module1.F[N, 22] / T + Module1.F[N, 23] * Log(T);
                    int Count1 = 1;

                    do
                    {
                        A1 = Log(Pvp1) + Module1.F[N, 24] * Pvp1 / Pow(T, 2d);
                        if (Abs(A1 / A2) < 0.01d)
                            break;

                        Pvp1 += 1d;
                        Count1 += 1;
                    }
                    while (Count1 != 1000000);
                    if (Count1 == 1000000)
                    {
                        Interaction.MsgBox("Результат не получен");
                        PVP = 0d;
                    }
                    else
                    {
                        PVP = Pvp1 * 100000d;
                    }
                }

                else if (Abs(Module1.F[N, 20] - 3d) < 0.5d)
                {
                    // ***********УРАВНЕНИЕ 3
                    PVP = Exp(Module1.F[N, 21] - Module1.F[N, 22] / (T + Module1.F[N, 23]));

                }
            }

            // *Расчет для веществ, для котоpых не опpеделены к-ты Антуана 
            else
            {
                object argPVP = PVP;
                LIKc(Module1.selMatterIndex, T, ref argPVP);
                PVP = Conversions.ToDouble(argPVP);
            }
            PropValue = Round(PVP, 2);
        }
        // ************************************************************
        // * LIK  ПОДПРОГРАММА     (уавнение Питцеpа)                 *
        // ************************************************************
        // * ВЫЧИСЛЯЕТ ДАВЛЕНИЕ НАСЫЩЕНИЯ ПО ЗАДАННОЙ ТЕМПЕРАТУРЕ     *
        // ************************************************************
        public void LIKc(object NU, object T, ref object PVP)
        {
            // Dim KSI As Double
            double TC = Module1.F[Conversions.ToInteger(NU), 4];
            double TB = Module1.F[Conversions.ToInteger(NU), 3];
            double PC = Module1.F[Conversions.ToInteger(NU), 5] / 101325d;
            double TBR = TB / TC;
            var TR = Operators.DivideObject(T, TC);
            double W = Module1.F[Conversions.ToInteger(NU), 8];
            // *****************АНТУАН*******************************
            // *****************РИДЕЛЬ*******************************
            // *	  KSI=-35.+36./TBR+42.*ALOG(TBR)-TBR**6	
            // *	  ALFC=(0.315*KSI+ALOG(PC))/(0.0838*KSI-ALOG(TBR))
            // *	  Q=0.0838*(3.758-ALFC)
            // *	  A=-35.*Q
            // *	  B=-36.*Q
            // *	  C=42.*Q+ALFC
            // *	  D=-Q
            // *	  PVPR=EXP(A-B/TR+C*ALOG(TR)+D*TR**6)
            // *	  PVP=PVPR*PC*101325
            // *	ELSE IF(I.EQ.4)THEN
            // ******************НАТ**********************************
            // *	  A=0.0094-0.0144*W**2
            // *	  B=0.4506-0.4371*W+0.2127*W**2
            // *	  C=0.9827+0.0736*W-0.0210*W**2
            // *	  PVPR=(-B+(B**2-4.*A*(1./TR-C))**0.5)/2./A
            // *	  PVP=10**PVPR*PC*101325.
            // *	ELSE IF(I.EQ.2)THEN
            // ************ПИТЦЕР*******************************************
            double T0 = Module1.F[Conversions.ToInteger(NU), 3] / Module1.F[Conversions.ToInteger(NU), 4];
            // *ФАКТОР АЦЕНТРИЧНОСТИ ПО ЛИ-КЕСЛЕРУ	
            double OM = (-Log(Module1.F[Conversions.ToInteger(NU), 5] / 101325d) - 5.92714d + 6.09648d / T0 + 1.28862d * Log(T0) - 0.169347d * Pow(T0, 6d)) / (15.2518d - 15.6875d / T0 - 13.4721d * Log(T0) + 0.43577d * Pow(T0, 6d));
            T0 = Conversions.ToDouble(Operators.DivideObject(T, Module1.F[Conversions.ToInteger(NU), 4]));
            double FO = 5.92714d - 6.09848d / T0 - 1.28862d * Log(T0) + 0.169347d * Pow(T0, 6d);
            double F1 = 15.2518d - 15.6875d / T0 - 13.4721d * Log(T0) + 0.43577d * Pow(T0, 6d);
            PVP = Round(Exp(FO + OM * F1) * Module1.F[Conversions.ToInteger(NU), 5], 2);
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowGridIndex = e.RowIndex;
        }
        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (eKeyCode == 0)
                CalcProp();
            RowGridIndex = e.RowIndex;
            eKeyCode = 0;
        }
        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowGridIndex = e.RowIndex;
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            eKeyCode = (int)e.KeyCode;
            if (eKeyCode == 13 & RowGridIndex == DataGridView1.Rows.Count - 1)
            {
                RowGridIndex = DataGridView1.Rows.Count - 1;
                CalcProp();
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {


            CalcPropG();


        }
        // ***********************************************************
        // *     URS1С       ПОДПРОГРАММА                            *
        // ***********************************************************
        // *  ВЫЧИСЛЯЕТ ПЛОТНОСТЬ ГАЗА(СОАВЕ-ГРАБОССКИ-ДАУБЕРТ)      *
        // ***********************************************************	
        // * NU  - ПОРЯДКОВЫЙ НОМЕР КОМПОНЕНТА                       *
        // * P   - ДАВЛЕНИЕ, Па                                      *
        // * T   - ТЕМПЕРАТУРА, K                                    *
        // * ZM  - K-ЕНТ СЖИМАЕМОСТИ                                 *
        // * VM  - УДЕЛЬНЫЙ ОБ'ЕМ                                    *
        // * ROG - ПЛОТНОСТЬ, Кг/М**3                                *
        // ***********************************************************
        public void URS1C(object NU, object P, object T, object ZM, ref object VM, ref object ROG)
        {
            double fx1, fx2, eps, xx, x;
            // FX(Z)=Z**3-Z**2+(A-B-B**2)*Z-A*B
            const double SIGA = 0.42748d;
            const double SIGB = 0.08664d;
            const int R = 8314; // , RR = 0.08204
            double VMO = Module1.F[Conversions.ToInteger(NU), 1];
            double TC = Conversions.ToDouble(Operators.DivideObject(T, Module1.F[Conversions.ToInteger(NU), 4]));
            double PC = Conversions.ToDouble(Operators.DivideObject(P, Module1.F[Conversions.ToInteger(NU), 5]));
            double B = SIGB * PC / TC;
            double FM = Pow(1d + (0.48508d + 1.55171d * Module1.F[Conversions.ToInteger(NU), 8] - 0.15613d * Pow(Module1.F[Conversions.ToInteger(NU), 8], 2d)) * (1d - Sqrt(TC)), 2d);

            double A = SIGA * FM * PC / Pow(TC, 2d);
            x = 1d;
            eps = 0.00000001d;
            do
            {
                fx1 = Pow(x, 3d) - Pow(x, 2d) + (A - B - Pow(B, 2d)) * x - A * B;
                fx2 = Pow(x + eps, 3d) - Pow(x + eps, 2d) + (A - B - Pow(B, 2d)) * (x + eps) - A * B;

                xx = fx1 / ((fx2 - fx1) / eps);
                x = x - xx;
            }
            while (Abs(xx) > eps);
            VM = Operators.DivideObject(Operators.MultiplyObject(Operators.MultiplyObject(R, T), x), P);
            // IF(VM/F(NU,6).LT.2.8)VM=F(NU,6)/2.8
            ROG = Operators.DivideObject(Module1.F[Conversions.ToInteger(NU), 1], VM);
            PropValue = Conversions.ToDouble(ROG);
        }


        // ************************************************************
        // *     URSSС       ПОДПРОГРАММА                             *
        // ************************************************************
        // * РАССЧИТЫВАЕТ ПАРАМЕТРЫ СОСТОЯНИЯ ГАЗА ПО УРАВНЕНИЮ       *
        // *              РЕДЛИХА-КВОНГА-СОАВА-ГРАБОССКИ-ДАУБЕРТА     *
        // ************************************************************
        // * Y  - МАССИВ МОЛЬНЫХ ДОЛЕЙ КОМПОНЕНТОВ                    *
        // * NUN- ЧИСЛО КОМПОНЕНТОВ                                   *
        // * P  - ДАВЛЕНИЕ , Па                                       *
        // * Т  - ТЕМПЕРАТУРА, K                                      *
        // * ZM - К-ЕНТ СЖИМАЕМОСТИ                                   *
        // * VM - УДЕЛЬНЫЙ ОБ'ЕМ, М3/Кг                               *
        // * ROG- ПЛОТНОСТЬ, Kг/М3                                    *
        // * МOL- МОЛЕКУЛЯРНАЯ МАССА, Kг/Кмоль                        *
        // * FU - MACCИВ ФУГИТИВНОСТЕЙ КОМПОНЕНТОВ                    *
        // ************************************************************
        // SUBROUTINE(URSSC(NUN, P, T, ZM, VM, ROG, VMO, FU))
        // COMMON/F/F(10,32)
        // COMMON/Y/Y(10)
        // DIMENSION(FU(10))
        // DATA SIGA,SIGB,R,RR/0.42748,0.08664,8314.,0.08204/
        // FX(Z)=Z**3-Z**2+(A-B-B**2)*Z-A*B
        // B=0.
        // A=0.
        // VMO=0.
        // DO 1 I=1,NUN
        // VMO = VMO + F(I, 1) * Y(I)
        // TC = T / F(I, 4)
        // PC = P / F(I, 5)
        // B = B + Y(I) * SIGB * PC / TC
        // AA=0.
        // FMI=(1.+(0.48508+1.55171*F(I,8)-0.15613*F(I,8)**2)*
        // *   (1.-SQRT(TC)))**2
        // DO 2 J=1,NUN
        // TCC = T / F(J, 4)
        // PCC = P / F(J, 5)
        // FM=(1.+(0.48508+1.55171*F(J,8)-0.15613*F(J,8)**2)*
        // *    (1.-SQRT(TCC)))**2
        // AA=AA+(SIGA*FMI*PC/TC**2*Y(I)+SIGA*FM*PCC/TCC**2*
        // *           Y(J))*Y(I)*Y(J)
        // 2:              Continue Do
        // 1:              A = A + AA
        // X=1.
        // eps = 0.0001
        // 3:              fx1 = fx(x)
        // fx2 = fx(x + eps)
        // xx = eps * fx1 / (fx2 - fx1)
        // x = x - xx
        // IF(ABS(XX).GT.EPS)GOTO3
        // ZM = x
        // VM = R * T * ZM / P
        // ROG = VMO / VM
        // End



    }
}