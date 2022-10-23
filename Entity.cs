using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IroncladSewing
{
    public class Entity : Actor
    {
        public AnimatedSprite animatedSprite;
        public string name;
        public bool flipX = false;

        public Entity(Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null, 
        Vector2? scale = null,
        string name = "") 
        : base(((Vector2)position), ((Vector2)scale))
        {
            animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
            this.name = name;
        }

        public override void Update(float deltaTime)
        {
            animatedSprite.Update(deltaTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (name != "")
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(
                Game1.font, 
                name, 
                this.Position - new Vector2(0f, 12f), 
                Color.Gray);
                _spriteBatch.End();
            }
            animatedSprite.Draw(_spriteBatch, Position, Scale, flipX);
        }
    }
}