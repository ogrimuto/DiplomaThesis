Option Explicit On
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Math
Public Class Axis
    Sub New()
        InitializeComponent()
        rect.Width = Me.Width
        rect.Height = Me.Height
        PixSize = 2
    End Sub
#Region "Определения"
    Public Enum AxisType As Byte
        full = 1
        half_right = 2
        quarter = 3
        half_top = 4
        D3 = 5

    End Enum
    Public Enum PixType As Byte
        point = 1
        cross = 2
        circle = 3
        rect = 4
        Grad = 5
        poligon = 6
    End Enum
    Private Kx As Double = 1, Ky As Double = 1, Kz As Double = 1
    Private xMax, yMax, zMax As Double
    Private Xe As Integer
    Private Ye As Integer
    Private cAxisType As Byte = AxisType.full
    Private cPixType As Byte = PixType.point
    Private xBase As Double = 1
    Private yBase As Double = 1
    Private zBase As Double = 1
    Private xBase0, yBase0, zBase0 As Double
    Private xName As String = "X"
    Private yName As String = "Y"
    Private zName As String = "Z"
    Private xShift As Integer
    Private yShift As Integer
    Private cPixSize As Integer = 1
    Private PixSize As Double = 1
    Public PicBackColor As Color = Color.White
    ' Private DrawMode As Integer = 0
    Private rect As New Rectangle(0, 0, 1, 1)
    Public Ex As Integer
    Public Ey As Integer
    Dim Alpha As Double 'угол между осями X и Y в диметрии
    Public X_Phys, Y_Phys, Z_Phys As Double
    Public ClickFactor As Byte
    Public arrpoint() As PointF

    Private FirstPass As Boolean = True
    Private Graph As Graphics
    'оформление координат
    Dim axisPen As System.Drawing.Pen = _
            New System.Drawing.Pen(System.Drawing.Color.Gray)
    Dim axisFont As System.Drawing.Font = _
            New System.Drawing.Font("Courier", 12, FontStyle.Regular)
    Dim axisBrush As System.Drawing.SolidBrush = _
            New System.Drawing.SolidBrush(Drawing.Color.Black)
    'оформление маркеров
    Dim PixPen As System.Drawing.Pen = _
            New System.Drawing.Pen(System.Drawing.Color.Black)
    Public PixBrush As System.Drawing.SolidBrush = _
            New System.Drawing.SolidBrush(Drawing.Color.Black)
    Public PixBrushGrad As System.Drawing.Drawing2D.LinearGradientBrush
    Dim RectGrad As RectangleF
    'буфер для сохранения текущего отображения системы координат  
    Public buff_stat As System.Drawing.Bitmap
    Public buff_din As System.Drawing.Bitmap
    'объект для рисования 
    Dim g_pic As System.Drawing.Graphics
    Dim g_stat As System.Drawing.Graphics
    Dim g_din As System.Drawing.Graphics
    Const AtomCountMax = 1000000
    Public ClickCount As Integer
    'Public ClickArrayScreenX(AtomCountMax), ClickArrayScreenY(AtomCountMax), ClickArrayScreenZ(AtomCountMax) As Double
    'Public ClickArrayPhysX(AtomCountMax), ClickArrayPhysY(AtomCountMax), ClickArrayPhysZ(AtomCountMax) As Double
    Public AtomCount, AtomCountP, AtomCountC As Integer
    Public GridOn As Boolean
    Public GridType As Byte
    Public GridStepX, GridStepY As Double 'физические
    Public LineColor As Color
    Public GridColor As Color
    Dim LinePen As New Pen(Color.Black)
    Dim ShiftControl As Byte
