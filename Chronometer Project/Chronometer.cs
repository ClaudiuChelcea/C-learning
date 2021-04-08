using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chronometer
{
    public partial class label : Form
    {
        int centiseconds, seconds, minutes, hours;
        bool isActive;

        private void btnSTART_Click(object sender, EventArgs e)
        {
            if (isActive == false)
                btnSTART.Visible = true;
            if (isActive == true)
            {
                btnSTART.Text = "CONTINUE";
            }
            else
            {
                isActive = true;
                btnSTART.Text = "CONTINUE";
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            isActive = false;
            if (hours != 0 || seconds != 0 || minutes != 0 || centiseconds != 0)
            {
                btnSTART.Text = "CONTINUE";
            }
            else
                btnSTART.Text = "START";
            btnSTART.Visible = true;
        }

        private void btnRESET_Click(object sender, EventArgs e)
        {
            centiseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
            if (isActive == false)
                btnSTART.Text = "START";
            draw_labels();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                centiseconds++;
                if(centiseconds == 100)
                {
                    seconds++;
                    centiseconds = 0;
                    if(seconds == 60)
                    {
                        seconds = 0;
                        minutes++;
                        if(minutes == 60)
                        {
                            minutes = 0;
                            hours++;
                        }
                    }
                }
                if (seconds == 0 && minutes == 0 && hours == 0 && centiseconds == 0)
                    btnSTART.Text = "START";
                if (isActive)
                    btnSTART.Visible = false;
                draw_labels();
            }
        }

        public label()
        {
            InitializeComponent();
        }

        private void label_Load(object sender, EventArgs e)
        {
            centiseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
            isActive = false;
            draw_labels();
        }

        private void draw_labels()
        {
            label1.Text = String.Format("{0:00}", hours);
            label2.Text = String.Format("{0:00}", minutes);
            label6.Text = String.Format("{0:00}", seconds);
            label3.Text = String.Format("{0:00}", centiseconds);
        }
    }
}
