﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();

            
        }
    }
}
