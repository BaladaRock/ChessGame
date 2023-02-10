using System.Collections.Generic;

namespace ChessGame.Model
{
    public class Bishop : ChessPiece
    {
        public Bishop(ColorType color, byte size) : base(color, size)
        {
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.bishop;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetUpperLeftTwoColumnMovement(),
                GetLowerLeftTwoColumnMovement(),
                GetUpperRightOneColumnMovement(),
                GetLowerRightTwoColumnMovement()
            };
        }
    }
}