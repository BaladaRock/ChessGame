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

        public override List<(int, int)> GetAvailablePositions()
        {
            return Color == ColorType.white
                ? UpdateWhitePositions()
                : UpdateBlackPositions();
        }

        public override List<(int, int)> GetCapturePositions()
        {
            int yIndex = CurrentPosition.Item2;
            return Color == ColorType.white
                ? GetCapturePositions(yIndex - 1)
                : GetCapturePositions(yIndex + 1);
        }

        public override List<(int, int)> GetLowerLeftPositions()
        {
            return default;
        }

        public override List<(int, int)> GetUpperLeftPositions()
        {
            return default;
        }

        public override List<(int, int)> GetLowerRightPositions()
        {
            return default;
        }

        public override List<(int, int)> GetUpperRightPositions()
        {
            return default;
        }

        private List<(int, int)> UpdateWhitePositions()
        {
            return AddSingleSquarePositions(
             (CurrentX, CurrentY - 1),
             (CurrentX, CurrentY - 2),
             (CurrentY > 0 && CurrentY < boardSize, !WasMoved())
            );
        }

        private List<(int, int)> UpdateBlackPositions()
        {
            return AddSingleSquarePositions(
             (CurrentX, CurrentY + 1),
             (CurrentX, CurrentY + 2),
             (CurrentY > 0 && CurrentY < boardSize, !WasMoved())
            );
        }

        private List<(int, int)> GetCapturePositions(int yIncrement)
        {
            bool yIndexCondition = CurrentY > 0 && CurrentY < boardSize;
            return AddSingleSquarePositions(
            (CurrentX - 1, yIncrement),
            (CurrentX + 1, yIncrement),
            (yIndexCondition && CurrentX != 0, yIndexCondition && CurrentX != boardSize)
           );
        }

        private bool CheckPosition()
        {
            return Color == ColorType.white
                ? CurrentPosition.Item2 == 0
                : CurrentPosition.Item2 == boardSize;
        }
    }
}