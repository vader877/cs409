using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _408ClientSide
{
    public partial class Client : Form
    {
        bool isConnected;
        TcpClient clientSocket = new TcpClient();

        public Client()
        {
            isConnected = false;
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    connectButton.Text = "Disconnect";
                    byte ipPart1 = Convert.ToByte(serverIP.Text.Substring(0, 3));
                    byte ipPart2 = Convert.ToByte(serverIP.Text.Substring(4, 3));
                    byte ipPart3 = Convert.ToByte(serverIP.Text.Substring(8, 3));
                    byte ipPart4 = Convert.ToByte(serverIP.Text.Substring(12, 3));
                    string ipAddress = ipPart1.ToString() + "." + ipPart2.ToString() + "." + ipPart3.ToString() + "." + ipPart4.ToString();
                    int portNo = (int)portNumber.Value;
                    clientSocket.Connect(ipAddress, portNo);
                    statusText.Text = "CONNECTED";
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error is occurred while trying to conntect to the server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                clientSocket.Close();
                isConnected = false;
                statusText.Text = "DISCONNECTED";
                connectButton.Text = "Connect";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
