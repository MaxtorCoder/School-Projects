using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Harvan112.Structures;
using Harvan112.Constants;
using Newtonsoft.Json;

namespace Harvan112
{
    public class Session
    {
        private Socket ServerSocket;
        private byte[] buffer       = new byte[4096];
        private WebClient Client    = new WebClient();
        private List<AED> AEDs      = new List<AED>();

        public Session(Socket serverSocket, List<AED> aeds)
        {
            ServerSocket    = serverSocket;
            AEDs            = aeds;

            Console.WriteLine(">> New client connected...");
            ServerSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveDataCallback, null);

            var backgroundThread = new Thread(BackgroundUpdater);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        private void ReceiveDataCallback(IAsyncResult ar)
        {
            try
            {
                var length = ServerSocket.EndReceive(ar);
                if (length == 0)
                    return;

                var data = new byte[length];
                Buffer.BlockCopy(buffer, 0, data, 0, data.Length);

                OnData(data);

                ServerSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveDataCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                OnDisconnect();
            }
        }

        private void OnData(byte[] data)
        {
            var dataString  = Encoding.UTF8.GetString(data);
            var subData     = dataString.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var packet = new ClientMessage()
            {
                ControlRoomId   = uint.Parse(subData[0]),
                Message         = subData[1],
                Priority        = (Priority)Enum.Parse(typeof(Priority), subData[2]),
                AedId           = uint.Parse(subData[3]),
            };

            var aed     = AEDs[(int)packet.AedId - 1];
            var oldAed  = (AED)aed.Clone();

            if (aed.Battery == 25.0f)
            {
                aed.Battery -= 25.0f;
                aed.Enabled = 0;
            }
            else if (aed.Battery == 0.0f)
                aed.Enabled = 0;
            else
                aed.Battery -= 25.0f;

            UpdateAEDInfo(aed, oldAed);
        }

        private void UpdateAEDInfo(AED aed, AED oldAed)
        {
            Client.DownloadString($"http://localhost/LoginPage2/api/updateaedinfo.php?id={aed.Id}&location={aed.Location}&enabled={aed.Enabled}&battery={aed.Battery}");

            Console.WriteLine($">> Updating AED {aed.Id}:");

            if (oldAed.Battery != aed.Battery)
            {
                Console.Write($"   Battery  : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{oldAed.Battery}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" -> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{aed.Battery}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (oldAed.Location != aed.Location)
            {
                Console.Write($"   Location : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{oldAed.Location}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" -> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{aed.Location}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (oldAed.Enabled != aed.Enabled)
            {
                Console.Write($"   Enabled  : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{Convert.ToBoolean(oldAed.Enabled)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($" -> ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Convert.ToBoolean(aed.Enabled)}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private void BackgroundUpdater()
        {
            var updatedAEDs = 0;
            while (true)
            {
                Thread.Sleep(10000);

                foreach (var aed in AEDs)
                {
                    var oldAed = (AED)aed.Clone();
                    if (aed.Battery == 100.0f)
                        continue;

                    aed.Battery += 25.0f;
                    if (aed.Battery == 25.0f && aed.Enabled == 0)
                        aed.Enabled = 1;

                    UpdateAEDInfo(aed, oldAed);
                    updatedAEDs++;
                }

                if (updatedAEDs > 0)
                {
                    Console.WriteLine($">> Updated {updatedAEDs} AEDs...");
                    updatedAEDs = 0;
                }
            }
        }

        private void OnDisconnect()
        {
            Console.WriteLine(">> Client disconnected..");

            ServerSocket.Close();
        }

        public void Send(string data)
        {
            var newData = Encoding.UTF8.GetBytes(data);

            ServerSocket.Send(newData);
        }
    }
}
