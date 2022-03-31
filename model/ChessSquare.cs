namespace ChessGame.model
{
    public class ChessSquare
    {
        public (int, int) Position { get; }

        public IPiece Piece { get; private set; }

        public ColorType Type { get; }

        public ChessSquare((int, int) coordinates, ColorType type)
        {
            Position = coordinates;
            Type = type;
        }

        public bool IsOccupied()
        {
            return Piece != null;
        }

        public void EmptySquare()
        {
            Piece = null;
        }

        public void OccupySquare(IPiece newPiece)
        {
            Piece = newPiece;
        }
    }
}