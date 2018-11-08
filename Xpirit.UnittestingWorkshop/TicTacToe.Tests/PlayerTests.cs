using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TicTacToe.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void CreatingAPlayer_WhenPlayerIsNew_ThenNumberOfMovesShouldBe0()
        {
            // Arrange
            var name = string.Empty;
            var mark = default(char);
            const int expectedNumberOfMoves = 0;
            
            // Act
            var player = new Player(name, mark);

            // Assert
            Assert.Equal(expectedNumberOfMoves, player.NumberOfMoves);
        }

        [Fact]
        public void CreatingAPlayer_WhenPlayerIsNew_ThenNameAndMarkShouldBeSet()
        {
            // Arrange
            var name = "Bob";
            var mark = 'X';

            // Act
            var player = new Player(name, mark);

            // Assert
            Assert.Equal(name, player.Name);
            Assert.Equal(mark, player.Mark);

        }

        [Fact]
        public void MovePlayer_WhenPlayerMakesFirstMove_ThenNumberOfMovesShouldBe1()
        {
            // Arrange
            const int expectedNumberOfMOves = 1;
            var name = "Bob";
            var mark = 'X';

            var player = new Player(name, mark);

            // Act
            player.Move();

            // Assert
            Assert.Equal(expectedNumberOfMOves, player.NumberOfMoves);
        }
    }
}
