using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceT : Piece
    {
        public PieceT() : base(GLOBALS.Textures.BlueSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(1, 1) };
        }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