#End Region
#Region "Свойства"
    'оси координат
    Public Property Axis_Type() As Byte
        Get
            Return cAxisType
        End Get
        Set(ByVal Value As Byte)
            cAxisType = Value
        End Set
    End Property
    Public Property x_Base() As Double
        Get
            Return xBase
        End Get
        Set(ByVal Value As Double)
            If Value <= 0 Then xBase = 1 Else xBase = Value
        End Set
    End Property
    Public Property y_Base() As Double
        Get
            Return yBase
        End Get
        Set(ByVal Value As Double)
            If Value <= 0 Then yBase = 1 Else yBase = Value
        End Set
    End Property
    Public Property z_Base() As Double
        Get
            Return yBase
        End Get
        Set(ByVal Value As Double)
            If Value <= 0 Then zBase = 1 Else zBase = Value
        End Set
    End Property
    Public Property x_Base0() As Double
        Get
            Return xBase0
        End Get
        Set(ByVal Value As Double)
            If Value <= 0 Then xBase0 = 0 Else xBase0 = Value
        End Set
    End Property
    Public Property y_Base0() As Double
        Get
            Return yBase0
        End Get
        Set(ByVal Value As Double)
            If Value < 0 Then yBase0 = 0 Else yBase0 = Value
        End Set
    End Property
    Public Property x_Name() As String
        Get
            Return xName
        End Get
        Set(ByVal Value As String)
            xName = Value
        End Set
    End Property
    Public Property y_Name() As String
        Get
            Return yName
        End Get
        Set(ByVal Value As String)
            yName = Value
        End Set
    End Property
    Public Property z_Name() As String
        Get
            Return zName
        End Get
        Set(ByVal Value As String)
            zName = Value
        End Set
    End Property

    Public Property axis_color() As System.Drawing.Color
        Get
            Return axisPen.Color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            axisPen.Color = Value
        End Set
    End Property
    Public Property axis_bkcolor() As System.Drawing.Color
        Get
            Return PicBackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            PicBackColor = Value
        End Set
    End Property
    'маркер
    Public Property Pix_type() As Byte
        Get
            Return cPixType
        End Get
        Set(ByVal Value As Byte)
            cPixType = Value
        End Set
    End Property
    Public Property E_x() As Integer
        Get
            Return Ex
        End Get
        Set(ByVal Value As Integer)
            Ex = Value
        End Set
    End Property
    Public Property E_y() As Integer
        Get
            Return Ey
        End Get
        Set(ByVal Value As Integer)
            Ey = Value
        End Set
    End Property
    Public Property Pix_color() As System.Drawing.Color
        Get
            Return PixPen.Color
        End Get
        Set(ByVal Value As System.Drawing.Color)
            PixPen.Color = Value
            PixBrush.Color = Value
        End Set
    End Property
    ' размер маркера в долях от xBase
    Public Property Pix_Size() As Double
        Get
            Return PixSize
        End Get
        Set(ByVal Value As Double)
            PixSize = Value
        End Set
    End Property
