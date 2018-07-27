using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsGame
{
    public class PieceI : Piece
    {
        public PieceI(Point initialPosition, Block block) : base(initialPosition, block)
        {

        }

        //public override int GetMaskRows()
        //{
        //    return maskRows;
        //}

        //public override int GetMaskColumns()
        //{
        //    return maskColumns;
        //}

        //public const int maskColumns = 2;
        //public const int maskRows = 4;
        //public override int[,] StateMask
        //{
        //    get
        //    {
        //        return new int[,]   {
        //                                { 1,0},
        //                                { 1,0},
        //                                { 1,0},
        //                                { 1,0}
        //                            };
        //    }
        //}

        public override List<Point> PieceLayoutList
        {
            get
            {
                return pieceLayoutList;
            }
        }

        //private readonly int[,] pieceLayout = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 } };
        private readonly List<Point> pieceLayoutList = new List<Point> { new Point(0,0), new Point(1,0), new Point(2,0), new Point(3,0) };
        public override PieceKind Kind { get { return PieceKind.I; } }
    }
}
