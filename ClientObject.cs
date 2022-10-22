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
    public class ClientObject
    {
        public Client client = new Client();
        public string name;
        public string ip;
        public string port;
        public string address;

        public void Initialize()
        {
            RiptideLogger.Initialize(Console.WriteLine, Console.WriteLine, Console.WriteLine, Console.WriteLine, false);

            Console.WriteLine("Your username: (default Johannes)");
            name = InputText();
            name = name == "" ? "Johannes" : name;

            Console.WriteLine("Server IP: (default 127.0.0.1)");
            ip = InputText();
            ip = ip == "" ? "127.0.0.1" : ip;

            Console.WriteLine("Server port: (7777)");
            port = InputText();
            port = port == "" ? "7777" : port;
            address = ip + ":" + port;

            Console.WriteLine("Connecting to " + address + " as " + name);
            client.Connect(address);
        }

        public void Update()
        {
            client.Update();
        }
    }
}
