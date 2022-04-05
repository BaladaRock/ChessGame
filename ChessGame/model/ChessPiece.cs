using System;
using System.Collections.Generic;

namespace ChessGame.model
{
    public abstract class ChessPiece : IPiece
    {
        protected ChessSquare currentSquare;

        private bool wasMoved;

        protected ChessPiece(ColorType color)
        {
            Color = color;
            currentSquare = null;
            wasMoved = false;
            BoardSize = 7;
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

        protected int BoardSize { get; set; }

        protected int CurrentX => CurrentPosition.X;

        protected int CurrentY => CurrentPosition.Y;

        public abstract PieceType PieceType { get; }

        public abstract IEnumerable<IEnumerable<Position>> GetAvailablePositions();

        public virtual IEnumerable<Position> GetLowerLeftDiagonal()
        {
            var positions = new List<Position>(BoardSize);

            for (var (x, y) = (CurrentX - 1, CurrentY + 1); (x >= 0 && y <= BoardSize); x--, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetUpperLeftDiagonal()
        {
            var positions = new List<Position>(BoardSize);
            for (var (x, y) = (CurrentX - 1, CurrentY - 1); (x >= 0 && y >= 0); x--, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetLowerRightDiagonal()
        {
            var positions = new List<Position>(BoardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY + 1); (x <= BoardSize && y <= BoardSize); x++, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetUpperRightDiagonal()
        {
            var positions = new List<Position>(BoardSize);

            for (var (x, y) = (CurrentX + 1, CurrentY - 1); (x <= BoardSize && y >= 0); x++, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetLeftLine()
        {
            var positions = new List<Position>(BoardSize);

            for (int i = CurrentX - 1; i >= 0; i--)
            {
                positions.Add(new Position(i, CurrentY));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetRightLine()
        {
            var positions = new List<Position>(BoardSize);

            for (int i = CurrentX + 1; i <= BoardSize; i++)
            {
                positions.Add(new Position(i, CurrentY));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetUpperColumn()
        {
            var positions = new List<Position>(BoardSize);

            for (int i = CurrentY - 1; i >= 0; i--)
            {
                positions.Add(new Position(CurrentX, i));
            }

            return positions;
        }

        public virtual IEnumerable<Position> GetLowerColumn()
        {
            var positions = new List<Position>(BoardSize);

            for (int i = CurrentY + 1; i <= BoardSize; i++)
            {
                positions.Add(new Position(CurrentX, i));
            }

            return positions;
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