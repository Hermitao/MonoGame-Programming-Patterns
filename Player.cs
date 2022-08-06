using System;
using Microsoft.Xna.Framework;

namespace IroncladSewing
{
    public class Player : Component
    {
        private int playerNumber;

        private Character playerCharacter;
        private KeyBindings keyBindings;

        public Character PlayerCharacter
        {
            get
            { 
                return playerCharacter;
            }
            set
            {
                playerCharacter = value;
            }
        }


        public Player(Character playerCharacter, int playerNumber = 0)
        {
            this.playerCharacter = playerCharacter;
            this.playerNumber = playerNumber;

            keyBindings = new KeyBindings();

            switch (playerNumber)
            {
                case 0:
                    keyBindings = new KeyBindings(
                        GameSettings.attack0,
                        GameSettings.jump0,
                        GameSettings.moveRight0,
                        GameSettings.moveLeft0,
                        GameSettings.duck0
                    );
                    break;
                case 1:
                    keyBindings = new KeyBindings(
                        GameSettings.attack1,
                        GameSettings.jump1,
                        GameSettings.moveRight1,
                        GameSettings.moveLeft1,
                        GameSettings.duck1
                    );
                    break;
            }
        }

        public override void Update(float deltaTime)
        {
            HandleInput();
        }

        private void HandleInput()
        {
            Command command = new NullCommand();
            
            
            switch (PlayerCharacter.state)
            {
                case Character.State.Idle:
                    if (KeyboardHandler.Shot(keyBindings.attack))
                    { 
                        command = new AttackCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.duck))
                    { 
                        command = new DuckCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.jump))
                    { 
                        command = new JumpCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveRight))
                    { 
                        command = new MoveRightCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveLeft))
                    {
                        command = new MoveLeftCommand();
                    }
                    break;

                case Character.State.Attacking:
                    if (KeyboardHandler.Released(keyBindings.attack))
                    {
                        command = new AttackReleaseCommand();
                    }
                    break;

                case Character.State.Ducking:
                    if (KeyboardHandler.Shot(keyBindings.attack))
                    {
                        command = new AttackCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.jump))
                    {
                        command = new JumpCommand();
                    }
                    if (KeyboardHandler.Released(keyBindings.duck))
                    {
                        command = new DuckReleaseCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveRight))
                    {
                        command = new MoveRightCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveLeft))
                    {
                        command = new MoveLeftCommand();
                    }
                    break;

                case Character.State.Jumping:
                    
                    break;

                case Character.State.RunningRight:
                    if (KeyboardHandler.Shot(keyBindings.attack))
                    {
                        command = new AttackCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.jump))
                    {
                        command = new JumpCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.duck))
                    {
                        command = new DuckCommand();
                    }
                    if (KeyboardHandler.Released(keyBindings.moveRight))
                    {
                        command = new MoveRightReleaseCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveLeft))
                    {
                        command = new MoveLeftCommand();
                    }
                    break;

                case Character.State.RunningLeft:
                    if (KeyboardHandler.Shot(keyBindings.attack))
                    {
                        command = new AttackCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.jump))
                    {
                        command = new JumpCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.duck))
                    {
                        command = new DuckCommand();
                    }
                    if (KeyboardHandler.Released(keyBindings.moveLeft))
                    {
                        command = new MoveLeftReleaseCommand();
                    }
                    if (KeyboardHandler.Shot(keyBindings.moveRight))
                    {
                        command = new MoveRightCommand();
                    }
                    break;
            }
            command.execute(PlayerCharacter);
        }
    }
}