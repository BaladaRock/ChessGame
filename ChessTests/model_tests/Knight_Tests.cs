using ChessGame.Model;

namespace ChessTests.Model
{
    public class Knight_Tests
    {
        const ColorType black = ColorType.black;
        const ColorType white = ColorType.white;

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Column_Normal_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 4));
            var positions = knightPiece.GetUpperColumn();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3)
                 }, positions
            );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Diagonal_Normal_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 4));
            var positions = knightPiece.GetUpperLeftDiagonal();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(3, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Diagonal_Should_Return_Null_Outside_of_Board()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(1, 1));
            var positions = knightPiece.GetUpperLeftDiagonal();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Lower_Right_Column_Edge_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(6, 0));
            var positions = knightPiece.GetLowerColumn();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(7, 2)
                 }, positions
            );
        }
    }
}
