using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class Block
    {
        public Block(Vector2 initialPosition, Color color)
        {
            this.color = color;
            this.position = initialPosition;
            this.lastKeyboardState = new KeyboardState();
        }

        public void LoadContent()
        {
            texture = UTILITIES.CreateBorderedTexture2D(this.borderColor, _padding, color, _width, _height);
        }

        public void Update()
        {
            // Step Down

            KeyboardState kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Left))
            {
                if (this.lastKeyboardState.IsKeyUp(Keys.Left))
                    StepLeft(50);
            }
            else if (this.lastKeyboardState.IsKeyUp(Keys.Right) && kbState.IsKeyDown(Keys.Right))
            {
                StepRight(50);
            }
            else if (kbState.IsKeyDown(Keys.Down))
            {
                // move down
            }

            this.lastKeyboardState = kbState;
        }

        private void StepLeft(int stepAmount)
        {
            this.position.X -= stepAmount;
        }

        private void StepRight(int stepAmount)
        {
            this.position.X += stepAmount;
        }

        private void StepDown()
        {

        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(texture, this.Dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }

        public Rectangle Dimensions
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, _width, _height);
            }
        }

        KeyboardState lastKeyboardState;
        private Vector2 position = Vector2.Zero;
        private Texture2D texture;
        private Color color;
        private readonly Color borderColor = Color.Gray;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
