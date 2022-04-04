using System.Collections.Generic;

namespace ChessGame.model
{
    public interface IPiece
    {
        ChessSquare GetCurrentSquare();

        void MovePiece(ChessSquare activeSquare);

        List<Position> GetAvailablePositions();

        List<Position> GetCapturePositions();

        ColorType Color { get; }

        MovementType GetMovementType();

        PieceType PieceType { get; }
    }
}