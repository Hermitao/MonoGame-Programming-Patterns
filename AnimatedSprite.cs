using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
 
namespace TextureAtlas
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public float Fps { get; set;}
        public int MinFrame 
        { 
            get { return minFrame; }
            set
            {
                minFrame = value;
                totalFrames = MaxFrame - MinFrame + 1;
                currentFrame = minFrame;
            } 
        }
        public int MaxFrame
        {
            get { return maxFrame; }
            set
            {
                maxFrame = value;
                totalFrames = MaxFrame - MinFrame + 1;
                currentFrame = minFrame;
            } 
        }
        private int currentFrame;
        private int totalFrames;
        private float currentTime;
        private int minFrame;
        private int maxFrame;
 
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            Fps = 12;
            MinFrame = 0;
            MaxFrame = (Rows * Columns) - 1;
        }
 
        public void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds * (Fps);

            if (currentTime >= 1f)
            {
                currentTime = 0f;
                currentFrame++;
                if (currentFrame == MaxFrame)
                    currentFrame = MinFrame;
            }
        }
 
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Vector2 scale)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;
 
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);
 
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // spriteBatch.Draw(
            //     Texture, 
            //     destinationRectangle, 
            //     sourceRectangle, 
            //     Color.White);
            spriteBatch.Draw(
                Texture, 
                destinationRectangle, 
                sourceRectangle, 
                Color.White);
            spriteBatch.End();
        }
    }
}