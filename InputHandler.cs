using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InputHandler
{
    KeyboardState kstate;

    public virtual Command HandleInput()
    {
        if (kstate.IsKeyDown(Keys.Space)) { return buttonSpace; }
        if (kstate.IsKeyDown(Keys.S)) { return buttonS; }
        if (kstate.IsKeyDown(Keys.D)) { return buttonD; }
        if (kstate.IsKeyDown(Keys.W)) { return buttonW; }

        return null;
    }

    private Command buttonSpace;
    private Command buttonS;
    private Command buttonD;
    private Command buttonW;
}