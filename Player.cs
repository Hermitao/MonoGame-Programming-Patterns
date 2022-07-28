using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
 
public class Player : Character
{
    private InputHandler inputHandler;

    public Player(
        Texture2D spriteSheet, int rows, int columns, 
        Vector2? position = null,
        Vector2? scale = null) 
        : base(spriteSheet, rows, columns, (Vector2)position, (Vector2)scale)
    {
        
    }

    public override void Update(float deltaTime)
    {
        animatedSprite.Update(deltaTime);
    }
}