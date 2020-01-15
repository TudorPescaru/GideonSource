using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace GideonRevamp
{
    public partial class Form5 : Form
    {

        //performance counter that displays available RAM

        PerformanceCounter ramAvailableCount = new PerformanceCounter("Memory", "Available MBytes");

        public Form5()
        {
            InitializeComponent();
        }

        #region Variables

        //variables that display total RAM for each DIMM installed and that claculate total RAM available on the machine

        private int capacity1 = 0;
        private int capacity2 = 0;
        private int capacity3 = 0;
        private int capacity4 = 0;
        private double capacity;
        private int capacityTotal;
        private int capacityAvailable;

        //variable that displays clock speed for each dimm if it is available

        private int clock;

        //variable for accesing different WMI values

        private int counter;

        //variable that updates the progress bar

        private int percent;

        #endregion

        #region RAM Data

        //using WMI to get information (Total RAM, Clock Speed) about each DIMM installed

        private void ram_usage()
        {
            counter = 0;
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject mo in mos.Get())
            {

                //displaying manufacturer and name of the DIMMs

                label1.Text = mo["Manufacturer"].ToString() + " " + mo["Name"].ToString() + " Usage:";

                //asigning and converting values for total RAM and clock speed for each DIMM installed

                if(counter == 0)
                {
                    capacity = Convert.ToInt64(mo["Capacity"]);
                    capacity1 = (int)(capacity / (1024 * 1024));
                    clock = Convert.ToInt32(mo["ConfiguredClockSpeed"]);
                    label3.Text = "DIMM1 Clock Speed: " + clock.ToString() + " MHz";
                }
                if (counter == 1)
                {
                    capacity = Convert.ToInt64(mo["Capacity"]);
                    capacity2 = (int)(capacity / (1024 * 1024));
                    clock = Convert.ToInt32(mo["ConfiguredClockSpeed"]);
                    label4.Text = "DIMM2 Clock Speed: " + clock.ToString() + " MHz";
                }
                if (counter == 2)
                {
                    capacity = Convert.ToInt64(mo["Capacity"]);
                    capacity3 = (int)(capacity / (1024 * 1024));
                    clock = Convert.ToInt32(mo["ConfiguredClockSpeed"]);
                    label5.Text = "DIMM3 Clock Speed: " + clock.ToString() + " MHz";
                }
                if (counter == 3)
                {
                    capacity = Convert.ToInt64(mo["Capacity"]);
                    capacity4 = (int)(capacity / (1024 * 1024));
                    clock = Convert.ToInt32(mo["ConfiguredClockSpeed"]);
                    label6.Text = "DIMM4 Clock Speed: " + clock.ToString() + " MHz";
                }
                counter++;
            }

            //displaying total available RAM in the machine

            capacityTotal = (capacity1 + capacity2 + capacity3 + capacity4);
            capacityAvailable = (int)(ramAvailableCount.NextValue());
            percent = ((capacityTotal-capacityAvailable) * 100) / capacityTotal;
            bar_color(percent, metroProgressBar1);
            metroProgressBar1.Value = percent;
            label2.Text = capacityAvailable.ToString() + " MB available out of " + capacityTotal.ToString() + " MB";
        }

        #endregion

        #region Color Indicator

        //bar coloring function

        private void bar_color(int n, MetroFramework.Controls.MetroProgressBar a)
        {
            if (n <= 25) { a.Style = MetroFramework.MetroColorStyle.Green; }
            if (n > 25 && n <= 50) { a.Style = MetroFramework.MetroColorStyle.Yellow; }
            if (n > 50 && n < 90) { a.Style = MetroFramework.MetroColorStyle.Orange; }
            if (n >= 90) { a.Style = MetroFramework.MetroColorStyle.Red; }
        }

        #endregion

        #region Ram Usage

        System.Windows.Forms.Timer tmr = null;
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {

            //calling function and displaying all data through lables and progress bars

            ram_usage();
        }

        #endregion


        private void Form5_Load(object sender, EventArgs e)
        {

        }

        #region Move Form

        //code for moving the form

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Buttons

        //close button

        private void eqqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //minimize button

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Forms

        //code for navigating the form

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = this.Location;
            this.Hide();
        }

        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.Location = this.Location;
            this.Hide();
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.Location = this.Location;
            this.Hide();
        }

        private void hardDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.Location = this.Location;
            this.Hide();
        }

        private void appsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            form6.Location = this.Location;
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            form7.Location = this.Location;
            this.Hide();
        }

        #endregion

    }
}
