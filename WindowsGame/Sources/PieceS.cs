using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceS : Piece
    {
        public PieceS() : base(GLOBALS.Textures.GreenSquareTexture)
        {
        }

        public override List<Point> PieceLayoutList
        {
            get
            {
                if (pieceLayoutList == null)
                {
                    pieceLayoutList = new List<Point> { new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(0, 2) };
                }
                return pieceLayoutList;
            }
        }
    }
}
