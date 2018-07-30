using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceJ : Piece
    {
        public PieceJ() : base(GLOBALS.Textures.OrangeSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) };
        }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
