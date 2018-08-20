using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;
using System.Media;
using System.Drawing;

using System.Runtime.InteropServices;


namespace WpfApplication1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool Ellipse(IntPtr hdc, int x1, int y1, int x2, int y2);
        /*
        protected  void xOnPaint()//PaintEventArgs e)
        {
            SolidColorBrush b = new SolidColorBrush();
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            //Graphics g = Graphics.FromHdc(desktopDC);
            //g.FillEllipse(b, 0, 0, 1024,7 68);
            //g.Dispose();
            //LineTo(hdc, LOWORD(lParam), HIWORD(lParam)); 
            //Ellipse(desktopDC, (int)x, (int)y, 200, 200);
            ReleaseDC(desktopDC);
        }
        */
        byte a = 0;
        double w, h = 0.0;
        Canvas cvs = null;
        Button btn = null;
        String setName = "menu0";
        Image imagePie = null;

        double x, y;
        /*
        SoundPlayer player = null;
        SoundPlayer player_r0c0 = new System.Media.SoundPlayer("./res/r0c0.wav");
        SoundPlayer player_r0c1 = new System.Media.SoundPlayer("./res/r0c1.wav");
        SoundPlayer player_r0c2 = new System.Media.SoundPlayer("./res/r0c2.wav");
        SoundPlayer player_r0c3 = new System.Media.SoundPlayer("./res/r0c3.wav");
        SoundPlayer player_r1c0 = new System.Media.SoundPlayer("./res/r1c0.wav");
        SoundPlayer player_r1c1 = new System.Media.SoundPlayer("./res/r1c1.wav");
        SoundPlayer player_r1c2 = new System.Media.SoundPlayer("./res/r1c2.wav");
        SoundPlayer player_r1c3 = new System.Media.SoundPlayer("./res/r1c3.wav");                  
        */

        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

            //carImg[i] = new Image();
            //carImg[i].Source = carBitmap;
            //carImg[i].Width = carBitmap.Width;
            //carImg[i].Height = carBitmap.Height; 
            BitmapImage bitmapImagePie = new BitmapImage(new Uri("pack://application:,,,/res/pie.png"));
            imagePie = new Image();
            imagePie.Source = bitmapImagePie;
            /*
            Ellipse ce = new Ellipse();
            SolidColorBrush f = new SolidColorBrush();
            f.Color = Color.FromArgb(100, 0, 255, 0);
            ce.Fill = f;
            ce.StrokeThickness = 1;
            ce.Stroke = Brushes.Black;
            ce.Width = 50;
            ce.Height = 50;
            ((Canvas)this.canvas).Children.Add(ce);
            */

        }


        private void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Debug.WriteLine(((Button)sender).Name);
            Button b = (Button)sender;
            b.BringIntoView();
            focus(sender, b.IsEnabled);
        }

        private void focus(object sender, bool isEnabled)
        {
            Button b = (Button)sender;

            ((Canvas)this.r0c0).Children.Clear();
            ((Canvas)this.r0c1).Children.Clear();
            ((Canvas)this.r0c2).Children.Clear();
            ((Canvas)this.r0c3).Children.Clear();

            ((Canvas)this.r1c0).Children.Clear();
            ((Canvas)this.r1c1).Children.Clear();
            ((Canvas)this.r1c2).Children.Clear();
            ((Canvas)this.r1c3).Children.Clear();

            ((Canvas)this.menu0).Children.Clear();
            ((Canvas)this.menu1).Children.Clear();
            ((Canvas)this.menu2).Children.Clear();
            ((Canvas)this.menu3).Children.Clear();
            ((Canvas)this.menu4).Children.Clear();
            ((Canvas)this.menu5).Children.Clear();



            //if (b.IsEnabled)
            if (isEnabled)
            {

                a = 0;
                return;
            }

            //SoundPlayer player = null;
            /*
            Ellipse c = new Ellipse();
            //SolidColorBrush f = new SolidColorBrush();
            //f.Color = Color.FromArgb(100, 0, 0, 0);
            //c.Fill = f;
            c.StrokeThickness = 1;
            c.Stroke = Brushes.Black;
            c.Width = 250;
            c.Height = 250;
            c.IsEnabled = false;
            c.Focusable = false;
            Ellipse cf = new Ellipse();
            SolidColorBrush f = new SolidColorBrush();
            f.Color = Color.FromArgb(100, 0, 0, 0);
            cf.Fill = f;
            cf.StrokeThickness = 1;
            cf.Stroke = Brushes.Black;
            a = 20;
            cf.Width = a;
            cf.Height = a;
            cf.IsEnabled = false;
            cf.Focusable = false;
            */
            /*
            Path pth = new Path();
            PathGeometry pg = new PathGeometry();
            PathFigureCollection pfc = new PathFigureCollection();
            PathFigure pf = new PathFigure();
            pth.Fill = Brushes.BlueViolet;
            pth.Stroke = Brushes.OrangeRed;
            ArcSegment arc = new ArcSegment(new Point(1, 1), new Size(250, 250), a, true, SweepDirection.Clockwise, true);
    

            pth.Data = pg;
            pfc.Add(pf);
            pg.Figures = pfc;
            pf.Segments.Add(arc);
            */

            Canvas cv = null;
            if (b.Name == "b_r0c0")
            {
                cv = this.r0c0;
                //player = player_r0c0;
                //Canvas cv = this.canvas_r0c0;
                //Canvas.SetTop(c, 125);
                //Canvas.SetLeft(c, 125);
                //a = 20;
                //cv.Children.Add(c);
                //Canvas.SetTop(cf, (500 - a) / 2);
                //Canvas.SetLeft(cf, (500 - a) / 2);
                //cv.Children.Add(cf);
                //cv.Children.Add(pth);
                //player = new System.Media.SoundPlayer("./res/r0c0.wav");
            }
            if (b.Name == "b_r0c1")
            {
                cv = this.r0c1;
                //player = player_r0c1;
            }
            if (b.Name == "b_r0c2")
            {
                cv = this.r0c2;
                //player = player_r0c2;
            }
            if (b.Name == "b_r0c3")
            {
                cv = this.r0c3;
                //player = player_r0c3;
            }
            if (b.Name == "b_r1c0")
            {
                cv = this.r1c0;
                //player = player_r1c0;
            }
            if (b.Name == "b_r1c1")
            {
                cv = this.r1c1;
                //player = player_r1c1;
            }
            if (b.Name == "b_r1c2")
            {
                cv = this.r1c2;
                //player = player_r1c2;
            }
            if (b.Name == "b_r1c3")
            {
                cv = this.r1c3;
                //player = player_r1c3;
            }


            if (b.Name == "b_menu0")
            {
                cv = this.menu0;
            }
            if (b.Name == "b_menu1")
            {
                cv = this.menu1;
            }
            if (b.Name == "b_menu2")
            {
                cv = this.menu2;
            }
            if (b.Name == "b_menu3")
            {
                cv = this.menu3;
            }

            if (b.Name == "b_menu4")
            {
                cv = this.menu4;
            }
            if (b.Name == "b_menu5")
            {
                cv = this.menu5;
            }

            //if(b.Name.IndexOf("menu") < 0) 
            //{
            //    LayoutRoot0.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
            //}
            btn = b;
            w = cv.ActualWidth;
            h = cv.ActualHeight; //= w;// LayoutRoot.Height;

            //if (b.Name == "r1c2")
            //{
            //    cv = this.canvas_r1c2;
            //Canvas cv = this.canvas_r1c2;
            //cv.Children.Add(c);
            //player = new System.Media.SoundPlayer("./res/r1c2.wav");
            //}

            Ellipse c = new Ellipse();
            //SolidColorBrush f = new SolidColorBrush();
            //f.Color = Color.FromArgb(100, 0, 0, 0);
            //c.Fill = f;
            c.StrokeThickness = 1;
            c.Stroke = Brushes.Black;
            c.Width = 250;// w / 2;
            c.Height = 250;// h / 2;
            c.IsEnabled = false;
            c.Focusable = false;
            Ellipse cf = new Ellipse();
            SolidColorBrush f = new SolidColorBrush();
            f.Color = Color.FromArgb(100, 0, 255, 0);
            cf.Fill = f;
            cf.StrokeThickness = 1;
            cf.Stroke = Brushes.Black;
            a = 20;
            cf.Width = a;
            cf.Height = a;
            cf.IsEnabled = false;
            cf.Focusable = false;





            if (cv != null)
            {
                Canvas.SetZIndex(cv, 100);
                cv.Focusable = false;
                cv.IsEnabled = false;
                Canvas.SetTop(c, (h - 250) / 2);
                Canvas.SetLeft(c, (w - 250) / 2);
                cv.Children.Add(c);
                Canvas.SetTop(cf, (h - a) / 2);
                Canvas.SetLeft(cf, (w - a) / 2);
                cv.Children.Add(cf);

                //cv.Children.Add(pth);
                //Canvas.SetTop(pth, 125);
                //Canvas.SetLeft(pth, 125);

                cvs = cv;
            }
            //if (player != null)
            //    player.Play();
        }



        delegate void DisplayMessage(double x, double y);
        private void ShowWindowsMessage(double x, double y)
        {
            //Debug.WriteLine("X: {0} Y:{1}", x, y);
            this.x = x;
            this.y = y;
            //SetCursorPos((int)x, (int)y);
            //xOnPaint();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine("Y");
            //if(((Canvas)this.canvas_r0c0).Children.Count > 0) {
            if (cvs != null && cvs.Children.Count > 0 && a > 0)
            {
                App app = (App)Application.Current;
                //app.gazePointDataStream.GazePoint((gazePointX, gazePointY, gazePointZ));//, _);
                //app.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => Debug.WriteLine("X: {0} Y:{1}", gazePointX, gazePointY));

                DisplayMessage messageTarget;
                messageTarget = ShowWindowsMessage;
                app.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => messageTarget(gazePointX, gazePointY));
                //Ellipse ce = (Ellipse)((Canvas)this.canvas).Children[0];
                //Ellipse ce = (Ellipse)cvs.Children[0];
                //Canvas.SetTop(ce, 50);
                //Canvas.SetLeft(ce, 50);

                //Debug.WriteLine("X: {0} Y:{1}", gazePointX, gazePointY);

                //Debug.WriteLine(w);
                //Debug.WriteLine(h);
                //((Canvas)this.canvas_r0c0).Children[0].
                //Debug.WriteLine("X");
                //Ellipse c = (Ellipse)((Canvas)this.canvas_r0c0).Children[0];
                //Ellipse cf = (Ellipse)((Canvas)this.canvas_r0c0).Children[1];

                //f.Color = Color.FromArgb(a, 0, 0, 0);
                if (a < 250)
                {

                    Ellipse c = (Ellipse)cvs.Children[0];
                    Ellipse cf = (Ellipse)cvs.Children[1];



                    SolidColorBrush f = new SolidColorBrush();
                    a += 5;
                    cf.Height = a;
                    cf.Width = a;
                    Canvas.SetTop(cf, (h - a) / 2);
                    Canvas.SetLeft(cf, (w - a) / 2);


                }
                if (a == 250)
                {
                    a++;

                    if (cvs.Name.IndexOf("menu") < 0)
                    {
                        //Debug.WriteLine(cvs.Name);
                        SoundPlayer player = null;
                        //player = new System.Media.SoundPlayer("./res/r1c0.wav");
                        player = new System.Media.SoundPlayer("./res/" + setName + "/" + cvs.Name + ".wav");
                        //c.StrokeThickness = 20;
                        //player.PlaySync();
                        player.Play();
                        //c.StrokeThickness = 40;
                        //LayoutRoot0.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                        imagePie.Height = h;// *0.75;
                        imagePie.Width = w;// *0.75;
                        cvs.Children.Clear();
                        cvs.Children.Add(imagePie);

                        //Canvas.SetTop(imagePie, (h * 0.25) / 2);
                        //Canvas.SetLeft(imagePie, (w * 0.25) / 2);
                    }
                    else
                    {
                        setName = btn.Name.Substring(2);

                        //focus(btn, true);

                        //LayoutRoot0.RowDefinitions[1].Height =  new GridLength(3, GridUnitType.Star);
                        //focus(btn, false);
                        //i_r0c0.Source = new BitmapImage(new Uri("pack://application:,,,/AssemblyName;component/res/" + setName + "/r0c0.jpg"));
                        //i_r0c1.Source = new BitmapImage(new Uri("pack://application:,,,/AssemblyName;component/res/" + setName + "/r0c1.jpg"));

                        i_r0c0.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r0c0.jpg"));
                        i_r0c1.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r0c1.jpg"));
                        i_r0c2.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r0c2.jpg"));
                        i_r0c3.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r0c3.jpg"));
                        i_r1c0.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r1c0.jpg"));
                        i_r1c1.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r1c1.jpg"));
                        i_r1c2.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r1c2.jpg"));
                        i_r1c3.Source = new BitmapImage(new Uri("pack://application:,,,/res/" + setName + "/r1c3.jpg"));


                        //Image acbody = new Image();
                        //acbody.Source = image;  
                    }
                }
                //c.Fill = f;
                //c.StrokeThickness = 2;
                //c.Stroke = Brushes.Black;
                //c.Width = 500;
                //c.Height = 500;
            }
        }


        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //Button b = (Button)sender;
            //b.IsEnabled = false;
            focus(sender, true);
            focus(sender, false);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //a = 0;
            //((Canvas)this.canvas_r0c0).Children.Clear();
            //((Canvas)this.canvas_r1c2).Children.Clear();
            //Button b = (Button)sender;
            //b.IsEnabled = true;
            //focus(sender, true);
        }
    }

}