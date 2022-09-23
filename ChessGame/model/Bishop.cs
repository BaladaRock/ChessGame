using System.Collections.Generic;

namespace ChessGame.model
{
    public class Bishop : ChessPiece
    {
        public Bishop(ColorType color, int size) : base(color, size)
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