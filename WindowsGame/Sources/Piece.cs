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
    public enum PieceKind
    {
        I,
        J,
        L,
        O,
        S,
        T,
        Z
    }

    public abstract class Piece
    {
        public Piece(Point initialPosition, Block block)
        {
            blocks = new List<Block> { new Block(block), new Block(block), new Block(block), new Block(block) };
            //this.position = initialPosition;
            this.lastKeyboardState = new KeyboardState();
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

        private void StepLeft(int stepAmount)
        {
            //this.position.X -= stepAmount;
        }

        private void StepRight(int stepAmount)
        {
            //this.position.X += stepAmount;
        }

        private void StepDown()
        {

        }

        public virtual void Draw()
        {
            foreach (Block block in blocks)
            {
                block.Draw();
            }
        }

        //public abstract int GetMaskRows();
        //public abstract int GetMaskColumns();
        //public abstract int[,] StateMask { get; }

        /// <summary>
        /// The piece's position (for each block) on the grid
        /// </summary>
        public List<Point> PieceGridPositionList = new List<Point>(4);

        /// <summary>
        /// Basically a grid "mask"
        /// We use this to tell the grid which indices to set as "occupied"
        /// (set index to 1) for a given piece type
        /// </summary>
        public virtual List<Point> PieceLayoutList { get; }
        public abstract PieceKind Kind { get; }

        //public Rectangle Dimensions
        //{
        //    get
        //    {
        //        return new Rectangle(position.X, position.Y, _width, _height);
        //    }
        //}

        KeyboardState lastKeyboardState;
        //private Point position = Point.Zero;
        private List<Block> blocks;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
