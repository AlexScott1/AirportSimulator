using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace PlaneLogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int BUFSIZE = 128;
        private int numOfTakeoffs = 0, numOfLandings = 0;
        private string b = string.Empty;
        private Thread readThread;

        private void ChatServerForm_Load(object sender, EventArgs e)
        {

            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
            DisplayMessage("Server loaded and waiting for connections\r\n-----------------------------------------------------------------");
        }

        private void ChatServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Environment.Exit(System.Environment.ExitCode);
        }

        private delegate void DisplayDelegate(string message);

        private void DisplayMessage(string message)
        {
            if (displayTextBox.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else displayTextBox.AppendText(message);
        }

        private void DisplayTotPlanes(string message)
        {
            if (totalTakeOffsTB.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayTotPlanes), new object[] { message });
            }
            else
            {
                totalTakeOffsTB.Clear();
                totalTakeOffsTB.AppendText(message);
            }
        }

        private void DisplayTotLandings(string message)
        {
            if (planesLandedTB.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayTotLandings), new object[] { message });
            }
            else
            {
                planesLandedTB.Clear();
                planesLandedTB.AppendText(message);
            }
        }

        private delegate void DisableInputDelegate(bool value);
        
        public void RunServer()
        {
            int servPort = 888; //Port 888 is the default
           
            TcpListener listener = null; //Initalise and set it to null

            try //Try catch in case connection fails
            {
                //Create a TCPListener to accept client connections (from any IP address)
                listener = new TcpListener(IPAddress.Any, servPort);
                listener.Start();
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                Environment.Exit(se.ErrorCode);
            }

            byte[] rcvBuffer = new byte[BUFSIZE]; //Receive buffer
            int bytesRcvd; //Received byte count from the connection
            for (; ; ) //Run infinitely, accepting all connections until the application is closed
            { 
                TcpClient client = null;
                NetworkStream netStream = null;
               
                try
                {
                    client = listener.AcceptTcpClient(); //Get client connection
                    netStream = client.GetStream();
                    Console.Write("Handling client - ");

                    int totalBytesEchoed = 0; //Receive until client closes connection, indicated by 0 return value
                                       
                    while ((bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0)
                    {
                        netStream.Write(rcvBuffer, 0, bytesRcvd);
                        string s = Encoding.UTF8.GetString(rcvBuffer, 0, rcvBuffer.Length);

                        for (int i = 0; i < s.Length; i++) 
                        {
                            if (Char.IsDigit(s[i])) //Check if the string has a number in it (eg 'HUB 1')
                                b += s[i];
                        }

                        DisplayMessage("\r\n" + s); //Add the message to the logger
                        totalBytesEchoed += bytesRcvd;
                    }

                    if (b.Length == 0) //If there was no number in the string ('A plane has taken off')
                    {                  //Add 1 to the taken off count
                        numOfTakeoffs++;
                        DisplayTotPlanes(numOfTakeoffs.ToString());
                    }
                    else if (b.Length == 1) //If there was one number in the string ('A plane has arrived at HUB 1')
                    {                       //Add 1 to the landing count
                        b = string.Empty;
                        numOfLandings++;
                        DisplayTotLandings(numOfLandings.ToString());
                    }
                    else //If there was more than 1 number in the string ('A Boeing 747 has landed at the Airport')
                    {    //Don't increment any counters.
                        b = string.Empty;
                    }
                                            
                    Console.WriteLine("echoed {0} bytes.", totalBytesEchoed); //Echo it back to the console
                    
                    for (int i = 0; i < BUFSIZE; i++)
                        rcvBuffer[i] = 0;
                    
                    //Close the stream and socket. We are done with this connection
                    netStream.Close();
                    client.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    netStream.Close();
                }
            }

        }

        private void totalTakeOffsTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}