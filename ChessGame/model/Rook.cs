using System.Collections.Generic;

namespace ChessGame.model
{
    public class Rook : ChessPiece
    {
        public Rook(ColorType color, int size) : base(color, size)
        {
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.rook;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetLeftLine(),
                GetUpperColumn(),
                GetRightLine(),
                GetLowerColumn()
            };
        }
    }
}