using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceO : Piece
    {
        public PieceO() : base(GLOBALS.Textures.PinkSquareTexture)
        {
        }

        public override List<Point> PieceLayoutList
        {
            get
            {
                if (pieceLayoutList == null)
                {
                    pieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) };
                }
                return pieceLayoutList;
            }
        }
    }
}
