
namespace Chronometer
{
    partial class label
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSTART = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnRESET = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSTART
            // 
            this.btnSTART.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSTART.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSTART.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSTART.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSTART.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSTART.Location = new System.Drawing.Point(112, 365);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(125, 58);
            this.btnSTART.TabIndex = 0;
            this.btnSTART.Text = "START";
            this.btnSTART.UseVisualStyleBackColor = false;
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSTOP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSTOP.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSTOP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSTOP.Location = new System.Drawing.Point(278, 365);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(125, 58);
            this.btnSTOP.TabIndex = 1;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnRESET
            // 
            this.btnRESET.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRESET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRESET.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRESET.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRESET.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRESET.Location = new System.Drawing.Point(441, 365);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Size = new System.Drawing.Size(125, 58);
            this.btnRESET.TabIndex = 2;
            this.btnRESET.Text = "RESET";
            this.btnRESET.UseVisualStyleBackColor = false;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 129);
            this.label1.MinimumSize = new System.Drawing.Size(150, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 128);
            this.label1.TabIndex = 3;
            this.label1.Text = "00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(223, 129);
            this.label2.MinimumSize = new System.Drawing.Size(150, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 128);
            this.label2.TabIndex = 9;
            this.label2.Text = "00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(588, 129);
            this.label3.MinimumSize = new System.Drawing.Size(150, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 128);
            this.label3.TabIndex = 10;
            this.label3.Text = "00";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(184, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 75);
            this.label4.TabIndex = 11;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(556, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 75);
            this.label5.TabIndex = 12;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(409, 129);
            this.label6.MinimumSize = new System.Drawing.Size(150, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 128);
            this.label6.TabIndex = 13;
            this.label6.Text = "00";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(368, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 75);
            this.label7.TabIndex = 14;
            this.label7.Text = ":";
            // 
            // label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRESET);
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.btnSTART);
            this.MinimumSize = new System.Drawing.Size(30, 39);
            this.Name = "label";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.label_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSTART;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnRESET;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

