using System.Collections.Generic;

namespace ChessGame.Model
{
    public class Queen : ChessPiece
    {
        public Queen(ColorType color, byte size) : base(color, size)
        {
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.queen;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetUpperLeftTwoColumnMovement(),
                GetLowerLeftTwoColumnMovement(),
                GetUpperRightOneColumnMovement(),
                GetLowerRightTwoColumnMovement(),
                GetLowerLeftOneColumnMovement(),
                GetUpperLeftOneColumnMovement(),
                GetUpperRightTwoColumnMovement(),
                GetLowerRighOneColumnMovement()
            };
        }
    }
}