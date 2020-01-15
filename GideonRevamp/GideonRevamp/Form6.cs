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
using System.Windows.Input;

namespace GideonRevamp
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private string url;

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

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        #region App starting

        //open chrome with url

        public static void OpenWebsiteChrome(string URL)
        {
            Process chrome = new Process();
            chrome.StartInfo.FileName = "chrome.exe";
            chrome.StartInfo.Arguments = URL;
            chrome.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            try
            {
                chrome.Start();
            }
            catch(Win32Exception )
            {
                MessageBox.Show("This app is not installed");
            }
        }

        //open internet explorer with url

        public static void OpenWebsiteIE(string URL)
        {
            Process iexplorer = new Process();
            iexplorer.StartInfo.FileName = "iexplore.exe";
            iexplorer.StartInfo.Arguments = URL;
            iexplorer.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            try
            {
                iexplorer.Start();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("This app is not installed");
            }
        }

        //open firefox with url

        public static void OpenWebsiteFirefox(string URL)
        {
            Process firefox = new Process();
            firefox.StartInfo.FileName = "firefox.exe";
            firefox.StartInfo.Arguments = URL;
            firefox.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            try
            {
                firefox.Start();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("This app is not installed");
            }
        }

        public static void OpenCalc()
        {
            Process calc = new Process();
            calc.StartInfo.FileName = "calcu.exe";
            try
            {
                calc.Start();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("This app is not installed");
            }
        }

        public static void OpenNotepad()
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad.exe";
            try
            {
                notepad.Start();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("This app is not installed");
            }
        }

        #endregion

        #region Content Buttons

        #region Chrome

        private void label1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.StartsWith("https://") == true || metroTextBox1.Text.StartsWith("www") == true || metroTextBox1.Text == "" || metroTextBox1.Text == "Type URL here:")
            {
                url = metroTextBox1.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox1.ResetText();
                metroTextBox1.AppendText("That is not a valid URL");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.StartsWith("https://") == true || metroTextBox1.Text.StartsWith("www") == true || metroTextBox1.Text == "" || metroTextBox1.Text == "Type URL here:")
            {
                url = metroTextBox1.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox1.ResetText();
                metroTextBox1.AppendText("That is not a valid URL");
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            metroTextBox1.ReadOnly = false;
            metroTextBox1.ResetText();

        }

        #endregion

        #region Mozila Firefox

        private void label2_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text.StartsWith("https://") == true || metroTextBox2.Text.StartsWith("www") == true || metroTextBox2.Text == "" || metroTextBox2.Text == "Type URL here:")
            {
                url = metroTextBox2.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox2.ResetText();
                metroTextBox2.AppendText("That is not a valid URL");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text.StartsWith("https://") == true || metroTextBox2.Text.StartsWith("www") == true || metroTextBox2.Text == "" || metroTextBox2.Text == "Type URL here:")
            {
                url = metroTextBox2.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox2.ResetText();
                metroTextBox2.AppendText("That is not a valid URL");
            }
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            metroTextBox2.ReadOnly = false;
            metroTextBox2.ResetText();
        }

        #endregion

        #region Internet Explorer

        private void label3_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text.StartsWith("https://") == true || metroTextBox3.Text.StartsWith("www") == true || metroTextBox3.Text == "" || metroTextBox3.Text == "Type URL here:")
            {
                url = metroTextBox3.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox3.ResetText();
                metroTextBox3.AppendText("That is not a valid URL");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text.StartsWith("https://") == true || metroTextBox3.Text.StartsWith("www") == true || metroTextBox3.Text == "" || metroTextBox3.Text == "Type URL here:")
            {
                url = metroTextBox3.Text;
                OpenWebsiteChrome(url);
            }
            else
            {
                metroTextBox3.ResetText();
                metroTextBox3.AppendText("That is not a valid URL");
            }
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {
            metroTextBox3.ReadOnly = false;
            metroTextBox3.ResetText();
        }

        #endregion

        #region Calculator

        private void label8_Click(object sender, EventArgs e)
        {
            OpenCalc();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            OpenCalc();
        }

        #endregion

        #region Notepad

        private void label10_Click(object sender, EventArgs e)
        {
            OpenNotepad();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OpenNotepad();
        }

        #endregion

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

        private void rAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            form5.Location = this.Location;
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
