using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InputHandlerPlayer1
{
    KeyboardState kstate;

    private AttackCommand buttonAttack;
    private JumpCommand buttonJump;
    private MoveLeftCommand buttonMoveLeft;
    private DuckCommand buttonDuck;
    private MoveRightCommand buttonMoveRight;

    private NullCommand buttonNull;
    

    public Command HandleInput()
    {
        if (kstate.IsKeyDown(Keys.F)) { return buttonAttack; }
        if (kstate.IsKeyDown(Keys.W)) { return buttonJump; }
        if (kstate.IsKeyDown(Keys.A)) { return buttonMoveLeft; }
        if (kstate.IsKeyDown(Keys.S)) { return buttonDuck; }
        if (kstate.IsKeyDown(Keys.D)) { return buttonMoveRight; }
        
        return buttonNothing;
    }
}