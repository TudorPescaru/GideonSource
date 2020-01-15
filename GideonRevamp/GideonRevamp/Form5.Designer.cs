namespace GideonRevamp
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eqqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.cPUToolStripMenuItem,
            this.gPUToolStripMenuItem,
            this.hardDiskToolStripMenuItem,
            this.rAMToolStripMenuItem,
            this.appsToolStripMenuItem,
            this.eqqToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(84, 23);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // cPUToolStripMenuItem
            // 
            this.cPUToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cPUToolStripMenuItem.Image")));
            this.cPUToolStripMenuItem.Name = "cPUToolStripMenuItem";
            this.cPUToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.cPUToolStripMenuItem.Text = "CPU";
            this.cPUToolStripMenuItem.Click += new System.EventHandler(this.cPUToolStripMenuItem_Click);
            // 
            // gPUToolStripMenuItem
            // 
            this.gPUToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gPUToolStripMenuItem.Image")));
            this.gPUToolStripMenuItem.Name = "gPUToolStripMenuItem";
            this.gPUToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.gPUToolStripMenuItem.Text = "GPU";
            this.gPUToolStripMenuItem.Click += new System.EventHandler(this.gPUToolStripMenuItem_Click);
            // 
            // hardDiskToolStripMenuItem
            // 
            this.hardDiskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hardDiskToolStripMenuItem.Image")));
            this.hardDiskToolStripMenuItem.Name = "hardDiskToolStripMenuItem";
            this.hardDiskToolStripMenuItem.Size = new System.Drawing.Size(109, 23);
            this.hardDiskToolStripMenuItem.Text = "Hard Disk";
            this.hardDiskToolStripMenuItem.Click += new System.EventHandler(this.hardDiskToolStripMenuItem_Click);
            // 
            // rAMToolStripMenuItem
            // 
            this.rAMToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rAMToolStripMenuItem.Image")));
            this.rAMToolStripMenuItem.Name = "rAMToolStripMenuItem";
            this.rAMToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.rAMToolStripMenuItem.Text = "RAM";
            // 
            // appsToolStripMenuItem
            // 
            this.appsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("appsToolStripMenuItem.Image")));
            this.appsToolStripMenuItem.Name = "appsToolStripMenuItem";
            this.appsToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.appsToolStripMenuItem.Text = "Apps";
            this.appsToolStripMenuItem.Click += new System.EventHandler(this.appsToolStripMenuItem_Click);
            // 
            // eqqToolStripMenuItem
            // 
            this.eqqToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.eqqToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eqqToolStripMenuItem.Image")));
            this.eqqToolStripMenuItem.Name = "eqqToolStripMenuItem";
            this.eqqToolStripMenuItem.Size = new System.Drawing.Size(28, 23);
            this.eqqToolStripMenuItem.Click += new System.EventHandler(this.eqqToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(84, 23);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 23);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.FontWeight = MetroFramework.MetroProgressBarWeight.Bold;
            this.metroProgressBar1.HideProgressText = false;
            this.metroProgressBar1.Location = new System.Drawing.Point(12, 128);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(712, 42);
            this.metroProgressBar1.TabIndex = 2;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "DIMM1 Clock Speed: Unavailable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(8, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 19);
            this.label2.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "DIMM2 Clock Speed: Unavailable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(8, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "DIMM3 Clock Speed: Unavailable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(8, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(267, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "DIMM4 Clock Speed: Unavailable";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(220)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(736, 486);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5";
            this.Opacity = 0.95D;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eqqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}