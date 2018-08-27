using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceO : Piece
    {
        public PieceO() : base(GLOBALS.Textures.PinkSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) };
        }

        public override PieceKind Type { get { return PieceKind.O; } }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            // O Piece - no rotation needed
            return null;
        }

        protected override RotationDegree GetRotationDegreeFromRotationDirection(RotationDirection rotationDirection)
        {
            // O Piece - no rotation needed
            return RotationDegree.Zero;
        }
    }
}
