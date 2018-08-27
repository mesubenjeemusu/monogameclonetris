using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceZ : Piece
    {
        public PieceZ() : base(GLOBALS.Textures.PurpleSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2) };
            PivotIndex = 1;
        }

        public override PieceKind Type { get { return PieceKind.Z; } }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            Point pivot = PieceGridPositionList[PivotIndex];
            List<Point> rotateCandidateList = new List<Point>();
            RotationDegree candidateDegree = GetRotationDegreeFromRotationDirection(rotationDirection);

            // NOTE: rotationDirection matters not for this piece; it's just a toggle.
            // So, we'll just ignore it.
            switch (candidateDegree)
            {
                case RotationDegree.Zero:
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y - 1));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y));
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y + 1));
                    break;
                case RotationDegree.Ninety:
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y + 1));
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y + 1));
                    break;
            }

            return rotateCandidateList;
        }

        protected override RotationDegree GetRotationDegreeFromRotationDirection(RotationDirection rotationDirection)
        {
            RotationDegree degreeCalculation = Rotation;

            // This piece has, basically, two rotation states; simply toggle them.
            if (Rotation == RotationDegree.Zero)
                degreeCalculation = RotationDegree.Ninety;
            else if (Rotation == RotationDegree.Ninety)
                degreeCalculation = RotationDegree.Zero;

            return degreeCalculation;
        }
    }
}
