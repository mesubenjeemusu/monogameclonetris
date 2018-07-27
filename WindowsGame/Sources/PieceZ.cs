using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceZ : Piece
    {
        public PieceZ() : base(GLOBALS.Textures.PurpleSquareTexture)
        {
        }

        public override List<Point> PieceLayoutList
        {
            get
            {
                if (pieceLayoutList == null)
                {
                    pieceLayoutList = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2) };
                }
                return pieceLayoutList;
            }
        }
    }
}
