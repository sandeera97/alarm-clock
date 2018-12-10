using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            label1.Text = "Running";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();

            UpdateLable upd = UpdatedataLable;
            if (label1.InvokeRequired)
                Invoke(upd, label1, "stop");

            label1.Text = "Stop";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed+=timer_Elapsed;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime curruntTime = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            if (curruntTime.Hour == userTime.Hour && curruntTime.Minute == userTime.Minute && curruntTime.Second == userTime.Second)
            {
                timer.Stop();
                MessageBox.Show("time over","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        delegate void UpdateLable(Label lbl, string value);

        void UpdatedataLable (Label lbl ,string value)
        {
            lbl.Text = value;
        }
    }
}
