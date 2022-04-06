using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.model
{
    internal class ChessCalculator
    {
        private int boardSize;
        private ChessSquare[,] boardSquares;

        private IEnumerable<Position> forbiddenPositions;

        private ChessPiece attackingPiece;

        public ChessCalculator(int boardSize, ChessSquare[,] boardSquares)
        {
            this.boardSize = boardSize;
            this.boardSquares = boardSquares;
            forbiddenPositions = default;
        }

        internal bool KingIsChecked(ChessSquare lastActive, ChessSquare activeSquare, Position kingPosition)
        {
            var activePiece = (ChessPiece)activeSquare.Piece;

            return CheckedByActivePiece(activePiece, kingPosition);
        }

        private bool CheckedByActivePiece(ChessPiece activePiece, Position kingPosition)
        {
            return activePiece.GetCapturePositions()
                .Any(direction => ContainsKingPosition(activePiece, direction, kingPosition));
        }

        private bool ContainsKingPosition(ChessPiece activePiece, IEnumerable<Position> direction, Position kingPosition)
        {
            foreach (var position in direction)
            {
                if (position.Equals(kingPosition))
                {
                    forbiddenPositions = forbiddenPositions == null
                        ? direction
                        : forbiddenPositions.Union(direction);

                    attackingPiece = activePiece;

                    return true;
                }

                // Extra check that treats pawn promotion index error
                if (CheckPromotion(position.Y))
                {
                    break;
                }

                if (boardSquares[position.X, position.Y].IsOccupied())
                {
                    break;
                }
            }

            return false;
        }

        private bool CheckPromotion(int toCheck)
        {
            return toCheck < 0 || toCheck > boardSize - 1;
        }

        internal void UpdateBoard(ChessSquare[,] boardSquares)
        {
            this.boardSquares = boardSquares;
        }

        internal bool IsNotOutOfCheck(ChessSquare activeSquare, ChessSquare lastActive, Position kingPosition)
        {
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;

            // Verifies that attacking piece has been captured
            if(activePosition.Equals(attackingPiece.CurrentPosition))
            {
                return false;
            }

            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            bool stillInCheck = CheckedByActivePiece(attackingPiece, kingPosition);

            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);

            return stillInCheck;
        }
    }
}