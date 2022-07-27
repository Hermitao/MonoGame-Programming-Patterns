using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TextureAtlas;

namespace MonoGame_Programming_Patterns;

public class Game1 : Game
{
    enum State{
        Idle,
        Jumping,
        Ducking
    }

    Texture2D texture;
    Texture2D atlas;
    Vector2 position;
    float speed;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private AnimatedSprite animatedSprite;
    private State playerState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        position = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
        speed = 150f;
        playerState = State.Idle;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    texture = Content.Load<Texture2D>("Individual Sprites/adventurer-run-00");
        atlas = Content.Load<Texture2D>("adventurer-Sheet");
        animatedSprite = new AnimatedSprite(atlas, 11, 7);
        animatedSprite.MinFrame = 0;
        animatedSprite.MaxFrame = 3;
        animatedSprite.Fps = 5;
    }

     protected override void UnloadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        animatedSprite.Update(gameTime);

        var kstate = Keyboard.GetState();

        // if (kstate.IsKeyDown(Keys.Up))
        // {
        //     position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // }

        // if(kstate.IsKeyDown(Keys.Down))
        // {
        //     position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // }

        switch (playerState)
        {
            case State.Idle:
                if (kstate.IsKeyDown(Keys.Space))
                {
                    playerState = State.Jumping;
                    animatedSprite.MinFrame = 42;
                    animatedSprite.MaxFrame = 58;
                    animatedSprite.Fps = 10;
                }
                else if (kstate.IsKeyDown(Keys.S))
                {
                    playerState = State.Ducking;
                    animatedSprite.MinFrame = 4;
                    animatedSprite.MaxFrame = 6;
                    animatedSprite.Fps = 5;
                }
                break;
            case State.Jumping:
                if (kstate.IsKeyDown(Keys.D))
                {
                    playerState = State.Idle;
                    animatedSprite.MinFrame = 0;
                    animatedSprite.MaxFrame = 3;
                    animatedSprite.Fps = 5;
                }
                break;
            case State.Ducking:
                if (kstate.IsKeyDown(Keys.Space))
                {
                    playerState = State.Jumping;
                    animatedSprite.MinFrame = 42;
                    animatedSprite.MaxFrame = 58;
                    animatedSprite.Fps = 10;
                }
                break;
        }

        // if (kstate.IsKeyDown(Keys.Left))
        // {
        //     position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // }

        // if(kstate.IsKeyDown(Keys.Right))
        // {
        //     position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        // }

        // if(position.X > _graphics.PreferredBackBufferWidth - texture.Width * 2 / 2)
        // {
        //     position.X = _graphics.PreferredBackBufferWidth - texture.Width * 2 / 2;
        // }
        // else if(position.X < texture.Width / 2)
        // {
        //     position.X = texture.Width / 2;
        // }

        // if(position.Y > _graphics.PreferredBackBufferHeight - texture.Height * 2 / 2)
        // {
        //     position.Y = _graphics.PreferredBackBufferHeight - texture.Height * 2 / 2;
        // }
        // else if(position.Y < texture.Height / 2)
        // {
        //     position.Y = texture.Height / 2;
        // }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(0.1f, 0.1f, 0.1f));

        // TODO: Add your drawing code here
        // _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        // _spriteBatch.Draw( 
        //     ballTexture,
        //     ballPosition,
        //     null,
        //     Color.White,
        //     0f,
        //     new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
        //     new Vector2(2.0f, 2.0f),
        //     SpriteEffects.None,
        //     0f
        // );
        // _spriteBatch.End();

        animatedSprite.Draw(_spriteBatch, position, new Vector2(2, 2));

        base.Draw(gameTime);
    }
}
