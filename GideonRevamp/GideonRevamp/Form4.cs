using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using System.Management;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace GideonRevamp
{
    public partial class Form4 : Form
    {

        #region Elements

        //array of drives for pulling info about all drives installed on the machine

        private DriveInfo[] allDrives = DriveInfo.GetDrives();

        //thread that checks the hdd status

        Thread hddWorker;

        //performance counter that displays hdd usage

        PerformanceCounter hddUseCount = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");

        #endregion

        public Form4()
        {
            InitializeComponent();
            
            //starting the thread

            hddWorker = new Thread(new ThreadStart(HddThread));
            hddWorker.Start();
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

        //counter for accessing different drive values

        private int counter = 0;

        //variables that memorize hdd data for up to 4 disks

        private double disk1T;
        private double disk1A;
        private int disk1F;
        private double disk2T;
        private double disk2A;
        private int disk2F;
        private double disk3T;
        private double disk3A;
        private int disk3F;
        private double disk4T;
        private double disk4A;
        private int disk4F;

        //variable used to convert bytes into GB

        private int byteConvert = 1073741824;

        //bool for activating the in-use indicator

        private bool spin;

        //variable that memorizes hdd usage

        private int hddUse;

        #endregion

        #region HDD Data Pulling

        //pulling hdd name, total size and available space for up to 4 drives

        private void hdd_space()
        {
            counter = 0;
            foreach (DriveInfo d in allDrives)
            {
                if (counter == 0)
                {
                    label1.Text = d.Name;
                }
                if (counter == 1)
                {
                    label2.Text = d.Name;
                }
                if (counter == 2)
                {
                    label3.Text = d.Name;
                }
                if (counter == 3)
                {
                    label4.Text = d.Name;
                }
                if(d.IsReady == true)
                {

                    //converting and displaying the data for each drive if a drive is installed/is available

                    if (counter == 0)
                    {
                        disk1T = d.TotalSize / byteConvert;
                        disk1A = d.AvailableFreeSpace / byteConvert;
                        label5.Text = Convert.ToString(disk1A) + " GB free of " + Convert.ToString(disk1T) + " GB";
                        disk1F = (int)(100-((disk1A * 100) / disk1T));
                        bar_color(disk1F, metroProgressBar1);
                        metroProgressBar1.Value = disk1F;

                    }
                    if (counter == 1)
                    {
                        disk2T = d.TotalSize / byteConvert;
                        disk2A = d.AvailableFreeSpace / byteConvert;
                        if (disk2T <= 0)
                        {
                            metroProgressBar2.Value = 0;
                            label6.Text = "Unavailable";
                            label2.Text = "Unavailable";
                        }
                        else
                        {
                            label6.Text = Convert.ToString(disk2A) + " GB free of " + Convert.ToString(disk2T) + " GB";
                            disk2F = (int)(100 - ((disk2A * 100) / disk2T));
                            bar_color(disk2F, metroProgressBar2);
                            metroProgressBar2.Value = disk1F;
                        }
                    }
                    if (counter == 2)
                    {
                        disk3T = d.TotalSize / byteConvert;
                        disk3A = d.AvailableFreeSpace / byteConvert;
                        if (disk3T <= 0)
                        {
                            metroProgressBar3.Value = 0;
                            label7.Text = "Unavailable";
                            label3.Text = "Unavailable";
                        }
                        else
                        {
                            label7.Text = Convert.ToString(disk3A) + " GB free of " + Convert.ToString(disk3T) + " GB";
                            disk3F = (int)(100 - ((disk3A * 100) / disk3T));
                            bar_color(disk3F, metroProgressBar3);
                            metroProgressBar3.Value = disk3F;
                        }
                    }
                    if (counter == 3)
                    {
                        disk4T = d.TotalSize / byteConvert;
                        disk4A = d.AvailableFreeSpace / byteConvert;
                        if (disk4T <= 0)
                        {
                            metroProgressBar4.Value = 0;
                            label8.Text = "Unavailable";
                            label4.Text = "Unavailable";
                        }
                        else
                        {
                            label8.Text = Convert.ToString(disk4A) + " GB free of " + Convert.ToString(disk4T) + " GB";
                            disk4F = (int)(100 - ((disk4A * 100) / disk4T));
                            bar_color(disk4F, metroProgressBar4);
                            metroProgressBar4.Value = disk4F;
                        }
                    }
                }

                counter++;
            }
        }

        #endregion

        #region HDD Usage

        //checking fo hdd usage using WMI and a thread

        private void HddThread()
        {
            ManagementClass driveDataClass = new ManagementClass("Win32_PerfFormattedData_PerfDisk_PhysicalDisk");
            try
            {
                while (true)
                {
                    ManagementObjectCollection driveDataClassCollection = driveDataClass.GetInstances();
                    foreach (ManagementObject obj in driveDataClassCollection)
                    {
                        if (obj["Name"].ToString() == "_Total")
                        {
                            if (Convert.ToUInt64(obj["DiskBytesPersec"]) > 0)
                            {
                                spin = true;
                            }
                            else
                            {
                                spin = false;
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            }catch (ThreadAbortException tbe )
            {
                driveDataClass.Dispose();
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

        private void Form4_Load(object sender, EventArgs e)
        {

            //WIP warning message box 

            MessageBox.Show("This app has support for up to 4 physical hard disks.");
        }

        #region HDD info

        System.Windows.Forms.Timer tmr = null;
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 100;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {

            //calling functions and updating lables and progress bars

            hdd_space();
            metroProgressSpinner1.Spinning = spin;
            hddUseCount.NextValue();
            hddUse = (int)hddUseCount.NextValue();
            metroProgressSpinner1.Value = hddUse;
            label9.Text = hddUse.ToString() + " %";
        }

        #endregion

        #region Buttons

        //close button

        private void eqqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            hddWorker.Abort();
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
            hddWorker.Abort();
        }

        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.Location = this.Location;
            this.Hide();
            hddWorker.Abort();
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.Location = this.Location;
            this.Hide();
            hddWorker.Abort();
        }

        private void rAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            form5.Location = this.Location;
            this.Hide();
            hddWorker.Abort();
        }

        private void appsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            form6.Location = this.Location;
            this.Hide();
            hddWorker.Abort();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            form7.Location = this.Location;
            this.Hide();
            hddWorker.Abort();
        }


        #endregion

    }
}
