using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceL : Piece
    {
        public PieceL() : base(GLOBALS.Textures.YellowSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1) };
        }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
