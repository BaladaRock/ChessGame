using ChessGame.Model;

namespace ChessTests.Model
{
    public class Knight_Tests
    {
        const ColorType black = ColorType.black;

        // Test upper-left moves
        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Normal_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 4));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(3, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Should_Return_Empty_Knight_Is_On_First_Column()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(0, 4));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Should_Return_Empty_Knight_Is_On_First_Line()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(3, 0));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Should_Return_Empty_Knight_Is_On_Second_Line()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(3, 1));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Should_Return_Empty_Very_Small_Board()
        {
            // Assert
            byte boardSize = 3;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(2, 1));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Available_Position_Very_Small_Board()
        {
            // Assert
            byte boardSize = 3;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(2, 2));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Equal(
                new[] {
                   new Position(1, 0)
                }, positions
           );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_One_Column_Bigger_Size_Board()
        {
            // Assert
            byte boardSize = 155;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(140, 140));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Equal(
                new[] {
                   new Position(139, 138)
                }, positions
           );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Normal_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 4));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3)
                 }, positions
            );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Should_Return_Empty_Knight_Is_On_First_Line()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 0));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Should_Return_Empty_Knight_Is_On_Second_Line_And_Second_Column()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(1, 1));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Should_Return_Empty_Knight_Is_On_Second_Column()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(1, 3));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Should_Return_Empty_Very_Small_Board()
        {
            // Assert
            byte boardSize = 3;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(1, 2));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Available_Position_Very_Small_Board()
        {
            // Assert
            byte boardSize = 3;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(2, 2));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Equal(
                new[] {
                   new Position(0, 1)
                }, positions
           );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Left_Two_Column_Bigger_Size_Board()
        {
            // Assert
            byte boardSize = 156;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(140, 140));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Equal(
                new[] {
                   new Position(138, 139)
                }, positions
           );
        }

        // Test upper-right moves
        [Fact]
        public void Test_Knight_Moves_Upper_Right_One_Column_Normal_Case()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(4, 4));
            var positions = knightPiece.GetUpperRightOneColumnMovement();

            // Act
            Assert.Equal(
                 new[] {
                   new Position(5, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Right_One_Column_Should_Return_Empty_Knight_Is_On_First_Column()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(0, 4));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Right_One_Column_Should_Return_Empty_Knight_Is_On_First_Line()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(3, 0));
            var positions = knightPiece.GetUpperLeftTwoColumnMovement();

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Knight_Moves_Upper_Right_One_Column_Should_Return_Empty_Knight_Is_On_Second_Line()
        {
            // Assert
            byte boardSize = 8;
            var board = new ChessBoard(boardSize);
            var knightPiece = new Knight(black, boardSize);

            // Arrange
            knightPiece.OccupySquare(board.GetSquare(3, 1));
            var positions = knightPiece.GetUpperLeftOneColumnMovement();

            // Act
            Assert.Empty(positions);
        }
      
    }
}
