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

        internal void OccupySquare(string piece, string pieceColor, int rowIndex, int columnIndex)
        {
            ChessPiece pieceToAdd = BuildPiece(piece, pieceColor);
            pieceToAdd.OccupySquare(board.GetSquare(rowIndex, columnIndex));
        }
        private ChessPiece BuildPiece(string piece, string pieceColor)
        {
            throw new NotImplementedException();
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
