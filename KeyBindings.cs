using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IroncladSewing
{
    public class KeyBindings
    {
        public Keys attack;
        public Keys jump;
        public Keys moveRight;
        public Keys moveLeft;
        public Keys duck;

        public KeyBindings(
            Keys attack = Keys.F,
            Keys jump = Keys.W,
            Keys moveRight = Keys.D,
            Keys moveLeft = Keys.A,
            Keys duck = Keys.S
        )
        {
            this.attack = attack;
            this.jump = jump;
            this.moveRight = moveRight;
            this.moveLeft = moveLeft;
            this.duck = duck;
        }
    }
}
