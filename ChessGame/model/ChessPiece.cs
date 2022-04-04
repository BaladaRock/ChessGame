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

        protected List<Position> AddSingleSquarePositions(Position firstPair, Position secondPair, (bool, bool) requirements)
        {
            var positions = new List<Position>(2);

            if (requirements.Item1)
            {
                positions.Add(firstPair);
            }

            if (requirements.Item2)
            {
                positions.Add(secondPair);
            }

            return positions;
        }

        public ChessSquare GetCurrentSquare() => currentSquare;

        public Position CurrentPosition => currentSquare == null ? new Position(0, 0) : currentSquare.Position;

        public ColorType Color { get; }

        public MovementType Movement { get; protected set; }

        protected int BoardSize { get; set; }

        protected int CurrentX => CurrentPosition.X;

        protected int CurrentY => CurrentPosition.Y;

        public abstract PieceType PieceType { get; }

        public abstract List<Position> GetAvailablePositions();

        public abstract List<Position> GetLowerLeftPositions();

        public abstract List<Position> GetUpperLeftPositions();

        public abstract List<Position> GetLowerRightPositions();

        public abstract List<Position> GetUpperRightPositions();

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

        public bool WasMoved()
        {
            return wasMoved;
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

        public virtual List<Position> GetCapturePositions()
        {
            return GetAvailablePositions();
        }

        public MovementType GetMovementType() => Movement;
    }
}