using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceL : Piece
    {
        public PieceL() : base(GLOBALS.Textures.YellowSquareTexture)
        {
        }

        public override List<Point> PieceLayoutList
        {
            get
            {
                if (pieceLayoutList == null)
                {
                    pieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1) };
                }
                return pieceLayoutList;
            }
        }
    }
}
