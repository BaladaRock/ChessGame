using System.Collections.Generic;
using System.Linq;

namespace ChessGame.model
{
    public class Rook : ChessPiece
    {
        private readonly int boardSize;

        public Rook(ColorType color) : base(color)
        {
            boardSize = BoardSize;
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.rook;

        public override List<(int, int)> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<(int, int)> GetLowerLeftPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (int i = CurrentX - 1; i >= 0; i--)
            {
                positions.Add((i, CurrentY));
            }

            return positions;
        }

        public override List<(int, int)> GetUpperLeftPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (int i = CurrentY - 1; i >= 0; i--)
            {
                positions.Add((CurrentX, i));
            }

            return positions;
        }

        public override List<(int, int)> GetLowerRightPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (int i = CurrentY + 1; i <= boardSize; i++)
            {
                positions.Add((CurrentX, i));
            }

            return positions;
        }

        public override List<(int, int)> GetUpperRightPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (int i = CurrentX + 1; i <= boardSize; i++)
            {
                positions.Add((i, CurrentY));
            }

            return positions;
        }
    }
}