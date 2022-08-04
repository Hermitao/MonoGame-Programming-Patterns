using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IroncladSewing
{
    public static class GameSettings
    {
        public static class InputPlayer1
        {
            public static Keys attack = Keys.F;
            public static Keys jump = Keys.W;
            public static Keys moveRight = Keys.D;
            public static Keys moveLeft = Keys.A;
            public static Keys duck = Keys.S;
        }

        public static class InputPlayer2
        {
            public static Keys attack = Keys.OemPeriod;
            public static Keys jump = Keys.Up;
            public static Keys moveRight = Keys.Right;
            public static Keys moveLeft = Keys.Left;
            public static Keys duck = Keys.Down;
        }
    }
}