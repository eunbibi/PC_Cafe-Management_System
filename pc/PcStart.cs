using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pc
{
    public partial class PcStart : Form
    {
        int hour;
        int min;
        int sec;

        bool isRunning = false;

        public PcStart()
        {
            InitializeComponent();
        }

        public void init()
        {
            Point p = new Point();

            Screen s = Screen.PrimaryScreen;
            //p.X = s.Bounds.Width - Size.Width;
            //p.Y = 0;
            hour = 0;
            min = 0;
            sec = 0;
            DesktopLocation = p;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PC사용을 시작합니다.");

            isRunning = true;

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isRunning = false;
            // timer1.Stop();
            //   button2.BackColor = Color.White;

            MessageBox.Show("PC사용을 종료합니다.");

            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = (++sec).ToString();
            textBox2.Text = (min).ToString();
            textBox1.Text = (hour).ToString();
            if (sec == 60)
            {
                sec = 0;
                textBox3.Text = "0";
                textBox2.Text = (++min).ToString();
            }
            if (min == 60)
            {
                min = 0;
                textBox2.Text = "0";
                textBox1.Text = (++hour).ToString();
            }
        }
    }
}
