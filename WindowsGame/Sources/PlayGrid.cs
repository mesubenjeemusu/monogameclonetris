using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            this.lastKeyboardState = new KeyboardState();

            state = new int[this.rows, this.columns];
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.columns; j++)
                {
                    state[i, j] = 0;
                }
            }

            Dimensions = new Rectangle(50, 50, widthWithPadding, heightWithPadding);
            pieces = new List<Piece>();
        }

        public void LoadContent()
        {
            texture = UTILITIES.CreateBorderedTexture2D(Color.White, _padding, Color.Black, this.Dimensions.Width, this.Dimensions.Height);
            GLOBALS.Textures.RedSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Red, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.OrangeSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Orange, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.YellowSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Yellow, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.GreenSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Green, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.PurpleSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Purple, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.PinkSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Pink, _squareWidthHeight, _squareWidthHeight);
            GLOBALS.Textures.BlueSquareTexture = UTILITIES.CreateBorderedTexture2D(Color.Gray, _padding, Color.Blue, _squareWidthHeight, _squareWidthHeight);
        }

        public void Update()
        {
            if (!isPieceInPlay)
                SpawnPiece();

            CheckInputAndMovePiece(Keyboard.GetState());

            if (IsPieceFinishedMoving())
                isPieceInPlay = false;

            // Update static pieces
            foreach(Piece piece in pieces)
            {
                piece.Update();
            }
        }

        public void Draw()
        {
            GLOBALS.SpriteBatch.Draw(texture, Dimensions, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.1f);

            foreach (Piece piece in pieces)
            {
                piece.Draw();
            }
        }

        private void CheckInputAndMovePiece(KeyboardState kbState)
        {
            if (this.lastKeyboardState.IsKeyUp(Keys.Left) && kbState.IsKeyDown(Keys.Left))
            {
                StepLeft();
            }
            else if (this.lastKeyboardState.IsKeyUp(Keys.Right) && kbState.IsKeyDown(Keys.Right))
            {
                StepRight();
            }
            else if (kbState.IsKeyDown(Keys.Down))
            {
                StepDown();
            }

            this.lastKeyboardState = kbState;
        }

        private void SpawnPiece()
        {
            pieceInPlay = GetRandomPiece();

            // Set state
            int initialRow = 0;
            int initialColumn = (this.columns / 2) - 1;

            int rowIndex = 0;
            int columnIndex = 0;
            for (int i = 0; i < pieceInPlay.PieceLayoutList.Count; i++)
            {
                rowIndex = initialRow + pieceInPlay.PieceLayoutList[i].X;
                columnIndex = initialColumn + pieceInPlay.PieceLayoutList[i].Y;

                state[rowIndex, columnIndex] = 1;
                pieceInPlay.PieceGridPositionList[i] = new Point(rowIndex, columnIndex);
            }

            // Debug check
            PrintStateDebug();

            isPieceInPlay = true;
            pieces.Add(pieceInPlay);
        }

        private Piece GetRandomPiece()
        {
            Random random = new Random();
            PieceKind randomPieceKind = (PieceKind)random.Next((int)PieceKind.I, (int)PieceKind.Z);

            // Set to I piece for testing
            randomPieceKind = PieceKind.I;

            switch(randomPieceKind)
            {
                case PieceKind.I:
                    return new PieceI();
                case PieceKind.J:
                    return new PieceJ();
                case PieceKind.L:
                    return new PieceL();
                case PieceKind.O:
                    return new PieceO();
                case PieceKind.S:
                    return new PieceS();
                case PieceKind.T:
                    return new PieceT();
                case PieceKind.Z:
                    return new PieceZ();
                default:
                    return null;
            }
        }

        public void PrintStateDebug()
        {
            // Print Grid
            string stateString = string.Empty;

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
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

        private bool CollisionDetected(Point offset)
        {
            for (int i = 0; i < pieceInPlay.PieceGridPositionList.Count; i++)
            {
                // Create new move point candidate based on offset
                Point point = pieceInPlay.PieceGridPositionList[i];
                point.Y += offset.Y;
                point.X += offset.X;

                // Check play area bounds
                if (point.X < 0 || point.Y < 0 || point.X >= this.rows || point.Y >= this.columns)
                    return true;

                // Can't collide with space you already occupy
                if (pieceInPlay.PieceGridPositionList.Exists(piecePoint => { return (point.X == piecePoint.X && point.Y == piecePoint.Y); }))
                    continue;

                // Check for collision with other pieces
                if (state[point.X, point.Y] == 1)
                    return true;
            }

            return false;
        }

        private bool IsPieceFinishedMoving()
        {
            return pieceInPlay.PieceGridPositionList.Exists(piecePoint =>
                    {
                        // If piece has reached the bottom we're done
                        if (piecePoint.X == (this.rows - 1))
                            return true;

                        Point blockBelow = new Point(piecePoint.X + 1, piecePoint.Y);

                        // If block below is a part of this piece, continue checking
                        // Can't collide with space you already occupy
                        if (pieceInPlay.PieceGridPositionList.Exists((pieceInPlayPiece) => { return (blockBelow.X == pieceInPlayPiece.X && blockBelow.Y == pieceInPlayPiece.Y); }))
                            return false;
                        
                        // If piece is blocked by another piece below it, we're done
                        if (state[blockBelow.X, blockBelow.Y] == 1)
                            return true;

                        return false;
                    });
        }

        private void StepLeft()
        {
            Step(new Point(0, -1));
        }

        private void StepRight()
        {
            Step(new Point(0, 1));
        }

        private void StepDown()
        {
            Step(new Point(1, 0));
        }

        private void Step(Point offset)
        {
            // Check for collision
            if (CollisionDetected(offset))
                return;

            // Debug
            PrintStateDebug();

            // Zero out current pieceInPlay position in state
            for (int i = 0; i < pieceInPlay.PieceGridPositionList.Count; i++)
            {
                Point point = pieceInPlay.PieceGridPositionList[i];
                state[point.X, point.Y] = 0;
            }

            // Debug
            PrintStateDebug();

            // Move piece in play based on offset
            for (int i = 0; i < pieceInPlay.PieceGridPositionList.Count; i++)
            {
                // Update position in grid based on offset
                Point point = pieceInPlay.PieceGridPositionList[i];
                point.Y += offset.Y;
                point.X += offset.X;

                // Commit pieceInPlay and game state
                pieceInPlay.PieceGridPositionList[i] = point;
                state[point.X, point.Y] = 1;
            }

            // Debug
            PrintStateDebug();
        }

        private BoundingBox GetBoundingBox()
        {
            if (boundingBox == null)
            {
                Vector2 minBounds = new Vector2(Dimensions.X + _padding, Dimensions.Y + _padding);
                Vector2 maxBounds = new Vector2(Dimensions.X + Dimensions.Width - _padding, Dimensions.Y + Dimensions.Height - _padding);

                boundingBox = new BoundingBox(new Vector3(minBounds, 0.0f), new Vector3(maxBounds, 0.0f));
            }

            return boundingBox;
        }

        KeyboardState lastKeyboardState;
        public Rectangle Dimensions { get; }
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
