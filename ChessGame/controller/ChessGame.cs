using ChessGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Controller
{
    internal class ChessGame
    {
        private Model.ChessBoard board;

        public byte BoardSize { get; private set; }

        public ChessGame(byte gameSize)
        {
            BoardSize = gameSize;
            board = new Model.ChessBoard(BoardSize);
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
                    return new Pawn(color, BoardSize);
                case "bishop":
                    return new Bishop(color, BoardSize);
                case "knight":
                    return new Knight(color, BoardSize);
                case "king":
                    return new King(color, BoardSize);
                case "queen":
                    return new Queen(color, BoardSize);
                case "rook":
                    return new Rook(color, BoardSize);
                default:
                    return new Pawn(color, BoardSize);
            }
        }

        internal bool UpdatedAfterClick(byte x, byte y)
        {
            //var pieceHasMoved = board.UpdatedAfterClick(x, y);

            //if (pieceHasMoved)
            //{
            //    board.AppplyMove(x, y);
            //    board.CheckPromotion();
            //    board.CheckIsInCheck();
            //}

            return board.UpdatedAfterClick(x, y);
        }

        internal void BuildChessGame(byte size)
        {
            BoardSize = size;
            board = new Model.ChessBoard(BoardSize);
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
