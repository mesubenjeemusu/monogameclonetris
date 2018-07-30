using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    public class Block
    {
        public Block(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(this.texture, this.Dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }

        public Point Position { get; set; } = Point.Zero;

        public Rectangle Dimensions
        {
            get
            {
                return new Rectangle(Position.X, Position.Y, _width, _height);
            }
        }

        private Texture2D texture;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
