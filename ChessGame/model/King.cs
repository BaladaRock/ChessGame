using System.Collections.Generic;

namespace ChessGame.Model
{
    public class King : ChessPiece
    {
        private readonly byte boardSize;

        public King(ColorType color, byte size) : base(color, size)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.king;

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

        public override IEnumerable<Position> GetLowerLeftTwoColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY + 1)),
              CurrentX > 0 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetLowerLeftOneColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), CurrentY),
              CurrentX > 0
            );
        }

        public override IEnumerable<Position> GetUpperLeftTwoColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY - 1)),
              CurrentX > 0 && CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetUpperLeftOneColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, (byte)(CurrentY - 1)),
              CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetLowerRighOneColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, (byte)(CurrentY + 1)),
              CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetLowerRightTwoColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY + 1)),
              CurrentX < boardSize && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetUpperRightOneColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY - 1)),
              CurrentX < boardSize && CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetUpperRightTwoColumnMovement()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), CurrentY),
              CurrentX < boardSize
            );
        }
    }
}