using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tobii.EyeX;

namespace EyeComMouse
{
    partial class Form1
    {
        /*
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr dc);
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool Ellipse(IntPtr hdc, int x1, int y1, int x2, int y2);

        protected void xOnPaint()//PaintEventArgs e)
        {
            //SolidColorBrush b = new SolidColorBrush();
            //IntPtr desktopDC = GetDC(IntPtr.Zero);
            //Graphics g = Graphics.FromHdc(desktopDC);
            //g.FillEllipse(b, 0, 0, 1024,7 68);
            //g.Dispose();
            //LineTo(hdc, LOWORD(lParam), HIWORD(lParam)); 
            //Ellipse(desktopDC, (int)x, (int)y, 200, 200);
            //ReleaseDC(desktopDC);
        }

        delegate void DisplayMessage(double x, double y);
        private void ShowWindowsMessage(double x, double y)
        {
            //Debug.WriteLine("X: {0} Y:{1}", x, y);
            //this.x = x;
            //this.y = y;
            SetCursorPos((int)x, (int)y);
            //xOnPaint();
        }
        */          

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.buttonRowsCount = new System.Windows.Forms.Button();
            this.buttonRowsCountDown = new System.Windows.Forms.Button();
            this.buttonRowsCountUp = new System.Windows.Forms.Button();
            this.buttonColumnsCountUp = new System.Windows.Forms.Button();
            this.buttonColumnsCountDown = new System.Windows.Forms.Button();
            this.buttonColumnsCount = new System.Windows.Forms.Button();
            this.buttonTopOffsetUp = new System.Windows.Forms.Button();
            this.buttonTopOffsetDown = new System.Windows.Forms.Button();
            this.buttonTopOffset = new System.Windows.Forms.Button();
            this.buttonRadiusSpeedUp = new System.Windows.Forms.Button();
            this.buttonRadiusSpeedDown = new System.Windows.Forms.Button();
            this.buttonRadiusSpeed = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(40, 36);
            this.buttonEnable.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(250, 69);
            this.buttonEnable.TabIndex = 0;
            this.buttonEnable.Text = "ENABLE";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonDisable
            // 
            this.buttonDisable.Location = new System.Drawing.Point(40, 123);
            this.buttonDisable.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(250, 69);
            this.buttonDisable.TabIndex = 1;
            this.buttonDisable.Text = "DISABLE";
            this.buttonDisable.UseVisualStyleBackColor = true;
            this.buttonDisable.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRowsCount
            // 
            this.buttonRowsCount.Location = new System.Drawing.Point(310, 36);
            this.buttonRowsCount.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRowsCount.Name = "buttonRowsCount";
            this.buttonRowsCount.Size = new System.Drawing.Size(250, 69);
            this.buttonRowsCount.TabIndex = 2;
            this.buttonRowsCount.Text = "COLUMNS";
            this.buttonRowsCount.UseVisualStyleBackColor = true;
            // 
            // buttonRowsCountDown
            // 
            this.buttonRowsCountDown.Location = new System.Drawing.Point(580, 36);
            this.buttonRowsCountDown.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRowsCountDown.Name = "buttonRowsCountDown";
            this.buttonRowsCountDown.Size = new System.Drawing.Size(250, 69);
            this.buttonRowsCountDown.TabIndex = 3;
            this.buttonRowsCountDown.Text = "-";
            this.buttonRowsCountDown.UseVisualStyleBackColor = true;
            this.buttonRowsCountDown.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRowsCountUp
            // 
            this.buttonRowsCountUp.Location = new System.Drawing.Point(850, 36);
            this.buttonRowsCountUp.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRowsCountUp.Name = "buttonRowsCountUp";
            this.buttonRowsCountUp.Size = new System.Drawing.Size(250, 69);
            this.buttonRowsCountUp.TabIndex = 4;
            this.buttonRowsCountUp.Text = "+";
            this.buttonRowsCountUp.UseVisualStyleBackColor = true;
            this.buttonRowsCountUp.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonColumnsCountUp
            // 
            this.buttonColumnsCountUp.Location = new System.Drawing.Point(850, 123);
            this.buttonColumnsCountUp.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonColumnsCountUp.Name = "buttonColumnsCountUp";
            this.buttonColumnsCountUp.Size = new System.Drawing.Size(250, 69);
            this.buttonColumnsCountUp.TabIndex = 7;
            this.buttonColumnsCountUp.Text = "+";
            this.buttonColumnsCountUp.UseVisualStyleBackColor = true;
            this.buttonColumnsCountUp.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonColumnsCountDown
            // 
            this.buttonColumnsCountDown.Location = new System.Drawing.Point(580, 123);
            this.buttonColumnsCountDown.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonColumnsCountDown.Name = "buttonColumnsCountDown";
            this.buttonColumnsCountDown.Size = new System.Drawing.Size(250, 69);
            this.buttonColumnsCountDown.TabIndex = 6;
            this.buttonColumnsCountDown.Text = "-";
            this.buttonColumnsCountDown.UseVisualStyleBackColor = true;
            this.buttonColumnsCountDown.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonColumnsCount
            // 
            this.buttonColumnsCount.Location = new System.Drawing.Point(310, 123);
            this.buttonColumnsCount.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonColumnsCount.Name = "buttonColumnsCount";
            this.buttonColumnsCount.Size = new System.Drawing.Size(250, 69);
            this.buttonColumnsCount.TabIndex = 5;
            this.buttonColumnsCount.Text = "ROWS";
            this.buttonColumnsCount.UseVisualStyleBackColor = true;
            // 
            // buttonTopOffsetUp
            // 
            this.buttonTopOffsetUp.Location = new System.Drawing.Point(850, 210);
            this.buttonTopOffsetUp.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonTopOffsetUp.Name = "buttonTopOffsetUp";
            this.buttonTopOffsetUp.Size = new System.Drawing.Size(250, 69);
            this.buttonTopOffsetUp.TabIndex = 10;
            this.buttonTopOffsetUp.Text = "+";
            this.buttonTopOffsetUp.UseVisualStyleBackColor = true;
            this.buttonTopOffsetUp.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonTopOffsetDown
            // 
            this.buttonTopOffsetDown.Location = new System.Drawing.Point(580, 210);
            this.buttonTopOffsetDown.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonTopOffsetDown.Name = "buttonTopOffsetDown";
            this.buttonTopOffsetDown.Size = new System.Drawing.Size(250, 69);
            this.buttonTopOffsetDown.TabIndex = 9;
            this.buttonTopOffsetDown.Text = "-";
            this.buttonTopOffsetDown.UseVisualStyleBackColor = true;
            this.buttonTopOffsetDown.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonTopOffset
            // 
            this.buttonTopOffset.Location = new System.Drawing.Point(310, 210);
            this.buttonTopOffset.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonTopOffset.Name = "buttonTopOffset";
            this.buttonTopOffset.Size = new System.Drawing.Size(250, 69);
            this.buttonTopOffset.TabIndex = 8;
            this.buttonTopOffset.Text = "TOP";
            this.buttonTopOffset.UseVisualStyleBackColor = true;
            // 
            // buttonRadiusSpeedUp
            // 
            this.buttonRadiusSpeedUp.Location = new System.Drawing.Point(850, 297);
            this.buttonRadiusSpeedUp.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRadiusSpeedUp.Name = "buttonRadiusSpeedUp";
            this.buttonRadiusSpeedUp.Size = new System.Drawing.Size(250, 69);
            this.buttonRadiusSpeedUp.TabIndex = 13;
            this.buttonRadiusSpeedUp.Text = "+";
            this.buttonRadiusSpeedUp.UseVisualStyleBackColor = true;
            this.buttonRadiusSpeedUp.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRadiusSpeedDown
            // 
            this.buttonRadiusSpeedDown.Location = new System.Drawing.Point(580, 297);
            this.buttonRadiusSpeedDown.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRadiusSpeedDown.Name = "buttonRadiusSpeedDown";
            this.buttonRadiusSpeedDown.Size = new System.Drawing.Size(250, 69);
            this.buttonRadiusSpeedDown.TabIndex = 12;
            this.buttonRadiusSpeedDown.Text = "-";
            this.buttonRadiusSpeedDown.UseVisualStyleBackColor = true;
            this.buttonRadiusSpeedDown.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonRadiusSpeed
            // 
            this.buttonRadiusSpeed.Location = new System.Drawing.Point(310, 297);
            this.buttonRadiusSpeed.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonRadiusSpeed.Name = "buttonRadiusSpeed";
            this.buttonRadiusSpeed.Size = new System.Drawing.Size(250, 69);
            this.buttonRadiusSpeed.TabIndex = 11;
            this.buttonRadiusSpeed.Text = "R SPEED";
            this.buttonRadiusSpeed.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(40, 297);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(250, 69);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2407, 1184);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRadiusSpeedUp);
            this.Controls.Add(this.buttonRadiusSpeedDown);
            this.Controls.Add(this.buttonRadiusSpeed);
            this.Controls.Add(this.buttonTopOffsetUp);
            this.Controls.Add(this.buttonTopOffsetDown);
            this.Controls.Add(this.buttonTopOffset);
            this.Controls.Add(this.buttonColumnsCountUp);
            this.Controls.Add(this.buttonColumnsCountDown);
            this.Controls.Add(this.buttonColumnsCount);
            this.Controls.Add(this.buttonRowsCountUp);
            this.Controls.Add(this.buttonRowsCountDown);
            this.Controls.Add(this.buttonRowsCount);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.buttonEnable);
            this.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Form1";
            this.Text = "EyeConMouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonEnable;
        private Button buttonDisable;
        private Button buttonRowsCount;
        private Button buttonRowsCountDown;
        private Button buttonRowsCountUp;
        private Button buttonColumnsCountUp;
        private Button buttonColumnsCountDown;
        private Button buttonColumnsCount;
        private Button buttonTopOffsetUp;
        private Button buttonTopOffsetDown;
        private Button buttonTopOffset;
        private Button buttonRadiusSpeedUp;
        private Button buttonRadiusSpeedDown;
        private Button buttonRadiusSpeed;
        private Button buttonSave;
    }
}

