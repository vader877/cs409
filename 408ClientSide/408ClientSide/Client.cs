﻿using System;
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
            statusText.Text = "DISCONNECTED";
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    // establishing connection to the server 

                    connectButton.Text = "Disconnect";
                    byte ipPart1 = Convert.ToByte(ipServer.Text.Substring(0, 3));
                    byte ipPart2 = Convert.ToByte(ipServer.Text.Substring(4, 3));
                    byte ipPart3 = Convert.ToByte(ipServer.Text.Substring(8, 3));
                    byte ipPart4 = Convert.ToByte(ipServer.Text.Substring(12, 3));
                    string ipFinal = ipPart1.ToString() + "." + ipPart2.ToString() + "." + ipPart3.ToString() + "." + ipPart4.ToString();
                    int portNo = (int)portNumber.Value;
                    newClient.Connect(ipFinal, portNo);
                    displayScreen.AppendText("Establising connection to the server...\n");

                    // sending playerName to the server

                    NetworkStream serverStream = newClient.GetStream();
                    byte[] sentStream = System.Text.Encoding.ASCII.GetBytes(playerName.Text + "$");
                    serverStream.Write(sentStream, 0, sentStream.Length);
                    serverStream.Flush();

                    displayScreen.AppendText("Checking for " + playerName + "...\n");

                    // receiving acknowledgement from the server about if playerName is unique or not

                    byte[] approvalByte = new byte[1024];
                    serverStream.Read(approvalByte, 0, (int)approvalByte.Length);
                    string approvalString = System.Text.Encoding.ASCII.GetString(approvalByte);

                    if (approvalString == "y")
                    {

                        isConnected = true;
                        displayScreen.AppendText("Connection successful!\n\n");
                        statusText.Text = "CONNECTED";
                    }

                    else
                    {
                        displayScreen.AppendText("Player already exists. Please try a different name.\n\n");
                        connectButton.Text = "Connect";
                        newClient.Close();
                        playerName.Clear();
                    }
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listButton_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = newClient.GetStream();
            byte[] sentStream = System.Text.Encoding.ASCII.GetBytes("PL$");
            serverStream.Write(sentStream, 0, sentStream.Length);
            serverStream.Flush();

            displayScreen.AppendText("Generating the list of online players...\n\n");

            byte[] PLByte = new byte[1024];
            serverStream.Read(PLByte, 0, (int)PLByte.Length);
            string PLString = System.Text.Encoding.ASCII.GetString(PLByte);
            string[] words = PLString.Split('$');
            
            for(int i=0; i<words.Length; i++)
            {
                displayScreen.AppendText(words[0] + "\n");
            }

            displayScreen.AppendText("\n");
        }
    }
}