namespace ChessGame.model
{
    public interface IChess
    {
        IPiece GetActivePiece();

        void MovePiece(IPiece chessPiece, ChessSquare activeSquare);
    }
}