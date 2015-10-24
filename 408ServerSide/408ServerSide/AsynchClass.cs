using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchServer
{
    class AsynchClass
    {
        int counter = 0;

        string dataFromClient = null;
        Boolean running = false;
        TcpListener serverSocket;
        TcpClient clientSocket;
        Thread myListenerThread;
        List<ClientConnection> clientList = new List<ClientConnection>();

        public void start(IPAddress ip, int port)
        {
            running = true;
            serverSocket = new TcpListener(ip, port);
            serverSocket.Start();
            myListenerThread = new Thread(listenerThread);
            myListenerThread.Start();
        }

        private void listenerThread()
        {
            while (running)
            {
                counter++;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >>A new client requested connection!");
                ClientConnection client = new ClientConnection(clientList);
                client.startClient(clientSocket, counter);
            }
        }
        public void stop()
        {
            running = false;
            serverSocket.Stop();
            foreach(ClientConnection x in clientList)
            {
                x.sendData("999$");
                x.stopClient();
            }
        }

        private class ClientConnection
        {
            int retry = 3;
            Boolean rejected = false;
            string clientName = null;
            int clNo;
            Boolean running = false;
            TcpClient clientSocket;
            Thread recievedDataThread;
            Byte[] sendBytes = null;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            NetworkStream networkStream;
            List<ClientConnection> clientList;


            public ClientConnection(List<ClientConnection> clientList)
            {
                this.clientList = clientList;
            }

            public void startClient(TcpClient inClientSocket, int clineNo)
            {
                running = true;
                this.clientSocket = inClientSocket;
                this.clNo = clineNo;

                networkStream = clientSocket.GetStream();

                recievedDataThread = new Thread(recievedData);
                recievedDataThread.Start();

                for (int x = 0; x < retry; x++ )
                {
                    sendData("001$");
                    Thread.Sleep(500);
                    clientName = dataFromClient;
                }
                
                if(clientName == null)
                {
                    //no response recieved
                    stopClient();
                }
                else
                {
                    foreach(ClientConnection x in clientList)
                    {
                        if(x.clientName.Equals(this.clientName))
                        {
                            rejected = true;
                            sendData("002$");
                        }
                    }
                    if(!rejected)
                    {
                        clientList.Add(this);
                        sendData("003$");
                    }
                }
            }

            public void stopClient()
            {
                running = false;
                recievedDataThread.Abort();
                if(clientList.Contains(this))
                {
                    clientList.Remove(this);
                }
            }

            public void sendData(String data)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    sendBytes = Encoding.ASCII.GetBytes(data);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                    stopClient();
                }
            }

            public void recievedData()
            {
                while(running)
                {
                    try
                    {
                        networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                        dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        Console.WriteLine(" >> " + "From client-" + clNo + dataFromClient);

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(" >> " + ex.ToString());
                        stopClient();
                    }
                }
            }
        }  
    }
}
