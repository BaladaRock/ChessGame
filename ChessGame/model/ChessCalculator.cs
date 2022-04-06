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
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;

            // Verifies that attacking piece has been captured
            if (activePosition.Equals(attackingPiece.CurrentPosition))
            {
                return false;
            }

            // return !HasBlockedCheck(activePosition);

            // Emulate wanted move
            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            // Store result in a variable
            bool stillInCheck = CheckedByActivePiece(attackingPiece, kingPosition);

            // Undo emulated move
            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);

            return stillInCheck;
        }

        private bool HasBlockedCheck(Position activePosition)
        {
            return forbiddenPositions.Any(position => position.Equals(activePosition));
        }

        internal bool KingWouldBeInCheck(ChessSquare activeSquare, ChessSquare lastActive, Position kingPosition)
        {
            var activePosition = activeSquare.Position;
            var lastPosition = lastActive.Position;
            //var temp = new Position(kingPosition.X, kingPosition.Y);


            //// First, emulate the wanted move
            boardSquares[activePosition.X, activePosition.Y].OccupySquare(lastActive.Piece);
            boardSquares[lastPosition.X, lastPosition.Y].EmptySquare();

            ////Separately treat the case when the piece moved is actually the king
            //if (lastActive.Piece.PieceType == PieceType.king)
            //{
            //    kingWasMoved = true;
            //    kingPosition = new Position(activePosition.X, activePosition.Y);
            //}

            // Get king position

            // Deduce the direction the king could be in check, from the relation between the wanted to move piece
            // and king's position

            // Then, check for enemy pieces, on the optained direction

            IEnumerable<Position> enemyCheckersPositions = GetEnemySquares(kingPosition, lastPosition);
            foreach (var element in enemyCheckersPositions)
            {
                Console.WriteLine($"{element.X} {element.Y}");
            }

            // Store result in a variable
            bool wouldBeInCheck = CheckEnemyCheckers(enemyCheckersPositions, kingPosition, activeSquare.Piece.Color);

            // Undo emulated move and king position update
            var lastPiece = boardSquares[activePosition.X, activePosition.Y].Piece;
            boardSquares[activePosition.X, activePosition.Y].EmptySquare();
            boardSquares[lastPosition.X, lastPosition.Y].OccupySquare(lastPiece);
            //if(kingWasMoved)
            //{
            //    kingPosition = temp;
            //    kingWasMoved = false;
            //}

            return wouldBeInCheck;
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
                case int x when kingY == movedY && kingX > movedX:
                    return PositionsCalculator.GetLeftLine(boardSize - 1, movedX, movedY);

                case int x when kingY == movedY && kingX < movedX:
                    return PositionsCalculator.GetRightLine(boardSize - 1, movedX, movedY);

                case int x when kingX == movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperColumn(boardSize - 1, movedX, movedY);

                case int x when kingX == movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerColumn(boardSize - 1, movedX, movedY);

                case int x when kingX > movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerLeftDiagonal(boardSize - 1, movedX, movedY);

                case int x when kingX > movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperLeftDiagonal(boardSize - 1, movedX, movedY);

                case int x when kingX < movedX && kingY < movedY:
                    return PositionsCalculator.GetLowerRightDiagonal(boardSize - 1, movedX, movedY);

                case int x when kingX < movedX && kingY > movedY:
                    return PositionsCalculator.GetUpperRightDiagonal(boardSize - 1, movedX, movedY);

                default:
                    return Enumerable.Empty<Position>();
            }
        }
    }
}