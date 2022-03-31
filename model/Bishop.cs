using System.Collections.Generic;
using System.Linq;

namespace ChessGame.model
{
    public class Bishop : ChessPiece
    {
        private readonly int boardSize;

        public Bishop(ColorType color) : base(color)
        {
            boardSize = BoardSize;
            Movement = MovementType.multipleSquares;
        }

        public override PieceType PieceType => PieceType.bishop;

        public override List<(int, int)> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<(int, int)> GetLowerLeftPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (var (x, y) = (CurrentX - 1, CurrentY + 1); (x >= 0 && y <= boardSize); x--, y++)
            {
                positions.Add((x, y));
            }

            return positions;
        }

        public override List<(int, int)> GetUpperLeftPositions()
        {
            var positions = new List<(int, int)>(boardSize);
            for (var (x, y) = (CurrentX - 1, CurrentY - 1); (x >= 0 && y >= 0); x--, y--)
            {
                positions.Add((x, y));
            }

            return positions;
        }

        public override List<(int, int)> GetLowerRightPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY + 1); (x <= boardSize && y <= boardSize); x++, y++)
            {
                positions.Add((x, y));
            }

            return positions;
        }

        public override List<(int, int)> GetUpperRightPositions()
        {
            var positions = new List<(int, int)>(boardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY - 1); (x <= boardSize && y >= 0); x++, y--)
            {
                positions.Add((x, y));
            }

            return positions;
        }
    }
}