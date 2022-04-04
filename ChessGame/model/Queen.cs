using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.model
{
    public class Queen : ChessPiece
    {
        private readonly Bishop bishopVersion;

        public Queen(ColorType color) : base(color)
        {
            Movement = MovementType.multipleSquares;
            bishopVersion = new Bishop(color);
            RookPiece = new Rook(color);
        }

        public override PieceType PieceType => PieceType.queen;

        public Rook RookPiece { get; }

        public override void OccupySquare(ChessSquare chessSquare)
        {
            if (chessSquare == null)
            {
                throw new ArgumentNullException(paramName: nameof(chessSquare), message: "Please provide a square that is not null!");
            }

            bishopVersion.OccupySquare(chessSquare);
            RookPiece.OccupySquare(chessSquare);
            base.OccupySquare(chessSquare);
        }

        public override void MovePiece(ChessSquare activeSquare)
        {
            if (activeSquare == null)
            {
                throw new ArgumentNullException(paramName: nameof(activeSquare), message: "Please provide a square that is not null!");
            }

            bishopVersion.MovePiece(activeSquare);
            RookPiece.MovePiece(activeSquare);
            base.MovePiece(activeSquare);
        }

        public override List<Position> GetAvailablePositions()
        {
            return RookPiece.GetAvailablePositions().Concat(
                bishopVersion.GetAvailablePositions())
                .ToList();
        }

        public override List<Position> GetLowerLeftPositions()
        {
            return bishopVersion.GetLowerLeftPositions();
        }

        public override List<Position> GetUpperLeftPositions()
        {
            return bishopVersion.GetUpperLeftPositions();
        }

        public override List<Position> GetLowerRightPositions()
        {
            return bishopVersion.GetLowerRightPositions();
        }

        public override List<Position> GetUpperRightPositions()
        {
            return bishopVersion.GetUpperRightPositions();
        }
    }
}