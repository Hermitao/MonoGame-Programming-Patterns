using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
 
namespace IroncladSewing
{
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
            Vector2? position = null, Vector2? scale = null
            )
        {
            if (position == null)
            {
                Position = Vector2.Zero;
            }
            else
            {
                Position = ((Vector2)position);
            }
            if (scale == null)
            {
                Scale = Vector2.One;
            }
            else
            {
                Scale = ((Vector2)scale);
            }
        }

        public virtual void Initialize()
        {
            
        }

        public virtual void LoadContent()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            
        }
    }
}