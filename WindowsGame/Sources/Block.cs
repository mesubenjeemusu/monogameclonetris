using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class Block
    {
        public Block(Texture2D texture)
        {
            this.texture = texture;
        }

        public Block(Block block)
        {
            this.texture = block.texture;
            this.position = block.position;
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(this.texture, this.Dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }

        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Rectangle Dimensions
        {
            get
            {
                return new Rectangle(position.X, position.Y, _width, _height);
            }
        }

        private Rectangle dimensions;
        private Point position = Point.Zero;
        private Texture2D texture;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
