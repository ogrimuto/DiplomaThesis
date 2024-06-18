using System;
using System.Drawing;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsApplication1
{


    public partial class MolDinamics
    {
        private const double AEM = 1.66054E-27d;
        private const double k = 1.380685E-23d;
        private double mel = 13d; // 74 ' * AEM
        private const double Angstrem = 0.0000000001d;
        private double Unit;
        private int AtomDefIndex, neighborIndex, centerIndex;
        private double DUDR, rij, sigma6, xBase, yBase, zBase;
        private double FullE, PotE, KinE, KinEc, KinEp, PotE0;
        private double Xm, Ym, Zm, KSI;
        private double Rgir;
        private double Tcl, Tc, Tp, Tclaver, Tcaver, Tpaver;
        private bool FirstStart = true;

        public MolDinamics()
        {
            InitializeComponent();
        }
        private void MolDinamics_Load(object sender, EventArgs e)
        {
            ListBoxConfiguration.SelectedIndex = 0;
            TextBoxSigma.Text = Module1.Sigma[Module1.selMatterPotencialIndex].ToString();
            TextBoxEpsilon.Text = Module1.Epsilon[Module1.selMatterPotencialIndex].ToString();
            Axis1.Width = Axis1.Height;
        }
        private void RadioButton3D_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton3D.Checked)
                Module1.DimIndex = 3;
            else
                Module1.DimIndex = 2;
        }
        private void RadioButton2D_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2D.Checked)
                Module1.DimIndex = 2;
            else
                Module1.DimIndex = 3;
        }
        public void ClearConfiguration()
        {
            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                Module1.X[i] = 0d;
                Module1.Y[i] = 0d;
                Module1.Z[i] = 0d;
            }
            Module1.AtomCount = 0;
        }

        public void InitConfiguration()
        {
            // D2.D3
            ClearConfiguration();
            xBase = Conversion.Val(TextBoxBase.Text);
            Module1.MinDist = Conversion.Val(TextBoxMinDist.Text);
            Module1.AtomCountLine = (int)Round(Conversion.Val(TextBoxAtomCountLine.Text));
            Module1.Rows = (int)Round(Conversion.Val(TextBoxRows.Text));
            Module1.BreakOn = false;
            if (RadioButton2D.Checked)
            {
                Axis1.Axis_Type = 1;
            }
            else
            {
                Axis1.Axis_Type = 5;
            }

            switch (Module1.ConfigurationIndex)
            {
                case 0:
                    {
                        Module1.AtomCount = 13;
                        TextBoxAtomCount.Text = Module1.AtomCount.ToString();
                        break;
                    }
                case 1:
                case 2:
                    {
                        Module1.AtomCount = (int)Round(Pow(Conversion.Val(TextBoxAtomCountLine.Text), 2d) * Module1.Rows);
                        break;
                    }
                case var @case when @case == 2:
                    {
                        break;
                    }
            }
            Axis1.x_Base = xBase;
            Axis1.y_Base = xBase;
            Axis1.z_Base = xBase;
            yBase = xBase;
            zBase = xBase;
            Axis1.x_Name = "X,sigma";
            Axis1.y_Name = "Y,sigma";
            Axis1.z_Name = "Z,sigma";
            if (Module1.DimIndex == 2)
                Axis1.Pix_type = 1;
            else
                Axis1.Pix_type = 5;

            Axis1.GridColor = Color.LightGray;
            Axis1.Pix_Size = Conversion.Val(TextBoxDiametr.Text) / xBase;
            Axis1.Pix_color = Color.Red;
            Axis1.axis_color = Color.Black;

            if (RadioButtonRect.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Module1.MinDist;
            }
            else
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Sqrt(3d) * Module1.MinDist;
            }
            Axis1.AxisDraw();

            switch (Module1.ConfigurationIndex)
            {

                case 0: // GCK
                    {
                        GCK();
                        break;
                    }
                case 1: // 
                    {
                        Axis1.AtomCount = Module1.AtomCount;
                        RectPacking();
                        break;
                    }
                case 2: // Set
                    {
                        DensestPacking();
                        break;
                    }
                case 3: // Free
                    {
                        break;
                    }


            }

            ShowAtoms();
            InitGraph();
            PotE0 = 0d;
            for (int i = 0, loopTo = Module1.AtomCount - 2; i <= loopTo; i++)
            {
                for (int j = i + 1, loopTo1 = Module1.AtomCount - 1; j <= loopTo1; j++)
                {
                    rij = Sqrt(Pow(Module1.X[i] - Module1.X[j], 2d) + Pow(Module1.Y[i] - Module1.Y[j], 2d) + Pow(Module1.Z[i] - Module1.Z[j], 2d));
                    PotE0 += 4d * (Pow(1d / rij, 12d) - Pow(1d / rij, 6d));
                }
            }
            TextBoxEnergy.Text = PotE0.ToString();
            TextBoxEnergy.Text = (Abs(PotE0) * 2d).ToString();
            Module1.dtau = Conversion.Val(TextBoxdtau.Text); // c
            Module1.tau = 0d;
            Module1.tau1 = 0d;
            Tclaver = 0d;
            Tcaver = 0d;
            Tpaver = 0d;

        }

        public void InitGraph()
        {

            AxisE.Axis_Type = 2;
            AxisE.x_Base = Conversion.Val(TextBoxBaseTau.Text);
            AxisE.y_Base = Abs(PotE0) / Module1.AtomCount * 5d; // 1.2 'Val(TextBoxEnergy.Text) ' * 2
            AxisE.x_Name = "время";
            AxisE.y_Name = "энергия";
            AxisE.Pix_type = 1;
            AxisE.Pix_Size = 0.005d;
            AxisE.PicBackColor = Color.Bisque;
            AxisE.AxisDraw();

            AxisKinEPotE.Axis_Type = 3;
            AxisKinEPotE.GridOn = true;
            AxisKinEPotE.GridColor = Color.LightGray;
            AxisKinEPotE.GridType = 1;
            AxisKinEPotE.x_Base = Conversion.Val(TextBoxBaseTau.Text);
            AxisKinEPotE.y_Base = 1d;
            AxisKinEPotE.x_Name = "время";
            AxisKinEPotE.y_Name = "Ekin/Epot";
            AxisKinEPotE.Pix_type = 1;
            AxisKinEPotE.Pix_Size = 0.005d;
            AxisKinEPotE.PicBackColor = Color.Bisque;
            AxisKinEPotE.AxisDraw();

            AxisGir.Axis_Type = 3;
            AxisGir.x_Base = Conversion.Val(TextBoxBaseTau.Text);
            AxisGir.y_Base = 3d * Module1.MinDist * Sqrt(Module1.AtomCount);
            AxisGir.x_Name = "время";
            AxisGir.y_Name = "длина связности";
            AxisGir.Pix_type = 1;
            AxisGir.Pix_Size = 0.008d;
            AxisGir.PicBackColor = Color.DarkBlue;
            AxisGir.AxisDraw();

            AxisT.Axis_Type = 3;
            AxisT.x_Base = Conversion.Val(TextBoxBaseTau.Text);
            AxisT.y_Base = 100d;
            AxisT.x_Name = "время";
            AxisT.y_Name = "температура, K";
            AxisT.Pix_type = 1;
            AxisT.Pix_Size = 0.008d;
            AxisT.PicBackColor = Color.DarkBlue;
            AxisT.AxisDraw();

        }

        private void ListBoxConfiguration_MouseClick(object sender, MouseEventArgs e)
        {

            ButtonStart.Enabled = true;
            FirstStart = true;
            Timer1.Enabled = false;
            Module1.ConfigurationIndex = (byte)ListBoxConfiguration.SelectedIndex;
            InitConfiguration();
            InitGraph();

        }
        public object GetAtomInLine()
        {
            object GetAtomInLineRet = default;
            Module1.AtomCount = (int)Round(Conversion.Val(TextBoxAtomCount.Text));
            GetAtomInLineRet = Sqrt(Module1.AtomCount);
            return GetAtomInLineRet;
        }
        public void DensestPacking()
        {
            double ShiftX;
            double ShiftY;
            double ShiftX1;
            int AtomInLine;
            int IntCountX = (int)Round(xBase / Module1.MinDist - xBase % Module1.MinDist) * 2;

            if (Module1.AtomCount > 1)
            {
                AtomInLine = (int)Round(Conversion.Val(TextBoxAtomCountLine.Text)); // GetAtomInLine()
                ShiftX = xBase - AtomInLine * Module1.MinDist / 2d;
                ShiftX1 = xBase - AtomInLine * Module1.MinDist / 2d - Module1.MinDist / 2d;
                ShiftY = xBase - AtomInLine * Module1.MinDist * Sqrt(3d) / 2d / 2d;
            }
            else
            {
                return;
            }

            int AtomDefIndex = 0;
            for (int i = 1, loopTo = AtomInLine; i <= loopTo; i++)
            {
                for (int j = 1, loopTo1 = AtomInLine; j <= loopTo1; j++)
                {
                    if (j % 2 == 0)
                        Module1.X[AtomDefIndex] = -xBase + Module1.MinDist * i + ShiftX1;
                    else
                        Module1.X[AtomDefIndex] = -xBase + Module1.MinDist * i + ShiftX;
                    Module1.Y[AtomDefIndex] = -xBase + Module1.MinDist * (Sqrt(3d) / 2d) * j + ShiftY;
                    AtomDefIndex += 1;
                }
            }

            Module1.AtomCount = AtomDefIndex;
            Axis1.AtomCount = Module1.AtomCount;

            for (int i = 0, loopTo2 = Module1.AtomCount - 1; i <= loopTo2; i++)
            {
                Module1.m[i] = mel;
                Module1.Vx[i] = 0d;
                Module1.Vy[i] = 0d;
                Module1.Vz[i] = 0d;
            }

        }
        public void RectPacking()
        {
            double ShiftX;
            double ShiftY;
            int IntCountX = (int)Round(xBase / Module1.MinDist - xBase % Module1.MinDist) * 2;
            IntCountX = (int)Round(Conversion.Val(TextBoxAtomCountLine.Text)); // GetAtomInLine()
            int AtomDefIndex = 0;
            ShiftX = xBase - IntCountX * Module1.MinDist / 2d;
            ShiftY = ShiftX;
            for (int L = 0; L <= 0; L++)
            {
                for (int i = 1, loopTo = IntCountX; i <= loopTo; i++)
                {
                    for (int j = 1, loopTo1 = IntCountX; j <= loopTo1; j++)
                    {
                        Module1.X[AtomDefIndex] = -xBase + ShiftX + Module1.MinDist * i;
                        Module1.Y[AtomDefIndex] = -xBase + ShiftY + Module1.MinDist * j;
                        Module1.Z[AtomDefIndex] = L * Module1.MinDist;
                        AtomDefIndex += 1;

                    }
                }
            }
            if (Module1.DimIndex == 3)
            {
                int CountSloj = AtomDefIndex;
                for (int L = 1, loopTo2 = Module1.Rows - 1; L <= loopTo2; L++)
                {
                    for (int i = 1, loopTo3 = IntCountX; i <= loopTo3; i++)
                    {
                        for (int j = 1, loopTo4 = IntCountX; j <= loopTo4; j++)
                        {
                            Module1.X[AtomDefIndex] = Module1.X[AtomDefIndex - CountSloj];
                            Module1.Y[AtomDefIndex] = Module1.Y[AtomDefIndex - CountSloj];
                            Module1.Z[AtomDefIndex] = L * Module1.MinDist;
                            Module1.ConfigP_C[AtomDefIndex] = Module1.ConfigP_C[AtomDefIndex - CountSloj];
                            AtomDefIndex += 1;

                        }
                    }
                }
            }
            Module1.AtomCount = AtomDefIndex;
            Axis1.AtomCount = Module1.AtomCount;


            for (int i = 0, loopTo5 = Module1.AtomCount - 1; i <= loopTo5; i++)
            {
                Module1.m[i] = mel;
                Module1.Vx[i] = 0d;
                Module1.Vy[i] = 0d;
                Module1.Vz[i] = 0d;
            }

        }
        private void GCK()
        {

            // центральный атом
            Module1.X[0] = 0d;
            Module1.Y[0] = 0d;
            Module1.Z[0] = 0d;

            centerIndex = 0;
            AtomDefIndex = 0;
            Module1.AtomCount = 7;
            for (int i = 1; i <= 6; i++)
            {
                AtomDefIndex += 1;
                var tmp = Module1.X;
                float argX1 = (float)tmp[AtomDefIndex];
                var tmp1 = Module1.Y;
                float argY1 = (float)tmp1[AtomDefIndex];
                var tmp2 = Module1.Z;
                float argZ1 = (float)tmp2[AtomDefIndex];
                Rotate(3, (float)((i - 1) * PI / 3d), (float)Module1.MinDist, 0f, 0f, ref argX1, ref argY1, ref argZ1);
                tmp[AtomDefIndex] = argX1;
                tmp1[AtomDefIndex] = argY1;
                tmp2[AtomDefIndex] = argZ1;
                AtomDefIndex += 1;
                var tmp3 = Module1.X;
                float argX11 = (float)tmp3[AtomDefIndex];
                var tmp4 = Module1.Y;
                float argY11 = (float)tmp4[AtomDefIndex];
                var tmp5 = Module1.Z;
                float argZ11 = (float)tmp5[AtomDefIndex];
                Rotate(3, (float)((i - 1) * 2 * PI / 3d), (float)(Module1.MinDist / 2d), (float)(Module1.MinDist * Sqrt(2d / 3d)), (float)(Module1.MinDist / Sqrt(12d)), ref argX11, ref argY11, ref argZ11);
                tmp3[AtomDefIndex] = argX11;
                tmp4[AtomDefIndex] = argY11;
                tmp5[AtomDefIndex] = argZ11;

            }

            if (Module1.DimIndex == 3)
            {
                for (int i = 1; i <= 3; i++)
                {
                    AtomDefIndex += 1;
                    var tmp6 = Module1.X;
                    float argX12 = (float)tmp6[AtomDefIndex];
                    var tmp7 = Module1.Y;
                    float argY12 = (float)tmp7[AtomDefIndex];
                    var tmp8 = Module1.Z;
                    float argZ12 = (float)tmp8[AtomDefIndex];
                    Rotate(3, (float)((i - 1) * 2 * PI / 3d), (float)(Module1.MinDist / 2d), (float)(Module1.MinDist * Sqrt(2d / 3d)), (float)(Module1.MinDist / Sqrt(12d)), ref argX12, ref argY12, ref argZ12);
                    tmp6[AtomDefIndex] = argX12;
                    tmp7[AtomDefIndex] = argY12;
                    tmp8[AtomDefIndex] = argZ12;
                    AtomDefIndex += 1;
                    var tmp9 = Module1.X;
                    float argX13 = (float)tmp9[AtomDefIndex];
                    var tmp10 = Module1.Y;
                    float argY13 = (float)tmp10[AtomDefIndex];
                    var tmp11 = Module1.Z;
                    float argZ13 = (float)tmp11[AtomDefIndex];
                    Rotate(3, (float)((i - 1) * 2 * PI / 3d), (float)(Module1.MinDist / 2d), (float)(-Module1.MinDist * Sqrt(2d / 3d)), (float)(Module1.MinDist / Sqrt(12d)), ref argX13, ref argY13, ref argZ13);
                    tmp9[AtomDefIndex] = argX13;
                    tmp10[AtomDefIndex] = argY13;
                    tmp11[AtomDefIndex] = argZ13;
                }

                Module1.AtomCount = 13;
            }

            Axis1.AtomCount = Module1.AtomCount;

            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                Module1.m[i] = mel;
                Module1.Vx[i] = 0d;
                Module1.Vy[i] = 0d;
                Module1.Vz[i] = 0d;
            }
            SortZ();
        }
        public void SortZ()
        {
            float XX, YY, ZZ, Conf;
            bool Priz = false;

            while (Priz == false)
            {
                Priz = true;
                for (int I = 0, loopTo = Module1.AtomCount - 2; I <= loopTo; I++)
                {
                    if (Module1.Z[I] > Module1.Z[I + 1])
                    {
                        Priz = false;
                        XX = (float)Module1.X[I];
                        YY = (float)Module1.Y[I];
                        ZZ = (float)Module1.Z[I];
                        Conf = Module1.ConfigP_C[I];

                        Module1.X[I] = Module1.X[I + 1];
                        Module1.Y[I] = Module1.Y[I + 1];
                        Module1.Z[I] = Module1.Z[I + 1];
                        Module1.ConfigP_C[I] = Module1.ConfigP_C[I + 1];

                        Module1.X[I + 1] = XX;
                        Module1.Y[I + 1] = YY;
                        Module1.Z[I + 1] = ZZ;
                        Module1.ConfigP_C[I + 1] = (byte)Round(Conf);
                    }
                }

            }


        }
        public void Rotate(byte WhatAxis, float Angle, float X, float Y, float Z, ref float X1, ref float Y1, ref float Z1)
        {
            switch (WhatAxis)
            {
                case 1: // X
                    {
                        Y1 = (float)(Y * Cos(Angle) - Z * Sin(Angle));
                        Z1 = (float)(Y * Sin(Angle) + Z * Cos(Angle));
                        X1 = X;
                        break;
                    }
                case 2: // Y
                    {
                        X1 = (float)(Z * Sin(Angle) + X * Cos(Angle));
                        Z1 = (float)(Z * Cos(Angle) - X * Sin(Angle));
                        Y1 = Y;
                        break;
                    }
                case 3: // Z
                    {
                        X1 = (float)(X * Cos(Angle) - Y * Sin(Angle));
                        Y1 = (float)(X * Sin(Angle) + Y * Cos(Angle));
                        Z1 = Z;
                        break;
                    }

            }

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {

            Module1.tau += Module1.dtau;
            Module1.tau1 += Module1.dtau;
            TextBoxtau.Text = Module1.tau.ToString();

            Xm = 0d;
            Ym = 0d;
            Zm = 0d;

            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                Xm += Module1.X[i];
                Ym += Module1.Y[i];
                Zm += Module1.Z[i];
            }
            Xm += Xm / Module1.AtomCount;
            Ym += Ym / Module1.AtomCount;
            Zm += Zm / Module1.AtomCount;

            // силы

            for (int i = 0, loopTo1 = Module1.AtomCount - 1; i <= loopTo1; i++)
            {
                Module1.Fx[i] = 0d;
                Module1.Fy[i] = 0d;
                Module1.Fz[i] = 0d;
                for (int j = 0, loopTo2 = Module1.AtomCount - 1; j <= loopTo2; j++)
                {
                    if (i != j)
                    {
                        rij = Sqrt(Pow(Module1.X[i] - Module1.X[j], 2d) + Pow(Module1.Y[i] - Module1.Y[j], 2d) + Pow(Module1.Z[i] - Module1.Z[j], 2d));
                        DUDR = 24d * (Pow(1d / rij, 7d) - 2d * Pow(1d / rij, 13d)) / rij;
                        Module1.Fx[i] += DUDR * (Module1.X[j] - Module1.X[i]) / rij;
                        Module1.Fy[i] += DUDR * (Module1.Y[j] - Module1.Y[i]) / rij;
                        Module1.Fz[i] += DUDR * (Module1.Z[j] - Module1.Z[i]) / rij;

                    }

                }

            }
            // ускорения, скорости, координаты
            for (int i = 0, loopTo3 = Module1.AtomCount - 1; i <= loopTo3; i++)
            {

                Module1.ax = Module1.Fx[i] / Module1.m[i];
                Module1.ay = Module1.Fy[i] / Module1.m[i];
                Module1.az = Module1.Fz[i] / Module1.m[i];

                Module1.Vxk[i] = Module1.Vx[i] + Module1.ax * Module1.dtau;
                Module1.Vyk[i] = Module1.Vy[i] + Module1.ay * Module1.dtau;
                Module1.Vzk[i] = Module1.Vz[i] + Module1.az * Module1.dtau;

                Module1.Xk[i] = Module1.X[i] + Module1.dtau * (Module1.Vx[i] + Module1.Vxk[i]) / 2d + Module1.ax * Pow(Module1.dtau, 2d) / 2d;
                Module1.Yk[i] = Module1.Y[i] + Module1.dtau * (Module1.Vy[i] + Module1.Vyk[i]) / 2d + Module1.ay * Pow(Module1.dtau, 2d) / 2d;
                Module1.Zk[i] = Module1.Z[i] + Module1.dtau * (Module1.Vz[i] + Module1.Vzk[i]) / 2d + Module1.az * Pow(Module1.dtau, 2d) / 2d;

            }

            // ЭНЕРГИЯ

            KinE = 0d;
            KinEc = 0d;
            KinEp = 0d;
            PotE = 0d;
            Rgir = 0d;

            for (int i = 0, loopTo4 = Module1.AtomCount - 2; i <= loopTo4; i++)
            {
                for (int j = i + 1, loopTo5 = Module1.AtomCount - 1; j <= loopTo5; j++)
                {
                    rij = Sqrt(Pow(Module1.X[i] - Module1.X[j], 2d) + Pow(Module1.Y[i] - Module1.Y[j], 2d) + Pow(Module1.Z[i] - Module1.Z[j], 2d));
                    PotE += 4d * (Pow(1d / rij, 12d) - Pow(1d / rij, 6d));
                    Rgir += rij;

                }

            }

            Module1.AtomCountC = 0;
            Module1.AtomCountP = 0;
            KSI = 0d;
            for (int i = 0, loopTo6 = Module1.AtomCount - 1; i <= loopTo6; i++)
            {
                KinE += Module1.m[i] * (Pow((Module1.Vx[i] + Module1.Vxk[i]) / 2d, 2d) + Pow((Module1.Vy[i] + Module1.Vyk[i]) / 2d, 2d) + Pow((Module1.Vz[i] + Module1.Vzk[i]) / 2d, 2d)) / 2d;
                if (Module1.ConfigP_C[i] == 1)
                {
                    Module1.AtomCountC += 1;
                    KinEc += Module1.m[i] * (Pow((Module1.Vx[i] + Module1.Vxk[i]) / 2d, 2d) + Pow((Module1.Vy[i] + Module1.Vyk[i]) / 2d, 2d) + Pow((Module1.Vz[i] + Module1.Vzk[i]) / 2d, 2d)) / 2d;
                }
                else if (Module1.ConfigP_C[i] == 2)
                {
                    Module1.AtomCountP += 1;
                    KinEp += Module1.m[i] * (Pow((Module1.Vx[i] + Module1.Vxk[i]) / 2d, 2d) + Pow((Module1.Vy[i] + Module1.Vyk[i]) / 2d, 2d) + Pow((Module1.Vz[i] + Module1.Vzk[i]) / 2d, 2d)) / 2d;
                }
                KSI += Sqrt(Pow(Module1.X[i] - Xm, 2d) + Pow(Module1.Y[i] - Ym, 2d) + Pow(Module1.Z[i] - Zm, 2d)); // связность
            }
            Tcl = KinE / Module1.AtomCount / 3d * Module1.Epsilon[Module1.PotencialIndex];

            if (Module1.AtomCountC > 0)
            {
                Tc = KinEc / Module1.AtomCountC / 3d * Module1.Epsilon[Module1.PotencialIndex];
                Tcaver += Tc * Module1.dtau;
            }
            if (Module1.AtomCountP > 0)
            {
                Tp = KinEp / Module1.AtomCountP / 3d * Module1.Epsilon[Module1.PotencialIndex];
                Tpaver += Tp * Module1.dtau;

            }

            Tclaver += Tcl * Module1.dtau;
            TextBoxTcl.Text = Tcl.ToString();
            FullE = PotE + KinE;


            for (int i = 0, loopTo7 = Module1.AtomCount - 1; i <= loopTo7; i++)
            {

                Module1.Vx[i] = Module1.Vxk[i];
                Module1.Vy[i] = Module1.Vyk[i];
                Module1.Vz[i] = Module1.Vzk[i];

                Module1.X[i] = Module1.Xk[i];
                Module1.Y[i] = Module1.Yk[i];
                Module1.Z[i] = Module1.Zk[i];

            }

            // Timer1.Enabled = False
            // SortZ()
            ShowAtoms();
            // Timer1.Enabled = True

            AxisE.PixDraw(Module1.tau, (PotE - PotE0) / Module1.AtomCount, Color.Blue, 1);
            AxisE.PixDraw(Module1.tau, KinE / Module1.AtomCount, Color.Red, 1);
            AxisE.PixDraw(Module1.tau, (FullE - PotE0) / Module1.AtomCount, Color.Black, 1);
            AxisE.StatToPic();

            if (Abs(PotE) > 0d)
            {

                AxisKinEPotE.PixDraw(Module1.tau, Abs(KinE / PotE), Color.Blue, 1);
                AxisKinEPotE.StatToPic();
            }

            AxisGir.PixDraw(Module1.tau, 2d * Rgir / (Module1.AtomCount * (Module1.AtomCount - 1)), Color.Black, 1);
            AxisGir.PixDraw(Module1.tau, KSI / Module1.AtomCount, Color.Blue, 1);
            AxisGir.PixDraw(Module1.tau, 1.122d, Color.Red, 1);
            AxisGir.StatToPic();

            AxisT.PixDraw(Module1.tau, Tcl, Color.LightCoral, 1);
            AxisT.PixDraw(Module1.tau, Tc, Color.LightYellow, 1);
            AxisT.PixDraw(Module1.tau, Tp, Color.LightGreen, 1);
            AxisT.PixDraw(Module1.tau, Tclaver / Module1.tau1, Color.Red, 1);
            AxisT.PixDraw(Module1.tau, Tcaver / Module1.tau1, Color.Yellow, 1);
            AxisT.PixDraw(Module1.tau, Tpaver / Module1.tau1, Color.Green, 1);
            AxisT.StatToPic();


            TextBoxE.Text = (2d * Rgir / (Module1.AtomCount * (Module1.AtomCount - 1))).ToString();

            if (Module1.tau > AxisE.x_Base)
            {
                Module1.tau = 0d;

                AxisE.AxisDraw();
                AxisGir.AxisDraw();
                AxisT.AxisDraw();
                AxisKinEPotE.AxisDraw();
            }
        }


        private void ButtonStart_Click(object sender, EventArgs e)
        {

            TextBoxAtomCount.Text = Axis1.AtomCount.ToString();
            Module1.AtomCount = Axis1.AtomCount;
            if (Axis1.AtomCount == 0)
            {
                Interaction.MsgBox("Нет атомов");
                return;

            }
            if (FirstStart)
            {
                Module1.AtomCount = Axis1.AtomCount;
                for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
                {
                    // X(i) = Axis1.ClickArrayPhysX(i)
                    // Y(i) = Axis1.ClickArrayPhysY(i)

                    Module1.m[i] = mel;
                    Module1.Vx[i] = 0d;
                    Module1.Vy[i] = 0d;
                    Module1.Vz[i] = 0d;
                }
                // Axis1.AxisDraw()
                if (Module1.ConfigurationIndex == 3)
                    InitGraph();
                // ShowAtoms()
                FirstStart = false;
            }


            Timer1.Enabled = true;

        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }



        private void MolDinamics_Resize(object sender, EventArgs e)
        {

            GroupBox1.Top = 0;
            GroupBox1.Left = DisplayRectangle.Width - GroupBox1.Width;

            Axis1.Left = 0;
            Axis1.Top = 0;
            Axis1.Height = DisplayRectangle.Height;
            Axis1.Width = Axis1.Height;

            AxisE.Left = Axis1.Width;
            AxisE.Width = DisplayRectangle.Width - Axis1.Width - GroupBox1.Width;
            AxisE.Top = 0;
            AxisE.Height = (int)Round(Axis1.Height / 6d);

            AxisKinEPotE.Height = (int)Round(Axis1.Height / 6d);
            AxisKinEPotE.Left = Axis1.Width;
            AxisKinEPotE.Width = DisplayRectangle.Width - Axis1.Width - GroupBox1.Width;
            AxisKinEPotE.Top = AxisE.Height + AxisE.Top;
            AxisKinEPotE.Height = (int)Round(Axis1.Height / 6d);


            AxisGir.Left = Axis1.Width;
            AxisGir.Width = DisplayRectangle.Width - Axis1.Width - GroupBox1.Width;
            AxisGir.Top = AxisKinEPotE.Height + AxisKinEPotE.Top;
            AxisGir.Height = (int)Round(Axis1.Height / 6d);

            AxisT.Left = Axis1.Width;
            AxisT.Width = DisplayRectangle.Width - Axis1.Width - GroupBox1.Width;
            AxisT.Top = AxisGir.Height + AxisGir.Top;
            AxisT.Height = (int)Round(Axis1.Height / 3d);

            InitConfiguration();
        }

        private void CheckBoxGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxGrid.Checked)
                Axis1.GridOn = true;
            else
                Axis1.GridOn = false;
            InitConfiguration();
            ShowAtoms();
        }

        public void ShowAtoms()        // AxisDraw()
        {
            if (Module1.ViewAtom == false | Module1.AtomCount == 0)
                return;
            Color PixPenColor;
            Axis1.StatToDin();
            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                if (Module1.ConfigP_C[i] == 1)
                {
                    PixPenColor = Color.Orange;
                    Axis1.PixBrush.Color = Color.DarkOrange;
                }

                else if (Module1.ConfigP_C[i] == 2)
                {
                    PixPenColor = Color.Green;
                    Axis1.PixBrush.Color = Color.DarkGreen;
                }

                else
                {
                    PixPenColor = Color.Red;
                    Axis1.PixBrush.Color = Color.DarkRed;
                }
                if (Axis1.Axis_Type == 5)
                    Axis1.PixDraw(Module1.X[i], Module1.Y[i], Module1.Z[i], PixPenColor, 2);
                else
                    Axis1.PixDraw(Module1.X[i], Module1.Y[i], PixPenColor, 2);
                if (Module1.BreakOn)
                    break;
            }
            Axis1.DinToPic();
        }
        public void ClearMarkColor()
        {
            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
                Module1.ConfigP_C[i] = 0;
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            ClearMarkColor();
            if (CheckBoxAtom.Checked)
            {
                Module1.AtomCount = 0;
                TextBoxAtomCount.Text = "0";
                Axis1.AtomCount = 0;
            }

            InitConfiguration();
        }

        private void ButtonLess_Click(object sender, EventArgs e)
        {
            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                Module1.Vx[i] = Sqrt(0.9d) * Module1.Vx[i];
                Module1.Vy[i] = Sqrt(0.9d) * Module1.Vy[i];
            }
        }

        private void ButtonMore_Click(object sender, EventArgs e)
        {
            for (int i = 0, loopTo = Module1.AtomCount - 1; i <= loopTo; i++)
            {
                Module1.Vx[i] = Sqrt(1.1d) * Module1.Vx[i];
                Module1.Vy[i] = Sqrt(1.1d) * Module1.Vy[i];
            }

        }

        private void RadioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonNormal.Checked)
                Module1.SelectMode = 0;
        }

        private void RadioButtonCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonCenter.Checked)
                Module1.SelectMode = 1;
        }

        private void RadioButtonPerif_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonPerif.Checked)
                Module1.SelectMode = 2;
        }

        private void CheckBoxAtom_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAtom.Checked)
                Module1.ViewAtom = true;
            else
                Module1.ViewAtom = false;
        }

        private void CheckBoxGrid_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckBoxGrid.Checked)
                Axis1.GridOn = true;
            else
                Axis1.GridOn = false;
            if (RadioButtonRect.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Module1.MinDist;
                Axis1.GridType = 1;
            }
            else if (RadioButtonTriangl.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Sqrt(3d) * Module1.MinDist / 2d;
                Axis1.GridType = 2;
            }
            else
            {
                Axis1.GridType = 0;
            }

        }

        private void RadioButtonTriangl_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonRect.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Module1.MinDist;
                Axis1.GridType = 1;
            }
            else if (RadioButtonTriangl.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Sqrt(3d) * Module1.MinDist;
                Axis1.GridType = 2;
            }
            else
            {
                Axis1.GridType = 0;
            }
        }

        private void RadioButtonRect_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonRect.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Module1.MinDist;
                Axis1.GridType = 1;
            }
            else if (RadioButtonTriangl.Checked)
            {
                Axis1.GridStepX = Module1.MinDist;
                Axis1.GridStepY = Sqrt(3d) * Module1.MinDist / 2d;
                Axis1.GridType = 2;
            }
            else
            {
                Axis1.GridType = 0;
            }
        }


        private void ListBoxConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBoxConfiguration_TabStopChanged(object sender, EventArgs e)
        {

        }
    }
}