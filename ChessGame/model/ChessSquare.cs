namespace ChessGame.model
{
    public class ChessSquare
    {
        public Position Position { get; }

        public IPiece Piece { get; private set; }

        public ColorType Type { get; }

        public ChessSquare(Position coordinates, ColorType type)
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