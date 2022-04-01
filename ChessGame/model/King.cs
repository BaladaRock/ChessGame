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

        public override List<(int, int)> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<(int, int)> GetLowerLeftPositions()
        {
            return AddSingleSquarePositions(
               (CurrentX - 1, CurrentY + 1),
               (CurrentX, CurrentY + 1),
               (CurrentX > 0 && CurrentY < boardSize, CurrentY < boardSize)
            );
        }

        public override List<(int, int)> GetUpperLeftPositions()
        {
            return AddSingleSquarePositions(
                (CurrentX - 1, CurrentY),
                (CurrentX - 1, CurrentY - 1),
                (CurrentX > 0, CurrentX > 0 && CurrentY > 0)
            );
        }

        public override List<(int, int)> GetLowerRightPositions()
        {
            return AddSingleSquarePositions(
                (CurrentX + 1, CurrentY),
                (CurrentX + 1, CurrentY + 1),
                (CurrentX < boardSize, CurrentX < boardSize && CurrentY < boardSize)
             );
        }

        public override List<(int, int)> GetUpperRightPositions()
        {
            return AddSingleSquarePositions(
                (CurrentX, CurrentY - 1),
                (CurrentX + 1, CurrentY - 1),
                (CurrentY > 0, CurrentX < boardSize && CurrentY > 0)
            );
        }
    }
}