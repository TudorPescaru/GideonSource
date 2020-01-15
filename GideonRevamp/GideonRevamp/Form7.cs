using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace GideonRevamp
{
    public partial class Form7 : Form
    {

        //speech synthesizer for audio feedback

        public static SpeechSynthesizer synth = new SpeechSynthesizer();

        public Form7()
        {
            InitializeComponent();
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

        //code for navigating between forms

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

        private void appsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            form6.Location = this.Location;
            this.Hide();
        }

        #endregion

        private void Form7_Load(object sender, EventArgs e)
        {

            //reciting about information and displaying it in a text box

            textBox1.AppendText("Hello, my name is Gideon and I am your personal asistant. I am able to offer information about the state of your computer, open apps and offer acces to a few other nifty features. This is my new and improved interface, my original one being in console. You can take a look at my legacy version by pressing the button down bellow.");
            string helloVocalMessage = String.Format("Hello, my name is Gideon and I am your personal asistant. I am able to offer information about the state of your computer, open apps and offer acces to a few other nifty features. This is my new and improved interface, my original one being in console. You can take a look at my legacy version by pressing the button down bellow.");
            GideonVoice(helloVocalMessage, VoiceGender.Female, 2);
        }

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

        #region Content Buttons

        //buttons that allow you to acces different content/information


        //button that launches legacy/console version of Gideon

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Users\User\Documents\Visual Studio 2015\Projects\GideonRevamp\GideonRevamp\Resources\Gideon.exe");
            Process.Start(info);
        }

        //button that displays a message box with every version and it's contents taht the program has gone through

        private void metroButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("01.09.2018\nVersions:\n-Alpha-\n0.1 - Added Home interface\n-Beta-\n0.2 - Added CPU interface\n0.3 - Added About and Hard Disk interfaces\n0.4 - Added RAM interface\n0.5 - Added Apps interface\n-Full Release-\n1.0 - Added GPU interface");
        }

        //button that displays a message box crediting fellow developers for their contributions - ideas/code/ui elements/icons

        private void metroButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In colaboration with Petrescu Cosmin\nMetro Framework: Copyright (c) 2011 Sven Walter & Copyright (c) 2013 Dennis Magno\nOpen Hardware Monitor: Copyright © 2010-2018 Michael Möller\nIcons from flaticon.com: Dave Gandy, Freepik, Smashicons, Pixel perfect");
        }

        #endregion
    }
}
