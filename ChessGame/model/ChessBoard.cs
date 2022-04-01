﻿using System;
using System.Collections.Generic;

namespace ChessGame.model
{
    public class ChessBoard : IChess
    {
        private ChessSquare[,] boardSquares;

        private ChessSquare lastActive;

        protected int boardSize;

        private bool piecePreviouslyClicked;

        internal ChessSquare ActiveSquare { get; set; }

        private ColorType playerToMove;

        public ChessBoard(int size)
        {
            boardSize = size;
            boardSquares = new ChessSquare[boardSize, boardSize];
            playerToMove = ColorType.white;
            piecePreviouslyClicked = false;
            BuildChessBoard();
        }

        private void BuildChessBoard()
        {
            BuildSquares(ColorType.white, ColorType.black);
        }

        private void BuildSquares(ColorType white, ColorType black)
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    ColorType squareColor = j % 2 == 0 ? white : black;
                    boardSquares[i, j] = new ChessSquare((i, j), squareColor);
                }
                SwapColors(ref white, ref black);
            }
        }

        internal bool UpdatedAfterClick(int x, int y)
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
                  && MoveIfLegal(freshlyClicked, x, y);
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
            return CheckPromotion();
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
                ? ActiveSquare.Position.Item2 - 1
                : ActiveSquare.Position.Item2 + 1;

            return boardSquares[ActiveSquare.Position.Item1, yIndex].IsOccupied();
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

        private bool MoveIfLegal(ChessSquare freshlyClicked, int x, int y)
        {
            ChessPiece pieceToCheck = (ChessPiece)ActiveSquare.Piece;

            if (pieceToCheck.GetMovementType() == MovementType.multipleSquares)
            {
                return CheckMultiplePositions(pieceToCheck, freshlyClicked);
            }

            foreach (var position in GetAvailablePositions(pieceToCheck))
            {
                if (position.Item1 == x && position.Item2 == y)
                {
                    return ApplyMove(freshlyClicked);
                }
            }
            return ResetState();
        }

        private bool CheckCaptureSquares(ChessSquare freshlyClicked)
        {
            ChessPiece pieceToCheck = (ChessPiece)freshlyClicked.Piece;
            ChessPiece activePiece = (ChessPiece)ActiveSquare.Piece;
            if (pieceToCheck.Color == activePiece.Color)
            {
                return false;
            }

            if (activePiece.GetMovementType() == MovementType.multipleSquares)
            {
                return CheckMultipleCapturePositions(activePiece, freshlyClicked);
            }

            (int, int) coordinates = pieceToCheck.CurrentPosition;

            foreach (var position in activePiece.GetCapturePositions())
            {
                if (position.Item1 == coordinates.Item1 && position.Item2 == coordinates.Item2)
                {
                    return ApplyMove(freshlyClicked);
                }
            }

            return ResetState();
        }

        private bool CheckMultipleCapturePositions(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            bool foundPositions = ChececkForAllCaptureDirections(pieceToCheck, clickedSquare);

            if (pieceToCheck.PieceType == PieceType.queen)
            {
                Queen queenPiece = (Queen)pieceToCheck;
                foundPositions = foundPositions || ChececkForAllCaptureDirections(queenPiece.RookPiece, clickedSquare);
            }

            return foundPositions ? foundPositions : ResetState();
        }

        private bool ChececkForAllCaptureDirections(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            return CheckForOneCaptureDirection(clickedSquare, pieceToCheck.GetUpperLeftPositions(), pieceToCheck.Color) ||
                CheckForOneCaptureDirection(clickedSquare, pieceToCheck.GetLowerLeftPositions(), pieceToCheck.Color) ||
                CheckForOneCaptureDirection(clickedSquare, pieceToCheck.GetUpperRightPositions(), pieceToCheck.Color) ||
                CheckForOneCaptureDirection(clickedSquare, pieceToCheck.GetLowerRightPositions(), pieceToCheck.Color);
        }

        private bool CheckMultiplePositions(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            bool foundPositions = ChececkForAllDirections(pieceToCheck, clickedSquare);

            if (pieceToCheck.PieceType == PieceType.queen)
            {
                Queen queenPiece = (Queen)pieceToCheck;
                foundPositions = foundPositions || ChececkForAllDirections(queenPiece.RookPiece, clickedSquare);
            }

            return foundPositions ? foundPositions : ResetState();
        }

        private bool ChececkForAllDirections(ChessPiece pieceToCheck, ChessSquare clickedSquare)
        {
            return CheckForOneDirection(clickedSquare, pieceToCheck.GetUpperLeftPositions()) ||
                CheckForOneDirection(clickedSquare, pieceToCheck.GetLowerLeftPositions()) ||
                CheckForOneDirection(clickedSquare, pieceToCheck.GetUpperRightPositions()) ||
                CheckForOneDirection(clickedSquare, pieceToCheck.GetLowerRightPositions());
        }

        private bool CheckForOneDirection(ChessSquare clickedSquare, IEnumerable<(int, int)> squares)
        {
            (int, int) clicked = clickedSquare.Position;
            foreach (var position in squares)
            {
                var checkedSquare = boardSquares[position.Item1, position.Item2];
                bool match = position.Item1 == clicked.Item1 && position.Item2 == clicked.Item2;

                if (checkedSquare.IsOccupied())
                {
                    return false;
                }
                else if (match)
                {
                    return ApplyMove(clickedSquare);
                }
            }
            return false;
        }

        private bool CheckForOneCaptureDirection(ChessSquare clickedSquare, IEnumerable<(int, int)> squares, ColorType pieceColor)
        {
            bool foundFirst = false;
            (int, int) found = (-1, -1);
            (int, int) clicked = clickedSquare.Position;
            foreach (var position in squares)
            {
                var checkedSquare = boardSquares[position.Item1, position.Item2];
                if (!foundFirst && checkedSquare.IsOccupied())
                {
                    if (checkedSquare.Piece.Color == pieceColor)
                    {
                        return false;
                    }
                    else
                    {
                        found = position;
                        foundFirst = true;
                    }
                }
            }

            return found == clicked && ApplyMove(clickedSquare);
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
            Console.WriteLine($"Currently active: {ActiveSquare.Position}");
            Console.WriteLine($"Last active: {lastActive.Position}");
        }

        internal (int, int) GetLastActivePositions()
        {
            return lastActive == null ? (-1, -1) : lastActive.Position;
        }

        private void SwapColors(ref ColorType firstColor, ref ColorType secondColor)
        {
            var tempColor = firstColor;
            firstColor = secondColor;
            secondColor = tempColor;
        }

        public IPiece GetActivePiece()
        {
            return ActiveSquare.Piece;
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
                if (square.Position.Item1 == rowIndex && square.Position.Item2 == columnIndex)
                {
                    return square;
                }
            }

            return null;
        }

        public List<(int, int)> GetAvailablePositions(IPiece activePiece)
        {
            var availablePositions = new List<(int, int)>(boardSize);
            foreach (var position in activePiece?.GetAvailablePositions())
            {
                var squareToCheck = boardSquares[position.Item1, position.Item2];
                if (!squareToCheck.IsOccupied())
                {
                    availablePositions.Add(position);
                }
            }
            return availablePositions;
        }
    }
}