namespace ClickRedPixelsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.textBoxmaxTargets = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTurrets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFireRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(12, 631);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(437, 131);
            this.textBoxOutput.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(270, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Kill the basterds";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(179, 13);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(85, 20);
            this.textBoxDistance.TabIndex = 3;
            this.textBoxDistance.Text = "50";
            this.textBoxDistance.TextChanged += new System.EventHandler(this.textBoxDistance_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(179, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 10);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxProgress
            // 
            this.pictureBoxProgress.BackColor = System.Drawing.Color.Black;
            this.pictureBoxProgress.Location = new System.Drawing.Point(21, 42);
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.pictureBoxProgress.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxProgress.TabIndex = 5;
            this.pictureBoxProgress.TabStop = false;
            // 
            // textBoxmaxTargets
            // 
            this.textBoxmaxTargets.Location = new System.Drawing.Point(86, 454);
            this.textBoxmaxTargets.Name = "textBoxmaxTargets";
            this.textBoxmaxTargets.Size = new System.Drawing.Size(85, 20);
            this.textBoxmaxTargets.TabIndex = 6;
            this.textBoxmaxTargets.Text = "250";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Max targets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Turrets";
            // 
            // textBoxTurrets
            // 
            this.textBoxTurrets.Location = new System.Drawing.Point(86, 478);
            this.textBoxTurrets.Name = "textBoxTurrets";
            this.textBoxTurrets.Size = new System.Drawing.Size(85, 20);
            this.textBoxTurrets.TabIndex = 8;
            this.textBoxTurrets.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fire rate";
            // 
            // textBoxFireRate
            // 
            this.textBoxFireRate.Location = new System.Drawing.Point(87, 504);
            this.textBoxFireRate.Name = "textBoxFireRate";
            this.textBoxFireRate.Size = new System.Drawing.Size(85, 20);
            this.textBoxFireRate.TabIndex = 10;
            this.textBoxFireRate.Text = "0.3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 774);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFireRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTurrets);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxmaxTargets);
            this.Controls.Add(this.pictureBoxProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "TLDR: Pls die already";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private System.Windows.Forms.TextBox textBoxmaxTargets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTurrets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFireRate;
    }
}

