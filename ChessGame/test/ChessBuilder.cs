using ChessGame.model;
using System;
using System.Diagnostics;
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
            // Test which version of PositionsCalculator is more time efficient
            PositionsCalculator.BoardSize = 8;
            var testOld = new Stopwatch();

            for (int x = 0; x < 50; x++)
            {
                testOld.Start();
                for (int i = 0; i < 5000000; i++)
                {
                    var randomGenerator = new Random();
                    byte xCoord = (byte)randomGenerator.Next(0, 7);
                    byte yCoord = (byte)randomGenerator.Next(0, 7);

                    PositionsCalculator.GetLeftLine(xCoord, yCoord);
                    PositionsCalculator.GetRightLine(xCoord, yCoord);
                    PositionsCalculator.GetUpperColumn(xCoord, yCoord);
                    PositionsCalculator.GetLowerColumn(xCoord, yCoord);
                    PositionsCalculator.GetLowerLeftDiagonal(xCoord, yCoord);
                    PositionsCalculator.GetLowerRightDiagonal(xCoord, yCoord);
                    PositionsCalculator.GetUpperLeftDiagonal(xCoord, yCoord);
                    PositionsCalculator.GetUpperRightDiagonal(xCoord, yCoord);
                }


                testOld.Stop();

                Console.WriteLine("Execution time: {0}", testOld.Elapsed);
                testOld.Reset();
            }

            // Results per 1 million values
            // Execution time: < 1.5 sec for linq implementation
            // Execution time: ~ 2 secs for iterative implementation

        }
    }
}