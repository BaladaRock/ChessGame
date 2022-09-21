using System;
using System.Collections.Generic;

namespace ChessGame.model
{
    public static class PositionsCalculator
    {
        internal static IEnumerable<Position> GetLowerLeftDiagonal(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);
            for (var (x, y) = (currentX - 1, currentY + 1); (x >= 0 && y <= boardSize); x--, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public static IEnumerable<Position> GetUpperLeftDiagonal(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);
            for (var (x, y) = (currentX - 1, currentY - 1); (x >= 0 && y >= 0); x--, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public static IEnumerable<Position> GetLowerRightDiagonal(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);
            for (var (x, y) = (currentX + 1, currentY + 1); (x <= boardSize && y <= boardSize); x++, y++)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public static IEnumerable<Position> GetUpperRightDiagonal(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);
            for (var (x, y) = (currentX + 1, currentY - 1); (x <= boardSize && y >= 0); x++, y--)
            {
                positions.Add(new Position(x, y));
            }

            return positions;
        }

        public static IEnumerable<Position> GetLeftLine(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);
            for (int i = currentX - 1; i >= 0; i--)
            {
                positions.Add(new Position(i, currentY));
            }

            return positions;
        }

        public static IEnumerable<Position> GetRightLine(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);

            for (int i = currentX + 1; i <= boardSize; i++)
            {
                positions.Add(new Position(i, currentY));
            }

            return positions;
        }

        public static IEnumerable<Position> GetUpperColumn(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);

            for (int i = currentY - 1; i >= 0; i--)
            {
                positions.Add(new Position(currentX, i));
            }

            return positions;
        }

        public static IEnumerable<Position> GetLowerColumn(int boardSize, int currentX, int currentY)
        {
            var positions = new List<Position>(boardSize);

            for (int i = currentY + 1; i < boardSize; i++)
            {
                positions.Add(new Position(currentX, i));
            }

            return positions;
        }
    }
}