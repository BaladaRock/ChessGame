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

        public override List<Position> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<Position> GetLowerLeftPositions()
        {
            var positions = new List<Position>(boardSize);

            for (var (x, y) = (CurrentX - 1, CurrentY + 1); (x >= 0 && y <= boardSize); x--, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public override List<Position> GetUpperLeftPositions()
        {
            var positions = new List<Position>(boardSize);
            for (var (x, y) = (CurrentX - 1, CurrentY - 1); (x >= 0 && y >= 0); x--, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public override List<Position> GetLowerRightPositions()
        {
            var positions = new List<Position>(boardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY + 1); (x <= boardSize && y <= boardSize); x++, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public override List<Position> GetUpperRightPositions()
        {
            var positions = new List<Position>(boardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY - 1); (x <= boardSize && y >= 0); x++, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }
    }
}