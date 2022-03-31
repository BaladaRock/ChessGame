using System.Collections.Generic;

namespace ChessGame.model
{
    public interface IChess
    {
        IPiece GetActivePiece();

        void MovePiece(IPiece chessPiece, ChessSquare activeSquare);

        List<(int, int)> GetAvailablePositions(IPiece activePiece);
    }
}