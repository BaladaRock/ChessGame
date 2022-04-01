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

        public override List<(int, int)> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<(int, int)> GetLowerLeftPositions()
        {
            return AddSingleSquarePositions(
              (CurrentX - 1, CurrentY + 2),
              (CurrentX - 2, CurrentY + 1),
              (CurrentX > 0 && CurrentY < boardSize - 1, CurrentX > 1 && CurrentY < boardSize)
            );
        }

        public override List<(int, int)> GetUpperLeftPositions()
        {
            return AddSingleSquarePositions(
             (CurrentX - 1, CurrentY - 2),
             (CurrentX - 2, CurrentY - 1),
             (CurrentX > 0 && CurrentY > 1, CurrentX > 1 && CurrentY > 0)
            );
        }

        public override List<(int, int)> GetLowerRightPositions()
        {
            return AddSingleSquarePositions(
             (CurrentX + 1, CurrentY + 2),
             (CurrentX + 2, CurrentY + 1),
             (CurrentX < boardSize && CurrentY < boardSize - 1, CurrentX < boardSize - 1 && CurrentY < boardSize)
            );
        }

        public override List<(int, int)> GetUpperRightPositions()
        {
            return AddSingleSquarePositions(
             (CurrentX + 1, CurrentY - 2),
             (CurrentX + 2, CurrentY - 1),
             (CurrentX < boardSize && CurrentY > 1, CurrentX < boardSize - 1 && CurrentY > 0)
            );
        }
    }
}