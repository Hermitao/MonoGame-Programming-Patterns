using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// namespace MonoGame_Programming_Patterns;

namespace IroncladSewing
{
    public class Game1 : Game
    {
        Texture2D texture;
        Texture2D atlas;
        Vector2 position;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private InputHandlerPlayer1 inputHandlerPlayer1;
        private InputHandlerPlayer2 inputHandlerPlayer2;
        private Character player1;
        private Character player2;

        private List<Actor> actors = new List<Actor>();

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

            inputHandlerPlayer1 = new InputHandlerPlayer1();
            inputHandlerPlayer2 = new InputHandlerPlayer2();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("Individual Sprites/adventurer-run-00");
            atlas = Content.Load<Texture2D>("adventurer-Sheet");

            player1 = new Character(
                atlas, 
                11, 7, 
                position, 
                new Vector2(2f, 2f));
            player2 = new Character(
                atlas, 
                11, 7, 
                position + new Vector2(50f, 0f), 
                new Vector2(2f, 2f));

            actors.Add(player1);
            actors.Add(player2);

            Character npc1 = new Character(
                atlas,
                11, 7,
                position + new Vector2(-50f, 0f), 
                new Vector2(2f, 2f));
            AI_Swordsman ai_swordsman = new AI_Swordsman(npc1, player1);
            npc1.components.Add(ai_swordsman);
            actors.Add(npc1);

            Character npc2 = new Character(
                atlas,
                11, 7,
                position + new Vector2(-100f, 0f), 
                new Vector2(2f, 2f));
            AI_Swordsman ai_swordsman2 = new AI_Swordsman(npc2, npc1);
            npc2.components.Add(ai_swordsman2);
            actors.Add(npc2);
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
            
            Command commandPlayer1 = inputHandlerPlayer1.HandleInput();
            Command commandPlayer2 = inputHandlerPlayer2.HandleInput();

            commandPlayer1.execute(player1);
            commandPlayer2.execute(player2);

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

            base.Draw(gameTime);
        }
    }
}
