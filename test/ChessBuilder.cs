using ChessGame.model;
using System;

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

            //var whitePawn = new Pawn(ColorType.white);
            //var square = chessBoard.GetSquare(6, 6);
            //whitePawn.OccupySquare(square);

            //// Test pawn movement
            //whitePawn.MovePiece(chessBoard.GetSquare(6, 5));
            //var capturePositions = whitePawn.GetCapturePositions();
            //capturePositions.ForEach(x => Console.WriteLine(x));

            //// Test knight movement
            //var blackKnight = new Knight(ColorType.black);
            //var knightSquare = chessBoard.GetSquare(5, 4);
            //blackKnight.OccupySquare(knightSquare);

            //var knightMoves = blackKnight.GetAvailablePositions();
            //for (int i = 0; i < knightMoves.Count; i++)
            //{
            //    Console.WriteLine($"Knight available moves: {knightMoves[i]}");
            //}

            //var knightCaptures = blackKnight.GetCapturePositions();
            //for (int i = 0; i < knightCaptures.Count; i++)
            //{
            //    Console.WriteLine($"Knight available captures: {knightCaptures[i]}");
            //}

            //// Test bishop movement
            var whiteBishop = new Bishop(ColorType.white);
            var bishopSquare = chessBoard.GetSquare(4, 4);
            whiteBishop.OccupySquare(bishopSquare);

            // Lower left diagonal
            var bishopLowerLeft = whiteBishop.GetLowerLeftPositions();
            Console.WriteLine($"Count test: {bishopLowerLeft?.Count}");

            for (int i = 0; i < bishopLowerLeft?.Count; i++)
            {
                Console.WriteLine($"Bishop available moves low-left: {bishopLowerLeft[i]}");
            }
            // Upper left diagonal
            var bishopUpperLeft = whiteBishop.GetUpperLeftPositions();
            Console.WriteLine($"Count test: {bishopUpperLeft?.Count}");

            for (int i = 0; i < bishopUpperLeft?.Count; i++)
            {
                Console.WriteLine($"Bishop available moves up-left: {bishopUpperLeft[i]}");
            }
            // Lower right diagonal
            var bishopLowerRight = whiteBishop.GetLowerRightPositions();
            for (int i = 0; i < bishopLowerRight.Count; i++)
            {
                Console.WriteLine($"Bishop available moves low-right: {bishopLowerRight[i]}");
            }
            // Upper right diagonal
            var bishopUpperRight = whiteBishop.GetUpperRightPositions();
            for (int i = 0; i < bishopUpperRight.Count; i++)
            {
                Console.WriteLine($"Bishop available moves up-right: {bishopUpperRight[i]}");
            }

            // Test queen movement
            var whiteQueen = new Queen(ColorType.white);
            var queenSquare = chessBoard.GetSquare(4, 4);
            whiteQueen.OccupySquare(queenSquare);

            // Lower left diagonal
            var queenLowerLeft = whiteQueen.GetLowerLeftPositions();
            Console.WriteLine($"Count test: {queenLowerLeft?.Count}");

            for (int i = 0; i < queenLowerLeft?.Count; i++)
            {
                Console.WriteLine($"Queen available moves low-left: {queenLowerLeft[i]}");
            }
            // Upper left diagonal
            var queenUpperLeft = whiteQueen.GetUpperLeftPositions();
            Console.WriteLine($"Count test: {queenUpperLeft?.Count}");

            for (int i = 0; i < queenUpperLeft?.Count; i++)
            {
                Console.WriteLine($"Queen available moves up-left: {queenUpperLeft[i]}");
            }
            // Lower right diagonal
            var queenLowerRight = whiteQueen.GetLowerRightPositions();
            for (int i = 0; i < queenLowerRight.Count; i++)
            {
                Console.WriteLine($"Queen available moves low-right: {queenLowerRight[i]}");
            }
            // Upper right diagonal
            var queenUpperRight = whiteQueen.GetUpperRightPositions();
            for (int i = 0; i < queenUpperRight.Count; i++)
            {
                Console.WriteLine($"Queen available moves up-right: {queenUpperRight[i]}");
            }
        }
    }
}