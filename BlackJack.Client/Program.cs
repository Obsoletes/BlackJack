using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BlackJack.Client
{
    class Program
    {
        static void Main(string[] args)
        {
			int port = 6000;
			string host = "47.100.172.185";

			IPAddress ip = IPAddress.Parse(host);
			IPEndPoint ipe = new IPEndPoint(ip, port);
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
			{
				socket.Connect(ipe);
				string sendStr = "send to server : hello,ni hao";
				byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
				byte[] recBytes = new byte[4096];
				socket.Send(sendBytes);
				while (true)
				{
					string recStr = "";
					int bytes = socket.Receive(recBytes, recBytes.Length, 0);
					recStr = Encoding.ASCII.GetString(recBytes, 0, bytes);
					Console.WriteLine(recStr);
					System.Threading.Thread.Sleep(500);
					socket.Send(sendBytes);
				}
			}
			
		}
    }
}
