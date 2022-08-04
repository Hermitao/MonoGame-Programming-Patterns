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

        public bool flipX = false;

        public Entity(Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null, 
        Vector2? scale = null) 
        : base(((Vector2)position), ((Vector2)scale))
        {
            animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
        }

        public override void Update(float deltaTime)
        {
            animatedSprite.Update(deltaTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            animatedSprite.Draw(_spriteBatch, Position, Scale, flipX);
        }
    }
}