using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IroncladSewing
{
    public class Character : Entity
    {
        public enum State{
            Idle,
            RunningRight,
            RunningLeft,
            Jumping,
            Ducking,
            Attacking
        }

        public List<Component> components;
        public float speed = 4f;
        public float jumpVelocity = 9f;
        public Vector2 currentVelocity;
        public State state;
        public bool PressingRight 
        { 
            get
            {
                return pressingRight;
            } 
            
            set
            {
                pressingRight = value;
            }
        }
        public bool PressingLeft 
        {
            get
            {
                return pressingLeft;
            } 
            set
            {
                pressingLeft = value;
            } 
        }


        private float initialXScale;
        
        
        private bool pressingRight = false;
        private bool pressingLeft = false;

        public Character(
            Texture2D spriteSheet, int rows, int columns, 
            Vector2? position = null,
            Vector2? scale = null) 
            : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
        {
            animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
            currentVelocity = new Vector2(0, 0);
            this.initialXScale = scale.Value.X;
            components = new List<Component>();

            Idle();
        }

        public override void Update(float deltaTime)
        {
            currentVelocity = currentVelocity + WorldSettings.gravity * deltaTime;

            Position += currentVelocity;

            if (Position.Y > 400f)
            {
                Position = new Vector2(Position.X, 400f);

                switch (state)
                {
                    case State.Jumping:
                        if (pressingRight)
                        {
                            MoveRight();
                        }
                        else if (pressingLeft)
                        {
                            MoveLeft();
                        }
                        else
                        {
                            Idle();
                        }
                        break;
                }
            }

            foreach (Component component in components)
            {
                component.Update(deltaTime);
            }

            base.Update(deltaTime);
        }

        public void Attack()
        {
            state = State.Attacking;
            animatedSprite.MinFrame = 42;
            animatedSprite.MaxFrame = 56;
            animatedSprite.Fps = 12;

            currentVelocity = new Vector2(0, currentVelocity.Y);
        }

        public void Idle()
        {
            state = State.Idle;
            animatedSprite.MinFrame = 0;
            animatedSprite.MaxFrame = 3;
            animatedSprite.Fps = 5;

            currentVelocity = new Vector2(0, currentVelocity.Y);
        }

        public void Duck()
        {
            state = State.Ducking;
            animatedSprite.MinFrame = 4;
            animatedSprite.MaxFrame = 7;
            animatedSprite.Fps = 5;

            currentVelocity = new Vector2(0, currentVelocity.Y);
        }

        public void Jump()
        {
            state = State.Jumping;
            animatedSprite.MinFrame = 16;
            animatedSprite.MaxFrame = 17;
            animatedSprite.Fps = 5;

            currentVelocity = new Vector2(currentVelocity.X, -jumpVelocity);
        }

        public void MoveRight(bool releasedCommand = false)
        {
            if (releasedCommand)
            {
                if (pressingLeft)
                {
                    MoveLeft();
                }
                else
                {
                    Idle();
                }
                return;
            }

            state = State.RunningRight;
            animatedSprite.MinFrame = 8;
            animatedSprite.MaxFrame = 13;
            animatedSprite.Fps = 11;

            currentVelocity = new Vector2(speed, currentVelocity.Y);
            flipX = false;
        }

        public void MoveLeft(bool releasedCommand = false)
        {
            if (releasedCommand)
            {
                if (pressingRight)
                {
                    MoveRight();
                }
                else
                {
                    Idle();
                }
                return;
            }

            state = State.RunningLeft;
            animatedSprite.MinFrame = 8;
            animatedSprite.MaxFrame = 13;
            animatedSprite.Fps = 11;

            currentVelocity = new Vector2(-speed, currentVelocity.Y);
            flipX = true;
        }
    }
}