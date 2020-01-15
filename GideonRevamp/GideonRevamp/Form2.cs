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
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;

namespace GideonRevamp
{
    public partial class Form2 : Form
    {

        //performance counter for pulling cpu load data

        PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");

        //computer for accessing OpenHardwareMonitor data

        private Computer c = new Computer { CPUEnabled = true };

        //WIP bool *see below*

        private bool msg = true;

        public Form2()
        {
            InitializeComponent();

            //starting the computer

            c.Open();
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

        #region Variables

        //counters for accesing different OpenHardwareMonitor values

        private int counter = 0;
        private int counter2 = 0;

        //variables for storing cpu temp data for each core

        private int cpuTempTotal;
        private int cpuTemp1;
        private int cpuTemp2;
        private int cpuTemp3;
        private int cpuTemp4;

        //variable for storing cpu load data

        private int cpuUsageTotal;

        //variables for storing cpu clock speed data for each core

        private int cpuClock1;
        private int cpuClock2;
        private int cpuClock3;
        private int cpuClock4;

        #endregion

        #region CPU Temp and Usage

        //using OpenHardwareMonitor to pull cpu temp data and displaying it for each core

        private void cpu_use_temp()
        {
            counter = 0;
            foreach (IHardware hardware in c.Hardware)
            {
                hardware.Update();

                label9.Text = hardware.Name.ToString();

                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        if (counter == 0)
                        {
                            cpuTemp1 = (int)sensor.Value;
                            metroProgressBar1.Value = cpuTemp1;
                            bar_color(cpuTemp1, metroProgressBar1);
                            label10.Text = cpuTemp1.ToString() + " .C";
                        }
                        if (counter == 1)
                        {
                            cpuTemp2 = (int)sensor.Value;
                            metroProgressBar2.Value = cpuTemp2;
                            bar_color(cpuTemp2, metroProgressBar2);
                            label11.Text = cpuTemp2.ToString() + " .C";
                        }
                        if (counter == 2)
                        {
                            cpuTemp3 = (int)sensor.Value;
                            metroProgressBar3.Value = cpuTemp3;
                            bar_color(cpuTemp3, metroProgressBar3);
                            label12.Text = cpuTemp3.ToString() + " .C";
                        }
                        if (counter == 3)
                        {
                            cpuTemp4 = (int)sensor.Value;
                            metroProgressBar4.Value = cpuTemp4;
                            bar_color(cpuTemp4, metroProgressBar4);
                            label13.Text = cpuTemp4.ToString() + " .C";
                        }

                        counter++;

                        //calculating average temperature for the cpu package and displaying it

                        cpuTempTotal = (cpuTemp1 + cpuTemp2 + cpuTemp3 + cpuTemp4) / 4;
                        label8.Text = "Total: " + cpuTempTotal.ToString() + " .C";

                    }
                }
            }
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

        #region CPU Clock

        //using OpenHardwareMonitor to pull cpu clock speed data for each core and displaying it

        private void cpu_clock()
        {
            counter2 = 0;
            foreach (IHardware hardware in c.Hardware)
            {
                hardware.Update();
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if(sensor.SensorType == SensorType.Clock)
                    {
                        if (counter2 == 0)
                        {
                            cpuClock1 = (int)sensor.Value;
                            label14.Text = "Core#1: " + cpuClock1.ToString() + " MHz";
                        }
                        if (counter2 == 1)
                        {
                            cpuClock2 = (int)sensor.Value;
                            label15.Text = "Core#2: " + cpuClock2.ToString() + " MHz";
                        }
                        if (counter2 == 2)
                        {
                            cpuClock3 = (int)sensor.Value;
                            label16.Text = "Core#3: " + cpuClock3.ToString() + " MHz";
                        }
                        if (counter2 == 3)
                        {
                            cpuClock4 = (int)sensor.Value;
                            label17.Text = "Core#4: " + cpuClock4.ToString() + " MHz";
                        }

                        counter2++;
                    }
                }
            }
        }

        #endregion

        #region Processor usage and temp

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

            //calling functions and updating lables and progress bars

            cpu_use_temp();
            cpu_clock();
            cpuUsageTotal = (int)perfCpuCount.NextValue();
            bar_color(cpuUsageTotal, metroProgressBar5);
            label7.Text = "Total: " + cpuUsageTotal.ToString() + "%";
            metroProgressBar5.Value = cpuUsageTotal;

        }

        #endregion

        private void Form2_Load(object sender, EventArgs e)
        {

            //WIP one-time appearance for the warning messagebox

            if (msg == true)
            {
                MessageBox.Show("Warning! This app is intended for use with quad-core processors.");
                msg = false;
            }
        }

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

        //code for navigating between forms

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = this.Location;
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

        private void rAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            form5.Location = this.Location;
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
