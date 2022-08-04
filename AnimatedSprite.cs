using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace IroncladSewing
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
                maxFrame = value + 1;
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

        public void Update(float deltaTime)
        {
            currentTime += deltaTime * (Fps);

            if (currentTime >= 1f)
            {
                currentTime = 0f;
                currentFrame++;
                if (currentFrame == MaxFrame)
                    currentFrame = MinFrame;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 scale, bool flipX = false)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X, (int)position.Y, 
                (int)((float)width * scale.X), (int)((float)height * scale.Y)
                );

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
                Color.White,
                0f,
                new Vector2(0, 0),
                flipX ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
                );
            spriteBatch.End();
        }
    }
}