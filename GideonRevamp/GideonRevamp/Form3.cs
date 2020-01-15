using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using System.IO;
using System.Management;
using System.Diagnostics;

namespace GideonRevamp
{
    public partial class Form3 : Form
    {
        //Computer for OpenHardwareMonitor enabled for GPU
        private Computer c = new Computer { GPUEnabled = true };

        public Form3()
        {
            InitializeComponent();
            c.Open();
        }

        #region Variables

        //variables for NVIDIA data pulling

        private string path = @"c:\NVSMI";
        private string sourcePath = @"C:\Program Files\NVIDIA Corporation\NVSMI\";
        private string destinationPath = @"c:\NVSMI";

        //private Char delimiter = '-';
        private Char delimiter2 = 'W';
        private int gpuCount = 0;
        private string output;

        //variables for GPU data

        private int gpuTemp;
        private int gpuLoad;
        private string gpuName;

        //variables for VRAM data

        private double vramT;
        private double vramA;
        private int percent;

        #endregion

        #region GPU Temperature and Name

        //using OpenHardwareMonitor to gather GPU temperature data

        private void gpu_temp()
        {
            foreach (IHardware hardware in c.Hardware)
            {
                hardware.Update();
                gpuName = hardware.Name.ToString();
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if(sensor.SensorType == SensorType.Temperature)
                    {
                        gpuTemp = (int)sensor.Value;
                    }
                    
                }
            }
        }

        #endregion

        #region GPU Load

        //using NVSMI/NVIDIA API to gather GPU load data

        private void gpu_load()
        {
            try
            {

                //checking for directory for NVIDIA files 

                if(!Directory.Exists(path))
                {

                    //trying to create the directory

                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.Write("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                    //copying to new directory

                    NVIDIAGPU();
                }
            }
            catch
            {
                MessageBox.Show("Unable to access NVIDIA files");
                return;
            }

            try
            {
                gpuCount = 0;

                //starting the process that gathers NVIDIA data 

                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", @"/C cd c:\NVSMI&nvidia-smi --query-gpu=utilization.memory --format=csv");
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.CreateNoWindow = true;

                Process process = Process.Start(processStartInfo);
                using (StreamReader streamReader = process.StandardOutput)
                {
                    output = streamReader.ReadToEnd();
                }

                String[] substrings = output.Split(delimiter2);

                //displaying/memorizing GPU data pulled

                foreach (var substring in substrings)
                {
                    if(gpuCount == 0)
                    {
                        label3.Text = "Current GPU Load: " + String.Join("", substring.Where(Char.IsDigit)) + " %";
                        gpuLoad = Convert.ToInt16(String.Join("", substring.Where(Char.IsDigit)));
                    }

                    gpuCount++;
                }
            }
            catch
            {
                MessageBox.Show("Unable to acess NVIDIA files");
                return;
            }
        }

        private void NVIDIAGPU()
        {

            //copying NVIDIA files to directory in C:\

            sourcePath = sourcePath.EndsWith(@"\") ? sourcePath : sourcePath + @"\";
            destinationPath = destinationPath.EndsWith(@"\") ? destinationPath : destinationPath + @"\";

            try
            {
                if (Directory.Exists(sourcePath))
                {
                    if (Directory.Exists(destinationPath) == false)
                    {
                        Directory.CreateDirectory(destinationPath);
                    }

                    foreach (string files in Directory.GetFiles(sourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);
                        fileInfo.CopyTo(string.Format(@"{0}\{1}", destinationPath, fileInfo.Name), true);
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("NVIDIA File Access Error");
                this.Close();
            }
        }

        #endregion

        #region VRAM Usage

        //using OpenHardwareMonitor and WMI to gather total and available VRAM  

        private void vram_usage()
        {
            foreach (IHardware hardware in c.Hardware)
            {
                hardware.Update();
                foreach(ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Load)
                    {
                        percent = (int)sensor.Value;
                    }
                }
            }
        }

        //WMI

        private void vram_total()
        {
            vram_usage();
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            foreach (ManagementObject mo in mos.Get())
            {
                vramT = Convert.ToInt64(mo["AdapterRAM"]);
                vramT = vramT / (1024 * 1024);
            }
            vramA = vramT - (percent * (vramT / 100));
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

        #region GPU Info

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

            //running all the functions and updating lables/progress bars

            gpu_temp();
            gpu_load();
            vram_total();
            label4.Text = gpuName;
            bar_color(gpuTemp, metroProgressBar1);
            metroProgressBar1.Value = gpuTemp;
            label2.Text = "Current GPU Temperature: " + gpuTemp.ToString() + " .C";
            bar_color(gpuLoad, metroProgressBar2);
            metroProgressBar2.Value = gpuLoad;
            label1.Text = "Avialable VRAM: " + vramA.ToString() + " MB out of " + vramT.ToString() + " MB";
            bar_color(percent, metroProgressBar3);
            metroProgressBar3.Value = percent;
        }

        #endregion

        private void Form3_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Warning! This app is intended for use with NVIDIA GPUs only.");
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

        //code for moving between forms

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
