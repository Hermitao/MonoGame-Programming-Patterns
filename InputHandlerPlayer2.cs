using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class InputHandlerPlayer2
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
        var kstate = Keyboard.GetState();

        buttonNull = new NullCommand();
        buttonAttack = new AttackCommand();
        buttonJump = new JumpCommand();
        buttonMoveLeft = new MoveLeftCommand();
        buttonDuck = new DuckCommand();
        buttonMoveRight = new MoveRightCommand();
        
        if (kstate.IsKeyDown(Keys.OemPeriod)) { return buttonAttack; }
        if (kstate.IsKeyDown(Keys.Up)) { return buttonJump; }
        if (kstate.IsKeyDown(Keys.Left)) { return buttonMoveLeft; }
        if (kstate.IsKeyDown(Keys.Down)) { return buttonDuck; }
        if (kstate.IsKeyDown(Keys.Right)) { return buttonMoveRight; }
        
        return buttonNull;
    }
}