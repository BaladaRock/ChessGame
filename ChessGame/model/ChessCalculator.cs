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

        private bool kingWasMoved;

        public ChessCalculator(int boardSize, ChessSquare[,] boardSquares)
        {
            this.boardSize = boardSize;
            this.boardSquares = boardSquares;
            forbiddenPositions = default;
            kingWasMoved = false;
        }

        internal bool KingIsChecked(ChessSquare lastActive, ChessSquare activeSquare, Position kingPosition)
        {
            var activePiece = activeSquare.Piece;

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
                    forbiddenPositions = direction;

                    //forbiddenPositions = forbiddenPositions == null
                    //    ? direction
                    //    : forbiddenPositions.Union(direction);

                    attackingPiece = activePiece;
                    foreach (var element in forbiddenPositions)
                    {
                        Console.WriteLine($"{element.X} {element.Y}");
                    }

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
            bool stillInCheck = false;
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;

            if (activePosition.Equals(attackingPiece.CurrentPosition))
            {
                return false;
            }

            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            if (activeSquare.Piece.PieceType == PieceType.king)
            {
                stillInCheck = KingCanMove(activePosition, activeSquare.Piece.Color);
            }
            else
            {
                stillInCheck = CheckedByActivePiece(attackingPiece, kingPosition);
            }

            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);

            return stillInCheck;
        }

        internal bool KingWouldBeChecked(ChessSquare activeSquare, ChessSquare lastActive, Position kingPosition)
        {
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;
            bool wouldBeInCheck = false;

            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            if (activeSquare.Piece.PieceType == PieceType.king)
            {
                wouldBeInCheck = KingCanMove(activePosition, activeSquare.Piece.Color);
            }
            else
            {
                wouldBeInCheck = CheckEnemyCheckers(
                    GetEnemySquares(kingPosition, lastPosition),
                    kingPosition,
                    activeSquare.Piece.Color
                    );
            }

            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);

            return wouldBeInCheck;
        }

        private bool KingCanMove(Position activePosition, ColorType color)
        {
            var knightSquare = new ChessSquare(activePosition, color);
            Knight knightPiece = new Knight(color);
            knightPiece.OccupySquare(knightSquare);

            var allDirections = new[]
            {
                PositionsCalculator.GetUpperLeftDiagonal(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetLowerLeftDiagonal(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetUpperRightDiagonal(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetLowerRightDiagonal(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetLeftLine(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetUpperColumn(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetRightLine(boardSize -1, activePosition.X, activePosition.Y),
                PositionsCalculator.GetLowerColumn(boardSize -1, activePosition.X, activePosition.Y),
            }
            .Union(knightSquare.Piece.GetAvailablePositions());

            return allDirections.Any(direction => CheckEnemyCheckers(direction, activePosition, color));
        }

        private bool CheckEnemyCheckers(IEnumerable<Position> enemyCheckersPositions, Position kingPosition, ColorType ownColor)
        {
            foreach (var position in enemyCheckersPositions)
            {
                var currentPiece = boardSquares[position.X, position.Y].Piece;

                if (currentPiece == null)
                {
                    continue;
                }

                if (currentPiece.Color == ownColor)
                {
                    break;
                }

                if (CheckedByActivePiece((ChessPiece)currentPiece, kingPosition))
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<Position> GetEnemySquares(Position kingPosition, Position lastPosition)
        {
            int kingX = kingPosition.X;
            int kingY = kingPosition.Y;
            int movedX = lastPosition.X;
            int movedY = lastPosition.Y;

            switch (kingX)
            {
                case int _ when kingY == movedY && kingX > movedX:
                    return PositionsCalculator.GetLeftLine(boardSize - 1, movedX, movedY);

                case int _ when kingY == movedY && kingX < movedX:
                    return PositionsCalculator.GetRightLine(boardSize - 1, movedX, movedY);

                case int _ when kingX == movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperColumn(boardSize - 1, movedX, movedY);

                case int _ when kingX == movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerColumn(boardSize - 1, movedX, movedY);

                case int _ when kingX > movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerLeftDiagonal(boardSize - 1, movedX, movedY);

                case int _ when kingX > movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperLeftDiagonal(boardSize - 1, movedX, movedY);

                case int _ when kingX < movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerRightDiagonal(boardSize - 1, movedX, movedY);

                case int _ when kingX < movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperRightDiagonal(boardSize - 1, movedX, movedY);

                default:
                    return Enumerable.Empty<Position>();
            }
        }
    }
}