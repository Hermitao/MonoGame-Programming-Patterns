using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
 
public class Entity : Actor
{
    public AnimatedSprite animatedSprite;

    public Entity(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2 position = new Vector2(0, 0), 
        Vector2 scale = new Vector2(1, 1)) 
        : Actor(position, scale)
    {
        animatedSprite = new AnimatedSprite(spriteSheet, rows, columns);
    }

    public void Initialize()
    {

    }

    public void LoadContent()
    {

    }

    public override void Update(float deltaTime)
    {
        animatedSprite.Update(deltaTime);
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        animatedSprite.Draw(_spriteBatch, position, scale);
    }
}