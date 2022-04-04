using System.Collections.Generic;
using System.Linq;

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

        public override List<Position> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<Position> GetLowerLeftPositions()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX - 1, CurrentY + 2),
              new Position(CurrentX - 2, CurrentY + 1),
              (CurrentX > 0 && CurrentY < boardSize - 1, CurrentX > 1 && CurrentY < boardSize)
            );
        }

        public override List<Position> GetUpperLeftPositions()
        {
            return AddSingleSquarePositions(
             new Position(CurrentX - 1, CurrentY - 2),
             new Position(CurrentX - 2, CurrentY - 1),
             (CurrentX > 0 && CurrentY > 1, CurrentX > 1 && CurrentY > 0)
            );
        }

        public override List<Position> GetLowerRightPositions()
        {
            return AddSingleSquarePositions(
             new Position(CurrentX + 1, CurrentY + 2),
             new Position(CurrentX + 2, CurrentY + 1),
             (CurrentX < boardSize && CurrentY < boardSize - 1, CurrentX < boardSize - 1 && CurrentY < boardSize)
            );
        }

        public override List<Position> GetUpperRightPositions()
        {
            return AddSingleSquarePositions(
             new Position(CurrentX + 1, CurrentY - 2),
             new Position(CurrentX + 2, CurrentY - 1),
             (CurrentX < boardSize && CurrentY > 1, CurrentX < boardSize - 1 && CurrentY > 0)
            );
        }
    }
}