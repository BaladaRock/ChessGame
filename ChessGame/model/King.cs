using System.Collections.Generic;

namespace ChessGame.model
{
    public class King : ChessPiece
    {
        private readonly int boardSize;

        public King(ColorType color) : base(color)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.king;

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
              new Position(CurrentX - 1, CurrentY + 1),
              CurrentX > 0 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetLeftLine()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 1, CurrentY),
              CurrentX > 0
            );
        }

        public override IEnumerable<Position> GetUpperLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 1, CurrentY - 1),
              CurrentX > 0 && CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetUpperColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, CurrentY - 1),
              CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetLowerColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, CurrentY + 1),
              CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetLowerRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 1, CurrentY + 1),
              CurrentX < boardSize && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetUpperRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 1, CurrentY - 1),
              CurrentX < boardSize && CurrentY > 0
            );
        }

        public override IEnumerable<Position> GetRightLine()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 1, CurrentY),
              CurrentX < boardSize
            );
        }
    }
}