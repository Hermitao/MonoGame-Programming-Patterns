using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
 
public class Actor
{
    public Vector2 Position 
    { 
        get { return position; } 
        set { position = value; } 
    }
    public Vector2 Scale 
    { 
        get {return scale;}
        set {scale = value;} 
    }

    private Vector2 position;
    private Vector2 scale;

    public Actor(
        Vector2 position = new Vector2(0, 0), Vector2 scale = new Vector2(1, 1)
        )
    {
        Position = position;
        Scale = scale;
    }

    public void Update(float deltaTime)
    {
        
    }
}