Module Module1
    Public PropIndex As Integer
    Public selMatterIndex As Integer
    Public F(618, 32) As Double
    Public T As Double
    Public PotencialIndex As Byte

    Public Sigma(100), Epsilon(100), MM(100) As Double

    '_____________MD

    Public Const AtomCountmax = 1000000
    Public ConfigurationIndex As Byte
    Public DimIndex As Byte = 2 '2D
    Public selMatterPotencialIndex As Byte

    Public AtomCount, AtomCountP, AtomCountC, AtomCountLine, AtomCountAll As Integer
    Public MinDist As Double 'минимальное расстояние между атомами
    Public X(AtomCountmax), Y(AtomCountmax), Z(AtomCountmax) As Double
    Public Vx(AtomCountMax), Vy(AtomCountMax), Vz(AtomCountMax) As Double
    Public Xk(AtomCountMax), Yk(AtomCountMax), Zk(AtomCountMax) As Double
    Public Vxk(AtomCountMax), Vyk(AtomCountMax), Vzk(AtomCountMax) As Double
    Public Fx(AtomCountmax), Fy(AtomCountmax), Fz(AtomCountmax) As Double
    Public ConfigP_C(AtomCountmax) As Byte '
    Public m(AtomCountmax) As Double
    Public Uij, ax, ay, az As Double
    Public tau, tau1, dtau As Double 'время
    Public GridType As Byte
    Public SelectMode As Byte '1-green,2- orange
    Public ViewAtom As Boolean = True
    Public BreakOn As Boolean = False
    Public Mel As Double = 1
    Public Rows As Integer = 1



    Public Function GetConnStr(ByVal sourceName As String) As String
        GetConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=True;Data Source=" & sourceName
        '        If InStr(CurDir$, "A") > 0 Then
        '            ChDrive Mid(App.path, 1, 1)
        '            ChDir App.path
        '        End If
        'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\free\Struc.TDN;Persist Security Info=True;Jet OLEDB:Database Password=123
    End Function
End Module





