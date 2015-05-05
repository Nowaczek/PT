namespace PTKlient
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
            this.buttonPołącz = new System.Windows.Forms.Button();
            this.comboBoxLocalIP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxserverIP = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // buttonPołącz
            // 
            this.buttonPołącz.Location = new System.Drawing.Point(97, 218);
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
            this.comboBoxLocalIP.Location = new System.Drawing.Point(133, 26);
            this.comboBoxLocalIP.Name = "comboBoxLocalIP";
            this.comboBoxLocalIP.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLocalIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "LocalIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "serverlIP";
            // 
            // textBoxserverIP
            // 
            this.textBoxserverIP.Location = new System.Drawing.Point(142, 70);
            this.textBoxserverIP.Name = "textBoxserverIP";
            this.textBoxserverIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxserverIP.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxserverIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLocalIP);
            this.Controls.Add(this.buttonPołącz);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

