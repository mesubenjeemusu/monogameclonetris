using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceI : Piece
    {
        public PieceI() : base(GLOBALS.Textures.RedSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0) };
            PivotIndex = 1;
        }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            Point pivot = PieceGridPositionList[PivotIndex];
            List<Point> rotateCandidateList = new List<Point>();

            // NOTE: rotationDirection matters not for this piece; it's just a toggle.
            // So, we'll just ignore it.
            switch (Rotation)
            {
                case RotationDegree.Zero:
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y - 1));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y + 1));
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y + 2));
                    break;
                case RotationDegree.Ninety:
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y));
                    rotateCandidateList.Add(new Point(pivot.X + 2, pivot.Y));
                    break;
            }

            return rotateCandidateList;
        }

        public override void UpdateRotationDegree(RotationDirection rotationDirection)
        {
            // This piece has, basically, two rotation states; simply toggle them.
            if (Rotation == RotationDegree.Zero)
                Rotation = RotationDegree.Ninety;
            else if (Rotation == RotationDegree.Ninety)
                Rotation = RotationDegree.Zero;
        }
    }
}
