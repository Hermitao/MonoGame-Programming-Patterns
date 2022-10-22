using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Riptide;
using Riptide.Utils;

namespace IroncladSewing
{
    public static class Utils
    {
        public static string InputText()
        {
            Console.Write(">");
            string text = Console.ReadLine();
            return text;
        }

        public static void print(string textToPrint)
        {
            Console.WriteLine(textToPrint);
        }
    }
}
