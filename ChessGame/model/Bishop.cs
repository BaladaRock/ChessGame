using System.Collections.Generic;

namespace ChessGame.model
{
    public class Bishop : ChessPiece
    {
        public Bishop(ColorType color) : base(color)
        {
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.bishop;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetUpperLeftDiagonal(),
                GetLowerLeftDiagonal(),
                GetUpperRightDiagonal(),
                GetLowerRightDiagonal()
            };
        }
    }
}