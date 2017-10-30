using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Server
    {
        static void Main(string[] args)
        {
            //Server


            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 54321);
            listener.Start();
            while(true)
            {
                Socket socket = listener.AcceptSocket();

                Thread t = new Thread(new ParameterizedThreadStart(threadMethod));
                t.Start(socket);
            }
        }

        private static void threadMethod(object obj)
        {
            Socket socket = (Socket)obj;

            NetworkStream ns = new NetworkStream(socket);
            StreamWriter sr = new StreamWriter(ns);

            bool cont = true;

            while (cont)
            {
                try
                {
                    sr.WriteLine("Hello");
                    sr.Flush();
                }catch(Exception e)
                {
                    cont = false;
                }
            }
        }
    }
}
