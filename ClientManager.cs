using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Riptide;
using Riptide.Utils;

using static IroncladSewing.Utils;

namespace IroncladSewing
{
    public class ClientManager
    {
        public Client client = new Client();
        public string ip;
        public string port;
        public string address;

        public void Initialize()
        {
            RiptideLogger.Initialize(Console.WriteLine, Console.WriteLine, Console.WriteLine, Console.WriteLine, false);
            Console.WriteLine("Server IP: (default 127.0.0.1)");
            ip = InputText();
            ip = ip == "" ? "127.0.0.1" : ip;
            Console.WriteLine("Server port: (7777)");
            port = InputText();
            port = port == "" ? "7777" : port;
            address = ip + ":" + port;
            Console.WriteLine("Connecting to " + address);
            client.Connect(address);
        }

        public void Update()
        {
            client.Update();
        }
    }
}
