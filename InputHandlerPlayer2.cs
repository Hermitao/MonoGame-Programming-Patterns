using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IroncladSewing
{
    public class InputHandlerPlayer2
    {
        private AttackCommand buttonAttack;
        private JumpCommand buttonJump;
        private MoveLeftCommand buttonMoveLeft;
        private MoveLeftReleaseCommand buttonMoveLeftRelease;
        private DuckCommand buttonDuck;
        private DuckReleaseCommand buttonDuckRelease;
        private MoveRightCommand buttonMoveRight;
        private MoveRightReleaseCommand buttonMoveRightRelease;

        private NullCommand buttonNull;
        
        public Command HandleInput()
        {
            buttonNull = new NullCommand();
            buttonAttack = new AttackCommand();
            buttonJump = new JumpCommand();
            buttonMoveLeft = new MoveLeftCommand();
            buttonMoveLeftRelease = new MoveLeftReleaseCommand();
            buttonDuck = new DuckCommand();
            buttonDuckRelease = new DuckReleaseCommand();
            buttonMoveRight = new MoveRightCommand();
            buttonMoveRightRelease = new MoveRightReleaseCommand();
            
            if (KeyboardHandler.Shot(GameSettings.InputPlayer2.attack))
            { return buttonAttack; }

            if (KeyboardHandler.Shot(GameSettings.InputPlayer2.jump)) 
            { return buttonJump; }

            if (KeyboardHandler.Shot(GameSettings.InputPlayer2.moveLeft)) 
            { return buttonMoveLeft; }
            if (KeyboardHandler.Released(GameSettings.InputPlayer2.moveLeft)) 
            { return buttonMoveLeftRelease; }

            if (KeyboardHandler.Shot(GameSettings.InputPlayer2.duck)) 
            { return buttonDuck; }
            if (KeyboardHandler.Released(GameSettings.InputPlayer2.duck)) 
            { return buttonDuckRelease; }

            if (KeyboardHandler.Shot(GameSettings.InputPlayer2.moveRight)) 
            { return buttonMoveRight; }
            if (KeyboardHandler.Released(GameSettings.InputPlayer2.moveRight)) 
            { return buttonMoveRightRelease; }
            
            return buttonNull;
        }
    }
}