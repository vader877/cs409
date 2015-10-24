﻿using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

//22:45

namespace _408ClientSide
{
    public partial class Client : Form
    {
        TcpClient newClient = new TcpClient();

        public Client()
        {
            InitializeComponent();
            statusText.Text = "DISCONNECTED";
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!newClient.Connected)
            {
                try
                {
                    // establishing connection to the server
                    connectButton.Text = "Disconnect";
                    IPAddress ipAdr= IPAddress.Parse(ipServer.Text);
                    int portNo = (int)portNumber.Value;
                    newClient.Connect(ipAdr, portNo);
                    NetworkStream serverStream = newClient.GetStream();
                    displayScreen.AppendText("Establising connection to the server...\n");
                
                    byte[] approvalByte = new byte[4];
                    
                    for (int k=0; k<3; k++)
                    {
                        if (newClient.Connected)
                        {
                            serverStream.Read(approvalByte, 0, (int)approvalByte.Length);
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    
                    string approvalString = System.Text.Encoding.ASCII.GetString(approvalByte);
                   

                    if (approvalString == "001$")
                    {
                        // sending playerName to the server
                        displayScreen.AppendText("Checking for " + playerName + "...\n");
                        byte[] pNameByte = System.Text.Encoding.ASCII.GetBytes(playerName.Text + "$");
                        serverStream.Write(pNameByte, 0, pNameByte.Length);
                        serverStream.Flush();

                        // receiving acknowledgement from the server about if playerName is unique or not
                        byte[] nameCheckByte = new byte[4];
                        serverStream.Read(nameCheckByte, 0, (int)nameCheckByte.Length);
                        string nameCheckString = System.Text.Encoding.ASCII.GetString(nameCheckByte);

                        if (nameCheckString == "002$")
                        {
                            displayScreen.AppendText("Connection successful!\n\n");
                            statusText.Text = "CONNECTED";
                        }

                        else
                        {
                            displayScreen.AppendText("Player already exists. Please try a different name.\n\n");
                            connectButton.Text = "Connect";

                            if (newClient.Connected)
                                newClient.Close();
                            
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
                NetworkStream disconnectStream = newClient.GetStream();
                byte[] disconnectByte = System.Text.Encoding.ASCII.GetBytes("004$");
                disconnectStream.Write(disconnectByte, 0, disconnectByte.Length);
                disconnectStream.Flush();
                newClient.Close();
                
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
            byte[] sentStream = System.Text.Encoding.ASCII.GetBytes("PL");
            serverStream.Write(sentStream, 0, sentStream.Length);
            serverStream.Flush();

            displayScreen.AppendText("Generating the list of online players...\n\n");

            byte[] PLByte = new byte[102400];   // a list size of 100 kilobytes
            serverStream.Read(PLByte, 0, (int)PLByte.Length);
            string PLString = System.Text.Encoding.ASCII.GetString(PLByte);
            string[] words = PLString.Split('$');
            
            for(int i=0; i<words.Length; i++)
            {
                displayScreen.AppendText(words[i] + "\n");
            }

            displayScreen.AppendText("\n");
        }
       
    }
}
