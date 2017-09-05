using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Server
    {
       String myLine;
       //al kode som håndtere Client ligger i denne metode.
       public void DoClient(TcpListener server)
       {
           using (TcpClient socket = server.AcceptTcpClient())
           using (NetworkStream ns = socket.GetStream())
           using (StreamReader sreader = new StreamReader(ns))
           using (StreamWriter swriter = new StreamWriter(ns))
           {
            //While-Loop, checker om programmet skal stoppes eller ej.
               while (true)
               {
                   //checker clients input
                   String line = sreader.ReadLine();
                   //If-statements - Hvis en linje = Stop. skal programmet stoppes
                   if (line == "STOP" || myLine == "STOP")
                   {
                       break;
                   }
                   //Hvis ikke - fortsæt og print det ud
                   Console.WriteLine(line);
                    
                   //Skriver til Client-siden
                   Console.Write("Server: ");
                   myLine = Console.ReadLine();
                   swriter.WriteLine(myLine);
                   swriter.Flush();
               }
           }
       }

       //starter server op. Og køre DoClient metode    
       public void Start()
       {
           TcpListener Server = new TcpListener(IPAddress.Loopback, 7070);
           Server.Start();
           DoClient(Server);
       }        
    }
}
