using System.Collections.Generic;
using System.Linq;

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

        public override List<Position> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<Position> GetLowerLeftPositions()
        {
            return AddSingleSquarePositions(
               new Position(CurrentX - 1, CurrentY + 1),
               new Position(CurrentX, CurrentY + 1),
               (CurrentX > 0 && CurrentY < boardSize, CurrentY < boardSize)
            );
        }

        public override List<Position> GetUpperLeftPositions()
        {
            return AddSingleSquarePositions(
                new Position(CurrentX - 1, CurrentY),
                new Position(CurrentX - 1, CurrentY - 1),
                (CurrentX > 0, CurrentX > 0 && CurrentY > 0)
            );
        }

        public override List<Position> GetLowerRightPositions()
        {
            return AddSingleSquarePositions(
                new Position(CurrentX + 1, CurrentY),
                new Position(CurrentX + 1, CurrentY + 1),
                (CurrentX < boardSize, CurrentX < boardSize && CurrentY < boardSize)
             );
        }

        public override List<Position> GetUpperRightPositions()
        {
            return AddSingleSquarePositions(
                new Position(CurrentX, CurrentY - 1),
                new Position(CurrentX + 1, CurrentY - 1),
                (CurrentY > 0, CurrentX < boardSize && CurrentY > 0)
            );
        }
    }
}