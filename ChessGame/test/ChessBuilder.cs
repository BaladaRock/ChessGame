using ChessGame.model;
using System;
using System.Linq;

namespace ChessGame.test
{
    internal class ChessBuilder
    {
        public ChessBuilder()
        {
        }

        public void TestObjects()
        {
            //// Create new empty board and add pawns
            var chessBoard = new model.ChessBoard(8);

            var whitePawn = new Pawn(ColorType.white, 7);
            var square = chessBoard.GetSquare(6, 6);
            whitePawn.OccupySquare(square);

            // Test pawn movement
            //whitePawn.MovePiece(chessBoard.GetSquare(6, 5));
            //var pawnPositions = whitePawn.GetAvailablePositions();

            //for (int i = 0; i < pawnPositions.ToList().Count; i++)
            //{
            //    foreach (var position in pawnPositions.ToList()[i])
            //    {
            //        Console.WriteLine($"Pawn available moves: {position.X}, {position.Y}");
            //    }
            //}

            //whitePawn.MovePiece(chessBoard.GetSquare(6, 5));
            //var capturePositions = whitePawn.GetCapturePositions();

            //for (int i = 0; i < capturePositions.ToList().Count; i++)
            //{
            //    foreach (var position in capturePositions.ToList()[i])
            //    {
            //        Console.WriteLine($"Pawn available capture moves: {position.X}, {position.Y}");
            //    }
            //}

            //// Test knight movement
            var blackKnight = new Knight(ColorType.black, 7);
            var knightSquare = chessBoard.GetSquare(4, 6);
            blackKnight.OccupySquare(knightSquare);

            var knightMoves = blackKnight.GetAvailablePositions().ToList();
            Console.WriteLine($"Count test: {knightMoves?.Count}");
            for (int i = 0; i < knightMoves.ToList().Count; i++)
            {
                foreach (var position in knightMoves.ToList()[i])
                {
                    Console.WriteLine($"Knight available moves: {position.X}, {position.Y}");
                }
            }

            var knightCaptures = blackKnight.GetCapturePositions().ToList();
            Console.WriteLine($"Count test: {knightCaptures?.Count}");
            for (int i = 0; i < knightCaptures.ToList().Count; i++)
            {
                foreach (var position in knightCaptures.ToList()[i])
                {
                    Console.WriteLine($"Knight available capture moves: {position.X}, {position.Y}");
                }
            }

            //// Test bishop movement
            var whiteBishop = new Bishop(ColorType.white, 7);
            var bishopSquare = chessBoard.GetSquare(5, 1);
            whiteBishop.OccupySquare(bishopSquare);

            var bishopCaptures = whiteBishop.GetCapturePositions().ToList();
            Console.WriteLine($"Count test: {bishopCaptures?.Count}");

            for (int i = 0; i < bishopCaptures?.Count; i++)
            {
                foreach (var position in bishopCaptures.ToList()[i])
                {
                    Console.WriteLine($"Bishop available capture moves: {position.X}, {position.Y}");
                }
            }

            //// Test queen movement
            var whiteQueen = new Queen(ColorType.white, 7);
            var queenSquare = chessBoard.GetSquare(4, 4);
            whiteQueen.OccupySquare(queenSquare);

            // Lower left diagonal
            var queenCaptures = whiteQueen.GetAvailablePositions().ToList();
            Console.WriteLine($"Count test: {queenCaptures?.Count}");

            for (int i = 0; i < queenCaptures?.Count; i++)
            {
                foreach (var position in queenCaptures.ToList()[i])
                {
                    Console.WriteLine($"Queen available capture moves: {position.X}, {position.Y}");
                }
            }
        }
    }
}