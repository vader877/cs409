namespace _408ClientSide
{
    partial class Client
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
            this.connectButton = new System.Windows.Forms.Button();
            this.listButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.playerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.portNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(65, 370);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(79, 46);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // listButton
            // 
            this.listButton.Location = new System.Drawing.Point(177, 370);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(79, 46);
            this.listButton.TabIndex = 1;
            this.listButton.Text = "Player List";
            this.listButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Server IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port:";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(65, 62);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(100, 20);
            this.serverIP.TabIndex = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(65, 132);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(297, 218);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(65, 12);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(100, 20);
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
            // portNumber
            // 
            this.portNumber.Location = new System.Drawing.Point(65, 88);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(100, 20);
            this.portNumber.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Status:";
            // 
            // statusText
            // 
            this.statusText.Location = new System.Drawing.Point(262, 65);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(100, 20);
            this.statusText.TabIndex = 18;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(283, 370);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(79, 46);
            this.exitButton.TabIndex = 19;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 446);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Client";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button listButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown portNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusText;
        private System.Windows.Forms.Button exitButton;
    }
}

