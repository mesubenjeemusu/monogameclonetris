using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace WindowsGame
{
    public enum PieceKind : int { I, J, L, O, S, T, Z }

    public abstract class Piece
    {
        public Piece(Texture2D texture)
        {
            blocks = new List<Block> { new Block(texture), new Block(texture), new Block(texture), new Block(texture) };
        }

        public void Update()
        {
            UpdateBlockPositionsFromGridIndices();
        }

        /// <summary>
        /// Convert grid row-column indices into screen coordinates
        /// IMPORTANT: Remember that in grid context, row = x; column = y
        /// However, in coordinate context, x = column; y = row
        /// </summary>
        private void UpdateBlockPositionsFromGridIndices()
        {
            for (int i = 0; i < 4; i++)
            {
                int x = (this.PieceGridPositionList[i].Y * _width) + 55;
                int y = (this.PieceGridPositionList[i].X * _height) + 55;

                blocks[i].Position = new Point(x, y);
            }
        }

        public virtual void Draw()
        {
            foreach (Block block in blocks)
            {
                block.Draw();
            }
        }

        /// <summary>
        /// The piece's position (for each block) on the grid
        /// </summary>
        public List<Point> PieceGridPositionList = new List<Point>(4);

        /// <summary>
        /// Basically a grid "mask"
        /// We use this to tell the grid which indices to set as "occupied"
        /// (set index to 1) for a given piece type
        /// </summary>
        public abstract List<Point> PieceLayoutList { get; }
        protected List<Point> pieceLayoutList;

        private List<Block> blocks;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
