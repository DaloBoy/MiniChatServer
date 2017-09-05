using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        string line;
        public void Start()
        {
            //anlægger Client-håndterende kode
            using(TcpClient client = new TcpClient("localhost", 7))
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //While-Loop. While True, do this
                while (true)
                {
                    //Skriver til serveren
                    Console.Write("Client: ");
                    String cLine = Console.ReadLine();
                    sw.WriteLine(cLine);
                    sw.Flush();

                    //Læs for at håndtere input fra server
                    line = sr.ReadLine();
                    if (cLine == "STOP" || line == "STOP")
                    {
                        break;
                    }
                    //Hvis condition er false print det ud
                    Console.WriteLine(line);
                }
            }
        }
    }
}
