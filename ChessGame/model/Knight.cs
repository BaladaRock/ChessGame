using System.Collections.Generic;

namespace ChessGame.model
{
    public class Knight : ChessPiece
    {
        private readonly int boardSize;

        public Knight(ColorType color) : base(color)
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

        protected override IEnumerable<Position> GetLowerLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 1, CurrentY + 2),
              CurrentX > 0 && CurrentY < boardSize - 1
            );
        }

        protected override IEnumerable<Position> GetLeftLine()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 2, CurrentY + 1),
              CurrentX > 1 && CurrentY < boardSize
            );
        }

        protected override IEnumerable<Position> GetUpperLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 1, CurrentY - 2),
              CurrentX > 0 && CurrentY > 1
            );
        }

        protected override IEnumerable<Position> GetUpperColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 2, CurrentY - 1),
              CurrentX > 1 && CurrentY > 0
            );
        }

        protected override IEnumerable<Position> GetLowerColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 1, CurrentY + 2),
              CurrentX < boardSize && CurrentY < boardSize - 1
            );
        }

        protected override IEnumerable<Position> GetLowerRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 2, CurrentY + 1),
              CurrentX < boardSize - 1 && CurrentY < boardSize
            );
        }

        protected override IEnumerable<Position> GetUpperRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 1, CurrentY - 2),
              CurrentX < boardSize && CurrentY > 1
            );
        }

        protected override IEnumerable<Position> GetRightLine()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX + 2, CurrentY - 1),
              CurrentX < boardSize - 1 && CurrentY > 0
            );
        }
    }
}