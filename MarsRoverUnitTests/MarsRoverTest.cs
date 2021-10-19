using System.Collections.Generic;
using MarsRover;
using Xunit;

namespace MarsRoverUnitTests
{
    public class MarsRoverTest
    {
        [Fact]
        public void TurnLeft()
        {
            Movements movements = new Movements("1 2 N");

            movements.TurnLeft();

            Assert.Equal("W", movements.Direction.ToString());
        }

        [Fact]
        public void TurnRight()
        {
            Movements movements = new Movements("1 2 N");

            movements.TurnRight();

            Assert.Equal("E", movements.Direction.ToString());
        }

        [Fact]
        public void MoveOnePoint()
        {
            Movements movements = new Movements("1 2 N");

            movements.MoveOnePoint();

            Assert.Equal(3, movements.Y);
        }

        [Fact]
        public void Move()
        {
            Movements movements = new Movements("1 2 N");
            List<int> area = new List<int>
            {
                5,
                5
            };

            movements.Move(area, "LMLMLMLMM");

            Assert.Equal("1 3 N", movements.X + " " + movements.Y + " " + movements.Direction);
        }
    }
}
