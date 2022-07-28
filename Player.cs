using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
 
public class Player : Character
{
    public Player(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        
    }

    public void Update(float deltaTime)
    {
        animatedSprite.Update(deltaTime);
        
    }

    void HandleInput(Command command)
    {
        switch (state)
        {
            case State.Idle:
                if (command == JumpCommand)
                    Jump();
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    Duck();
                }
                break;
            case State.Jumping:
                if (kstate.IsKeyDown(Keys.D))
                {
                    Idle();
                }
                if (kstate.IsKeyDown(Keys.S))
                {
                    Duck();
                }
                break;
            case State.Ducking:
                if (kstate.IsKeyDown(Keys.Space))
                {
                    Jump();
                }
                if (kstate.IsKeyDown(Keys.W))
                {
                    Idle();
                }
                break;
        }
    }
}