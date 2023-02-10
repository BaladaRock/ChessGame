using System.Collections.Generic;

namespace ChessGame.Model
{
    public class Pawn : ChessPiece
    {
        private const byte DoubleMove = 2;

        private readonly byte boardSize;

        public Pawn(ColorType color, byte size) : base(color, size)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.pawn;

        public bool Promoted => CheckPosition();

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            var doubleMove = GetDoubleMove(Color);

            return Color == ColorType.white
                ? new[] {
                    GetUpperColumn(),
                    doubleMove
                }

                : new[] {
                    GetLowerColumn(),
                    doubleMove
                };
        }

        public override IEnumerable<IEnumerable<Position>> GetCapturePositions()
        {
            return Color == ColorType.white
                ? new[] {
                    GetUpperLeftDiagonal(),
                    GetUpperRightDiagonal()
                }

                : new[] {
                    GetLowerLeftDiagonal(),
                    GetLowerRightDiagonal()
                };
        }

        public override IEnumerable<Position> GetUpperColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, (byte)(CurrentY - 1)),
              CurrentY > 0 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetLowerColumn()
        {
            return AddSingleSquarePositions(
              new Position(CurrentX, (byte)(CurrentY + 1)),
              CurrentY > 0 && CurrentY < boardSize
            );
        }

        public override IEnumerable<Position> GetUpperLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY - 1)),
              CurrentY > 0 && CurrentX > 0
            );
        }

        public override IEnumerable<Position> GetLowerLeftDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX - 1), (byte)(CurrentY + 1)),
              CurrentY > 0 && CurrentX > 0
            );
        }

        public override IEnumerable<Position> GetUpperRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY - 1)),
              CurrentY < boardSize && CurrentX < boardSize
            );
        }

        public override IEnumerable<Position> GetLowerRightDiagonal()
        {
            return AddSingleSquarePositions(
              new Position((byte)(CurrentX + 1), (byte)(CurrentY + 1)),
              CurrentY < boardSize && CurrentX < boardSize
            );
        }

        private IEnumerable<Position> GetDoubleMove(ColorType color)
        {
            byte toMove = (byte)(color == ColorType.white ? CurrentY - DoubleMove : CurrentY + DoubleMove);

            return AddSingleSquarePositions(
              new Position(CurrentX, toMove),
              !WasMoved()
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