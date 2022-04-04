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

        public override List<Position> GetAvailablePositions()
        {
            return GetUpperLeftPositions().Concat(GetLowerLeftPositions()
                .Concat(GetUpperRightPositions()).Concat(GetLowerRightPositions()))
                .ToList();
        }

        public override List<Position> GetLowerLeftPositions()
        {
            var positions = new List<Position>(boardSize);

            for (int i = CurrentX - 1; i >= 0; i--)
            {
                positions.Add(new Position(i, CurrentY));
            }

            return positions;
        }

        public override List<Position> GetUpperLeftPositions()
        {
            var positions = new List<Position>(boardSize);

            for (int i = CurrentY - 1; i >= 0; i--)
            {
                positions.Add(new Position(CurrentX, i));
            }

            return positions;
        }

        public override List<Position> GetLowerRightPositions()
        {
            var positions = new List<Position>(boardSize);

            for (int i = CurrentY + 1; i <= boardSize; i++)
            {
                positions.Add(new Position(CurrentX, i));
            }

            return positions;
        }

        public override List<Position> GetUpperRightPositions()
        {
            var positions = new List<Position> (boardSize);

            for (int i = CurrentX + 1; i <= boardSize; i++)
            {
                positions.Add(new Position(i, CurrentY));
            }

            return positions;
        }
    }
}