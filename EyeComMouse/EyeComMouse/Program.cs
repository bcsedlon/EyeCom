using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tobii.EyeX;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows;

namespace EyeComMouse
{
    static class Program
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("User32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        //[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        //private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr CreateCursor(IntPtr hInst, int xHotSpot, int yHotSpot, int nWidth, int nHeight, byte[] pvANDPlane, byte[] pvXORPlane);
        /*
        static byte[] andMaskCursor = new byte[]
        { 
            0xFF, 0xFC, 0x3F, 0xFF,   // line 1 
            0xFF, 0xC0, 0x1F, 0xFF,   // line 2 
            0xFF, 0x00, 0x3F, 0xFF,   // line 3             

            0xFF, 0xC3, 0xFF, 0xFF,   // line 31 
            0xFF, 0xFF, 0xFF, 0xFF    // line 32 
        };
        static byte[] xorMaskCursor = new byte[]
        { 
            0x00, 0x00, 0x00, 0x00,   // line 1 
            0x00, 0x03, 0xC0, 0x00,   // line 2 
            0x00, 0x3F, 0x00, 0x00,   // line 3             

            0x00, 0x00, 0x00, 0x00,   // line 31 
            0x00, 0x00, 0x00, 0x00    // line 32 
        };
        */

        static public bool bEnable = true;
        static public int screenHeight, screenWidth;
        static public int topOffset = 200;
        static public int radiusSpeed = 1;
        static int radius;
        static int radiusInit = 20;
        static int radiusLimit = 60;
        static int X;
        static int Y;
        static int lastX;
        static int lastY;

        static public int columnsCount = 6;
        static public int rowsCount = 4;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;           
        }

        static public int cellWidth, cellHeight; 

        public static void saveSettings()
        {
            Properties.Settings.Default["Rows"] = Program.columnsCount;
            Properties.Settings.Default["Columns"] = Program.rowsCount;
            Properties.Settings.Default["Top"] = Program.topOffset;
            Properties.Settings.Default["Speed"] = Program.radiusSpeed;
            Properties.Settings.Default.Save();
        }

        public static void loadSettings()
        {
            Program.columnsCount = (int)Properties.Settings.Default["Rows"];
            Program.rowsCount = (int)Properties.Settings.Default["Columns"];
            Program.topOffset = (int)Properties.Settings.Default["Top"];
            Program.radiusSpeed = (int)Properties.Settings.Default["Speed"];
        }

        delegate void GazeHook(double x, double y);
        static private void GazeHookFunc(double x, double y)
        {
            int cellX = (int)x / cellWidth;
            cellX = cellX * cellWidth + cellWidth / 2;
            
            int cellY = ((int)y - topOffset) / cellHeight;
            cellY = cellY * cellHeight + cellHeight / 2;
            cellY += topOffset;

            X = cellX;
            Y = cellY;

            if (bEnable)
            {
                SetCursorPos(X, Y);
            }

            //POINT lpPoint;
            //GetCursorPos(out lpPoint);
            //Console.WriteLine("M X: {0} Y:{1}", lpPoint.X, lpPoint.Y);
            Console.WriteLine("G X: {0} Y:{1}", (int)x, (int)y);

            /*
            int grid = 1;
            int i = (int)x / grid;
            Program.x = i * grid;
            i = (int)y / grid;
            Program.y = i * grid;
             * */
            //SetCursorPos((int)x, (int)y);

            //if (cellY > screenHeight || cellY < topOffset)
            //    return;

            //SetCursorPos(cellX, cellY);
            //DrawCursor((int)x, (int)y);
            //xOnPaint();
        }

        

        static private void DrawCursor(int x, int y, int r)
        {
            //Cursor.Current = new Cursor(c(r));
            //return;
            
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            
            Graphics g = Graphics.FromHdc(desktopPtr);
            //SolidBrush b = new SolidBrush(Color.GreenYellow);
            SolidBrush b = new SolidBrush(Color.FromArgb(15, 0, 255, 0));
            Pen p = new Pen(Color.Black);
            //Pen p = new Pen(b);
            g.DrawEllipse(p, x - radiusLimit, y - radiusLimit,  radiusLimit * 2, radiusLimit * 2);           
            g.FillEllipse(b, x - r, y - r,  r * 2, r * 2);
            b.Dispose();
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desktopPtr);

