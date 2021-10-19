using System.Collections.Generic;

namespace MarsRover
{
    public abstract class RoverPosition
    {
        public abstract void TurnLeft();
        public abstract void TurnRight();
        public abstract void MoveOnePoint();
        public abstract void Move(List<int> locationPoints, string moves);
    }
}
