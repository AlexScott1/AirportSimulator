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

//////////////////////////////////////////////////////////////////////////////////////////
//                                                                                      //
//           Code based on :                                                            //
//           "C# for Programmers Second Edition", Deitel & Deitel .                     //
//           [Chapter 23, pages 1028-1031]                                              //
//                                                                                      //
//////////////////////////////////////////////////////////////////////////////////////////


namespace ChatServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Socket connection;
        private Thread readThread;
        private NetworkStream socketStream;
        private BinaryWriter writer;
        private BinaryReader reader;
        private const int BUFSIZE = 128;
        private int numOfTakeoffs = 0, numOfLandings = 0;
        private string b = string.Empty;

        private void ChatServerForm_Load(object sender, EventArgs e)
        {

            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
            DisplayMessage("Server loaded and connected\r\n-----------------------------------------------");
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

            
            int servPort = 888; // (args.Length == 1) ? Int32.Parse(args[0]) : 8080;
           
            TcpListener listener = null;

            try
            {
                // Create a TCPListener to accept client connections
                listener = new TcpListener(IPAddress.Any, servPort);
                listener.Start();
            }
            catch (SocketException se)
            {
                // IPAddress.Any
                Console.WriteLine(se.ErrorCode + ": " + se.Message);
                //Console.ReadKey();
                Environment.Exit(se.ErrorCode);

            }

            byte[] rcvBuffer = new byte[BUFSIZE]; // Receive buffer
            int bytesRcvd; // Received byte count
            for (; ; )
            { // Run forever, accepting and servicing connections
                // Console.WriteLine(IPAddress.Any);
                TcpClient client = null;
                NetworkStream netStream = null;
                //Console.WriteLine(IPAddress.None);

                try
                {
                    client = listener.AcceptTcpClient(); // Get client connection
                    netStream = client.GetStream();
                    Console.Write("Handling client - ");

                    // Receive until client closes connection, indicated by 0 return value
                    int totalBytesEchoed = 0;
                    
                    
                    while ((bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0)
                    {
                        
                        netStream.Write(rcvBuffer, 0, bytesRcvd);
                        string s = Encoding.UTF8.GetString(rcvBuffer, 0, rcvBuffer.Length);

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (Char.IsDigit(s[i]))
                                b += s[i];
                        }

                        DisplayMessage("\r\n" + s);
                        totalBytesEchoed += bytesRcvd;
                        
                        
                    }
                    if (b.Length < 1)
                    {
                        numOfTakeoffs++;
                        DisplayTotPlanes(numOfTakeoffs.ToString());
                    }
                    else
                    {
                        b = string.Empty;
                        numOfLandings++;
                        DisplayTotLandings(numOfLandings.ToString());
                    }
                        
                    Console.WriteLine("echoed {0} bytes.", totalBytesEchoed);
                    
                    for (int i = 0; i < BUFSIZE; i++)
                        rcvBuffer[i] = 0;
                    
                    // Close the stream and socket. We are done with this client!
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