namespace PTKlient
{
    partial class PTKlient
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
            this.buttonPołącz = new System.Windows.Forms.Button();
            this.comboBoxLocalIP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxserverIP = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxWiadomosc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonWyslijWiadomosc = new System.Windows.Forms.Button();
            this.buttonRozlacz = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonPołącz
            // 
            this.buttonPołącz.Location = new System.Drawing.Point(25, 65);
            this.buttonPołącz.Name = "buttonPołącz";
            this.buttonPołącz.Size = new System.Drawing.Size(75, 23);
            this.buttonPołącz.TabIndex = 0;
            this.buttonPołącz.Text = "Połącz";
            this.buttonPołącz.UseVisualStyleBackColor = true;
            this.buttonPołącz.Click += new System.EventHandler(this.buttonPołącz_Click);
            // 
            // comboBoxLocalIP
            // 
            this.comboBoxLocalIP.FormattingEnabled = true;
            this.comboBoxLocalIP.Location = new System.Drawing.Point(100, 12);
            this.comboBoxLocalIP.Name = "comboBoxLocalIP";
            this.comboBoxLocalIP.Size = new System.Drawing.Size(100, 21);
            this.comboBoxLocalIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lokalne IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serwera IP:";
            // 
            // textBoxserverIP
            // 
            this.textBoxserverIP.Location = new System.Drawing.Point(100, 39);
            this.textBoxserverIP.Name = "textBoxserverIP";
            this.textBoxserverIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxserverIP.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // textBoxWiadomosc
            // 
            this.textBoxWiadomosc.Location = new System.Drawing.Point(100, 94);
            this.textBoxWiadomosc.Name = "textBoxWiadomosc";
            this.textBoxWiadomosc.Size = new System.Drawing.Size(100, 20);
            this.textBoxWiadomosc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wiadomość:";
            // 
            // buttonWyslijWiadomosc
            // 
            this.buttonWyslijWiadomosc.Location = new System.Drawing.Point(70, 120);
            this.buttonWyslijWiadomosc.Name = "buttonWyslijWiadomosc";
            this.buttonWyslijWiadomosc.Size = new System.Drawing.Size(75, 23);
            this.buttonWyslijWiadomosc.TabIndex = 7;
            this.buttonWyslijWiadomosc.Text = "Wyślij";
            this.buttonWyslijWiadomosc.UseVisualStyleBackColor = true;
            this.buttonWyslijWiadomosc.Click += new System.EventHandler(this.buttonWyslijWiadomosc_Click);
            // 
            // buttonRozlacz
            // 
            this.buttonRozlacz.Location = new System.Drawing.Point(106, 65);
            this.buttonRozlacz.Name = "buttonRozlacz";
            this.buttonRozlacz.Size = new System.Drawing.Size(75, 23);
            this.buttonRozlacz.TabIndex = 8;
            this.buttonRozlacz.Text = "Rozłącz";
            this.buttonRozlacz.UseVisualStyleBackColor = true;
            this.buttonRozlacz.Click += new System.EventHandler(this.buttonRozlacz_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PTKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 153);
            this.Controls.Add(this.buttonRozlacz);
            this.Controls.Add(this.buttonWyslijWiadomosc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWiadomosc);
            this.Controls.Add(this.textBoxserverIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLocalIP);
            this.Controls.Add(this.buttonPołącz);
            this.MaximizeBox = false;
            this.Name = "PTKlient";
            this.Text = "PTKlient 0.01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPołącz;
        private System.Windows.Forms.ComboBox comboBoxLocalIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxserverIP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxWiadomosc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonWyslijWiadomosc;
        private System.Windows.Forms.Button buttonRozlacz;
        private System.Windows.Forms.Timer timer1;
    }
}

