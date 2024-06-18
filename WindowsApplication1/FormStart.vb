Imports System.Math

Public Class FormStart
    Dim Vts As Integer 'потенциалы с твердой сферой
    Dim Vlj As Integer 'Потенциал Леннарда-Джонса
    Dim Vmorze As Integer ' Потенциал Морзе
    Dim Vpt As Integer ' Потенциал Пешля–Теллера
    Dim Vbuk As Integer 'Потенциал Букингема
    Dim Vrid As Integer ' Потенциал Ридберга
    Dim V As Integer
    Dim b As Integer ' коэффициент потенциала Ридберга
    Dim r As Integer
    Dim SigmaNum As Integer
    Dim a As Integer
    Dim Eb As Integer 'глубина потенциальной ямы
    Dim alf As Integer 'крутизна экспоненциального отталкивания
    Dim rm As Integer 'значение r в min
    Dim sh As Integer '
    Dim ch As Integer


    Public Function GetConnStr(ByVal sourceName As String) As String
        GetConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=True;Data Source=" & sourceName
        '        If InStr(CurDir$, "A") > 0 Then
        '            ChDrive Mid(App.path, 1, 1)
        '            ChDir App.path
        '        End If
        'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\free\Struc.TDN;Persist Security Info=True;Jet OLEDB:Database Password=123
    End Function
    Sub OpenDB()
        Dim ConnStr As String
        ConnStr = GetConnStr("Lenard_D.MDB")
        Dim Conn As New OleDb.OleDbConnection(ConnStr)

        Dim SQLString As String = "Select * From Tab1 Where Potencial=" + PotencialIndex.ToString
        Dim ReadUpdate As New clsOleDBReadUpdateDB(ConnStr, SQLString)
        ReadUpdate.stSelect = SQLString
        ReadUpdate.ReadFieldToListBox(ListBox1, 0)

        ReadUpdate.ReadFieldToArray(Sigma, 1)
        ReadUpdate.ReadFieldToArray(Epsilon, 2)
        ReadUpdate.ReadFieldToArray(MM, 3)

        Select Case PotencialIndex

            Case 1

            Case 2
                'Lenard


            Case 3

            Case 4
            Case 5
            Case 6


        End Select





    End Sub
    Sub InitAxis()

        Axis1.x_Base = 10
        Axis1.y_Base = 700
        Axis1.Axis_Type = 2
        Axis1.x_Name = "r, A"
        Axis1.y_Name = "U, K"
        Axis1.Pix_type = 1
        Axis1.Pix_Size = 0.004
        Axis1.AxisDraw()


    End Sub



    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If r < SigmaNum Then Vts = V
        If SigmaNum < r < a * SigmaNum Then Vts = -Eb
        If r > a * SigmaNum Then Vts = 0

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        'L-D

        If CheckBox2.Checked Then
            PotencialIndex = 2
            OpenDB()

        End If
        selMatterPotencialIndex = 0
        ListBox1.SelectedIndex = 0


    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

        Vbuk = (Eb / 1 - (6 / alf)) * ((6 / alf) * Exp(alf * (1 - (r / rm))) - (rm / r) ^ 6)

    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged

        Vmorze = Eb * (Exp(-2 * alf * (r - rm)) - 2 * Exp(-alf * (r - rm)))

    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged

        Vpt = Eb * ((sh ^ 4 * (0.5 * alf * rm) / sh ^ 2 * (alf)) - (ch ^ 4 * (0.5 * alf * rm) / ch ^ 2 * (alf)))

    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged

        Vrid = -Eb * (1 + (b / rm) * (r - rm)) * Exp(-(b / rm) * (r - rm))

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitAxis()
        CheckBox2.Checked = True
    End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim r, dr As Double
        selMatterPotencialIndex = ListBox1.SelectedIndex
        r = 2
        dr = Axis1.x_Base / 1000
        Do Until r >= Axis1.x_Base
            r += Dr
            Vlj = 4 * Epsilon(ListBox1.SelectedIndex) * ((Sigma(ListBox1.SelectedIndex) / r) ^ 12 - (Sigma(ListBox1.SelectedIndex) / r) ^ 6)
            Axis1.PixDraw(r - 2, Vlj, Color.Blue, 1)
        Loop
        TextBoxSigma.Text = Sigma(ListBox1.SelectedIndex).ToString
        TextBoxEpsilon.Text = Epsilon(ListBox1.SelectedIndex).ToString
        MolDinamics.TextBoxM.Text = MM(ListBox1.SelectedIndex).ToString
        Axis1.StatToPic()
    End Sub



    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBase.Click
        FormBase.Show()
    End Sub

    Private Sub ButtonParameter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParameter.Click
        FormParameter.Show()
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MolDinamics.ShowDialog()
    End Sub

  
End Class
