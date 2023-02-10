using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Linq.Enumerable;


namespace ChessGame.Model
{
    public static class PositionsCalculator
    {
        public static byte BoardSize { get; set; }

        public static IEnumerable<Position> GetLowerLeftDiagonal(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(0, currentX).Reverse())
               : Empty<Position>();
        }
        public static IEnumerable<Position> GetLowerRightDiagonal(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(currentX + 1, BoardSize - currentX - 1))
               : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperLeftDiagonal(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
              ? GetDiagonal(currentY, Range(0, currentX).Reverse(), -1)
              : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperRightDiagonal(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
               ? GetDiagonal(currentY, Range(currentX + 1, BoardSize - currentX - 1), -1)
               : Empty<Position>();
        }

        public static IEnumerable<Position> GetLeftLine(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetLine(currentY, Range(0, currentX).Reverse())
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetRightLine(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetLine(currentY, Range(currentX + 1, BoardSize - currentX - 1))
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetUpperColumn(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetColumn(currentX, Range(0, currentY).Reverse())
                : Empty<Position>();
        }

        public static IEnumerable<Position> GetLowerColumn(byte currentX, byte currentY)
        {
            return CheckSizes(currentX, currentY)
                ? GetColumn(currentX, Range(currentY + 1, BoardSize - currentY - 1))
                : Empty<Position>();
        }

        private static IEnumerable<Position> GetColumn(byte incrementX, IEnumerable<int> positionsRange)
        {
            return positionsRange.Select(element => new Position(incrementX, (byte)element));
        }

        private static IEnumerable<Position> GetLine(byte incrementY, IEnumerable<int> positionsRange)
        {
            return positionsRange.Select(element => new Position((byte)element, incrementY));
        }

        private static IEnumerable<Position> GetDiagonal(byte incrementY, IEnumerable<int> positionsRange, sbyte reverse = 1)
        {
            return positionsRange.Select((element, index) =>
                        new Position((byte)element, (byte)(incrementY + (index * reverse) + reverse)))
                                .TakeWhile(position => CheckSizes(position.X, position.Y));
        }

        private static bool CheckSizes(byte xPosition, byte yPosition)
        {
            return (xPosition >= 0 && xPosition < BoardSize)
                && (yPosition >= 0 && yPosition < BoardSize);
        }
    }
}