            //InvalidateRect(desktopPtr, new Rectangle(x, y, 10, 10), true);
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, false);
            //InvalidateRect(IntPtr.Zero, IntPtr(new Rectangle(x, y, 10, 10)), true);
            //g.FillRectangle(b, new Rectangle(x, y, 10, 10));            
            //SolidColorBrush b = new SolidColorBrush();
            //IntPtr desktopDC = GetDC(IntPtr.Zero);
            //Graphics g = Graphics.FromHdc(desktopDC);
            //g.FillEllipse(b, 0, 0, 1024,7 68);
            //g.Dispose();
            //LineTo(hdc, LOWORD(lParam), HIWORD(lParam)); 
            //Ellipse(desktopDC, (int)x, (int)y, 200, 200);
            //ReleaseDC(desktopDC);
        }

        static private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!bEnable)
            {
                return;
            }

            //POINT lpPoint;
            //GetCursorPos(out lpPoint);
            //GazeHookFunc(lpPoint.X, lpPoint.Y);

            //TODO:
            if (Y > screenHeight + topOffset || Y < topOffset)
            {
                //radius = radiusInit;
                //InvalidateRect(IntPtr.Zero, IntPtr.Zero, false);
                return;
            }
            
            if (X != lastX || Y != lastY)
            {
                SetCursorPos(X, Y);
            }

            if (Math.Abs(X - lastX) < radiusInit && Math.Abs(Y - lastY) < radiusInit)
            {
                if (radius <= radiusLimit)
                {
                    radius += radiusSpeed;

                    if (radius > radiusLimit)
                    {
                        //r += radiusSpeed;
                        InvalidateRect(IntPtr.Zero, IntPtr.Zero, false);
                        //Rect rect = new Rect(10, 20, 10, 20);
                        //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(rect));
                        //Marshal.StructureToPtr(rect, p, false);
                        //InvalidateRect(IntPtr.Zero, p, false);
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)lastX, (uint)lastY, 0, 0);
                    }
                }
            }
            else
            {
                radius = radiusInit;
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, false);
                //Rect rect = new Rect(10, 20, 10, 20);
                //IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(rect));
                //Marshal.StructureToPtr(rect, p, false);
                //InvalidateRect(IntPtr.Zero, p, false);
                                
                lastX = X;
                lastY = Y;
            }
            if (radius < radiusLimit)
            {
                //if (x != xPrev)
                {
                    //SetCursorPos(xPrev, yPrev);
                    DrawCursor(lastX, lastY, radius);
                }
            }
        }

        static void OnGlobalMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y > screenHeight + topOffset || e.Y < topOffset)
            {
                //radius = radiusInit;
                X = -1;
                Y = -1;
                return;
            }
            
            //Console.WriteLine(e.Location.ToString());
            if(e.X != X && e.Y != Y) {
                Console.WriteLine("M X: {0} Y:{1}", e.X, e.Y);
                int cellX = e.X / cellWidth;
                cellX = cellX * cellWidth + cellWidth / 2;

                int cellY = (e.Y - topOffset) / cellHeight;
                cellY = cellY * cellHeight + cellHeight / 2;
                cellY += topOffset;

                X = cellX;
                Y = cellY;
            }
        }
        class MouseMessageFilter : IMessageFilter
        {
            public static event MouseEventHandler MouseMove = delegate { };
            const int WM_MOUSEMOVE = 0x0200;

            public bool PreFilterMessage(ref Message m)
            {
                //if (m.Msg == WM_MOUSEMOVE)
                {
                    System.Drawing.Point mousePosition = Control.MousePosition;
                    MouseMove(null, new MouseEventArgs(MouseButtons.None, 0, mousePosition.X, mousePosition.Y, 0));
                }
                return false;
            }
        }

        /*
        static IntPtr c(int radius)
        {
            int sideLength = radius * 2;
            if (sideLength % 16 != 15)
            {
                sideLength = sideLength + 16 - sideLength % 16;
            }
            int length = sideLength * sideLength / 8;
            byte[] andMaskCursor = new byte[length];
            byte[] xorMaskCursor = new byte[length];
            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    double x = i - radius;
                    double y = j - radius;
                    double pRadius = Math.Pow(
            Math.Pow(x, 2) + Math.Pow(y, 2), 0.5
            );
                    if ((int)pRadius != radius)
                    {
                        int ii = (i * sideLength) + j;
                        andMaskCursor[ii / 8] =
                        (byte)Math.Pow(2, 7 - ii % 8);
                    }
                }
            }
            IntPtr handle = IntPtr.Zero;// 0x0400000;
            IntPtr cursorHandle = CreateCursor(
               handle,             // app. instance 
               radius,             // hot spot horiz pos
               radius,             // hot spot vert pos 
               sideLength,         // cursor width 
               sideLength,         // cursor height 
               andMaskCursor,      // AND mask 
               xorMaskCursor       // XOR mask 
            );
            return cursorHandle;
        }
        */

        static public void setParams()
        {
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height - topOffset;
            float screenRatio = (float)screenWidth / (float)screenHeight;
            cellWidth = screenWidth / columnsCount;
            //cellHeight = (int)((float)screenHeight / (float)columnsCount * screenRatio);
            cellHeight = (int)((float)screenHeight / (float)rowsCount);

            int cellX = X / cellWidth;
            cellX = cellX * cellWidth + cellWidth / 2;

            int cellY = (Y - topOffset) / cellHeight;
            cellY = cellY * cellHeight + cellHeight / 2;
            cellY += topOffset;

            X = cellX;
            Y = cellY;

            //X = 0;
            //Y = 0;
            lastX = X;
            lastY = Y;
            //r = rInit;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loadSettings();
            setParams();

            var host = new Tobii.Interaction.Host();
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            //gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => Console.WriteLine("X: {0} Y:{1}", gazePointX, gazePointY));

            GazeHook gazeHookTarget;
            gazeHookTarget = GazeHookFunc;
            gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => gazeHookTarget(gazePointX, gazePointY));

            //IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
            //if (hook == IntPtr.Zero) throw new System.ComponentModel.Win32Exception();
            //return hook;

            Application.AddMessageFilter(new MouseMessageFilter());
            MouseMessageFilter.MouseMove += new MouseEventHandler(OnGlobalMouseMove);

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
