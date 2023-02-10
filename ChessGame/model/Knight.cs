using System.Collections.Generic;

namespace ChessGame.Model
{
    public class Knight : ChessPiece
    {
        private readonly byte boardSize;

        public Knight(ColorType color, byte size) : base(color, size)
        {
            boardSize = BoardSize;
            Movement = MovementType.singleSquare;
        }

        public override PieceType PieceType => PieceType.knight;

        public override IEnumerable<IEnumerable<Position>> GetAvailablePositions()
        {
            return new[] {
                GetUpperLeftOneColumnMovement(),
                GetUpperLeftTwoColumnMovement(),
                GetUpperRightOneColumnMovement(),
                GetUpperRightTwoColumnMovement(),
                GetLowerLeftOneColumnMovement(),
                GetLowerLeftTwoColumnMovement(),
                GetLowerRighOneColumnMovement(),
                GetLowerRightTwoColumnMovement()
            };
        }

        public override IEnumerable<Position> GetLowerLeftTwoColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX - 2), (byte)(CurrentY + 1));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetLowerLeftOneColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX - 1), (byte)(CurrentY + 2));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetUpperLeftTwoColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX - 2), (byte)(CurrentY - 1));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetUpperLeftOneColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX - 1), (byte)(CurrentY - 2));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetLowerRighOneColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX + 1), (byte)(CurrentY + 2));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetLowerRightTwoColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX + 2), (byte)(CurrentY + 1));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetUpperRightOneColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX + 1), (byte)(CurrentY - 2));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }

        public override IEnumerable<Position> GetUpperRightTwoColumnMovement()
        {
            var possibleMove = new Position((byte)(CurrentX + 2), (byte)(CurrentY - 1));
            return AddSingleSquarePositions(
              possibleMove,
              CheckThatPositionIsInsideBoard(possibleMove.X, possibleMove.Y)
            );
        }
    }
}