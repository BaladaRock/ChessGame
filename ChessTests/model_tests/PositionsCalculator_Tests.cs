using ChessGame.Model;

namespace ChessTests.Model
{
    public class PositionsCalculator_Tests
    {
        [Fact]
        public void Test_Positions_Lower_Column_Small_Size()
        {
            // Assert
            byte boardSize = 4;
            byte x = 2;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Column_Bigger_Size()
        {
            // Assert
            byte boardSize = 14;
            byte x = 2;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3),
                   new Position(2, 4),
                   new Position(2, 5),
                   new Position(2, 6),
                   new Position(2, 7),
                   new Position(2, 8),
                   new Position(2, 9),
                   new Position(2, 10),
                   new Position(2, 11),
                   new Position(2, 12),
                   new Position(2, 13)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Column_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Column_Should_Return_Empty_No_Position_Available()
        {
            // Assert
            byte boardSize = 5;
            byte x = 3;
            byte y = 4;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Column_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 3;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 4)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Column_Small_Size()
        {
            // Assert
            byte boardSize = 8;
            byte x = 7;
            byte y = 7;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(7, 6),
                   new Position(7, 5),
                   new Position(7, 4),
                   new Position(7, 3),
                   new Position(7, 2),
                   new Position(7, 1),
                   new Position(7, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Column_Bigger_Size()
        {
            // Assert
            byte boardSize = 14;
            byte x = 12;
            byte y = 12;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(12, 11),
                   new Position(12, 10),
                   new Position(12, 9),
                   new Position(12, 8),
                   new Position(12, 7),
                   new Position(12, 6),
                   new Position(12, 5),
                   new Position(12, 4),
                   new Position(12, 3),
                   new Position(12, 2),
                   new Position(12, 1),
                   new Position(12, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Column_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 0;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Column_Should_Return_Empty_No_Position_Available()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Column_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 1;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Left_Line_Small_Size()
        {
            // Assert
            byte boardSize = 4;
            byte x = 3;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 2),
                   new Position(1, 2),
                   new Position(0, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Left_Line_Bigger_Size()
        {
            // Assert
            byte boardSize = 14;
            byte x = 12;
            byte y = 13;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(11, 13),
                   new Position(10, 13),
                   new Position(9, 13),
                   new Position(8, 13),
                   new Position(7, 13),
                   new Position(6, 13),
                   new Position(5, 13),
                   new Position(4, 13),
                   new Position(3, 13),
                   new Position(2, 13),
                   new Position(1, 13),
                   new Position(0, 13)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Left_Line_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Left_Line_Should_Return_Empty_No_Position_Available()
        {
            // Assert
            byte boardSize = 5;
            byte x = 0;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Left_Line_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(0, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Right_Line_Small_Size()
        {
            // Assert
            byte boardSize = 4;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 2),
                   new Position(3, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Right_Line_Bigger_Size()
        {
            // Assert
            byte boardSize = 14;
            byte x = 1;
            byte y = 12;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 12),
                   new Position(3, 12),
                   new Position(4, 12),
                   new Position(5, 12),
                   new Position(6, 12),
                   new Position(7, 12),
                   new Position(8, 12),
                   new Position(9, 12),
                   new Position(10, 12),
                   new Position(11, 12),
                   new Position(12, 12),
                   new Position(13, 12)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Right_Line_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Right_Line_Should_Return_Empty_No_Position_Available()
        {
            // Assert
            byte boardSize = 5;
            byte x = 4;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Right_Line_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Small_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3),
                   new Position(3, 4)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Bigger_Size()
        {
            // Assert
            byte boardSize = 10;
            byte x = 0;
            byte y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(1, 1),
                   new Position(2, 2),
                   new Position(3, 3),
                   new Position(4, 4),
                   new Position(5, 5),
                   new Position(6, 6),
                   new Position(7, 7),
                   new Position(8, 8),
                   new Position(9, 9)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 1;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Should_Return_Empty_Edge_Case_X()
        {
            // Assert
            byte boardSize = 5;
            byte x = 4;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Should_Return_Empty_Edge_Case_Y()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Small_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(1, 3),
                   new Position(0, 4)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Bigger_Size()
        {
            // Assert
            byte boardSize = 10;
            byte x = 9;
            byte y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(8, 1),
                   new Position(7, 2),
                   new Position(6, 3),
                   new Position(5, 4),
                   new Position(4, 5),
                   new Position(3, 6),
                   new Position(2, 7),
                   new Position(1, 8),
                   new Position(0, 9)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 1;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(0, 2)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Should_Return_Empty_Edge_Case_X()
        {
            // Assert
            byte boardSize = 5;
            byte x = 0;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Should_Return_Empty_Edge_Case_Y()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Small_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(3, 1),
                   new Position(4, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Bigger_Size()
        {
            // Assert
            byte boardSize = 10;
            byte x = 0;
            byte y = 9;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(1, 8),
                   new Position(2, 7),
                   new Position(3, 6),
                   new Position(4, 5),
                   new Position(5, 4),
                   new Position(6, 3),
                   new Position(7, 2),
                   new Position(8, 1),
                   new Position(9, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 1;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Should_Return_Empty_Edge_Case_X()
        {
            // Assert
            byte boardSize = 5;
            byte x = 4;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Should_Return_Empty_Edge_Case_Y()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Small_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 2;
            byte y = 3;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(1, 2),
                   new Position(0, 1)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Bigger_Size()
        {
            // Assert
            byte boardSize = 10;
            byte x = 9;
            byte y = 8;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(8, 7),
                   new Position(7, 6),
                   new Position(6, 5),
                   new Position(5, 4),
                   new Position(4, 3),
                   new Position(3, 2),
                   new Position(2, 1),
                   new Position(1, 0),
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Element_Exceeds_Max_Size()
        {
            // Assert
            byte boardSize = 5;
            byte x = 5;
            byte y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Should_Return_Single_Possition_Edge_Case()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 1;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(0, 0)
                 }, positions
            );
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Should_Return_Empty_Edge_Case_X()
        {
            // Assert
            byte boardSize = 5;
            byte x = 0;
            byte y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Should_Return_Empty_Edge_Case_Y()
        {
            // Assert
            byte boardSize = 3;
            byte x = 1;
            byte y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

    }
}