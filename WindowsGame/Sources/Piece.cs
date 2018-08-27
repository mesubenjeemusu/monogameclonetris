using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace WindowsGame
{
    public enum PieceKind : int
    {
        Nil = 0,
        I = 1,
        J,
        L,
        O,
        S,
        T,
        Z
    }

    public enum RotationDegree : int { Zero, Ninety, OneEighty, TwoSeventyFive }

    public abstract class Piece
    {
        public Piece(Texture2D texture)
        {
            blocks = new List<Block> { new Block(texture), new Block(texture), new Block(texture), new Block(texture) };
            PieceGridPositionList = new List<Point> { Point.Zero, Point.Zero, Point.Zero, Point.Zero };
            Rotation = RotationDegree.Zero;
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

        public virtual List<Point> GetMoveTranslationCandidate(MoveDirection moveDirection)
        {
            List<Point> moveCandidateList = new List<Point>();
            Point offset = Point.Zero;

            switch(moveDirection)
            {
                case MoveDirection.Left:
                    offset.Y -= 1;
                    break;
                case MoveDirection.Right:
                    offset.Y += 1;
                    break;
                case MoveDirection.Down:
                    offset.X += 1;
                    break;
            }

            Point candidatePoint = Point.Zero;
            for (int i = 0; i < 4; i++)
            {
                candidatePoint.X = PieceGridPositionList[i].X + offset.X;
                candidatePoint.Y = PieceGridPositionList[i].Y + offset.Y;
                moveCandidateList.Add(new Point(candidatePoint.X, candidatePoint.Y));
            }

            return moveCandidateList;
        }

        public abstract List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection);
        public void UpdateRotationDegree(RotationDirection rotationDirection)
        {
            Rotation = GetRotationDegreeFromRotationDirection(rotationDirection);
        }

        protected virtual RotationDegree GetRotationDegreeFromRotationDirection(RotationDirection rotationDirection)
        {
            RotationDegree degreeCalculation = Rotation;

            switch (rotationDirection)
            {
                case RotationDirection.Clockwise:
                    if (Rotation == RotationDegree.TwoSeventyFive)
                        degreeCalculation = RotationDegree.Zero;
                    else
                        degreeCalculation += 1;
                    break;
                case RotationDirection.CounterClockwise:
                    if (Rotation == RotationDegree.Zero)
                        degreeCalculation = RotationDegree.TwoSeventyFive;
                    else
                        degreeCalculation -= 1;
                    break;
            }

            return degreeCalculation;
        }

        public int PivotIndex { get; protected set; }
        public RotationDegree Rotation { get; protected set; }

        /// <summary>
        /// The piece's position (for each block) on the grid
        /// </summary>
        public List<Point> PieceGridPositionList { get; set; }

        /// <summary>
        /// Basically a grid "mask"
        /// We use this to tell the grid which indices to set as "occupied"
        /// (set index to 1) for a given piece type
        /// </summary>
        public List<Point> PieceLayoutList { get; protected set; }

        public abstract PieceKind Type { get; }

        private List<Block> blocks;
        private const int _width = 50;
        private const int _height = 50;
        private const int _padding = 5;
    }
}
