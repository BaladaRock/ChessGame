using ChessGame.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.controller
{
    internal class ChessGame
    {
        private model.ChessBoard board;

        public int BoardSize { get; private set; }

        public ChessGame(int gameSize)
        {
            BoardSize = gameSize;
            board = new model.ChessBoard(BoardSize);
        }

        internal void OccupySquare(string piece, string pieceColor, int rowIndex, int columnIndex)
        {
            ChessPiece pieceToAdd = BuildPiece(piece, pieceColor);
            pieceToAdd.OccupySquare(board.GetSquare(rowIndex, columnIndex));
        }
        private ChessPiece BuildPiece(string piece, string pieceColor)
        {
            ColorType color = pieceColor == "white" ? ColorType.white : ColorType.black;

            switch(piece)
            {
                case "pawn":
                    return new Pawn(color);
                case "bishop":
                    return new Bishop(color);
                case "knight":
                    return new Knight(color);
                case "king":
                    return new King(color);
                case "queen":
                    return new Queen(color);
                case "rook":
                    return new Rook(color);
                default:
                    return new Pawn(color);
            }
        }

        internal bool UpdatedAfterClick(int x, int y)
        {
            return board.UpdatedAfterClick(x, y);
        }

        internal void BuildChessGame(int size)
        {
            BoardSize = size;
            board = new model.ChessBoard(BoardSize);
        }

        internal string GetActivePiece()
        {
            return default;
        }

        internal Position GetLastActivePositions()
        {
            return board.GetLastActivePositions();
        }

        internal string GetActivePieceColor()
        {
            return board.GetActivePiece().Color == ColorType.white ? "white" : "black";
        }

        internal string GetActivePieceType()
        {
            return board.GetActivePiece().PieceType.ToString();
        }
    }
}
