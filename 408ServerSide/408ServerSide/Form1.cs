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
        private Boolean running = false;
        private string ipAddress;
       // private Listener myListener;
        TcpClient clientSocket = default(TcpClient);

        public Form1()
        {
            InitializeComponent();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                try
                {
                    byte ipPart1 = Convert.ToByte(ipBox.Text.Substring(0, 3));
                    byte ipPart2 = Convert.ToByte(ipBox.Text.Substring(4, 3));
                    byte ipPart3 = Convert.ToByte(ipBox.Text.Substring(8, 3));
                    byte ipPart4 = Convert.ToByte(ipBox.Text.Substring(12, 3));

                    ipAddress = ipPart1.ToString() + "." + ipPart2.ToString() + "." + ipPart3.ToString() + "." + ipPart4.ToString();

                    Console.WriteLine("here");
                    running = true;
                    startStopButton.Text = "Stop";
                    //verSocket = new TcpListener(IPAddress.Any, Int32.Parse(portBox.Text));
                    //myListener.start()
                    myAsynchServer.start(IPAddress.Parse(ipAddress), Convert.ToInt32(portBox.Text));

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Invalid IP adress");
                }
                
                

            }
            else
            {
                running = false;
                startStopButton.Text = "Start";
                myAsynchServer.stop();
            }
        }





    }
}


