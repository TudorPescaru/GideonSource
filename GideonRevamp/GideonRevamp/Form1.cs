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
using System.Threading;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace GideonRevamp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //speech synthesizer for audio feedback

        public static SpeechSynthesizer synth = new SpeechSynthesizer();

        //system up-time performance counter

        PerformanceCounter perfTimeCount = new PerformanceCounter("System", "System Up Time");

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

        private void Form1_Load(object sender, EventArgs e)
        {

            //start-up hello messages

            #region Hello messages

            //message list

            List<string> helloMessages = new List<string>();
            helloMessages.Add("Hello there!");
            helloMessages.Add("Hi, how are you?");
            helloMessages.Add("Good to see you again!");
            helloMessages.Add("Greetings!");

            //randomizer

            Random rand = new Random();

            //using specialized welcome phrases depending on time of day and displying them

            string time = DateTime.Now.ToString("HH");

            int timeint = Int32.Parse(time);

            if (timeint < 11)
            {
                label1.Text = "Good morning!";
                string helloVocalMessage = String.Format("Good morning!");
                GideonVoice(helloVocalMessage, VoiceGender.Female, 2);
            }
            else
            {
                if(timeint > 19)
                {
                    label1.Text = "Good evening!";
                    string helloVocalMessage = String.Format("Good evening!");
                    GideonVoice(helloVocalMessage, VoiceGender.Female, 2);
                }
                else
                {
                    string random = helloMessages[rand.Next(4)];
                    label1.Text = random;
                    string helloVocalMessage = String.Format(random);
                    GideonVoice(helloVocalMessage, VoiceGender.Female, 2);
                }
            }

            #endregion

        }

        #region Date and Time and Uptime

        //time and date

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

            //displaying up-to-date system up time as well as current time and date

            label2.Text = DateTime.Now.ToString("HH:mm:ss");
            label5.Text = DateTime.Now.ToShortDateString();
            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfTimeCount.NextValue());
            int days = (int)uptimeSpan.TotalDays;
            int hours = (int)uptimeSpan.Hours;
            int minutes = (int)uptimeSpan.Minutes;
            int seconds = (int)uptimeSpan.Seconds;
            label3.Text = days.ToString() + " days " + hours.ToString() + " hours " + minutes.ToString() + " minutes and " + seconds.ToString() + " seconds";
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

        #region Speech

        //custom voice api

        public static void GideonVoice(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }

        //custom voice api with rate

        public static void GideonVoice(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            GideonVoice(message, voiceGender);
        }

        #endregion

        /*

        #region URL oppener

        //open chrome with url

        public static void OpenWebsiteChrome(string URL)
        {
            Process chrome = new Process();
            chrome.StartInfo.FileName = "chrome.exe";
            chrome.StartInfo.Arguments = URL;
            chrome.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            chrome.Start();
        }

        //open internet explorer with url

        public static void OpenWebsiteIE(string URL)
        {
            Process iexplorer = new Process();
            iexplorer.StartInfo.FileName = "iexplore.exe";
            iexplorer.StartInfo.Arguments = URL;
            iexplorer.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            iexplorer.Start();
        }

        //open firefox with url

        public static void OpenWebsiteFirefox(string URL)
        {
            Process firefox = new Process();
            firefox.StartInfo.FileName = "firefox.exe";
            firefox.StartInfo.Arguments = URL;
            firefox.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            firefox.Start();
        }

        #endregion

    */

        #region Forms

        //code for navigating between forms

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
