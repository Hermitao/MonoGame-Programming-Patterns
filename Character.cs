using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
 
public class Character : Entity
{
    public enum State{
        Idle,
        Jumping,
        Ducking
    }

    public State state;

    public Character(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
        Idle();
    }

    public void Jump()
    {
        state = State.Jumping;
        animatedSprite.MinFrame = 42;
        animatedSprite.MaxFrame = 56;
        animatedSprite.Fps = 12;
    }

    public void Idle()
    {
        state = State.Idle;
        animatedSprite.MinFrame = 0;
        animatedSprite.MaxFrame = 3;
        animatedSprite.Fps = 5;
    }

    public void Duck()
    {
        state = State.Ducking;
        animatedSprite.MinFrame = 4;
        animatedSprite.MaxFrame = 7;
        animatedSprite.Fps = 5;
    }
}