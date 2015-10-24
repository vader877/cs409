using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using AsynchServer;

namespace _408ServerSide
{
    public partial class Form1 : Form
    {
        AsynchServer.AsynchClass myAsynchServer = new AsynchClass();

        delegate void SetTextCallback(string text);


        private Boolean running = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                IPAddress adrr = IPAddress.Parse(ipBox.Text);
                running = true;
                startStopButton.Text = "Stop";

                myAsynchServer.OnMessageArrived += new AsynchClass.MessageRecieved(updateUI);

                myAsynchServer.start(adrr, Convert.ToInt32(portBox.Text));

            }
            else
            {
                running = false;
                startStopButton.Text = "Start";
                myAsynchServer.stop();
            }
        }

        public void updateUI(object a, ServerArgs e)
        {
            Console.WriteLine(e.Target);

            if (e.Target.Equals("status"))
            {
                if (this.statusText.InvokeRequired)
                {
                    SetTextCallback setText = n => { statusText.Text = n; };
                    this.Invoke(setText, new object[] { e.Message });
                }
                else
                {
                    statusText.Text = e.Message;
                }
            }
            else if(e.Target.Equals("rtb"))
            {
                if (this.infoBox.InvokeRequired)
                {
                    SetTextCallback setText = n => { infoBox.AppendText(n + "\n"); };
                    this.Invoke(setText, new object[] { e.Message });
                }
                else
                {
                    infoBox.AppendText(e.Message + "\n");
                }
            }
        }
    }
}


