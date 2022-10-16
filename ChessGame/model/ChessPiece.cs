using System;
using System.Collections.Generic;

namespace ChessGame.model
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
            var positions = new List<Position>(1);

            if (requirement)
            {
                positions.Add(position);
            }

            return positions;
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

        public virtual IEnumerable<Position> GetLowerLeftDiagonal()
        {

            return PositionsCalculator.GetLowerLeftDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperLeftDiagonal()
        {
            return PositionsCalculator.GetUpperLeftDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLowerRightDiagonal()
        {
            return PositionsCalculator.GetLowerRightDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperRightDiagonal()
        {
            return PositionsCalculator.GetUpperRightDiagonal(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLeftLine()
        {
            return PositionsCalculator.GetLeftLine(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetRightLine()
        {
            return PositionsCalculator.GetRightLine(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetUpperColumn()
        {
            return PositionsCalculator.GetUpperColumn(CurrentX, CurrentY);
        }

        public virtual IEnumerable<Position> GetLowerColumn()
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