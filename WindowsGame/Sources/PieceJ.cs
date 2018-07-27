using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceJ : Piece
    {
        public PieceJ() : base(GLOBALS.Textures.OrangeSquareTexture)
        {
        }

        public override List<Point> PieceLayoutList
        {
            get
            {
                if (pieceLayoutList == null)
                {
                    pieceLayoutList = new List<Point> { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) };
                }
                return pieceLayoutList;
            }
        }
    }
}
