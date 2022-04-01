using System.Collections.Generic;

namespace ChessGame.model
{
    public interface IPiece
    {
        ChessSquare GetCurrentSquare();

        void MovePiece(ChessSquare activeSquare);

        List<(int, int)> GetAvailablePositions();

        List<(int, int)> GetCapturePositions();

        ColorType Color { get; }

        MovementType GetMovementType();

        PieceType PieceType { get; }
    }
}