#End Region
#Region "Методы"
    Public Sub AxisDraw()
        Dim lxName As String
        Dim lyName As String
        Dim lzName As String
        rect.Width = CInt(xMax)
        rect.Height = CInt(yMax)
        If FirstPass = False Then
            FirstPass = False
            g_stat.Dispose()
            g_din.Dispose()
            g_pic.Dispose()
            buff_stat.Dispose()
            buff_din.Dispose()
        End If

        Try
            buff_stat = New System.Drawing.Bitmap(CInt(xMax), CInt(yMax))
            buff_din = New System.Drawing.Bitmap(CInt(xMax), CInt(yMax))
            'Pic.Image = New System.Drawing.Bitmap(CInt(xMax), CInt(yMax))

            g_stat = System.Drawing.Graphics.FromImage(buff_stat)
            g_din = System.Drawing.Graphics.FromImage(buff_din)
            StatToPic()
            g_pic = Graphics.FromImage(Pic.Image)
            'названия осей

            lxName = Str(Round(xBase, 2)) + ", " + xName
            lyName = Str(Round(yBase, 2)) + ", " + yName
            lzName = Str(Round(zBase, 2)) + ", " + zName

            Select Case cAxisType
                Case AxisType.full

                    xShift = xMax / 2
                    yShift = yMax / 2
                    g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_pic.TranslateTransform(xShift, yShift, MatrixOrder.Append)

                    Kx = xMax / 2 / (xBase - xBase0)
                    Ky = yMax / 2 / (yBase - yBase0)

                    If GridOn Then drawgrid()

                    LinePen.Color = axis_color
                    Line(-xBase, 0, xBase, 0, 1)
                    Line(0, yBase, 0, -yBase, 1)
                    g_stat.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 10) - xShift, CInt(yMax / 2 - 20) - yShift)
                    g_stat.DrawString(lyName, axisFont, axisBrush, CInt(xMax / 2) - xShift, 1 - xShift)

                    g_stat.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, CInt(xMax / 2) - xShift, CInt(yMax / 2 - 20 - yShift))


                Case AxisType.half_right

                    g_stat.DrawLine(axisPen, 0, CInt(yMax / 2), CInt(xMax), CInt(yMax / 2))
                    g_stat.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 10), CInt(yMax / 2 - 20))
                    g_stat.DrawString(lyName, axisFont, axisBrush, 1, 1)

                    g_stat.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, 0, CInt(yMax / 2 - 20))


                    g_pic.DrawLine(axisPen, 0, CInt(yMax / 2), CInt(xMax), CInt(yMax / 2))
                    g_pic.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 10), CInt(yMax / 2 - 20))
                    g_pic.DrawString(lyName, axisFont, axisBrush, 1, 1)

                    g_pic.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, 0, CInt(yMax / 2 - 20))




                    xShift = 0
                    yShift = yMax / 2
                    g_stat.TranslateTransform(0, yMax / 2, MatrixOrder.Append)
                    g_din.TranslateTransform(0, yMax / 2, MatrixOrder.Append)
                    g_pic.TranslateTransform(0, yMax / 2, MatrixOrder.Append)


                    Kx = xMax / (xBase - xBase0)
                    Ky = yMax / 2 / (yBase - yBase0)


                    If GridOn Then drawgrid()

                    LineColor = Color.Black
                    Line(-xBase, 0, xBase, 0, 1)
                    g_stat.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 10), CInt(yMax / 2 - 20 - yShift))
                    g_stat.DrawString(lyName, axisFont, axisBrush, 1, 1 - yShift)

                    g_stat.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, 0, CInt(yMax / 2 - 20 - yShift))


                Case AxisType.half_top '4
                    g_stat.DrawLine(axisPen, CInt(xMax / 2), 0, CInt(xMax / 2), CInt(yMax))
                    g_stat.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 7), CInt(yMax - 15))
                    g_stat.DrawString(lyName, axisFont, axisBrush, CInt(xMax / 2), 1)

                    g_stat.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, CInt(xMax / 2), CInt(yMax - 15))

                    xShift = xMax / 2
                    yShift = yMax
                    g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    Kx = xMax / 2 / (xBase - xBase0)
                    Ky = yMax / (yBase - yBase0)



                Case AxisType.quarter '3

                    xShift = 0
                    yShift = yMax
                    g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append)

                    Kx = xMax / (xBase - xBase0)
                    Ky = yMax / (yBase - yBase0)

                    If GridOn Then drawgrid()

                    g_stat.DrawString(lxName, axisFont, axisBrush, CInt(xMax - lxName.Length * 7) - xShift, CInt(yMax - 15) - yShift)
                    g_stat.DrawString(lyName, axisFont, axisBrush, 1, 1 - yShift)
                    g_stat.DrawString(yBase0.ToString + "/" + xBase0.ToString, axisFont, axisBrush, 0, CInt(yMax - 15) - yShift)


                Case AxisType.D3
                    'построение осей
                    Dim y1 As Double = (xMax / 2) * (1 / Sqrt(3) + 1)
                    g_stat.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), 0, CSng(y1))
                    g_stat.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), CSng(xMax), CSng(y1))
                    g_stat.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), CSng(xMax / 2), 0)

                    g_stat.DrawString(lxName, axisFont, axisBrush, xMax - 100, y1)
                    g_stat.DrawString(lyName, axisFont, axisBrush, xMax / 2 + 20, 10)
                    g_stat.DrawString(lzName, axisFont, axisBrush, 20, y1)


                    g_pic.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), 0, CSng(y1))
                    g_pic.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), CSng(xMax), CSng(y1))
                    g_pic.DrawLine(axisPen, CSng(xMax / 2), CSng(yMax / 2), CSng(xMax / 2), 0)

                    g_pic.DrawString(lxName, axisFont, axisBrush, xMax - 100, y1)
                    g_pic.DrawString(lyName, axisFont, axisBrush, xMax / 2 + 20, 10)
                    g_pic.DrawString(lzName, axisFont, axisBrush, 20, y1)


                    xShift = xMax / 2
                    yShift = yMax / 2
                    g_stat.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_din.TranslateTransform(xShift, yShift, MatrixOrder.Append)
                    g_pic.TranslateTransform(xShift, yShift, MatrixOrder.Append)

                    ' StatToPic()
                    Kx = xMax / 2 / xBase
                    Ky = yMax / 2 / yBase
                    zMax = xMax
                    Kz = zMax / 2 / zBase
                    Alpha = 2 * PI / 3

            End Select


            StatToPic()
        Catch
        End Try
        'ShowAtoms()

    End Sub 'отображение 
    Sub drawgrid()
        Grid(GridType, 1)
        Grid(GridType, 0)




    End Sub
   
    'screen coordinates, 2D
    Public Sub PixDraw(ByVal x As Double, ByVal y As Double, ByVal CColor As Color, ByVal DrawMode As Byte)
        Try
            Xe = CInt(x * Kx)
            Ye = CInt(-y * Ky)
            PixDraw_(CColor, DrawMode)
        Catch ex As Exception
            MolDinamics.Timer1.Enabled = False
            ' MsgBox("По-видимому,надо уменьшить временной шаг")
            BreakOn = True

        End Try
    End Sub

    'screen coordinates, 3D
    Public Sub PixDraw(ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal CColor As Color, ByVal DrawMode As Byte)
        Try
            Xe = CInt((x - z) * Kx * Cos(PI / 6))
            Ye = -CInt((y - (z + x) / 2) * Kx)
            PixDraw_(CColor, DrawMode)
        Catch
        End Try
    End Sub
    'отображение точки(маркера)
    Private Sub PixDraw_(ByVal PointColor As Color, ByVal DrawMode As Byte)
        Dim x1, y1, x2, y2 As Integer
        Try
            PixPen.Color = PointColor
            PixBrush.Color = PixPen.Color
            cPixSize = Kx * Pix_Size * xBase

            If cPixSize < 1 Then cPixSize = 1
            If DrawMode = 0 Then
                Graph = g_pic
            ElseIf DrawMode = 1 Then
                Graph = g_stat
            ElseIf DrawMode = 2 Then
                Graph = g_din
            End If
            Select Case cPixType
                Case PixType.point
                    'Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    'Graph.FillEllipse(PixBrush, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    RectGrad = New RectangleF(Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    PixBrushGrad = New LinearGradientBrush(RectGrad, Color.White, PixBrush.Color, LinearGradientMode.BackwardDiagonal)
                    PixBrushGrad.SetSigmaBellShape(0.8, 1)
                    Graph.FillEllipse(PixBrushGrad, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)

                Case PixType.cross
                    x1 = Xe
                    x2 = Xe
                    y1 = Ye - cPixSize / 2
                    y2 = Ye + cPixSize / 2
                    Graph.DrawLine(PixPen, x1, y1, x2, y2)
                    x1 = Xe - cPixSize / 2
                    x2 = Xe + cPixSize / 2
                    y1 = Ye
                    y2 = Ye
                    Graph.DrawLine(PixPen, x1, y1, x2, y2)
                Case PixType.circle
                    Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                Case PixType.rect
                    Graph.FillRectangle(PixBrush, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                Case PixType.Grad
                    RectGrad = New RectangleF(Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    PixBrushGrad = New LinearGradientBrush(RectGrad, Color.White, PixBrush.Color, LinearGradientMode.BackwardDiagonal)
                    PixBrushGrad.SetSigmaBellShape(0.8, 1)
                    Graph.FillEllipse(PixBrushGrad, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                    Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                Case PixType.poligon

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'string drawing
    Public Sub StringDraw(ByVal St As String, ByVal X As Double, ByVal Y As Double, _
                 ByVal StringFont As Font, ByVal StringColor As Color, ByVal DrawMode As Byte)
        Dim StringBrush As New SolidBrush(StringColor)
        X = X * Kx
        Y = -Y * Ky
        Select Case DrawMode
            Case 0
                g_pic.DrawString(St, StringFont, StringBrush, X, Y)
            Case 1
                g_stat.DrawString(St, StringFont, StringBrush, X, Y)
            Case 2
                g_din.DrawString(St, StringFont, StringBrush, X, Y)
        End Select
    End Sub
    'line drawing
    Public Sub Line(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal DrawMode As Byte)
        Dim xe1, ye1, xe2, ye2 As Integer

        xe1 = CInt(x1 * Kx)
        xe2 = CInt(x2 * Kx)
        ye1 = CInt(-y1 * Ky)
        ye2 = CInt(-y2 * Ky)

        If DrawMode = 0 Then
            Graph = g_pic
        ElseIf DrawMode = 1 Then
            Graph = g_stat
        ElseIf DrawMode = 2 Then
            Graph = g_din
        End If
        Graph.DrawLine(LinePen, xe1, ye1, xe2, ye2)
    End Sub


    Public Sub PixDrawScreenUnits(ByVal CColor As Color, ByVal DrawMode As Byte)
        Dim x1, y1, x2, y2 As Integer
        On Error GoTo err1
        Xe = Ex - xMax / 2
        Ye = Ey - yMax / 2
        PixPen.Color = CColor
        PixBrush.Color = PixPen.Color
        cPixSize = Kx * PixSize * xBase

        If cPixSize < 1 Then cPixSize = 1

        If DrawMode = 0 Then
            Graph = g_pic
        ElseIf DrawMode = 1 Then
            Graph = g_stat
        ElseIf DrawMode = 2 Then
            Graph = g_din
        End If

        Select Case cPixType
            Case PixType.point
                Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
                Graph.FillEllipse(PixBrush, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
            Case PixType.cross
                x1 = Xe
                x2 = Xe
                y1 = Ye - cPixSize / 2
                y2 = Ye + cPixSize / 2
                Graph.DrawLine(PixPen, x1, y1, x2, y2)
                x1 = Xe - cPixSize / 2
                x2 = Xe + cPixSize / 2
                y1 = Ye
                y2 = Ye
                Graph.DrawLine(PixPen, x1, y1, x2, y2)
            Case PixType.circle
                Graph.DrawEllipse(PixPen, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
            Case PixType.rect
                Graph.FillRectangle(PixBrush, Xe - cPixSize \ 2, Ye - cPixSize \ 2, cPixSize, cPixSize)
        End Select
err1:
    End Sub
   

    ''Рисует линию
    'Public Sub Line(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal DrawMode As Byte)
    '    Dim xe1, ye1, xe2, ye2 As Integer
    '    xe1 = CInt(x1 * Kx)
    '    ye1 = CInt(-y1 * Ky)
    '    xe2 = CInt(x2 * Kx)
    '    ye2 = CInt(-y2 * Ky)
    '    LinePen.Color = LineColor
    '    If DrawMode = 0 Then
    '        Graph = g_pic
    '    ElseIf DrawMode = 1 Then
    '        Graph = g_stat
    '    ElseIf DrawMode = 2 Then
    '        Graph = g_din
    '    End If

    '    Graph.DrawLine(LinePen, xe1, ye1, xe2, ye2)

    '    'If DrawMode = 0 Then
    '    '    Pic.Image = buff_stat.Clone(rect, Imaging.PixelFormat.Undefined)
    '    'End If
    '    'If DrawMode = 1 Then
    '    '    g_din.DrawImage(buff_stat, CSng(-xShift), CSng(-yShift), buff_din.Width, buff_din.Height)
    '    'End If
    'End Sub
    Public Sub DinToPic()
        Pic.Image = buff_din.Clone(rect, Imaging.PixelFormat.Undefined)
        g_din.Clear(PicBackColor)
    End Sub
    Public Sub StatToPic()
        Pic.Image = buff_stat.Clone(rect, Imaging.PixelFormat.Undefined)
    End Sub
    Public Sub StatToDin()
        g_din.DrawImage(buff_stat, CSng(-xShift), CSng(-yShift), buff_din.Width, buff_din.Height)
    End Sub
    Public Sub ClearPic()
        AxisDraw()
    End Sub
    Public Sub ClearDin()
        g_din.Clear(PicBackColor)
    End Sub
    Public Sub ClearStat()
        g_stat.Clear(PicBackColor)
    End Sub
#End Region
    Private Sub UserControl_Resize(ByVal sender As Object, _
                        ByVal e As System.EventArgs) Handles MyBase.Resize
        Pic.Top = 0
        Pic.Left = 0
        Pic.Width = Me.Width
        Pic.Height = Me.Height
        xMax = Pic.DisplayRectangle.Width
        yMax = Pic.DisplayRectangle.Height
    End Sub

    Private Sub Pic_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic.MouseDown
        Dim DefIndex As Integer
        Dim Px, Py, Pz As Double
        If MolDinamics.Timer1.Enabled = True Then Exit Sub
        If Axis_Type = 5 Then Exit Sub
        '2D
        Px = ConvertScreenXToPhys(e.X)
        Py = ConvertScreenYToPhys(e.Y)
        Pz = 0
       
        Dim priznak As Boolean
        priznak = False
        'проверка на замену или удаление
        For i = 0 To AtomCount - 1
            priznak = False
            If (Px - X(i)) ^ 2 + _
                 (Py - Y(i)) ^ 2 <= (Pix_Size * x_Base / 2) ^ 2 Then
                DefIndex = i
                priznak = True 'попали на атом
                Exit For
            End If
        Next

        If e.Button = Windows.Forms.MouseButtons.Right And priznak Then
            'удалить

            For j = DefIndex To AtomCount - 2
                X(j) = X(j + 1)
                Y(j) = Y(j + 1)
                Z(j) = Z(j + 1)
                ConfigP_C(j) = ConfigP_C(j + 1)
                m(j) = m(j + 1)
            Next
            AtomCount -= 1

        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            If priznak Then 'перекрасим атом
                ConfigP_C(DefIndex) = SelectMode
            Else
                'добавление нового атома
                priznak = True
                For i = 0 To AtomCount - 1
                    If (Px - X(i)) ^ 2 + _
                         (Py - Y(i)) ^ 2 < (Pix_Size * x_Base) ^ 2 Then
                        priznak = False

                    End If
                Next
                If priznak Then
                    X(AtomCount) = Px
                    Y(AtomCount) = Py
                    Z(AtomCount) = 0
                    m(AtomCount) = Mel
                    ConfigP_C(AtomCount) = SelectMode 'центр-периферия
                    AtomCount += 1

                End If
            End If
        End If
        ShowAtoms()

    End Sub

    Public Function ConvertScreenXToPhys(ByVal Ex As Double) As Double
        Select Case cAxisType
            Case AxisType.full
                ConvertScreenXToPhys = (Ex - xMax / 2) / Kx
            Case AxisType.half_right
                ConvertScreenXToPhys = Ex / Kx
            Case AxisType.quarter
                ConvertScreenXToPhys = Ex / Kx
            Case 4
                ConvertScreenXToPhys = (Ex - xMax / 2) / Kx

        End Select

    End Function
    Public Function ConvertScreenYToPhys(ByVal Ey As Double) As Double
        Select Case cAxisType
            Case AxisType.full
                ConvertScreenYToPhys = (yMax / 2 - Ey) / Ky
            Case AxisType.half_right
                ConvertScreenYToPhys = (yMax / 2 - Ey) / Ky
            Case AxisType.quarter
                ConvertScreenYToPhys = (yMax - Ey) / Ky
            Case 4
                ConvertScreenYToPhys = (yMax - Ey) / Ky

        End Select

    End Function

    Public Function ConvertPhysXToScreen(ByVal X As Double) As Double
        Select Case cAxisType
            Case AxisType.full
                ConvertPhysXToScreen = X * Kx '+ xMax / 2
            Case AxisType.half_right
                ConvertPhysXToScreen = X * Kx
            Case AxisType.quarter
                ConvertPhysXToScreen = X * Kx
            Case 4
                ConvertPhysXToScreen = X * Kx '+ xMax / 2

        End Select

    End Function
    Public Function ConvertPhysYToScreen(ByVal y As Double) As Double
        Select Case cAxisType
            Case AxisType.full
                ConvertPhysYToScreen = -y * Ky
            Case AxisType.half_right
                ConvertPhysYToScreen = -y * Ky
            Case AxisType.quarter
                ConvertPhysYToScreen = -y * Ky
            Case 4
                ConvertPhysYToScreen = -y * Ky
        End Select
    End Function

    Public Sub ShowAtoms()        'AxisDraw()
        If AtomCount = 0 Then Exit Sub
        'StatToDin()
        'PixPen.Color = Color.Red
        ''Grid(2)
        'For i = 0 To AtomCount - 1
        '    If ConfigP_C(i) = 1 Then
        '        PixPen.Color = Color.Orange
        '        PixBrush.Color = Color.DarkOrange
        '    ElseIf ConfigP_C(i) = 2 Then
        '        PixPen.Color = Color.Green
        '        PixBrush.Color = Color.DarkGreen
        '    Else
        '        PixPen.Color = Color.Blue
        '        PixBrush.Color = Color.DarkRed
        '    End If

        '    If cAxisType = 5 Then _
        '          PixDraw(X(i), Y(i), Z(i), PixPen.Color, 2) Else _
        '    PixDraw(X(i), Y(i), PixPen.Color, 2)
        '    If BreakOn Then Exit For
        'Next
        'DinToPic()

        ' If ViewAtom = False Or AtomCount = 0 Then Exit Sub
        Dim PixPenColor As Color
        StatToDin()
        For i = 0 To AtomCount - 1
            If ConfigP_C(i) = 1 Then
                PixPenColor = Color.Orange
                PixBrush.Color = Color.DarkOrange

            ElseIf ConfigP_C(i) = 2 Then
                PixPenColor = Color.Green
                PixBrush.Color = Color.DarkGreen

            Else
                PixPenColor = Color.Red
                PixBrush.Color = Color.DarkRed
            End If
            If Axis_Type = 5 Then _
                  PixDraw(X(i), Y(i), Z(i), PixPenColor, 2) Else _
                  PixDraw(X(i), Y(i), PixPenColor, 2)
            If BreakOn Then Exit For
        Next
        DinToPic()



    End Sub

    Sub Grid(ByVal GridType As Byte, ByVal DrawMode As Byte)
        Dim ShiftY As Double = yBase Mod GridStepY
        Dim ShiftX As Double = xBase Mod GridStepX
        Dim x As Double = x_Base
        Dim y As Double = -y_Base
        LinePen.Color = GridColor

        Select Case GridType
            Case 1 'прямоугольная

                x = -x_Base + ShiftX - GridStepX
                y = -y_Base + ShiftY - GridStepY

                Do While y < y_Base

                    y += GridStepY
                    Line(-x_Base, y, x_Base, y, DrawMode)
                Loop
                Do While x < x_Base

                    x += GridStepX
                    Line(x, -y_Base, x, y_Base, DrawMode)
                Loop

            Case 2    'треугольная
                x = x_Base - ShiftX + GridStepX
                y = -y_Base + ShiftY - GridStepY
                Do While x > -2 * x_Base
                    x -= GridStepX
                    y += GridStepY
                    Line(x, -y_Base + ShiftY - GridStepY, x_Base - ShiftX + GridStepX, y, DrawMode)

                Loop

                x = -x_Base + ShiftX - GridStepX
                y = -y_Base + ShiftY - GridStepY
                Do While x < 2 * x_Base
                    x += GridStepX
                    y += GridStepY
                    Line(x, -y_Base + ShiftY - GridStepY, -x_Base + ShiftX - GridStepX, y, DrawMode)
                Loop
                y = -y_Base + ShiftY - GridStepY

                Do While y < y_Base

                    y += GridStepY / 2
                    Line(-x_Base, y, x_Base, y, DrawMode)
                Loop
        End Select
    End Sub




End Class
