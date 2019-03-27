using System;
using System.Net;
using System.Net.Sockets;

namespace BlackJack.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Runing");
			int port = 6000;
			IPEndPoint ipe = new IPEndPoint(IPAddress.Loopback, port);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Bind(ipe);
			socket.Listen(0);
			while (true)
			{
				Socket serverSocket = socket.Accept();
				byte[] recByte = new byte[4096];
				int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
				serverSocket.Send(recByte, bytes, SocketFlags.None);
			}
		}
	}
}
