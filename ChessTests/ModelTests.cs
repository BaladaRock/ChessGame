using ChessGame.model;

namespace ChessTests
{
    public class ModelTests
    {
        [Fact]
        public void Test_Lower_Column_Small_Size()
        {
            // Assert
            int boardSize = 4;
            int x = 2;
            int y = 2;
            // Arrange
            var positions = PositionsCalculator.GetLowerColumn(boardSize, x, y);

            // Act
            Assert.Equal(
                 new[] {
                   new Position(2, 3)
                 }, positions
            );
        }
    }
}