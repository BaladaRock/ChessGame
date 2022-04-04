using System.Collections.Generic;

namespace ChessGame.model
{
    public class Pawn : ChessPiece
    {
        private readonly int boardSize;

        public Pawn(ColorType color) : base(color)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.pawn;

        public bool Promoted => CheckPosition();

        public override List<Position> GetAvailablePositions()
        {
            return Color == ColorType.white
                ? UpdateWhitePositions()
                : UpdateBlackPositions();
        }

        public override List<Position> GetCapturePositions()
        {
            int yIndex = CurrentPosition.Y;
            return Color == ColorType.white
                ? GetCapturePositions(yIndex - 1)
                : GetCapturePositions(yIndex + 1);
        }

        public override List<Position> GetLowerLeftPositions()
        {
            return default;
        }

        public override List<Position> GetUpperLeftPositions()
        {
            return default;
        }

        public override List<Position> GetLowerRightPositions()
        {
            return default;
        }

        public override List<Position> GetUpperRightPositions()
        {
            return default;
        }

        private List<Position> UpdateWhitePositions()
        {
            return AddSingleSquarePositions(
             new Position(CurrentX, CurrentY - 1),
             new Position(CurrentX, CurrentY - 2),
             (CurrentY > 0 && CurrentY < boardSize, !WasMoved())
            );
        }

        private List<Position> UpdateBlackPositions()
        {
            return AddSingleSquarePositions(
             new Position(CurrentX, CurrentY + 1),
             new Position(CurrentX, CurrentY + 2),
             (CurrentY > 0 && CurrentY < boardSize, !WasMoved())
            );
        }

        private List<Position> GetCapturePositions(int yIncrement)
        {
            bool yIndexCondition = CurrentY > 0 && CurrentY < boardSize;
            return AddSingleSquarePositions(
            new Position(CurrentX - 1, yIncrement),
            new Position(CurrentX + 1, yIncrement),
            (yIndexCondition && CurrentX != 0, yIndexCondition && CurrentX != boardSize)
           );
        }

        private bool CheckPosition()
        {
            return Color == ColorType.white
                ? CurrentPosition.Y == 0
                : CurrentPosition.Y == boardSize;
        }
    }
}