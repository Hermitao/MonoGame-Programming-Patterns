using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
 
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
        Vector2 position = new Vector2(0, 0), 
        Vector2 scale = new Vector2(1, 1)) 
        : Entity(spriteSheet, rows, columns, position, scale)
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

    public override void Update(float deltaTime, KeyboardState kstate)
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
                break;
            case State.Ducking:
                if (kstate.IsKeyDown(Keys.Space))
                {
                    Jump();
                }
                break;
        }
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        animatedSprite.Draw(_spriteBatch, position, scale);
    }

    public void Jump()
    {
        playerState = State.Jumping;
        animatedSprite.MinFrame = 42;
        animatedSprite.MaxFrame = 58;
        animatedSprite.Fps = 10;
    }

    public void Idle()
    {
        playerState = State.Idle;
        animatedSprite.MinFrame = 0;
        animatedSprite.MaxFrame = 3;
        animatedSprite.Fps = 5;
    }

    public void Duck()
    {
        playerState = State.Ducking;
        animatedSprite.MinFrame = 4;
        animatedSprite.MaxFrame = 6;
        animatedSprite.Fps = 5;
    }
}