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

namespace _408ServerSide
{
    public partial class Form1 : Form
    {
        int portno;
        TcpListener serverSocket;
        string ipAddress;
        Boolean isStarted = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void startStopButton_Click(object sender, EventArgs e)
        {

        }

        private void connect()
        {
            if(!isStarted)
            {
                byte ipPart1 = Convert.ToByte(ipBox.Text.Substring(0, 3));
                byte ipPart2 = Convert.ToByte(ipBox.Text.Substring(4, 3));
                byte ipPart3 = Convert.ToByte(ipBox.Text.Substring(8, 3));
                byte ipPart4 = Convert.ToByte(ipBox.Text.Substring(12, 3));
                ipAddress = ipPart1.ToString() + "." + ipPart2.ToString() + "." + ipPart3.ToString() + "." + ipPart4.ToString();
                serverSocket = new TcpListener(IPAddress.Any, Int32.Parse(portBox.Text));
                isStarted = true;
                TcpClient clientSocket = default(TcpClient);
                serverSocket.Start();
            }
            else
            {
                isStarted = false;
            }
            
        }
    }
}
