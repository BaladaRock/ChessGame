using ChessGame.model;

namespace ChessTests.model
{
    public class PositionsCalculator_Tests
    {
        [Fact]
        public void Test_Positions_Lower_Column_Small_Size()
        {
            // Assert
            int boardSize = 4;
            int x = 2;
            int y = 2;

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
            int boardSize = 14;
            int x = 2;
            int y = 2;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

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
            int boardSize = 5;
            int x = 3;
            int y = 4;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Lower_Column_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 5;
            int x = 2;
            int y = 3;

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
            int boardSize = 8;
            int x = 7;
            int y = 7;

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
            int boardSize = 14;
            int x = 12;
            int y = 12;

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
            int boardSize = 5;
            int x = 0;
            int y = 5;

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
            int boardSize = 5;
            int x = 2;
            int y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperColumn(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Upper_Column_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 5;
            int x = 2;
            int y = 1;

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
            int boardSize = 4;
            int x = 3;
            int y = 2;

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
            int boardSize = 14;
            int x = 12;
            int y = 13;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

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
            int boardSize = 5;
            int x = 0;
            int y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLeftLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Left_Line_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 2;

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
            int boardSize = 4;
            int x = 1;
            int y = 2;

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
            int boardSize = 14;
            int x = 1;
            int y = 12;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

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
            int boardSize = 5;
            int x = 4;
            int y = 2;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetRightLine(x, y);

            // Act
            Assert.Empty(positions);
        }

        [Fact]
        public void Test_Positions_Right_Line_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 2;

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
            int boardSize = 5;
            int x = 1;
            int y = 2;

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
            int boardSize = 10;
            int x = 0;
            int y = 0;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }


        [Fact]
        public void Test_Positions_Lower_Right_Diagonal_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 1;

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
            int boardSize = 5;
            int x = 4;
            int y = 2;

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
            int boardSize = 3;
            int x = 1;
            int y = 2;

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
            int boardSize = 5;
            int x = 2;
            int y = 2;

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
            int boardSize = 10;
            int x = 9;
            int y = 0;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetLowerLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }


        [Fact]
        public void Test_Positions_Lower_Left_Diagonal_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 1;

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
            int boardSize = 5;
            int x = 0;
            int y = 2;

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
            int boardSize = 3;
            int x = 1;
            int y = 2;

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
            int boardSize = 5;
            int x = 2;
            int y = 2;

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
            int boardSize = 10;
            int x = 0;
            int y = 9;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperRightDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }


        [Fact]
        public void Test_Positions_Upper_Right_Diagonal_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 1;

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
            int boardSize = 5;
            int x = 4;
            int y = 2;

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
            int boardSize = 3;
            int x = 1;
            int y = 0;

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
            int boardSize = 5;
            int x = 2;
            int y = 3;

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
            int boardSize = 10;
            int x = 9;
            int y = 8;

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
            int boardSize = 5;
            int x = 5;
            int y = 5;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }


        [Fact]
        public void Test_Positions_Upper_Left_Diagonal_Should_Return_Empty_For_Negative_Values()
        {
            // Assert
            int boardSize = 5;
            int x = -2;
            int y = -3;

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
            int boardSize = 3;
            int x = 1;
            int y = 1;

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
            int boardSize = 5;
            int x = 0;
            int y = 2;

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
            int boardSize = 3;
            int x = 1;
            int y = 0;

            // Arrange
            PositionsCalculator.BoardSize = boardSize;
            var positions = PositionsCalculator.GetUpperLeftDiagonal(x, y);

            // Act
            Assert.Empty(positions);
        }

    }
}