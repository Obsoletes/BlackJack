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
			int port = 80;
			string host = "47.100.172.185";
			Console.WriteLine("Start");
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
					int bytes = socket.Receive(recBytes, recBytes.Length, 0);
					Console.WriteLine(Encoding.ASCII.GetString(recBytes, 0, bytes));
					System.Threading.Thread.Sleep(500);
					Console.Write("Next:");
					sendStr = Console.ReadLine();
					sendBytes = Encoding.ASCII.GetBytes(sendStr); 
					socket.Send(sendBytes);
				}
			}

		}
	}
}
