﻿using System.Collections.Generic;

namespace ChessGame.Model
{
    public interface IPiece
    {
        ChessSquare GetCurrentSquare();

        void MovePiece(ChessSquare activeSquare);

        IEnumerable<IEnumerable<Position>> GetAvailablePositions();

        IEnumerable<IEnumerable<Position>> GetCapturePositions();

        ColorType Color { get; }

        MovementType GetMovementType();

        PieceType PieceType { get; }
    }
}