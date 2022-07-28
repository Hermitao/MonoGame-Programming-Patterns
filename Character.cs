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
        Running,
        Jumping,
        Ducking,
        Attacking
    }

    public float speed = 4f;
    public float jumpVelocity = 20f;
    public float currentVelocity;

    public State state;

    public Character(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
        currentVelocity = new Vector2(0, 0);
        Idle();
    }

    public override void Update(float deltaTime)
    {
        animatedSprite.Update(deltaTime);

        currentVelocity = new Vector2(
            currentVelocity.X, 
            currentVelocity.Y + WorldSettings.gravity * deltaTime);

        Position += currentVelocity;

        if (Position.Y > 400f)
        {
            Position.Y = 400f;
        }
    }

    public void Attack()
    {
        state = State.Attacking;
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

        currentVelocity = new Vector2(0, currentVelocity.Y);
    }

    public void Duck()
    {
        state = State.Ducking;
        animatedSprite.MinFrame = 4;
        animatedSprite.MaxFrame = 7;
        animatedSprite.Fps = 5;
    }

    public void Jump()
    {
        state = State.Jumping;
        animatedSprite.MinFrame = 16;
        animatedSprite.MaxFrame = 17;
        animatedSprite.Fps = 5;

        currentVelocity = new Vector2(currentVelocity.X, jumpVelocity);
    }

    public void MoveRight()
    {
        state = State.Running;
        animatedSprite.MinFrame = 8;
        animatedSprite.MaxFrame = 13;
        animatedSprite.Fps = 12;

        currentVelocity = new Vector2(speed, currentVelocity.Y);
    }

    public void MoveLeft()
    {
        state = State.Running;
        animatedSprite.MinFrame = 8;
        animatedSprite.MaxFrame = 13;
        animatedSprite.Fps = 12;

        currentVelocity = new Vector2(-speed, currentVelocity.Y);
    }
}