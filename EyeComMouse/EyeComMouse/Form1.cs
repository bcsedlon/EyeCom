using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EyeComMouse
{
    /*
    //Application settings wrapper class
    sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("4")]
        public int rows
        {
            get { return (int)this["ROWS"]; }
            set { this["ROWS"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("6")]
        public int columns
        {
            get { return (int)(this["COLUMNS"]); }
            set { this["COLUMNS"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("200")]
        public int top
        {
            get { return (int)this["TOP"]; }
            set { this["TOP"] = value; }
        }


        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("1")]
        public int speed
        {
            get { return (int)this["SPEED"]; }
            set { this["SPEED"] = value; }
        }
    }
    */

    public partial class Form1 : Form
    {
        int titleHeight;

        public Form1()
        {
            InitializeComponent();
        }

        private void setControl(Control c, int row, int column)
        {
            c.Top = Program.topOffset - titleHeight + Program.cellHeight * row;
            c.Left = Program.cellWidth * column;
            c.Width = Program.cellWidth;
            c.Height = Program.cellHeight;
        }

        private void setControls()
        {
            Program.setParams();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            titleHeight = (screenRectangle.Top - this.Top);// / 2;

            setControl(buttonEnable, 0, 0);
            setControl(buttonDisable, 1, 0);
            //setControl(buttonLoad, 2, 0);
            setControl(buttonSave, 3, 0);

            setControl(buttonRowsCount, 0, 1);
            setControl(buttonRowsCountDown, 0, 2);
            setControl(buttonRowsCountUp, 0, 3);

            setControl(buttonColumnsCount, 1, 1);
            setControl(buttonColumnsCountDown, 1, 2);
            setControl(buttonColumnsCountUp, 1, 3);

            setControl(buttonTopOffset, 2, 1);
            setControl(buttonTopOffsetDown, 2, 2);
            setControl(buttonTopOffsetUp, 2, 3);
            
            setControl(buttonRadiusSpeed, 3, 1);
            setControl(buttonRadiusSpeedDown, 3, 2);
            setControl(buttonRadiusSpeedUp, 3, 3);

            buttonRowsCount.Text = "RADKY\n" + Program.rowsCount.ToString();
            buttonColumnsCount.Text = "SLOUPCE\n" + Program.columnsCount.ToString();
            buttonTopOffset.Text = "HORNI ODSAZENI\n" + Program.topOffset.ToString();
            buttonRadiusSpeed.Text = "RYCHLOST\n" + Program.radiusSpeed.ToString();

            buttonEnable.Text = "ZAPNOUT";
            buttonDisable.Text = "VYPNOUT";
            buttonEnable.Enabled = !Program.bEnable;
            buttonDisable.Enabled = Program.bEnable;
            buttonSave.Text = "ULOZIT";

            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
            //this.TransparencyKey = this.BackColor;
            //this.BackColor = Color.FromArgb(10, this.BackColor);
            setControls();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 1);
            for (int x = Program.cellWidth; x <= Program.screenWidth; x += Program.cellWidth)
            {
                //e.Graphics.DrawLine(p, x, Program.topOffset - titleHeight, x, Program.screenHeight + Program.topOffset);
                e.Graphics.DrawLine(p, x, Program.topOffset - titleHeight, x, Program.cellHeight * Program.rowsCount + Program.topOffset - titleHeight);
            }
            for (int y = Program.topOffset - titleHeight; y < Program.screenHeight + (Program.topOffset - titleHeight); y += Program.cellHeight)
            {
                e.Graphics.DrawLine(p, 0, y, Program.screenWidth, y);
            }
            p.Dispose();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender == buttonRowsCountDown)
            {
                if (Program.rowsCount > 4)
                {
                    Program.rowsCount--;
                }
            }
            if (sender == buttonRowsCountUp)
            {
                //if (Program.rowsCount < 4)
                {
                    Program.rowsCount++;
                }
            }
            if (sender == buttonColumnsCountDown)
            {
                if (Program.columnsCount > 4)
                {
                    Program.columnsCount--;
                }
            }
            if (sender == buttonColumnsCountUp)
            {
                //if (Program.rowsCount > 4)
                {
                    Program.columnsCount++;
                }
            }
            if (sender == buttonTopOffsetDown)
            {
                if (Program.topOffset > titleHeight)
                {
                    Program.topOffset -= 10;
                }
            }
            if (sender == buttonTopOffsetUp)
            {
                //if (Program.topOffset > 100)
                {
                    Program.topOffset += 10;
                }
            }
            if (sender == buttonRadiusSpeedDown)
            {
                if (Program.radiusSpeed > 1)
                {
                    Program.radiusSpeed--;
                }
            }
            if (sender == buttonRadiusSpeedUp)
            {
                //if (Program.radiusSpeed > 2)
                {
                    Program.radiusSpeed++;
                }
            }
            if (sender == buttonEnable)
            {
                Program.bEnable = true;
            }
            if (sender == buttonDisable)
            {
                Program.bEnable = false;
            }  
            
            setControls();            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Program.saveSettings();
        }
    }
}
