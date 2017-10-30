using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 54321);

            var sw = new StreamReader(client.GetStream());

            while(true)
            {
                string line = sw.ReadLine();
                Console.WriteLine(line);
            }

        }
    }
}
