using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Programming_Patterns;

public class Game1 : Game
{
    Texture2D texture;
    Texture2D atlas;
    Vector2 position;
    float speed;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private InputHandlerPlayer1 inputHandlerPlayer1;
    private InputHandlerPlayer2 inputHandlerPlayer2;
    private Player player1;
    private Player player2;

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

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        texture = Content.Load<Texture2D>("Individual Sprites/adventurer-run-00");
        atlas = Content.Load<Texture2D>("adventurer-Sheet");

        player1 = new Player(
            atlas, 
            11, 7, 
            position, 
            new Vector2(2f, 2f));
        player2 = new Player(
            atlas, 
            11, 7, 
            position + new Vector2(50f, 0f), 
            new Vector2(2f, 2f));
    }

    protected override void UnloadContent()
    {

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back 
        == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Command commandPlayer1 = inputHandlerPlayer1.HandleInput();
        Command commandPlayer2 = inputHandlerPlayer2.HandleInput();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        command.execute(player);
        command.execute(player2);
        player1.Update(deltaTime);
        player2.Update(deltaTime);

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
        player1.Draw(_spriteBatch);
        player2.Draw(_spriteBatch);

        base.Draw(gameTime);
    }
}
