using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class InputHandlerPlayer2
{
    private AttackCommand buttonAttack;
    private JumpCommand buttonJump;
    private MoveLeftCommand buttonMoveLeft;
    private MoveLeftReleaseCommand buttonMoveLeftRelease;
    private DuckCommand buttonDuck;
    private MoveRightCommand buttonMoveRight;
    private MoveRightReleaseCommand buttonMoveRightRelease;

    private NullCommand buttonNull;
    

    public Command HandleInput()
    {
        KeyboardHandler.GetState();

        buttonNull = new NullCommand();
        buttonAttack = new AttackCommand();
        buttonJump = new JumpCommand();
        buttonMoveLeft = new MoveLeftCommand();
        buttonMoveLeftRelease = new MoveLeftReleaseCommand();
        buttonDuck = new DuckCommand();
        buttonMoveRight = new MoveRightCommand();
        buttonMoveRightRelease = new MoveRightReleaseCommand();
        
        if (KeyboardState.Shot(GameSettings.InputPlayer2.attack))
        { return buttonAttack; }

        if (KeyboardState.Shot(GameSettings.InputPlayer2.jump)) 
        { return buttonJump; }

        if (KeyboardState.Shot(GameSettings.InputPlayer2.moveLeft)) 
        { return buttonMoveLeft; }
        if (KeyboardState.Released(GameSettings.InputPlayer2.moveLeft)) 
        { return buttonMoveLeftRelease; }

        if (KeyboardState.Shot(GameSettings.InputPlayer2.duck)) 
        { return buttonDuck; }

        if (KeyboardState.Shot(GameSettings.InputPlayer2.moveRight)) 
        { return buttonMoveRight; }
        if (KeyboardState.Released(GameSettings.InputPlayer2.moveRight)) 
        { return buttonMoveRightRelease; }
        
        return buttonNull;
    }
}