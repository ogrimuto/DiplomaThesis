
namespace WindowsApplication1
{
    static class Module1
    {
        public static int PropIndex;
        public static int selMatterIndex;
        public static double[,] F = new double[619, 33];
        public static double T;
        public static byte PotencialIndex;

        public static double[] Sigma = new double[101], Epsilon = new double[101], MM = new double[101];

        // _____________MD

        public const int AtomCountmax = 1000000;
        public static byte ConfigurationIndex;
        public static byte DimIndex = 2; // 2D
        public static byte selMatterPotencialIndex;

        public static int AtomCount, AtomCountP, AtomCountC, AtomCountLine, AtomCountAll;
        public static double MinDist; // минимальное расстояние между атомами
        public static double[] X = new double[1000001], Y = new double[1000001], Z = new double[1000001];
        public static double[] Vx = new double[1000001], Vy = new double[1000001], Vz = new double[1000001];
        public static double[] Xk = new double[1000001], Yk = new double[1000001], Zk = new double[1000001];
        public static double[] Vxk = new double[1000001], Vyk = new double[1000001], Vzk = new double[1000001];
        public static double[] Fx = new double[1000001], Fy = new double[1000001], Fz = new double[1000001];
        public static byte[] ConfigP_C = new byte[1000001]; // 
        public static double[] m = new double[1000001];
        public static double Uij, ax, ay, az;
        public static double tau, tau1, dtau; // время
        public static byte GridType;
        public static byte SelectMode; // 1-green,2- orange
        public static bool ViewAtom = true;
        public static bool BreakOn = false;
        public static double Mel = 1d;
        public static int Rows = 1;



        public static string GetConnStr(string sourceName)
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
    }
}