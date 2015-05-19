namespace PTSerwer
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Serwer_on = new System.Windows.Forms.Button();
            this.l_stan = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.odbierzobraz = new System.ComponentModel.BackgroundWorker();
            this.timer_print = new System.Windows.Forms.Timer(this.components);
            this.nasluchiwanie = new System.ComponentModel.BackgroundWorker();
            this.timer_proces = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(805, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 21;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 405);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(779, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Podgląd użytkownika";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(773, 338);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "podgląd wyłączony";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Włącz/Wyłącz Podgląd";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Stream_ON_OFF_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Controls.Add(this.listBox2);
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(779, 379);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Przegląd uruchomionych programów";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(156, 6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(148, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "clear";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.wyczyszc_liste_procesow);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 35);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(774, 329);
            this.listBox2.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 6);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "procesy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.pobierz_procesy_Click);
            // 
            // Serwer_on
            // 
            this.Serwer_on.Location = new System.Drawing.Point(805, 37);
            this.Serwer_on.Name = "Serwer_on";
            this.Serwer_on.Size = new System.Drawing.Size(208, 28);
            this.Serwer_on.TabIndex = 23;
            this.Serwer_on.Text = "Włącz serwer";
            this.Serwer_on.UseVisualStyleBackColor = true;
            this.Serwer_on.Click += new System.EventHandler(this.Serwer_on_Click);
            // 
            // l_stan
            // 
            this.l_stan.AutoSize = true;
            this.l_stan.Location = new System.Drawing.Point(859, 68);
            this.l_stan.Name = "l_stan";
            this.l_stan.Size = new System.Drawing.Size(94, 13);
            this.l_stan.TabIndex = 24;
            this.l_stan.Text = "Serwer wyłączony";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(805, 88);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 329);
            this.listBox1.TabIndex = 25;
            // 
            // odbierzobraz
            // 
            this.odbierzobraz.DoWork += new System.ComponentModel.DoWorkEventHandler(this.odbierzobraz_DoWork);
            // 
            // timer_print
            // 
            this.timer_print.Interval = 1500;
            this.timer_print.Tick += new System.EventHandler(this.timer_print_Tick);
            // 
            // nasluchiwanie
            // 
            this.nasluchiwanie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.nasluchiwanie_DoWork);
            // 
            // timer_proces
            // 
            this.timer_proces.Interval = 1000;
            this.timer_proces.Tick += new System.EventHandler(this.timer_proces_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 430);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.l_stan);
            this.Controls.Add(this.Serwer_on);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Serwer_on;
        private System.Windows.Forms.Label l_stan;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker odbierzobraz;
        private System.Windows.Forms.Timer timer_print;
        private System.ComponentModel.BackgroundWorker nasluchiwanie;
        private System.Windows.Forms.Timer timer_proces;
    }
}

