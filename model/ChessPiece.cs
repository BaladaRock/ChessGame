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

        protected List<(int, int)> AddSingleSquarePositions((int, int) firstPair, (int, int) secondPair, (bool, bool) requirements)
        {
            var positions = new List<(int, int)>(2);

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

        public (int, int) CurrentPosition => currentSquare == null ? (0, 0) : currentSquare.Position;

        public ColorType Color { get; }

        public MovementType Movement { get; protected set; }

        protected int BoardSize { get; set; }

        protected int CurrentX => CurrentPosition.Item1;

        protected int CurrentY => CurrentPosition.Item2;

        public abstract PieceType PieceType { get; }

        public abstract List<(int, int)> GetAvailablePositions();

        public abstract List<(int, int)> GetLowerLeftPositions();

        public abstract List<(int, int)> GetUpperLeftPositions();

        public abstract List<(int, int)> GetLowerRightPositions();

        public abstract List<(int, int)> GetUpperRightPositions();

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

        public virtual List<(int, int)> GetCapturePositions()
        {
            return GetAvailablePositions();
        }

        public MovementType GetMovementType() => Movement;
    }
}