using System;

namespace ChessGame.Model
{
    public struct Position: IEquatable<Position>
    {
        public byte X { get; }

        public byte Y { get; }

        public Position(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}