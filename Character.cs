using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
 
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
    public float jumpVelocity = 9f;
    public Vector2 currentVelocity;

    public State state;

    private float initialXScale;

    public Character(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
        currentVelocity = new Vector2(0, 0);
        this.initialXScale = scale.Value.X;

        Idle();
    }

    public override void Update(float deltaTime)
    {
        animatedSprite.Update(deltaTime);

        currentVelocity = currentVelocity + WorldSettings.gravity * deltaTime;

        Position += currentVelocity;

        if (Position.Y > 400f)
        {
            Position = new Vector2(Position.X, 400f);

            bool movingRight = currentVelocity.X > 0.1f;
            bool movingLeft = currentVelocity.X < -0.1f;
            switch (state)
            {
                case State.Jumping:
                    if (movingRight)
                    {
                        MoveRight();
                    }
                    else if (movingLeft)
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

    public void MoveRight()
    {
        state = State.Running;
        animatedSprite.MinFrame = 8;
        animatedSprite.MaxFrame = 13;
        animatedSprite.Fps = 12;

        currentVelocity = new Vector2(speed, currentVelocity.Y);
        flipX = false;
        // Scale = new Vector2(initialXScale, Scale.Y);
    }

    public void MoveLeft()
    {
        state = State.Running;
        animatedSprite.MinFrame = 8;
        animatedSprite.MaxFrame = 13;
        animatedSprite.Fps = 12;

        currentVelocity = new Vector2(-speed, currentVelocity.Y);
        flipX = true;
        // Scale = new Vector2(-initialXScale, Scale.Y);
    }
}