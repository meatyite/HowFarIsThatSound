using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightningStrikeLocator
{
    public partial class Form1 : Form
    {
        private DateTime StartTime;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmrClock.Enabled = !tmrClock.Enabled;
            button1.Text = tmrClock.Enabled ? "I heard it" : "I seen it";
            StartTime = DateTime.Now;
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;

            // Start with the days if greater than 0.
            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";

            // Convert milliseconds into tenths of seconds.
            int tenths = elapsed.Milliseconds / 100;

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + "." +
                tenths.ToString("0");

            label1.Text = text;
            double meters = elapsed.TotalSeconds * 340;
            double kilometers = meters / 1000;
            double miles = kilometers / 1.609;
            label2.Text = String.Format("Distance of sound:\n{0} km\n{1} miles", kilometers, miles);
        }
    }
}
