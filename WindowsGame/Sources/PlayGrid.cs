using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class PlayGrid
    {
        public PlayGrid(int rows, int columns)
        {
            columns = Math.Min(columns, _maxColumns);
            rows = Math.Min(rows, _maxRows);
            int heightWithPadding = (50 * rows) + (2 * _padding);
            int widthWithPadding = (50 * columns) + (2 * _padding);

            dimensions = new Rectangle(50, 50, widthWithPadding, heightWithPadding);
            blocks = new List<Block>
            {
                new Block(new Vector2(55, 55), Color.Red),
                new Block(new Vector2(100, 55), Color.Green),
                new Block(new Vector2(145, 55), Color.Blue),
                new Block(new Vector2(190, 55), Color.Purple)
            };
        }

        public void LoadContent()
        {
            texture = UTILITIES.CreateBorderedTexture2D(Color.White, _padding, Color.Black, this.dimensions.Width, this.dimensions.Height);

            foreach(Block block in blocks)
            {
                block.LoadContent();
            }
        }

        public void Update()
        {
            foreach(Block block in blocks)
            {
                block.Update();
            }

            CheckBoundsAndAdjustIfNeeded();
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(texture, dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            foreach (Block block in blocks)
            {
                block.Draw();
            }
        }

        private void CheckBoundsAndAdjustIfNeeded()
        {
            foreach(Block block in blocks)
            {

            }
        }

        private BoundingBox GetBoundingBox()
        {
            if (boundingBox == null)
            {
                Vector2 minBounds = new Vector2(dimensions.X + _padding, dimensions.Y + _padding);
                Vector2 maxBounds = new Vector2(dimensions.X + dimensions.Width - _padding, dimensions.Y + dimensions.Height - _padding);

                boundingBox = new BoundingBox(new Vector3(minBounds, 0.0f), new Vector3(maxBounds, 0.0f));
            }

            return boundingBox;
        }

        public Rectangle Dimensions
        {
            get
            {
                return dimensions;
            }
        }

        private Rectangle dimensions;
        private BoundingBox boundingBox;
        private Texture2D texture;
        private List<Block> blocks;
        private const int _padding = 5;
        private const int _maxColumns = 20;
        private const int _maxRows = 20;
    }
}
