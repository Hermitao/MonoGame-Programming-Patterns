using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
 
public class Player : Entity
{
    enum State{
        Idle,
        Jumping,
        Ducking
    }

    State state;

    public Player(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
        state = State.Idle;
    }

    public override void Initialize()
    {

    }

    public override void LoadContent()
    {

    }

    public void Update(float deltaTime, KeyboardState kstate)
    {
        animatedSprite.Update(deltaTime);

        switch (state)
        {
            case State.Idle:
                if (kstate.IsKeyDown(Keys.Space))
                {
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

    public void Draw(SpriteBatch _spriteBatch)
    {
        animatedSprite.Draw(_spriteBatch, Position, Scale);
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