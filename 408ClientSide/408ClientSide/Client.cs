using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;

//00:41

namespace _408ClientSide
{
    public partial class Client : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        string lastData;    //last received data from the server
        
        public Client()
        {
            InitializeComponent();
            statusText.Text = "DISCONNECTED";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!sck.Connected)
            {
                try
                {
                    // establishing connection to the server
                    connectButton.Text = "Disconnect";
                    displayScreen.AppendText("Establising connection to the server...\n");

                    epLocal = new IPEndPoint(IPAddress.Any, (int)portNumber.Value);
                    sck.Bind(epLocal);

                    epRemote = new IPEndPoint(IPAddress.Parse(ipServer.Text), (int)portNumber.Value);
                    sck.Connect(epRemote);

                    buffer = new byte[3];
                    sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(CallBack), buffer);

                    ASCIIEncoding aEncoding = new ASCIIEncoding();
                    byte[] connectionRequest = aEncoding.GetBytes("10$");  // 10$ tells the server that there is a connection request from the client
                    sck.Send(connectionRequest);

                    for (int k=0; k<3; k++)
                    {
                        if (sck.Connected)
                            break;

                        else if (k == 2)
                        {
                            displayScreen.AppendText("Request timed out. No response from the server.\n\n");
                            break;
                        }
                            
                        Thread.Sleep(500);
                    }
                    

                    if (lastData == "11$")      // $11 tells the client that the connection is successful
                    {
                        lastData = string.Empty;
                        // sending playerName to the server
                        displayScreen.AppendText("Checking for " + playerName + "...\n");
                        byte[] pName = aEncoding.GetBytes(playerName.Text);
                        sck.Send(pName);

                        // receiving acknowledgement from the server about if playerName is unique or not
                        buffer = new byte[3];
                        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(CallBack), buffer);

                        if (lastData == "21$")  // 21$ tells the client that playerName is available
                        {
                            lastData = string.Empty;
                            displayScreen.AppendText("Connection successful!\n\n");
                            statusText.Text = "CONNECTED";
                        }

                        else
                        {
                            displayScreen.AppendText("Player already exists. Please try a different name.\n\n");
                            connectButton.Text = "Connect";

                            if (sck.Connected)
                                sck.Close();
                            
                            playerName.Clear();
                        }

                    }

                    else
                    {
                        displayScreen.AppendText("Connection failed!\n\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error is occurred while trying to connect to the server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                byte[] disconnectByte = aEncoding.GetBytes("40$");       // 40$ tells the server that the client requested to disconnect
                sck.Send(disconnectByte);

                sck.Close();

                statusText.Text = "DISCONNECTED";
                connectButton.Text = "Connect";
            }
        }

        private void CallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[10240];
                receivedData = (byte[])aResult.AsyncState;
                
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                lastData = aEncoding.GetString(receivedData);
                
                buffer = new byte[10240];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(CallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred while transmitting data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] listByte = aEncoding.GetBytes("30$");    // 30$ tells the server that the client requested the list of currently online players
            sck.Send(listByte);

            displayScreen.AppendText("Generating the list of online players...\n\n");

            buffer = new byte[10240];   // 10 kilobytes
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(CallBack), buffer);

            string[] words = lastData.Split('$');
            lastData = string.Empty;

            for(int i=0; i<words.Length; i++)
            {
                displayScreen.AppendText(words[i] + "\n");
            }

            displayScreen.AppendText("\n");
        }
       
    }
}
