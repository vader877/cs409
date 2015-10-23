namespace _408ClientSide
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
            this.button2 = new System.Windows.Forms.Button();
            this.ipBoxL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipBoxS = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.playerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.portBoxL = new System.Windows.Forms.NumericUpDown();
            this.portBoxS = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.portBoxL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portBoxS)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Player List";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ipBoxL
            // 
            this.ipBoxL.Location = new System.Drawing.Point(65, 67);
            this.ipBoxL.Name = "ipBoxL";
            this.ipBoxL.Size = new System.Drawing.Size(130, 20);
            this.ipBoxL.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Local IP:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Server IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port:";
            // 
            // ipBoxS
            // 
            this.ipBoxS.Location = new System.Drawing.Point(272, 67);
            this.ipBoxS.Name = "ipBoxS";
            this.ipBoxS.Size = new System.Drawing.Size(130, 20);
            this.ipBoxS.TabIndex = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(65, 132);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(337, 218);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(65, 12);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(130, 20);
            this.playerName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name:";
            // 
            // portBoxL
            // 
            this.portBoxL.Location = new System.Drawing.Point(65, 93);
            this.portBoxL.Name = "portBoxL";
            this.portBoxL.Size = new System.Drawing.Size(130, 20);
            this.portBoxL.TabIndex = 15;
            // 
            // portBoxS
            // 
            this.portBoxS.Location = new System.Drawing.Point(272, 93);
            this.portBoxS.Name = "portBoxS";
            this.portBoxS.Size = new System.Drawing.Size(130, 20);
            this.portBoxS.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 446);
            this.Controls.Add(this.portBoxS);
            this.Controls.Add(this.portBoxL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ipBoxS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipBoxL);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.portBoxL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portBoxS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ipBoxL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipBoxS;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown portBoxL;
        private System.Windows.Forms.NumericUpDown portBoxS;
    }
}

