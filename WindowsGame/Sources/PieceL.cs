﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame
{
    public class PieceL : Piece
    {
        public PieceL() : base(GLOBALS.Textures.YellowSquareTexture)
        {
            PieceLayoutList = new List<Point> { new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(2, 1) };
            PivotIndex = 1;
        }

        public override PieceKind Type { get { return PieceKind.L; } }

        public override List<Point> GetRotationTranslationCandidate(RotationDirection rotationDirection)
        {
            Point pivot = PieceGridPositionList[PivotIndex];
            List<Point> rotateCandidateList = new List<Point>();
            RotationDegree candidateDegree = GetRotationDegreeFromRotationDirection(rotationDirection);

            switch (candidateDegree)
            {
                case RotationDegree.Zero:
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y));
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y + 1));
                    break;
                case RotationDegree.Ninety:
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y + 1));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y - 1));
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y - 1));
                    break;
                case RotationDegree.OneEighty:
                    rotateCandidateList.Add(new Point(pivot.X + 1, pivot.Y));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y));
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y - 1));
                    break;
                case RotationDegree.TwoSeventyFive:
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y - 1));
                    rotateCandidateList.Add(pivot);
                    rotateCandidateList.Add(new Point(pivot.X, pivot.Y + 1));
                    rotateCandidateList.Add(new Point(pivot.X - 1, pivot.Y + 1));
                    break;
            }

            return rotateCandidateList;
        }
    }
}
