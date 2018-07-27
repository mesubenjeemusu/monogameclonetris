using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class PlayGrid
    {
        public PlayGrid(int rows, int columns)
        {
            this.columns = Math.Min(columns, _maxColumns);
            this.rows = Math.Min(rows, _maxRows);
            int heightWithPadding = (50 * this.rows) + (2 * _padding);
            int widthWithPadding = (50 * this.columns) + (2 * _padding);

            state = new int[this.rows, this.columns];
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.columns; j++)
                {
                    state[i, j] = 0;
                }
            }

            dimensions = new Rectangle(50, 50, widthWithPadding, heightWithPadding);
            pieces = new List<Piece>
            {
                //new Block(new Vector2(55, 55), Color.Red),
                //new Block(new Vector2(105, 55), Color.Red),
                //new Block(new Vector2(155, 55), Color.Red),
                //new Block(new Vector2(205, 55), Color.Red),
                //new Block(new Vector2(55, 105), Color.Orange),
                //new Block(new Vector2(55, 155), Color.Orange),
                //new Block(new Vector2(105, 155), Color.Orange),
                //new Block(new Vector2(155, 155), Color.Orange),
                //new Block(new Vector2(255, 155), Color.Yellow),
                //new Block(new Vector2(305, 155), Color.Yellow),
                //new Block(new Vector2(355, 155), Color.Yellow),
                //new Block(new Vector2(355, 105), Color.Yellow),
                //new Block(new Vector2(255, 255), Color.Green),
                //new Block(new Vector2(305, 255), Color.Green),
                //new Block(new Vector2(305, 205), Color.Green),
                //new Block(new Vector2(355, 205), Color.Green),
                //new Block(new Vector2(55, 205), Color.Purple),
                //new Block(new Vector2(105, 205), Color.Purple),
                //new Block(new Vector2(105, 255), Color.Purple),
                //new Block(new Vector2(155, 255), Color.Purple),
                //new Block(new Vector2(55, 305), Color.Pink),
                //new Block(new Vector2(105, 305), Color.Pink),
                //new Block(new Vector2(55, 355), Color.Pink),
                //new Block(new Vector2(105, 355), Color.Pink),
                //new Block(new Vector2(255, 305), Color.Blue),
                //new Block(new Vector2(205, 355), Color.Blue),
                //new Block(new Vector2(255, 355), Color.Blue),
                //new Block(new Vector2(305, 355), Color.Blue)
            };
        }

        public void LoadContent()
        {
            texture = UTILITIES.CreateBorderedTexture2D(Color.White, _padding, Color.Black, this.dimensions.Width, this.dimensions.Height);
            GLOBALS.Textures.RedSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Red, _squareWidthHeight, _squareWidthHeight);
        }

        public void Update()
        {
            if (!isPieceInPlay)
                SpawnPiece();

            // Update piece in play
            pieceInPlay.Update();

            // Update static pieces
            foreach(Piece piece in pieces)
            {
                piece.Update();
            }

            CheckBoundsAndAdjustIfNeeded();

            
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(texture, dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            foreach (Piece piece in pieces)
            {
                piece.Draw();
            }
        }

        private void SpawnPiece()
        {
            pieceInPlay = GetRandomPiece();

            // Set state
            int initialRow = 0;
            int initialColumn = this.columns / 2;

            int rowIndex = 0;
            int columnIndex = 0;
            for (int i = 0; i < pieceInPlay.PieceLayoutList.Count; i++)
            {
                rowIndex = initialRow + pieceInPlay.PieceLayoutList[i].X;
                columnIndex = initialColumn + pieceInPlay.PieceLayoutList[i].Y;

                state[rowIndex, columnIndex] = 1;
                pieceInPlay.PieceGridPositionList.Add(new Point(rowIndex, columnIndex));
            }

            // Debug check
            PrintStateDebug();

            isPieceInPlay = true;
            pieces.Add(pieceInPlay);
        }

        private Piece GetRandomPiece()
        {
            Random random = new Random();

            return new PieceI(new Point(dimensions.X + _padding, dimensions.Y + _padding), new Block(GLOBALS.Textures.RedSquareTexture));
        }

        public void PrintStateDebug()
        {
            // Print Grid
            string stateString = string.Empty;

            for (int i = 0; i < this.columns; i++)
            {
                for (int j = 0; j < this.rows; j++)
                {
                    stateString += state[i, j] + " ";
                }

                stateString += Environment.NewLine;
            }

            Debug.Write(stateString);

            // Print pieceInPlay grid indexes
            foreach (Point gridIndex in pieceInPlay.PieceGridPositionList)
            {
                Debug.WriteLine(string.Format("Row: {0}; Column: {1}", gridIndex.X, gridIndex.Y));
            }
        }

        private void CheckBoundsAndAdjustIfNeeded()
        {
            foreach(Piece block in pieces)
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
        private List<Piece> pieces;
        private Piece pieceInPlay;
        private bool isPieceInPlay = false;
        private int rows;
        private int columns;
        private int[,] state;
        private const int _padding = 5;
        private const int _squareWidthHeight = 50;
        private const int _maxColumns = 20;
        private const int _maxRows = 20;
    }
}
