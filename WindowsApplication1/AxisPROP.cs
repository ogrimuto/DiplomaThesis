using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Math;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsApplication1
{
    public partial class Axis
    {
        public Axis()
        {
            InitializeComponent();
            rect.Width = Width;
            rect.Height = Height;
            PixSize = 2d;
        }
        #region Определения
        public enum AxisType : byte
        {
            full = 1,
            half_right = 2,
            quarter = 3,
            half_top = 4,
            D3 = 5

        }
        public enum PixType : byte
        {
            point = 1,
            cross = 2,
            circle = 3,
            rect = 4,
            Grad = 5,
            poligon = 6
        }
        private double Kx = 1d;
        private double Ky = 1d;
        private double Kz = 1d;
        private double xMax, yMax, zMax;
        private int Xe;
        private int Ye;
        private byte cAxisType = (byte)AxisType.full;
        private byte cPixType = (byte)PixType.point;
        private double xBase = 1d;
        private double yBase = 1d;
        private double zBase = 1d;
        private double xBase0, yBase0, zBase0;
        private string xName = "X";
        private string yName = "Y";
        private string zName = "Z";
        private int xShift;
        private int yShift;
        private int cPixSize = 1;
        private double PixSize = 1d;
        public Color PicBackColor = Color.White;
        // Private DrawMode As Integer = 0
        private Rectangle rect = new Rectangle(0, 0, 1, 1);
        public int Ex;
        public int Ey;
        private double Alpha; // угол между осями X и Y в диметрии
        public double X_Phys, Y_Phys, Z_Phys;
        public byte ClickFactor;
        public PointF[] arrpoint;

        private bool FirstPass = true;
        private Graphics Graph;
        // оформление координат
        private Pen axisPen = new Pen(Color.Gray);
        private Font axisFont = new Font("Courier", 12f, FontStyle.Regular);
        private SolidBrush axisBrush = new SolidBrush(Color.Black);
        // оформление маркеров
        private Pen PixPen = new Pen(Color.Black);
        public SolidBrush PixBrush = new SolidBrush(Color.Black);
        public LinearGradientBrush PixBrushGrad;
        private RectangleF RectGrad;
        // буфер для сохранения текущего отображения системы координат  
        public Bitmap buff_stat;
        public Bitmap buff_din;
        // объект для рисования 
        private Graphics g_pic;
        private Graphics g_stat;
        private Graphics g_din;
        private const int AtomCountMax = 1000000;
        public int ClickCount;
        // Public ClickArrayScreenX(AtomCountMax), ClickArrayScreenY(AtomCountMax), ClickArrayScreenZ(AtomCountMax) As Double
        // Public ClickArrayPhysX(AtomCountMax), ClickArrayPhysY(AtomCountMax), ClickArrayPhysZ(AtomCountMax) As Double
        public int AtomCount, AtomCountP, AtomCountC;
        public bool GridOn;
        public byte GridType;
        public double GridStepX, GridStepY; // физические
        public Color LineColor;
        public Color GridColor;
        private Pen LinePen = new Pen(Color.Black);
        private byte ShiftControl;
        #endregion
        #region Свойства
        // оси координат
        public byte Axis_Type
        {
            get
            {
                return cAxisType;
            }
            set
            {
                cAxisType = value;
            }
        }
        public double x_Base
        {
            get
            {
                return xBase;
            }
            set
            {
                if (value <= 0d)
                    xBase = 1d;
                else
                    xBase = value;
            }
        }
        public double y_Base
        {
            get
            {
                return yBase;
            }
            set
            {
                if (value <= 0d)
                    yBase = 1d;
                else
                    yBase = value;
            }
        }
        public double z_Base
        {
            get
            {
                return yBase;
            }
            set
            {
                if (value <= 0d)
                    zBase = 1d;
                else
                    zBase = value;
            }
        }
        public double x_Base0
        {
            get
            {
                return xBase0;
            }
            set
            {
                if (value <= 0d)
                    xBase0 = 0d;
                else
                    xBase0 = value;
            }
        }
        public double y_Base0
        {
            get
            {
                return yBase0;
            }
            set
            {
                if (value < 0d)
                    yBase0 = 0d;
                else
                    yBase0 = value;
            }
        }
        public string x_Name
        {
            get
            {
                return xName;
            }
            set
            {
                xName = value;
            }
        }
        public string y_Name
        {
            get
            {
                return yName;
            }
            set
            {
                yName = value;
            }
        }
        public string z_Name
        {
            get
            {
                return zName;
            }
            set
            {
                zName = value;
            }
        }

        public Color axis_color
        {
            get
            {
                return axisPen.Color;
            }
            set
            {
                axisPen.Color = value;
            }
        }

        public Color axis_bkcolor
        {
            get
            {
                return PicBackColor;
            }
            set
            {
                PicBackColor = value;
            }
        }
        // маркер
        public byte Pix_type
        {
            get
            {
                return cPixType;
            }
            set
            {
                cPixType = value;
            }
        }
        public int E_x
        {
            get
            {
                return Ex;
            }
            set
            {
                Ex = value;
            }
        }
        public int E_y
        {
            get
            {
                return Ey;
            }
            set
            {
                Ey = value;
            }
        }
        public Color Pix_color
        {
            get
            {
                return PixPen.Color;
            }
            set
            {
                PixPen.Color = value;
                PixBrush.Color = value;
            }
        }
        // размер маркера в долях от xBase
        public double Pix_Size
        {
            get
            {
                return PixSize;
            }
            set
            {
                PixSize = value;
            }
        }
        #endregion
        #region Методы
        public void AxisDraw()
        {
            string lxName;
            string lyName;
            string lzName;
            rect.Width = (int)Round(xMax);
            rect.Height = (int)Round(yMax);
            if (FirstPass == false)
            {
                FirstPass = false;
                g_stat.Dispose();
                g_din.Dispose();
                g_pic.Dispose();
                buff_stat.Dispose();
                buff_din.Dispose();
            }

            try
            {
                buff_stat = new Bitmap((int)Round(xMax), (int)Round(yMax));
                buff_din = new Bitmap((int)Round(xMax), (int)Round(yMax));
                // Pic.Image = New System.Drawing.Bitmap(CInt(xMax), CInt(yMax))

                g_stat = Graphics.FromImage(buff_stat);
                g_din = Graphics.FromImage(buff_din);
                StatToPic();
                g_pic = Graphics.FromImage(Pic.Image);
                // названия осей

                lxName = Conversion.Str(Round(xBase, 2)) + ", " + xName;
                lyName = Conversion.Str(Round(yBase, 2)) + ", " + yName;
                lzName = Conversion.Str(Round(zBase, 2)) + ", " + zName;

                switch (cAxisType)
                {
                    case (byte)AxisType.full:
                        {

                            xShift = (int)Round(xMax / 2d);
                            yShift = (int)Round(yMax / 2d);
                            g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_pic.TranslateTransform(xShift, yShift, MatrixOrder.Append);

                            Kx = xMax / 2d / (xBase - xBase0);
                            Ky = yMax / 2d / (yBase - yBase0);

                            if (GridOn)
                                drawgrid();

                            LinePen.Color = axis_color;
                            Line(-xBase, 0d, xBase, 0d, 1);
                            Line(0d, yBase, 0d, -yBase, 1);
                            g_stat.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 10) - xShift, (int)Round(yMax / 2d - 20d) - yShift);
                            g_stat.DrawString(lyName, axisFont, axisBrush, (int)Round(xMax / 2d) - xShift, 1 - xShift);

                            g_stat.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, (int)Round(xMax / 2d) - xShift, (int)Round(yMax / 2d - 20d - yShift));
                            break;
                        }


                    case (byte)AxisType.half_right:
                        {

                            g_stat.DrawLine(axisPen, 0, (int)Round(yMax / 2d), (int)Round(xMax), (int)Round(yMax / 2d));
                            g_stat.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 10), (int)Round(yMax / 2d - 20d));
                            g_stat.DrawString(lyName, axisFont, axisBrush, 1f, 1f);

                            g_stat.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, 0f, (int)Round(yMax / 2d - 20d));


                            g_pic.DrawLine(axisPen, 0, (int)Round(yMax / 2d), (int)Round(xMax), (int)Round(yMax / 2d));
                            g_pic.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 10), (int)Round(yMax / 2d - 20d));
                            g_pic.DrawString(lyName, axisFont, axisBrush, 1f, 1f);

                            g_pic.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, 0f, (int)Round(yMax / 2d - 20d));




                            xShift = 0;
                            yShift = (int)Round(yMax / 2d);
                            g_stat.TranslateTransform(0f, (float)(yMax / 2d), MatrixOrder.Append);
                            g_din.TranslateTransform(0f, (float)(yMax / 2d), MatrixOrder.Append);
                            g_pic.TranslateTransform(0f, (float)(yMax / 2d), MatrixOrder.Append);


                            Kx = xMax / (xBase - xBase0);
                            Ky = yMax / 2d / (yBase - yBase0);


                            if (GridOn)
                                drawgrid();

                            LineColor = Color.Black;
                            Line(-xBase, 0d, xBase, 0d, 1);
                            g_stat.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 10), (int)Round(yMax / 2d - 20d - yShift));
                            g_stat.DrawString(lyName, axisFont, axisBrush, 1f, 1 - yShift);

                            g_stat.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, 0f, (int)Round(yMax / 2d - 20d - yShift));
                            break;
                        }


                    case (byte)AxisType.half_top: // 4
                        {
                            g_stat.DrawLine(axisPen, (int)Round(xMax / 2d), 0, (int)Round(xMax / 2d), (int)Round(yMax));
                            g_stat.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 7), (int)Round(yMax - 15d));
                            g_stat.DrawString(lyName, axisFont, axisBrush, (int)Round(xMax / 2d), 1f);

                            g_stat.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, (int)Round(xMax / 2d), (int)Round(yMax - 15d));

                            xShift = (int)Round(xMax / 2d);
                            yShift = (int)Round(yMax);
                            g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            Kx = xMax / 2d / (xBase - xBase0);
                            Ky = yMax / (yBase - yBase0);
                            break;
                        }



                    case (byte)AxisType.quarter: // 3
                        {

                            xShift = 0;
                            yShift = (int)Round(yMax);
                            g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append);

                            Kx = xMax / (xBase - xBase0);
                            Ky = yMax / (yBase - yBase0);

                            if (GridOn)
                                drawgrid();

                            g_stat.DrawString(lxName, axisFont, axisBrush, (int)Round(xMax - lxName.Length * 7) - xShift, (int)Round(yMax - 15d) - yShift);
                            g_stat.DrawString(lyName, axisFont, axisBrush, 1f, 1 - yShift);
                            g_stat.DrawString(yBase0.ToString() + "/" + xBase0.ToString(), axisFont, axisBrush, 0f, (int)Round(yMax - 15d) - yShift);
                            break;
                        }


                    case (byte)AxisType.D3:
                        {
                            // построение осей
                            double y1 = xMax / 2d * (1d / Sqrt(3d) + 1d);
                            g_stat.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), 0f, (float)y1);
                            g_stat.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), (float)xMax, (float)y1);
                            g_stat.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), (float)(xMax / 2d), 0f);

                            g_stat.DrawString(lxName, axisFont, axisBrush, (float)(xMax - 100d), (float)y1);
                            g_stat.DrawString(lyName, axisFont, axisBrush, (float)(xMax / 2d + 20d), 10f);
                            g_stat.DrawString(lzName, axisFont, axisBrush, 20f, (float)y1);


                            g_pic.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), 0f, (float)y1);
                            g_pic.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), (float)xMax, (float)y1);
                            g_pic.DrawLine(axisPen, (float)(xMax / 2d), (float)(yMax / 2d), (float)(xMax / 2d), 0f);

                            g_pic.DrawString(lxName, axisFont, axisBrush, (float)(xMax - 100d), (float)y1);
                            g_pic.DrawString(lyName, axisFont, axisBrush, (float)(xMax / 2d + 20d), 10f);
                            g_pic.DrawString(lzName, axisFont, axisBrush, 20f, (float)y1);


                            xShift = (int)Round(xMax / 2d);
                            yShift = (int)Round(yMax / 2d);
                            g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append);
                            g_pic.TranslateTransform(xShift, yShift, MatrixOrder.Append);

                            // StatToPic()
                            Kx = xMax / 2d / xBase;
                            Ky = yMax / 2d / yBase;
                            zMax = xMax;
                            Kz = zMax / 2d / zBase;
                            Alpha = 2d * PI / 3d;
                            break;
                        }

                }


                StatToPic();
            }
            catch
            {
            }
            // ShowAtoms()

        } // отображение 
        public void drawgrid()
        {
            Grid(GridType, 1);
            Grid(GridType, 0);




        }

        // screen coordinates, 2D
        public void PixDraw(double x, double y, Color CColor, byte DrawMode)
        {
            try
            {
                Xe = (int)Round(x * Kx);
                Ye = (int)Round(-y * Ky);
                PixDraw_(CColor, DrawMode);
            }
            catch (Exception ex)
            {
                My.MyProject.Forms.MolDinamics.Timer1.Enabled = false;
                // MsgBox("По-видимому,надо уменьшить временной шаг")
                Module1.BreakOn = true;

            }
        }

        // screen coordinates, 3D
        public void PixDraw(double x, double y, double z, Color CColor, byte DrawMode)
        {
            try
            {
                Xe = (int)Round((x - z) * Kx * Cos(PI / 6d));
                Ye = -(int)Round((y - (z + x) / 2d) * Kx);
                PixDraw_(CColor, DrawMode);
            }
            catch
            {
            }
        }
        // отображение точки(маркера)
        private void PixDraw_(Color PointColor, byte DrawMode)
        {
            int x1, y1, x2, y2;
            try
            {
                PixPen.Color = PointColor;
                PixBrush.Color = PixPen.Color;
                cPixSize = (int)Round(Kx * Pix_Size * xBase);

                if (cPixSize < 1)
                    cPixSize = 1;
                if (DrawMode == 0)
                {
                    Graph = g_pic;
                }
                else if (DrawMode == 1)
                {
                    Graph = g_stat;
                }
                else if (DrawMode == 2)
                {
                    Graph = g_din;
                }
                switch (cPixType)
                {
                    case (byte)PixType.point:
                        {
                            // Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                            // Graph.FillEllipse(PixBrush, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                            RectGrad = new RectangleF(Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            PixBrushGrad = new LinearGradientBrush(RectGrad, Color.White, PixBrush.Color, LinearGradientMode.BackwardDiagonal);
                            PixBrushGrad.SetSigmaBellShape(0.8f, 1f);
                            Graph.FillEllipse(PixBrushGrad, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            Graph.DrawEllipse(PixPen, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }

                    case (byte)PixType.cross:
                        {
                            x1 = Xe;
                            x2 = Xe;
                            y1 = (int)Round(Ye - cPixSize / 2d);
                            y2 = (int)Round(Ye + cPixSize / 2d);
                            Graph.DrawLine(PixPen, x1, y1, x2, y2);
                            x1 = (int)Round(Xe - cPixSize / 2d);
                            x2 = (int)Round(Xe + cPixSize / 2d);
                            y1 = Ye;
                            y2 = Ye;
                            Graph.DrawLine(PixPen, x1, y1, x2, y2);
                            break;
                        }
                    case (byte)PixType.circle:
                        {
                            Graph.DrawEllipse(PixPen, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                    case (byte)PixType.rect:
                        {
                            Graph.FillRectangle(PixBrush, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                    case (byte)PixType.Grad:
                        {
                            RectGrad = new RectangleF(Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            PixBrushGrad = new LinearGradientBrush(RectGrad, Color.White, PixBrush.Color, LinearGradientMode.BackwardDiagonal);
                            PixBrushGrad.SetSigmaBellShape(0.8f, 1f);
                            Graph.FillEllipse(PixBrushGrad, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            Graph.DrawEllipse(PixPen, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                    case (byte)PixType.poligon:
                        {
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }

        }
        // string drawing
        public void StringDraw(string St, double X, double Y, Font StringFont, Color StringColor, byte DrawMode)
        {
            var StringBrush = new SolidBrush(StringColor);
            X = X * Kx;
            Y = -Y * Ky;
            switch (DrawMode)
            {
                case 0:
                    {
                        g_pic.DrawString(St, StringFont, StringBrush, (float)X, (float)Y);
                        break;
                    }
                case 1:
                    {
                        g_stat.DrawString(St, StringFont, StringBrush, (float)X, (float)Y);
                        break;
                    }
                case 2:
                    {
                        g_din.DrawString(St, StringFont, StringBrush, (float)X, (float)Y);
                        break;
                    }
            }
        }
        // line drawing
        public void Line(double x1, double y1, double x2, double y2, byte DrawMode)
        {
            int xe1, ye1, xe2, ye2;

            xe1 = (int)Round(x1 * Kx);
            xe2 = (int)Round(x2 * Kx);
            ye1 = (int)Round(-y1 * Ky);
            ye2 = (int)Round(-y2 * Ky);

            if (DrawMode == 0)
            {
                Graph = g_pic;
            }
            else if (DrawMode == 1)
            {
                Graph = g_stat;
            }
            else if (DrawMode == 2)
            {
                Graph = g_din;
            }
            Graph.DrawLine(LinePen, xe1, ye1, xe2, ye2);
        }


        public void PixDrawScreenUnits(Color CColor, byte DrawMode)
        {
            int x1, y1, x2, y2;
            try
            {
                Xe = (int)Round(Ex - xMax / 2d);
                Ye = (int)Round(Ey - yMax / 2d);
                PixPen.Color = CColor;
                PixBrush.Color = PixPen.Color;
                cPixSize = (int)Round(Kx * PixSize * xBase);

                if (cPixSize < 1)
                    cPixSize = 1;

                if (DrawMode == 0)
                {
                    Graph = g_pic;
                }
                else if (DrawMode == 1)
                {
                    Graph = g_stat;
                }
                else if (DrawMode == 2)
                {
                    Graph = g_din;
                }

                switch (cPixType)
                {
                    case (byte)PixType.point:
                        {
                            Graph.DrawEllipse(PixPen, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            Graph.FillEllipse(PixBrush, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                    case (byte)PixType.cross:
                        {
                            x1 = Xe;
                            x2 = Xe;
                            y1 = (int)Round(Ye - cPixSize / 2d);
                            y2 = (int)Round(Ye + cPixSize / 2d);
                            Graph.DrawLine(PixPen, x1, y1, x2, y2);
                            x1 = (int)Round(Xe - cPixSize / 2d);
                            x2 = (int)Round(Xe + cPixSize / 2d);
                            y1 = Ye;
                            y2 = Ye;
                            Graph.DrawLine(PixPen, x1, y1, x2, y2);
                            break;
                        }
                    case (byte)PixType.circle:
                        {
                            Graph.DrawEllipse(PixPen, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                    case (byte)PixType.rect:
                        {
                            Graph.FillRectangle(PixBrush, Xe - cPixSize / 2, Ye - cPixSize / 2, cPixSize, cPixSize);
                            break;
                        }
                }
            }
            catch
            {
            }

        }


        // 'Рисует линию
        // Public Sub Line(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal DrawMode As Byte)
        // Dim xe1, ye1, xe2, ye2 As Integer
        // xe1 = CInt(x1 * Kx)
        // ye1 = CInt(-y1 * Ky)
        // xe2 = CInt(x2 * Kx)
        // ye2 = CInt(-y2 * Ky)
        // LinePen.Color = LineColor
        // If DrawMode = 0 Then
        // Graph = g_pic
        // ElseIf DrawMode = 1 Then
        // Graph = g_stat
        // ElseIf DrawMode = 2 Then
        // Graph = g_din
        // End If

        // Graph.DrawLine(LinePen, xe1, ye1, xe2, ye2)

        // 'If DrawMode = 0 Then
        // '    Pic.Image = buff_stat.Clone(rect, Imaging.PixelFormat.Undefined)
        // 'End If
        // 'If DrawMode = 1 Then
        // '    g_din.DrawImage(buff_stat, CSng(-xShift), CSng(-yShift), buff_din.Width, buff_din.Height)
        // 'End If
        // End Sub
        public void DinToPic()
        {
            Pic.Image = buff_din.Clone(rect, System.Drawing.Imaging.PixelFormat.Undefined);
            g_din.Clear(PicBackColor);
        }
        public void StatToPic()
        {
            Pic.Image = buff_stat.Clone(rect, System.Drawing.Imaging.PixelFormat.Undefined);
        }
        public void StatToDin()
        {
            g_din.DrawImage(buff_stat, -xShift, -yShift, buff_din.Width, (float)buff_din.Height);
        }
        public void ClearPic()
        {
            AxisDraw();
        }
        public void ClearDin()
        {
            g_din.Clear(PicBackColor);
        }
        public void ClearStat()
        {
            g_stat.Clear(PicBackColor);
        }
        #endregion
        private void UserControl_Resize(object sender, EventArgs e)
        {
            Pic.Top = 0;
            Pic.Left = 0;
            Pic.Width = Width;
            Pic.Height = Height;
            xMax = Pic.DisplayRectangle.Width;
            yMax = Pic.DisplayRectangle.Height;
        }

        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            var DefIndex = default(int);
            double Px, Py, Pz;
            if (My.MyProject.Forms.MolDinamics.Timer1.Enabled == true)
                return;
            if (Axis_Type == 5)
                return;
            // 2D
            Px = ConvertScreenXToPhys(e.X);
            Py = ConvertScreenYToPhys(e.Y);
            Pz = 0d;

            bool priznak;
            priznak = false;
            // проверка на замену или удаление
            for (int i = 0, loopTo = AtomCount - 1; i <= loopTo; i++)
            {
                priznak = false;
                if (Pow(Px - Module1.X[i], 2d) + Pow(Py - Module1.Y[i], 2d) <= Pow(Pix_Size * x_Base / 2d, 2d))
                {
                    DefIndex = i;
                    priznak = true; // попали на атом
                    break;
                }
            }

            if (e.Button == MouseButtons.Right & priznak)
            {
                // удалить

                for (int j = DefIndex, loopTo1 = AtomCount - 2; j <= loopTo1; j++)
                {
                    Module1.X[j] = Module1.X[j + 1];
                    Module1.Y[j] = Module1.Y[j + 1];
                    Module1.Z[j] = Module1.Z[j + 1];
                    Module1.ConfigP_C[j] = Module1.ConfigP_C[j + 1];
                    Module1.m[j] = Module1.m[j + 1];
                }
                AtomCount -= 1;
            }

            else if (e.Button == MouseButtons.Left)
            {
                if (priznak) // перекрасим атом
                {
                    Module1.ConfigP_C[DefIndex] = Module1.SelectMode;
                }
                else
                {
                    // добавление нового атома
                    priznak = true;
                    for (int i = 0, loopTo2 = AtomCount - 1; i <= loopTo2; i++)
                    {
                        if (Pow(Px - Module1.X[i], 2d) + Pow(Py - Module1.Y[i], 2d) < Pow(Pix_Size * x_Base, 2d))
                        {
                            priznak = false;

                        }
                    }
                    if (priznak)
                    {
                        Module1.X[AtomCount] = Px;
                        Module1.Y[AtomCount] = Py;
                        Module1.Z[AtomCount] = 0d;
                        Module1.m[AtomCount] = Module1.Mel;
                        Module1.ConfigP_C[AtomCount] = Module1.SelectMode; // центр-периферия
                        AtomCount += 1;

                    }
                }
            }
            ShowAtoms();

        }

        public double ConvertScreenXToPhys(double Ex)
        {
            double ConvertScreenXToPhysRet = default;
            switch (cAxisType)
            {
                case (byte)AxisType.full:
                    {
                        ConvertScreenXToPhysRet = (Ex - xMax / 2d) / Kx;
                        break;
                    }
                case (byte)AxisType.half_right:
                    {
                        ConvertScreenXToPhysRet = Ex / Kx;
                        break;
                    }
                case (byte)AxisType.quarter:
                    {
                        ConvertScreenXToPhysRet = Ex / Kx;
                        break;
                    }
                case 4:
                    {
                        ConvertScreenXToPhysRet = (Ex - xMax / 2d) / Kx;
                        break;
                    }

            }

            return ConvertScreenXToPhysRet;

        }
        public double ConvertScreenYToPhys(double Ey)
        {
            double ConvertScreenYToPhysRet = default;
            switch (cAxisType)
            {
                case (byte)AxisType.full:
                    {
                        ConvertScreenYToPhysRet = (yMax / 2d - Ey) / Ky;
                        break;
                    }
                case (byte)AxisType.half_right:
                    {
                        ConvertScreenYToPhysRet = (yMax / 2d - Ey) / Ky;
                        break;
                    }
                case (byte)AxisType.quarter:
                    {
                        ConvertScreenYToPhysRet = (yMax - Ey) / Ky;
                        break;
                    }
                case 4:
                    {
                        ConvertScreenYToPhysRet = (yMax - Ey) / Ky;
                        break;
                    }

            }

            return ConvertScreenYToPhysRet;

        }

        public double ConvertPhysXToScreen(double X)
        {
            double ConvertPhysXToScreenRet = default;
            switch (cAxisType)
            {
                case (byte)AxisType.full:
                    {
                        ConvertPhysXToScreenRet = X * Kx; // + xMax / 2
                        break;
                    }
                case (byte)AxisType.half_right:
                    {
                        ConvertPhysXToScreenRet = X * Kx;
                        break;
                    }
                case (byte)AxisType.quarter:
                    {
                        ConvertPhysXToScreenRet = X * Kx;
                        break;
                    }
                case 4:
                    {
                        ConvertPhysXToScreenRet = X * Kx; // + xMax / 2
                        break;
                    }

            }

            return ConvertPhysXToScreenRet;

        }
        public double ConvertPhysYToScreen(double y)
        {
            double ConvertPhysYToScreenRet = default;
            switch (cAxisType)
            {
                case (byte)AxisType.full:
                    {
                        ConvertPhysYToScreenRet = -y * Ky;
                        break;
                    }
                case (byte)AxisType.half_right:
                    {
                        ConvertPhysYToScreenRet = -y * Ky;
                        break;
                    }
                case (byte)AxisType.quarter:
                    {
                        ConvertPhysYToScreenRet = -y * Ky;
                        break;
                    }
                case 4:
                    {
                        ConvertPhysYToScreenRet = -y * Ky;
                        break;
                    }
            }

            return ConvertPhysYToScreenRet;
        }

        public void ShowAtoms()        // AxisDraw()
        {
            if (AtomCount == 0)
                return;
            // StatToDin()
            // PixPen.Color = Color.Red
            // 'Grid(2)
            // For i = 0 To AtomCount - 1
            // If ConfigP_C(i) = 1 Then
            // PixPen.Color = Color.Orange
            // PixBrush.Color = Color.DarkOrange
            // ElseIf ConfigP_C(i) = 2 Then
            // PixPen.Color = Color.Green
            // PixBrush.Color = Color.DarkGreen
            // Else
            // PixPen.Color = Color.Blue
            // PixBrush.Color = Color.DarkRed
            // End If

            // If cAxisType = 5 Then _
            // PixDraw(X(i), Y(i), Z(i), PixPen.Color, 2) Else _
            // PixDraw(X(i), Y(i), PixPen.Color, 2)
            // If BreakOn Then Exit For
            // Next
            // DinToPic()

            // If ViewAtom = False Or AtomCount = 0 Then Exit Sub
            Color PixPenColor;
            StatToDin();
            for (int i = 0, loopTo = AtomCount - 1; i <= loopTo; i++)
            {
                if (Module1.ConfigP_C[i] == 1)
                {
                    PixPenColor = Color.Orange;
                    PixBrush.Color = Color.DarkOrange;
                }

                else if (Module1.ConfigP_C[i] == 2)
                {
                    PixPenColor = Color.Green;
                    PixBrush.Color = Color.DarkGreen;
                }

                else
                {
                    PixPenColor = Color.Red;
                    PixBrush.Color = Color.DarkRed;
                }
                if (Axis_Type == 5)
                    PixDraw(Module1.X[i], Module1.Y[i], Module1.Z[i], PixPenColor, 2);
                else
                    PixDraw(Module1.X[i], Module1.Y[i], PixPenColor, 2);
                if (Module1.BreakOn)
                    break;
            }
            DinToPic();



        }

        public void Grid(byte GridType, byte DrawMode)
        {
            double ShiftY = yBase % GridStepY;
            double ShiftX = xBase % GridStepX;
            double x = x_Base;
            double y = -y_Base;
            LinePen.Color = GridColor;

            switch (GridType)
            {
                case 1: // прямоугольная
                    {

                        x = -x_Base + ShiftX - GridStepX;
                        y = -y_Base + ShiftY - GridStepY;

                        while (y < y_Base)
                        {

                            y += GridStepY;
                            Line(-x_Base, y, x_Base, y, DrawMode);
                        }
                        while (x < x_Base)
                        {

                            x += GridStepX;
                            Line(x, -y_Base, x, y_Base, DrawMode);
                        }

                        break;
                    }

                case 2:    // треугольная
                    {
                        x = x_Base - ShiftX + GridStepX;
                        y = -y_Base + ShiftY - GridStepY;
                        while (x > -2 * x_Base)
                        {
                            x -= GridStepX;
                            y += GridStepY;
                            Line(x, -y_Base + ShiftY - GridStepY, x_Base - ShiftX + GridStepX, y, DrawMode);

                        }

                        x = -x_Base + ShiftX - GridStepX;
                        y = -y_Base + ShiftY - GridStepY;
                        while (x < 2d * x_Base)
                        {
                            x += GridStepX;
                            y += GridStepY;
                            Line(x, -y_Base + ShiftY - GridStepY, -x_Base + ShiftX - GridStepX, y, DrawMode);
                        }
                        y = -y_Base + ShiftY - GridStepY;

                        while (y < y_Base)
                        {

                            y += GridStepY / 2d;
                            Line(-x_Base, y, x_Base, y, DrawMode);
                        }

                        break;
                    }
            }
        }




    }
}