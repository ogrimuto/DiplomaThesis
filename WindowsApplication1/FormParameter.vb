Imports System.Data.OleDb
Imports System.Math
Public Class FormParameter
    Dim Conn As New OleDbConnection
    Dim Da As OleDbDataAdapter
    Dim DS As New DataSet
    Dim Table As DataTable
    Dim NKL As Integer

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ConnStr As String = GetConnStr("Prop.MDB")
        Conn.ConnectionString = ConnStr
        Conn.Open()

        Da = New OleDbDataAdapter("Select * From TablePROP", Conn)

        Da.Fill(DS)
        Table = DS.Tables(0)

        For i = 0 To 617

            ListBox1.Items.Add(Table.Rows(i)("Title"))

            For j = 4 To Table.Columns.Count - 1
                F(i, j - 3) = Table.Rows(i)(j)
            Next

        Next

        'For i = 0 To 617
        '    For j = 4 To Table.Columns.Count - 1
        '        F(i, j - 3) = Table.Rows(i)(j)
        '    Next
        'Next

        Dim T0 As Double
        Dim OM As Double
        Dim AL As Double

        For j = 0 To 617

            If F(j, 27) < 1 Then F(j, 27) = F(j, 2)
            If F(j, 28) < 1 Then F(j, 28) = F(j, 4)
            If Abs(F(j, 8)) < 0.001 And F(j, 3) > 0.1 And F(j, 4) > 0.1 And F(j, 5) > 0 Then
                T0 = F(j, 3) / F(j, 4)
                'ФАКТОР АЦЕНТРИЧНОСТИ ПО ЛИ-КЕСЛЕРУ	
                OM = (-Log(F(j, 5) / 1.01325) - 5.92714 + 6.09648 / T0 + 1.28862 * Log(T0) - _
                      0.169347 * T0 ^ 6) / (15.2518 - 15.6875 / T0 - 13.4721 * Log(T0) + _
                      0.43577 * T0 ^ 6)
                F(j, 8) = OM
            End If
            F(j, 16) = Round(F(j, 16) + 273.15, 2)
            F(j, 17) = Round(F(j, 17) + 273.15, 2)
            F(j, 25) = j
            F(j, 5) = F(j, 5) * 100000
            If (F(j, 11) > -0.1) Then F(j, 11) = F(j, 11) / 3.162E+24
            F(j, 18) = F(j, 18) * 1000
            F(j, 19) = F(j, 19) * 1000
            Dim TT As Double
            If (F(j, 6) < 0.0001 And F(j, 4) > 0.001 And F(j, 5) > 0.001) Then
                TT = F(j, 3) / F(j, 4)
                'ридель критический объем
                AL = 0.9076 * (1 + TT * Log(F(j, 5) / 100000) / (1 - TT))
                F(j, 6) = 8314 * F(j, 4) / F(j, 5) / (3.72 + 0.26 * (AL - 7))
            Else
                F(j, 6) = F(j, 6) / 1000
            End If
            If (F(j, 7) < 0.0001 And F(j, 4) > 0.001) Then
                F(j, 7) = F(j, 6) * F(j, 5) / 8314 / F(j, 4)
            End If
            F(j, 9) = F(j, 9) * 1000

        Next

        selMatterIndex = 1
        ' ViewPropStart()
        ListBox1.SelectedIndex = 0
        NKL = 1
    End Sub

    Private Sub FormParameter_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ListBox1.Top = 0
        ListBox1.Left = 0
        ListBox1.Height = Me.DisplayRectangle.Height
        DataGridView1.Top = 0
        DataGridView1.Left = ListBox1.Width
        DataGridView1.Width = Me.DisplayRectangle.Width - ListBox1.Width
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        'отразить выбранный параметр

        selMatterIndex = ListBox1.SelectedIndex + 1

        DataGridView1.Rows.Add()
        DataGridView1.Item(0, DataGridView1.RowCount - 1).Value = ListBox1.Items(ListBox1.SelectedIndex)
        DataGridView1.Item(1, DataGridView1.RowCount - 1).Value = F(selMatterIndex, 1)
        DataGridView1.Item(2, DataGridView1.RowCount - 1).Value = F(selMatterIndex, 11)
        DataGridView1.Item(5, DataGridView1.RowCount - 1).Value = PotencialIndex.ToString
        DataGridView1.Item(4, DataGridView1.RowCount - 1).Value = F(selMatterIndex, 3)


    End Sub

  
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
       
    End Sub
End Class