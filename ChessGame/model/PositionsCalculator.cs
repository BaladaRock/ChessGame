using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Linq.Enumerable;


namespace ChessGame.model
{
    public static class PositionsCalculator
    {
        public static int BoardSize { get; set; }

        public static IEnumerable<Position> GetLowerLeftDiagonal(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(0, currentX).Reverse())
               : Empty<Position>();
        }
        public static IEnumerable<Position> GetLowerRightDiagonal(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(currentX + 1, BoardSize - currentX - 1))
               : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperLeftDiagonal(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
              ? GetDiagonal(currentY, Range(0, currentX).Reverse(), -1)
              : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperRightDiagonal(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(currentX + 1, BoardSize - currentX - 1), -1)
               : Empty<Position>();
        }

        public static IEnumerable<Position> GetLeftLine(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetLine(currentY, Range(0, currentX).Reverse())
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetRightLine(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetLine(currentY, Range(currentX + 1, BoardSize - currentX - 1))
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperColumn(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetColumn(currentX, Range(0, currentY).Reverse())
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetLowerColumn(int currentX, int currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetColumn(currentX, Range(currentY + 1, BoardSize - currentY - 1))
                : Empty<Position>();
        }

        private static IEnumerable<Position> GetColumn(int incrementX, IEnumerable<int> positionsRange)
        {
            return positionsRange.Select(element => new Position(incrementX, element));
        }

        private static IEnumerable<Position> GetLine(int incrementY, IEnumerable<int> positionsRange)
        {
            return positionsRange.Select(element => new Position(element, incrementY));
        }

        private static IEnumerable<Position> GetDiagonal(int incrementY, IEnumerable<int> positionsRange, short reverse = 1)
        {
            return positionsRange.Select((element, index) => new Position(element, incrementY + (index * reverse) + reverse))
                        .TakeWhile(position => CheckSizes(position.X, position.Y));
        }

        private static bool CheckSizes(int xPosition, int yPosition)
        {
            return (xPosition >= 0 && xPosition < BoardSize)
                && (yPosition >= 0 && yPosition < BoardSize);
        }
    }
}