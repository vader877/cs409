using System;
using System.Windows.Forms;
using System.Net.Sockets;

namespace _408ClientSide
{
    public partial class Client : Form
    {
        bool isConnected;
        TcpClient newClient = new TcpClient();

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
                    byte ipPart1 = Convert.ToByte(ipServer.Text.Substring(0, 3));
                    byte ipPart2 = Convert.ToByte(ipServer.Text.Substring(4, 3));
                    byte ipPart3 = Convert.ToByte(ipServer.Text.Substring(8, 3));
                    byte ipPart4 = Convert.ToByte(ipServer.Text.Substring(12, 3));
                    string ipFinal = ipPart1.ToString() + "." + ipPart2.ToString() + "." + ipPart3.ToString() + "." + ipPart4.ToString();
                    int portNo = (int)portNumber.Value;
                    newClient.Connect(ipFinal, portNo);
                    statusText.Text = "CONNECTED";
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error is occurred while trying to connect to the server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                newClient.Close();
                isConnected = false;
                statusText.Text = "DISCONNECTED";
                connectButton.Text = "Connect";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
