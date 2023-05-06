using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer2
{
    public partial class Form1 : Form
    {
        int timeCs = 0, timeSec = 0, timeMin = 0;
        bool isactive = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void make_lable()
        {
            int top, left, height, width;
            top = this.Height / 10;
            left = this.Width / 10;
            height = this.Height / 10;
            width = this.Width / 10;

            make_buttom(top, left, height, width);
            Label t = new Label();
            t.Font = new Font(t.Font.FontFamily, 20);
            t.Top = 2 * top;
            t.Left = 4 * left;
            t.Name = "lbl";
            t.Text = "1234";
            t.Width = 3 * width;
            t.Height = 4 * height;
            this.Controls.Add(t);
        }

        public void make_buttom(int top, int left, int height, int width)
        {
            string[] names_button = { "reset", "start", "stop" };
            for (int i = 1; i <= 3; i++)
            {
                Button b = new Button();
                b.Font = new Font(b.Font.FontFamily, 10);
                b.Text = names_button[i - 1];
                b.Top = 4 * top;
                b.Height = height;
                b.Width = 2 * width;
                b.Left = ((2 * i) * left);
                this.Controls.Add(b);
                if (b.Text == "start")
                {
                    b.Click += new EventHandler(start_click);

                }
                if (b.Text == "stop")
                {
                    b.Click += new EventHandler(stop_click);

                }
                if (b.Text == "reset")
                {
                    b.Click += new EventHandler(reset_click);

                }


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if (isactive)
            {
                timeCs++;
                if (timeCs >= 100)
                {
                    timeSec++;
                    timeCs = 0;
                    if (timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }
          show();

        }

        private void resetTime()
        {
            timeCs = 0;
            timeMin = 0;
            timeSec = 0;
        }
        private void start_click(object sender, EventArgs e)
        {
            isactive = true;

        }
        private void stop_click(object sender, EventArgs e)
        {
            isactive = false;
        }

        private void show_btn_Click(object sender, EventArgs e)
        {
            make_lable();
        }

        private void reset_click(object sender, EventArgs e)
        {
            isactive = false;
            resetTime();
        }
        private void show()
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name == "lbl")
                {
                    c.Text = $"{timeMin}:{timeSec}:{timeCs}";
                }
            }
        }
    }
}
