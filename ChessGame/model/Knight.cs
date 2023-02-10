using System.Collections.Generic;

namespace ChessGame.Model
{
    public class Knight : ChessPiece
    {
        private readonly byte boardSize;

        public Knight(ColorType color, byte size) : base(color, size)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.knight;

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

        public override IEnumerable<Position> GetLowerLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY + 2)),
              CurrentX > 0 && CurrentY < boardSize - 1
            );
        }

        public override IEnumerable<Position> GetLeftLine()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 2), (byte)(CurrentY + 1)),
              CurrentX > 1 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetUpperLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY - 2)),
              CurrentX > 0 && CurrentY > 1
            );
        }

        public override IEnumerable<Position> GetUpperColumn()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 2), (byte)(CurrentY - 1)),
              CurrentX > 1 && CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetLowerColumn()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY + 2)),
              CurrentX < boardSize && CurrentY < boardSize - 1
            );
        }

        public override IEnumerable<Position> GetLowerRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 2), (byte)(CurrentY + 1)),
              CurrentX < boardSize - 1 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetUpperRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY - 2)),
              CurrentX < boardSize && CurrentY > 1
            );
        }

        public override IEnumerable<Position> GetRightLine()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 2), (byte)(CurrentY - 1)),
              CurrentX < boardSize - 1 && CurrentY > 0
            );
        }
    }
}