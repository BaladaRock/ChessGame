using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Model
{
    public abstract class ChessPiece : IPiece
    {
        protected ChessSquare currentSquare;

        private bool wasMoved;

        protected ChessPiece(ColorType color, byte size)
        {
            Color = color;
            currentSquare = null;
            wasMoved = false;
            BoardSize = size;
        }

        protected IEnumerable<Position> AddSingleSquarePositions(Position position, bool requirement)
        {
            return requirement
                ? new List<Position> { position }
                : Enumerable.Empty<Position>().ToList();
        }

        protected bool CheckThatPositionIsInsideBoard(byte xPosition, byte yPosition)
        {
            return xPosition >= 0 && xPosition < BoardSize &&
                   yPosition >= 0 && yPosition < BoardSize;
        }
        public ChessSquare GetCurrentSquare() => currentSquare;

        public Position CurrentPosition => currentSquare == null ? new Position(0, 0) : currentSquare.Position;

        public ColorType Color { get; }

        public MovementType Movement { get; protected set; }

        public MovementType GetMovementType() => Movement;

        protected byte BoardSize { get; set; }

        protected byte CurrentX => CurrentPosition.X;

        protected byte CurrentY => CurrentPosition.Y;

        public abstract PieceType PieceType { get; }

        public abstract IEnumerable<IEnumerable<Position>> GetAvailablePositions();

        public virtual IEnumerable<Position> GetLowerLeftTwoColumnMovement()
        {

            return PositionsCalculator.GetLowerLeftDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperLeftTwoColumnMovement()
        {
            return PositionsCalculator.GetUpperLeftDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLowerRightTwoColumnMovement()
        {
            return PositionsCalculator.GetLowerRightDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperRightOneColumnMovement()
        {
            return PositionsCalculator.GetUpperRightDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLowerLeftOneColumnMovement()
        {
            return PositionsCalculator.GetLeftLine(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperRightTwoColumnMovement()
        {
            return PositionsCalculator.GetRightLine(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperLeftOneColumnMovement()
        {
            return PositionsCalculator.GetUpperColumn(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLowerRighOneColumnMovement()
        {
            return PositionsCalculator.GetLowerColumn(CurrentX, CurrentY);
        }

        public virtual void OccupySquare(ChessSquare chessSquare)
        {
            if (chessSquare == null)
            {
                throw new ArgumentNullException(paramName: nameof(chessSquare), message: "Please provide a square that is not null!");
            }

            currentSquare?.EmptySquare();
            chessSquare.OccupySquare(this);
            currentSquare = chessSquare;
        }

        public virtual void MovePiece(ChessSquare activeSquare)
        {
            if (activeSquare == null)
            {
                throw new ArgumentNullException(paramName: nameof(activeSquare), message: "Please provide a square that is not null!");
            }

            OccupySquare(activeSquare);
            wasMoved = true;
        }

        public bool WasMoved()
        {
            return wasMoved;
        }

        public virtual IEnumerable<IEnumerable<Position>> GetCapturePositions()
        {
            return GetAvailablePositions();
        }
    }
}