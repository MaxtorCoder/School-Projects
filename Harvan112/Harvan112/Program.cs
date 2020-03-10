using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Harvan112.Structures;
using Newtonsoft.Json;

namespace Harvan112
{
    class Program
    {
        private static TcpListener Listener;
        private static List<AED> AEDs = new List<AED>();

        static void Main(string[] args)
        {
            // Initializing AEDs
            InitializeAEDs();

            // Create a new instance of TcpListener
            Listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 6666);

            // Start the listener and start listening for incoming connections.
            Listener.Start();

            Console.WriteLine(">> Start listening for incoming requests...");
            new Thread(SocketThread).Start();
        }

        static void SocketThread()
        {
            while (true)
            {
                while (Listener.Pending())
                {
                    new Session(Listener.AcceptSocket(), AEDs);
                }
            }
        }

        private static AED GetAEDInfo(uint aedId)
        {
            var Client = new WebClient();
            var result = Client.DownloadString($"http://localhost/LoginPage2/api/getaedinfo.php?id={aedId}");
            var aedInfo = JsonConvert.DeserializeObject<AED>(result);
            return aedInfo;
        }

        private static void InitializeAEDs()
        {
            Console.WriteLine(">> Initializing AEDs...");

            // Only load 70 AEDs, above 70 is NULL.
            // This is also incredibely slow, have to find a way to speed up the process
            // of loading so it does not take 5 minutes with over 300 AEDs.
            for (var i = 0u; i < 70u; i++)
                AEDs.Add(GetAEDInfo(i + 1));

            Console.WriteLine($">> Initialized {AEDs.Count} AEDs..");
        }
    }
}
