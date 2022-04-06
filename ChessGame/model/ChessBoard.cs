using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.model
{
    public class ChessBoard : IChess
    {
        private readonly Position notFound;

        private readonly ChessSquare[,] boardSquares;

        private ChessSquare lastActive;

        private Position kingPosition;

        private ChessCalculator calculator;

        protected int boardSize;

        private bool piecePreviouslyClicked;

        private ColorType playerToMove;

        public ChessBoard(int size)
        {
            boardSize = size;
            boardSquares = new ChessSquare[boardSize, boardSize];
            playerToMove = ColorType.white;
            piecePreviouslyClicked = false;
            notFound = new Position(-1, -1);
            BuildChessBoard();
            WhiteKingPosition = new Position(4, 7);
            BlackKingPosition = new Position(4, 0);
            calculator = new ChessCalculator(boardSize, boardSquares);
        }

        public ChessSquare ActiveSquare { get; set; }

        public bool IsChecked { get; private set; }

        internal Position WhiteKingPosition { get; private set; }

        internal Position BlackKingPosition { get; private set; }

        public IPiece GetActivePiece()
        {
            return ActiveSquare.Piece;
        }

        public bool UpdatedAfterClick(int x, int y)
        {
            ChessSquare freshlyClicked = boardSquares[x, y];

            if (freshlyClicked.IsOccupied())
            {
                return piecePreviouslyClicked
                    ? CheckCaptureSquares(freshlyClicked)
                    : SetActivePiece(freshlyClicked);
            }
            else
            {
                return piecePreviouslyClicked
                  && MoveIfLegal(freshlyClicked);
            }
        }

        public void MovePiece(IPiece chessPiece, ChessSquare activeSquare)
        {
            ActiveSquare = activeSquare;
            chessPiece.MovePiece(activeSquare);
        }

        public ChessSquare GetSquare(int rowIndex, int columnIndex)
        {
            foreach (var square in boardSquares)
            {
                if (FoundSquare(square.Position, rowIndex, columnIndex))
                {
                    return square;
                }
            }

            return null;
        }

        public Position GetLastActivePositions()
        {
            return lastActive == null ? notFound : lastActive.Position;
        }

        private void BuildChessBoard()
        {
            BuildSquares(boardSquares, ColorType.white, ColorType.black);
        }

        private void BuildSquares(ChessSquare[,] boardSquares, ColorType white, ColorType black)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    ColorType squareColor = j % 2 == 0 ? white : black;
                    boardSquares[i, j] = new ChessSquare(new Position(i, j), squareColor);
                }
                SwapColors(ref white, ref black);
            }
        }

        private bool SetActivePiece(ChessSquare freshlyClicked)
        {
            ActiveSquare = freshlyClicked;
            lastActive = freshlyClicked;
            piecePreviouslyClicked = true;
            return false;
        }

        private bool ApplyMove(ChessSquare freshlyClicked)
        {
            if (playerToMove != lastActive.Piece.Color || CheckDoubleMove())
            {
                ResetState();
                return false;
            }

            if (IsChecked && calculator.IsNotOutOfCheck(freshlyClicked, ActiveSquare, kingPosition))
            {
                Console.WriteLine($"Please move out of check!!! {kingPosition.X} {kingPosition.Y}");
                return ResetState();
            }

            IsChecked = false;

            playerToMove = playerToMove == ColorType.white ? ColorType.black : ColorType.white;
            return UpdateState(freshlyClicked);
        }

        private bool UpdateState(ChessSquare freshlyClicked)
        {
            lastActive.Piece.MovePiece(freshlyClicked);
            lastActive.EmptySquare();
            ActiveSquare = freshlyClicked;
            piecePreviouslyClicked = false;
            WriteMessage();

            calculator.UpdateBoard(boardSquares);

            kingPosition = playerToMove == ColorType.white ? WhiteKingPosition : BlackKingPosition;

            if (calculator.KingIsChecked(lastActive, ActiveSquare, kingPosition))
            {
                IsChecked = true;
                Console.WriteLine("Check!!!");
            }

            UpdateKingPosition();
            return CheckPromotion();
        }

        private void UpdateKingPosition()
        {
            var active = (ChessPiece)ActiveSquare.Piece;

            if (active.PieceType != PieceType.king)
            {
                return;
            }

            var activePosition = ActiveSquare.Position;

            if(playerToMove == ColorType.white)
            {
                BlackKingPosition = new Position(activePosition.X, activePosition.Y);
            }
            else
            {
                WhiteKingPosition = new Position(activePosition.X, activePosition.Y);
            }

            calculator.UpdateBoard(boardSquares);
        }

        private bool CheckPromotion()
        {
            var active = (ChessPiece)ActiveSquare.Piece;
            if (active.PieceType != PieceType.pawn)
            {
                return true;
            }

            return CheckPawnPromotion((Pawn)active);
        }

        private bool CheckDoubleMove()
        {
            var active = (ChessPiece)ActiveSquare.Piece;
            if (active.PieceType != PieceType.pawn)
            {
                return false;
            }

            return CheckPieceBetween((Pawn)active);
        }

        private bool CheckPieceBetween(Pawn active)
        {
            if (active.WasMoved())
            {
                return false;
            }

            int yIndex = active.Color == ColorType.white
                ? ActiveSquare.Position.Y - 1
                : ActiveSquare.Position.Y + 1;

            return boardSquares[ActiveSquare.Position.X, yIndex].IsOccupied();
        }

        private bool CheckPawnPromotion(Pawn active)
        {
            if (!active.Promoted)
            {
                return true;
            }

            var newQueen = new Queen(active.Color);
            newQueen.OccupySquare(ActiveSquare);
            Console.WriteLine(newQueen.Movement);
            return true;
        }

        private bool MoveIfLegal(ChessSquare freshlyClicked)
        {
            //if (IsChecked && calculator.IsOutOfCheck(freshlyClicked, ActiveSquare, kingPosition))
            //{
            //    Console.WriteLine($"Please move out of check!!! {kingPosition.X} {kingPosition.Y}");
            //    return ResetState();
            //}

            //IsChecked = false;
            return CheckMultiplePositions((ChessPiece)ActiveSquare.Piece, freshlyClicked);
        }

        private bool FoundSquare(Position position, int x, int y)
        {
            return position.X == x && position.Y == y;
        }

        private bool CheckCaptureSquares(ChessSquare freshlyClicked)
        {
            ChessPiece pieceToCheck = (ChessPiece)freshlyClicked.Piece;
            ChessPiece activePiece = (ChessPiece)ActiveSquare.Piece;
            if (pieceToCheck.Color == activePiece.Color)
            {
                return false;
            }

            return CheckMultipleCapturePositions(activePiece, freshlyClicked);
        }

        private bool CheckMultipleCapturePositions(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            bool foundPositions = ChececkForAllCaptureDirections(pieceToCheck, clickedSquare);
            return foundPositions ? foundPositions : ResetState();
        }

        private bool CheckMultiplePositions(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            bool foundPositions = ChececkForAllDirections(pieceToCheck, clickedSquare);
            return foundPositions ? foundPositions : ResetState();
        }

        private bool ChececkForAllCaptureDirections(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            return pieceToCheck.GetCapturePositions()
               .Any(direction => CheckForOneCaptureDirection(clickedSquare, direction, pieceToCheck.Color));
        }

        private bool ChececkForAllDirections(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            return pieceToCheck.GetAvailablePositions()
                .Any(direction => CheckForOneDirection(clickedSquare, direction));
        }

        private bool CheckForOneDirection(ChessSquare clickedSquare, IEnumerable<Position> squares)
        {
            Position clicked = clickedSquare.Position;
            foreach (var position in squares)
            {
                var checkedSquare = boardSquares[position.X, position.Y];

                if (checkedSquare.IsOccupied())
                {
                    return false;
                }
                else if (position.Equals(clicked))
                {
                    return ApplyMove(clickedSquare);
                }
            }
            return false;
        }

        private bool CheckForOneCaptureDirection(ChessSquare clickedSquare, IEnumerable<Position> squares, ColorType pieceColor)
        {
            Position found = notFound;
            Position clicked = clickedSquare.Position;
            foreach (var position in squares)
            {
                var checkedSquare = boardSquares[position.X, position.Y];
                if (checkedSquare.IsOccupied())
                {
                    if (checkedSquare.Piece.Color == pieceColor)
                    {
                        return false;
                    }

                    found = position;
                    break;
                }
            }

            return found.Equals(clicked) && ApplyMove(clickedSquare);
        }

        private bool ResetState()
        {
            ActiveSquare = null;
            lastActive = null;
            piecePreviouslyClicked = false;
            return false;
        }

        private void WriteMessage()
        {
            Console.WriteLine("Made a move!");
            Console.WriteLine($"Currently active: {ActiveSquare.Position.X} {ActiveSquare.Position.Y}");
            Console.WriteLine($"Last active: {lastActive.Position.X} {lastActive.Position.Y}");
        }

        private void SwapColors(ref ColorType firstColor, ref ColorType secondColor)
        {
            var tempColor = firstColor;
            firstColor = secondColor;
            secondColor = tempColor;
        }
    }
}