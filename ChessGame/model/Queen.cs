using System.Collections.Generic;

namespace ChessGame.model
{
    public class Queen : ChessPiece
    {
        public Queen(ColorType color) : base(color)
        {
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.queen;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetUpperLeftDiagonal(),
                GetLowerLeftDiagonal(),
                GetUpperRightDiagonal(),
                GetLowerRightDiagonal(),
                GetLeftLine(),
                GetUpperColumn(),
                GetRightLine(),
                GetLowerColumn()
            };
        }
    }
}