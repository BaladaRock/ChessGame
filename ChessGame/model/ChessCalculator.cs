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

            return CheckedByDirectionMovement(activePiece, kingPosition);
        }

        private bool CheckedByDirectionMovement(ChessPiece activePiece, Position kingPosition)
        {
            return activePiece.GetCapturePositions()
                .Any(direction => CheckPositions(activePiece, direction, kingPosition));
        }

        private bool CheckPositions(ChessPiece activePiece, IEnumerable<Position> direction, Position kingPosition)
        {
            foreach (var position in direction)
            {

                // Extra check that treats pawn promotion index error
                if (position.X == -1 || position.Y == -1)
                {
                    return false;
                }


                if (position.Equals(kingPosition))
                {
                    forbiddenPositions = forbiddenPositions == null
                        ? direction
                        : forbiddenPositions.Union(direction);

                    attackingPiece = activePiece;

                    return true;
                }

                if (boardSquares[position.X, position.Y].IsOccupied())
                {
                    return false;
                }
            }

            return false;
        }

        internal void UpdateBoard(ChessSquare[,] boardSquares)
        {
            this.boardSquares = boardSquares;
        }

        internal bool CheckOutOfCheck(ChessSquare activeSquare, ChessSquare lastActive, Position kingPosition)
        {
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;

            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            bool notInCheck = CheckedByDirectionMovement(attackingPiece, kingPosition);

            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);

            return notInCheck;
        }
    }
}