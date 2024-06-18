
Option Explicit On
Imports System.Math


Public Class MolDinamics
    Const AEM = 1.66054E-27
    Const k = 1.380685E-23
    Dim mel As Double = 13 '74 ' * AEM
    Const Angstrem = 0.0000000001
    Dim Unit As Double
    Dim AtomDefIndex, neighborIndex, centerIndex As Integer
    Dim DUDR, rij, sigma6, xBase, yBase, zBase As Double
    Dim FullE, PotE, KinE, KinEc, KinEp, PotE0 As Double
    Dim Xm, Ym, Zm, KSI As Double
    Dim Rgir As Double
    Dim Tcl, Tc, Tp, Tclaver, Tcaver, Tpaver As Double
    Dim FirstStart As Boolean = True
    Private Sub MolDinamics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBoxConfiguration.SelectedIndex = 0
        TextBoxSigma.Text = Sigma(selMatterPotencialIndex).ToString
        TextBoxEpsilon.Text = Epsilon(selMatterPotencialIndex).ToString
        Axis1.Width = Axis1.Height
    End Sub
    Private Sub RadioButton3D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3D.CheckedChanged
        If RadioButton3D.Checked Then DimIndex = 3 Else DimIndex = 2
    End Sub
    Private Sub RadioButton2D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2D.CheckedChanged
        If RadioButton2D.Checked Then DimIndex = 2 Else DimIndex = 3
    End Sub
    Sub ClearConfiguration()
        For i = 0 To AtomCount - 1
            X(i) = 0
            Y(i) = 0
            Z(i) = 0
        Next
        AtomCount = 0
    End Sub

    Sub InitConfiguration()
        'D2.D3
        ClearConfiguration()
        xBase = Val(TextBoxBase.Text)
        MinDist = Val(TextBoxMinDist.Text)
        AtomCountLine = Val(TextBoxAtomCountLine.Text)
        Rows = Val(TextBoxRows.Text)
        BreakOn = False
        If RadioButton2D.Checked Then
            Axis1.Axis_Type = 1
        Else
            Axis1.Axis_Type = 5
        End If

        Select Case ConfigurationIndex
            Case 0
                AtomCount = 13
                TextBoxAtomCount.Text = AtomCount.ToString
            Case 1, 2
                AtomCount = Val(TextBoxAtomCountLine.Text) ^ 2 * Rows
            Case 2
        End Select
        Axis1.x_Base = xBase
        Axis1.y_Base = xBase
        Axis1.z_Base = xBase
        yBase = xBase
        zBase = xBase
        Axis1.x_Name = "X,sigma"
        Axis1.y_Name = "Y,sigma"
        Axis1.z_Name = "Z,sigma"
        If DimIndex = 2 Then Axis1.Pix_type = 1 Else Axis1.Pix_type = 5

        Axis1.GridColor = Color.LightGray
        Axis1.Pix_Size = Val(TextBoxDiametr.Text) / xBase
        Axis1.Pix_color = Color.Red
        Axis1.axis_color = Color.Black

        If RadioButtonRect.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = MinDist
        Else
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = Sqrt(3) * MinDist
        End If
        Axis1.AxisDraw()

        Select Case ConfigurationIndex

            Case 0 'GCK
                GCK()
            Case 1 '
                Axis1.AtomCount = AtomCount
                RectPacking()
            Case 2 'Set
                DensestPacking()
            Case 3 'Free


        End Select

        ShowAtoms()
        InitGraph()
        PotE0 = 0
        For i = 0 To AtomCount - 2
            For j = i + 1 To AtomCount - 1
                rij = Sqrt((X(i) - X(j)) ^ 2 + (Y(i) - Y(j)) ^ 2 + (Z(i) - Z(j)) ^ 2)
                PotE0 += 4 * ((1 / rij) ^ 12 - (1 / rij) ^ 6)
            Next
        Next
        TextBoxEnergy.Text = PotE0.ToString
        TextBoxEnergy.Text = (Abs(PotE0) * 2).ToString
        dtau = Val(TextBoxdtau.Text) 'c
        tau = 0
        tau1 = 0
        Tclaver = 0
        Tcaver = 0
        Tpaver = 0

    End Sub

    Sub InitGraph()

        AxisE.Axis_Type = 2
        AxisE.x_Base = Val(TextBoxBaseTau.Text)
        AxisE.y_Base = Abs(PotE0) / AtomCount * 5 '1.2 'Val(TextBoxEnergy.Text) ' * 2
        AxisE.x_Name = "время"
        AxisE.y_Name = "энергия"
        AxisE.Pix_type = 1
        AxisE.Pix_Size = 0.005
        AxisE.PicBackColor = Color.Bisque
        AxisE.AxisDraw()

        AxisKinEPotE.Axis_Type = 3
        AxisKinEPotE.GridOn = True
        AxisKinEPotE.GridColor = Color.LightGray
        AxisKinEPotE.GridType = 1
        AxisKinEPotE.x_Base = Val(TextBoxBaseTau.Text)
        AxisKinEPotE.y_Base = 1
        AxisKinEPotE.x_Name = "время"
        AxisKinEPotE.y_Name = "Ekin/Epot"
        AxisKinEPotE.Pix_type = 1
        AxisKinEPotE.Pix_Size = 0.005
        AxisKinEPotE.PicBackColor = Color.Bisque
        AxisKinEPotE.AxisDraw()

        AxisGir.Axis_Type = 3
        AxisGir.x_Base = Val(TextBoxBaseTau.Text)
        AxisGir.y_Base = 3 * MinDist * Sqrt(AtomCount)
        AxisGir.x_Name = "время"
        AxisGir.y_Name = "длина связности"
        AxisGir.Pix_type = 1
        AxisGir.Pix_Size = 0.008
        AxisGir.PicBackColor = Color.DarkBlue
        AxisGir.AxisDraw()

        AxisT.Axis_Type = 3
        AxisT.x_Base = Val(TextBoxBaseTau.Text)
        AxisT.y_Base = 100
        AxisT.x_Name = "время"
        AxisT.y_Name = "температура, K"
        AxisT.Pix_type = 1
        AxisT.Pix_Size = 0.008
        AxisT.PicBackColor = Color.DarkBlue
        AxisT.AxisDraw()

    End Sub

    Private Sub ListBoxConfiguration_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBoxConfiguration.MouseClick

        ButtonStart.Enabled = True
        FirstStart = True
        Timer1.Enabled = False
        ConfigurationIndex = ListBoxConfiguration.SelectedIndex
        InitConfiguration()
        InitGraph()

    End Sub
    Function GetAtomInLine()
        AtomCount = Val(TextBoxAtomCount.Text)
        GetAtomInLine = Sqrt(AtomCount)
    End Function
    Sub DensestPacking()
        Dim ShiftX As Double
        Dim ShiftY As Double
        Dim ShiftX1 As Double
        Dim AtomInLine As Integer
        Dim IntCountX As Integer = CInt((xBase / MinDist - (xBase Mod MinDist))) * 2

        If AtomCount > 1 Then
            AtomInLine = Val(TextBoxAtomCountLine.Text) ' GetAtomInLine()
            ShiftX = (xBase - (AtomInLine * MinDist) / 2)
            ShiftX1 = (xBase - (AtomInLine * MinDist) / 2) - MinDist / 2
            ShiftY = xBase - AtomInLine * MinDist * Sqrt(3) / 2 / 2
        Else
            Exit Sub
        End If

        Dim AtomDefIndex As Integer = 0
        For i = 1 To AtomInLine
            For j = 1 To AtomInLine
                If j Mod 2 = 0 Then X(AtomDefIndex) = -xBase + MinDist * (i) + ShiftX1 Else _
                    X(AtomDefIndex) = -xBase + MinDist * (i) + ShiftX
                Y(AtomDefIndex) = -xBase + MinDist * (Sqrt(3) / 2) * (j) + ShiftY
                AtomDefIndex += 1
            Next
        Next

        AtomCount = AtomDefIndex
        Axis1.AtomCount = AtomCount

        For i = 0 To AtomCount - 1
            m(i) = mel
            Vx(i) = 0
            Vy(i) = 0
            Vz(i) = 0
        Next

    End Sub
    Sub RectPacking()
        Dim ShiftX As Double
        Dim ShiftY As Double
        Dim IntCountX As Integer = CInt((xBase / MinDist - (xBase Mod MinDist))) * 2
        IntCountX = Val(TextBoxAtomCountLine.Text) 'GetAtomInLine()
        Dim AtomDefIndex As Integer = 0
        ShiftX = (xBase - (IntCountX * MinDist) / 2)
        ShiftY = ShiftX
        For L = 0 To 0
            For i = 1 To IntCountX
                For j = 1 To IntCountX
                    X(AtomDefIndex) = -xBase + ShiftX + MinDist * (i)
                    Y(AtomDefIndex) = -xBase + ShiftY + MinDist * (j)
                    Z(AtomDefIndex) = L * MinDist
                    AtomDefIndex += 1

                Next
            Next
        Next
        If DimIndex = 3 Then
            Dim CountSloj As Integer = AtomDefIndex
            For L = 1 To Rows - 1
                For i = 1 To IntCountX
                    For j = 1 To IntCountX
                        X(AtomDefIndex) = X(AtomDefIndex - CountSloj)
                        Y(AtomDefIndex) = Y(AtomDefIndex - CountSloj)
                        Z(AtomDefIndex) = L * MinDist
                        ConfigP_C(AtomDefIndex) = ConfigP_C(AtomDefIndex - CountSloj)
                        AtomDefIndex += 1

                    Next
                Next
            Next
        End If
        AtomCount = AtomDefIndex
        Axis1.AtomCount = AtomCount


        For i = 0 To AtomCount - 1
            m(i) = mel
            Vx(i) = 0
            Vy(i) = 0
            Vz(i) = 0
        Next

    End Sub
    Private Sub GCK()

        'центральный атом
        X(0) = 0
        Y(0) = 0
        Z(0) = 0

        centerIndex = 0
        AtomDefIndex = 0
        AtomCount = 7
        For i = 1 To 6
            AtomDefIndex += 1
            Rotate(3, (i - 1) * PI / 3, MinDist, 0, 0, X(AtomDefIndex), Y(AtomDefIndex), Z(AtomDefIndex))
            AtomDefIndex += 1
            Rotate(3, (i - 1) * 2 * PI / 3, MinDist / 2, MinDist * Sqrt(2 / 3), MinDist / Sqrt(12), X(AtomDefIndex), Y(AtomDefIndex), Z(AtomDefIndex))

        Next

        If DimIndex = 3 Then
            For i = 1 To 3
                AtomDefIndex += 1
                Rotate(3, (i - 1) * 2 * PI / 3, MinDist / 2, MinDist * Sqrt(2 / 3), MinDist / Sqrt(12), X(AtomDefIndex), Y(AtomDefIndex), Z(AtomDefIndex))
                AtomDefIndex += 1
                Rotate(3, (i - 1) * 2 * PI / 3, MinDist / 2, -MinDist * Sqrt(2 / 3), MinDist / Sqrt(12), X(AtomDefIndex), Y(AtomDefIndex), Z(AtomDefIndex))
            Next

            AtomCount = 13
        End If

        Axis1.AtomCount = AtomCount

        For i = 0 To AtomCount - 1
            m(i) = mel
            Vx(i) = 0
            Vy(i) = 0
            Vz(i) = 0
        Next
        SortZ()
    End Sub
    Sub SortZ()
        Dim XX, YY, ZZ, Conf As Single
        Dim Priz As Boolean = False

        Do While Priz = False
            Priz = True
            For I = 0 To AtomCount - 2
                If Z(I) > Z(I + 1) Then
                    Priz = False
                    XX = X(I)
                    YY = Y(I)
                    ZZ = Z(I)
                    Conf = ConfigP_C(I)

                    X(I) = X(I + 1)
                    Y(I) = Y(I + 1)
                    Z(I) = Z(I + 1)
                    ConfigP_C(I) = ConfigP_C(I + 1)

                    X(I + 1) = XX
                    Y(I + 1) = YY
                    Z(I + 1) = ZZ
                    ConfigP_C(I + 1) = Conf
                End If
            Next

        Loop


    End Sub
    Sub Rotate(ByVal WhatAxis As Byte, ByVal Angle As Single, ByVal X As Single, ByVal Y As Single, ByVal Z As Single, _
               ByRef X1 As Single, ByRef Y1 As Single, ByRef Z1 As Single)
        Select Case WhatAxis
            Case 1 'X
                Y1 = Y * Cos(Angle) - Z * Sin(Angle)
                Z1 = Y * Sin(Angle) + Z * Cos(Angle)
                X1 = X
            Case 2 'Y
                X1 = Z * Sin(Angle) + X * Cos(Angle)
                Z1 = Z * Cos(Angle) - X * Sin(Angle)
                Y1 = Y
            Case 3 'Z
                X1 = X * Cos(Angle) - Y * Sin(Angle)
                Y1 = X * Sin(Angle) + Y * Cos(Angle)
                Z1 = Z

        End Select

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        tau += dtau
        tau1 += dtau
        TextBoxtau.Text = tau.ToString

        Xm = 0
        Ym = 0
        Zm = 0

        For i = 0 To AtomCount - 1
            Xm += X(i)
            Ym += Y(i)
            Zm += Z(i)
        Next
        Xm += Xm / AtomCount
        Ym += Ym / AtomCount
        Zm += Zm / AtomCount

        'силы

        For i = 0 To AtomCount - 1
            Fx(i) = 0
            Fy(i) = 0
            Fz(i) = 0
            For j = 0 To AtomCount - 1
                If i <> j Then
                    rij = Sqrt((X(i) - X(j)) ^ 2 + (Y(i) - Y(j)) ^ 2 + (Z(i) - Z(j)) ^ 2)
                    DUDR = 24 * ((1 / rij) ^ 7 - 2 * (1 / rij) ^ 13) / rij
                    Fx(i) += (DUDR * (X(j) - X(i)) / rij)
                    Fy(i) += (DUDR * (Y(j) - Y(i)) / rij)
                    Fz(i) += (DUDR * (Z(j) - Z(i)) / rij)

                End If

            Next

        Next
        'ускорения, скорости, координаты
        For i = 0 To AtomCount - 1

            ax = Fx(i) / m(i)
            ay = Fy(i) / m(i)
            az = Fz(i) / m(i)

            Vxk(i) = Vx(i) + ax * dtau
            Vyk(i) = Vy(i) + ay * dtau
            Vzk(i) = Vz(i) + az * dtau

            Xk(i) = X(i) + dtau * (Vx(i) + Vxk(i)) / 2 + ax * (dtau ^ 2) / 2
            Yk(i) = Y(i) + dtau * (Vy(i) + Vyk(i)) / 2 + ay * (dtau ^ 2) / 2
            Zk(i) = Z(i) + dtau * (Vz(i) + Vzk(i)) / 2 + az * (dtau ^ 2) / 2

        Next

        'ЭНЕРГИЯ

        KinE = 0
        KinEc = 0
        KinEp = 0
        PotE = 0
        Rgir = 0

        For i = 0 To AtomCount - 2
            For j = i + 1 To AtomCount - 1
                rij = Sqrt((X(i) - X(j)) ^ 2 + (Y(i) - Y(j)) ^ 2 + (Z(i) - Z(j)) ^ 2)
                PotE += 4 * ((1 / rij) ^ 12 - (1 / rij) ^ 6)
                Rgir += rij

            Next

        Next

        AtomCountC = 0
        AtomCountP = 0
        KSI = 0
        For i = 0 To AtomCount - 1
            KinE += m(i) * (((Vx(i) + Vxk(i)) / 2) ^ 2 + ((Vy(i) + Vyk(i)) / 2) ^ 2 + ((Vz(i) + Vzk(i)) / 2) ^ 2) / 2
            If ConfigP_C(i) = 1 Then
                AtomCountC += 1
                KinEc += m(i) * (((Vx(i) + Vxk(i)) / 2) ^ 2 + ((Vy(i) + Vyk(i)) / 2) ^ 2 + ((Vz(i) + Vzk(i)) / 2) ^ 2) / 2
            ElseIf ConfigP_C(i) = 2 Then
                AtomCountP += 1
                KinEp += m(i) * (((Vx(i) + Vxk(i)) / 2) ^ 2 + ((Vy(i) + Vyk(i)) / 2) ^ 2 + ((Vz(i) + Vzk(i)) / 2) ^ 2) / 2
            End If
            KSI += Sqrt((X(i) - Xm) ^ 2 + (Y(i) - Ym) ^ 2 + (Z(i) - Zm) ^ 2) 'связность
        Next
        Tcl = (KinE / AtomCount / 3) * Epsilon(PotencialIndex)

        If AtomCountC > 0 Then
            Tc = (KinEc / AtomCountC / 3) * Epsilon(PotencialIndex)
            Tcaver += Tc * dtau
        End If
        If AtomCountP > 0 Then
            Tp = (KinEp / AtomCountP / 3) * Epsilon(PotencialIndex)
            Tpaver += Tp * dtau

        End If

        Tclaver += Tcl * dtau
        TextBoxTcl.Text = Tcl.ToString
        FullE = PotE + KinE


        For i = 0 To AtomCount - 1

            Vx(i) = Vxk(i)
            Vy(i) = Vyk(i)
            Vz(i) = Vzk(i)

            X(i) = Xk(i)
            Y(i) = Yk(i)
            Z(i) = Zk(i)

        Next

        'Timer1.Enabled = False
        'SortZ()
        ShowAtoms()
        'Timer1.Enabled = True

        AxisE.PixDraw(tau, (PotE - PotE0) / AtomCount, Color.Blue, 1)
        AxisE.PixDraw(tau, KinE / AtomCount, Color.Red, 1)
        AxisE.PixDraw(tau, (FullE - PotE0) / AtomCount, Color.Black, 1)
        AxisE.StatToPic()

        If Abs(PotE) > 0 Then

            AxisKinEPotE.PixDraw(tau, Abs(KinE / PotE), Color.Blue, 1)
            AxisKinEPotE.StatToPic()
        End If

        AxisGir.PixDraw(tau, 2 * Rgir / (AtomCount * (AtomCount - 1)), Color.Black, 1)
        AxisGir.PixDraw(tau, KSI / AtomCount, Color.Blue, 1)
        AxisGir.PixDraw(tau, 1.122, Color.Red, 1)
        AxisGir.StatToPic()

        AxisT.PixDraw(tau, Tcl, Color.LightCoral, 1)
        AxisT.PixDraw(tau, Tc, Color.LightYellow, 1)
        AxisT.PixDraw(tau, Tp, Color.LightGreen, 1)
        AxisT.PixDraw(tau, Tclaver / tau1, Color.Red, 1)
        AxisT.PixDraw(tau, Tcaver / tau1, Color.Yellow, 1)
        AxisT.PixDraw(tau, Tpaver / tau1, Color.Green, 1)
        AxisT.StatToPic()


        TextBoxE.Text = (2 * Rgir / (AtomCount * (AtomCount - 1))).ToString

        If tau > AxisE.x_Base Then
            tau = 0

            AxisE.AxisDraw()
            AxisGir.AxisDraw()
            AxisT.AxisDraw()
            AxisKinEPotE.AxisDraw()
        End If
    End Sub


    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click

        TextBoxAtomCount.Text = Axis1.AtomCount.ToString
        AtomCount = Axis1.AtomCount
        If Axis1.AtomCount = 0 Then
            MsgBox("Нет атомов")
            Exit Sub

        End If
        If FirstStart Then
            AtomCount = Axis1.AtomCount
            For i = 0 To AtomCount - 1
                'X(i) = Axis1.ClickArrayPhysX(i)
                'Y(i) = Axis1.ClickArrayPhysY(i)

                m(i) = mel
                Vx(i) = 0
                Vy(i) = 0
                Vz(i) = 0
            Next
            ' Axis1.AxisDraw()
            If ConfigurationIndex = 3 Then InitGraph()
            'ShowAtoms()
            FirstStart = False
        End If


        Timer1.Enabled = True

    End Sub

    Private Sub ButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        Timer1.Enabled = False
    End Sub



    Private Sub MolDinamics_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        GroupBox1.Top = 0
        GroupBox1.Left = Me.DisplayRectangle.Width - GroupBox1.Width

        Axis1.Left = 0
        Axis1.Top = 0
        Axis1.Height = Me.DisplayRectangle.Height
        Axis1.Width = Axis1.Height

        AxisE.Left = Axis1.Width
        AxisE.Width = Me.DisplayRectangle.Width - Axis1.Width - GroupBox1.Width
        AxisE.Top = 0
        AxisE.Height = Axis1.Height / 6

        AxisKinEPotE.Height = Axis1.Height / 6
        AxisKinEPotE.Left = Axis1.Width
        AxisKinEPotE.Width = Me.DisplayRectangle.Width - Axis1.Width - GroupBox1.Width
        AxisKinEPotE.Top = AxisE.Height + AxisE.Top
        AxisKinEPotE.Height = Axis1.Height / 6


        AxisGir.Left = Axis1.Width
        AxisGir.Width = Me.DisplayRectangle.Width - Axis1.Width - GroupBox1.Width
        AxisGir.Top = AxisKinEPotE.Height + AxisKinEPotE.Top
        AxisGir.Height = Axis1.Height / 6

        AxisT.Left = Axis1.Width
        AxisT.Width = Me.DisplayRectangle.Width - Axis1.Width - GroupBox1.Width
        AxisT.Top = AxisGir.Height + AxisGir.Top
        AxisT.Height = Axis1.Height / 3

        InitConfiguration()
    End Sub

    Private Sub CheckBoxGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CheckBoxGrid.Checked Then Axis1.GridOn = True Else Axis1.GridOn = False
        InitConfiguration()
        ShowAtoms()
    End Sub

    Public Sub ShowAtoms()        'AxisDraw()
        If ViewAtom = False Or AtomCount = 0 Then Exit Sub
        Dim PixPenColor As Color
        Axis1.StatToDin()
        For i = 0 To AtomCount - 1
            If ConfigP_C(i) = 1 Then
                PixPenColor = Color.Orange
                Axis1.PixBrush.Color = Color.DarkOrange

            ElseIf ConfigP_C(i) = 2 Then
                PixPenColor = Color.Green
                Axis1.PixBrush.Color = Color.DarkGreen

            Else
                PixPenColor = Color.Red
                Axis1.PixBrush.Color = Color.DarkRed
            End If
            If Axis1.Axis_Type = 5 Then _
                  Axis1.PixDraw(X(i), Y(i), Z(i), PixPenColor, 2) Else _
                  Axis1.PixDraw(X(i), Y(i), PixPenColor, 2)
            If BreakOn Then Exit For
        Next
        Axis1.DinToPic()
    End Sub
    Sub ClearMarkColor()
        For i = 0 To AtomCount - 1
            ConfigP_C(i) = 0
        Next
    End Sub
    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Timer1.Enabled = False
        ClearMarkColor()
        If CheckBoxAtom.Checked Then
            AtomCount = 0
            TextBoxAtomCount.Text = "0"
            Axis1.AtomCount = 0
        End If

        InitConfiguration()
    End Sub

    Private Sub ButtonLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLess.Click
        For i = 0 To AtomCount - 1
            Vx(i) = Sqrt(0.9) * Vx(i)
            Vy(i) = Sqrt(0.9) * Vy(i)
        Next
    End Sub

    Private Sub ButtonMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMore.Click
        For i = 0 To AtomCount - 1
            Vx(i) = Sqrt(1.1) * Vx(i)
            Vy(i) = Sqrt(1.1) * Vy(i)
        Next

    End Sub

    Private Sub RadioButtonNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonNormal.CheckedChanged
        If RadioButtonNormal.Checked Then SelectMode = 0
    End Sub

    Private Sub RadioButtonCenter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonCenter.CheckedChanged
        If RadioButtonCenter.Checked Then SelectMode = 1
    End Sub

    Private Sub RadioButtonPerif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPerif.CheckedChanged
        If RadioButtonPerif.Checked Then SelectMode = 2
    End Sub

    Private Sub CheckBoxAtom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxAtom.CheckedChanged
        If CheckBoxAtom.Checked Then ViewAtom = True Else ViewAtom = False
    End Sub

    Private Sub CheckBoxGrid_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxGrid.CheckedChanged
        If CheckBoxGrid.Checked Then Axis1.GridOn = True Else Axis1.GridOn = False
        If RadioButtonRect.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = MinDist
            Axis1.GridType = 1
        ElseIf RadioButtonTriangl.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = Sqrt(3) * MinDist / 2
            Axis1.GridType = 2
        Else
            Axis1.GridType = 0
        End If

    End Sub

    Private Sub RadioButtonTriangl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTriangl.CheckedChanged
        If RadioButtonRect.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = MinDist
            Axis1.GridType = 1
        ElseIf RadioButtonTriangl.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = Sqrt(3) * MinDist
            Axis1.GridType = 2
        Else
            Axis1.GridType = 0
        End If
    End Sub

    Private Sub RadioButtonRect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonRect.CheckedChanged
        If RadioButtonRect.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = MinDist
            Axis1.GridType = 1
        ElseIf RadioButtonTriangl.Checked Then
            Axis1.GridStepX = MinDist
            Axis1.GridStepY = Sqrt(3) * MinDist / 2
            Axis1.GridType = 2
        Else
            Axis1.GridType = 0
        End If
    End Sub

    
    Private Sub ListBoxConfiguration_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxConfiguration.SelectedIndexChanged

    End Sub

    Private Sub ListBoxConfiguration_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxConfiguration.TabStopChanged

    End Sub
End Class