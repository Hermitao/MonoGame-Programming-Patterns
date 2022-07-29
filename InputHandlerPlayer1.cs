using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class InputHandlerPlayer1
{
    private AttackCommand buttonAttack;
    private JumpCommand buttonJump;
    private MoveLeftCommand buttonMoveLeft;
    private DuckCommand buttonDuck;
    private MoveRightCommand buttonMoveRight;

    private NullCommand buttonNull;
    
    private KeyboardState oldState;

    public Command HandleInput()
    {
        var newState = Keyboard.GetState();

        // if(oldState.IsKeyUp(Keys.F) && newState.IsKeyDown(Keys.F))
        // {
        //     return buttonAttack;
        // }

        oldState = newState;

        buttonNull = new NullCommand();
        buttonAttack = new AttackCommand();
        buttonJump = new JumpCommand();
        buttonMoveLeft = new MoveLeftCommand();
        buttonDuck = new DuckCommand();
        buttonMoveRight = new MoveRightCommand();

        if (newState.IsKeyDown(Keys.F)) { return buttonAttack; }
        if (newState.IsKeyDown(Keys.W)) { return buttonJump; }
        if (newState.IsKeyDown(Keys.A)) { return buttonMoveLeft; }
        if (newState.IsKeyDown(Keys.S)) { return buttonDuck; }
        if (newState.IsKeyDown(Keys.D)) { return buttonMoveRight; }
        
        return buttonNull;
    }
}