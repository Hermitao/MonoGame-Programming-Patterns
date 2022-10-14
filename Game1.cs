using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Lidgren.Network;

namespace IroncladSewing
{
    public class Game1 : Game
    {
        Texture2D texture;
        Texture2D atlas;
        Vector2 position;

        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        Character player0;
        Character player1;

        List<Actor> actors = new List<Actor>();

        SpriteFont font;

        float fps = 0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("Individual Sprites/adventurer-run-00");
            atlas = Content.Load<Texture2D>("adventurer-Sheet");
            font = Content.Load<SpriteFont>("Fonts/FiraMono");

            player0 = new Character(
                atlas, 
                11, 7, 
                position, 
                new Vector2(2f, 2f));
            Player player0Component = new Player(player0, 0);
            player0.components.Add(player0Component);

            player1 = new Character(
                atlas, 
                11, 7, 
                position + new Vector2(50f, 0f), 
                new Vector2(2f, 2f));
            Player player1Component = new Player(player1, 1);
            player1.components.Add(player1Component);

            actors.Add(player0);
            actors.Add(player1);

            Character npc0 = new Character(
                atlas,
                11, 7,
                position + new Vector2(-50f, 0f), 
                new Vector2(2f, 2f));
            AI_Swordsman ai_swordsman = new AI_Swordsman(npc0, player0);
            npc0.components.Add(ai_swordsman);
            actors.Add(npc0);

            Character npc1 = new Character(
                atlas,
                11, 7,
                position + new Vector2(-100f, 0f), 
                new Vector2(2f, 2f));
            AI_Swordsman ai_swordsman2 = new AI_Swordsman(npc1, npc0);
            npc1.components.Add(ai_swordsman2);
            actors.Add(npc1);
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardHandler.GetState();

            fps = (1/deltaTime);
            
            // Command commandPlayer1 = inputHandlerPlayer1.HandleInput();
            // Command commandPlayer2 = inputHandlerPlayer2.HandleInput();

            // commandPlayer1.execute(player0);
            // commandPlayer2.execute(player1);

            foreach (Actor actor in actors)
            {
                actor.Update(deltaTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0.1f, 0.1f, 0.1f));

            // TODO: Add your drawing code here
            foreach (Entity entity in actors)
            {
                entity.Draw(_spriteBatch);
            }

            _spriteBatch.Begin();

            // _spriteBatch.DrawString(
            //     font, 
            //     "FPS: " + Math.Round(fps), 
            //     new Vector2(12, 12), Color.Gray);

            _spriteBatch.DrawString(
                font, 
                "Connected IP:", 
                new Vector2(12, 36), Color.Gray);

            _spriteBatch.DrawString(
                font, 
                "Neon Hearts Indev", 
                new Vector2(12, _graphics.PreferredBackBufferHeight - 24), 
                Color.Gray);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
