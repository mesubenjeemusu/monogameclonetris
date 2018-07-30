using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceS : Piece
    {
        public PieceS() : base(GLOBALS.Textures.GreenSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(0, 2) };
        }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
