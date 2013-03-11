using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Car
    {
        public int MaxSpeed { get; protected set; }
        public string Name { get; protected set; }
        public int Speed { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Car(String name)
        {
            Name = name;
            Speed = 7;
            MaxSpeed = 10;
        }

        public void UpdatePhase(int phase)
        {
            if (AutoGame.ManditoryMovementPhase(phase, Speed))
            {
                Y += 1;
            }
        }

        public bool Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Forwards:
                    Y += 1;
                    break;
                case Direction.Backwards:
                    Y -= 1;
                    break;
                case Direction.Left:
                    X -= 1;
                    break;
                case Direction.Right:
                    X += 1;
                    break;
            }
            return true;
        }

        public bool Accelerate()
        {
            if (Speed < MaxSpeed)
            {
                Speed += 1;
                return true;
            }
            return false;
        }

        public bool Decelerate()
        {
            if (Speed > 0)
            {
                Speed -= 1;
                return true;
            }
            return false;
        }

        public bool Decelerate2()
        {
            var ok = Decelerate();
            Decelerate();
            return ok;
        }
    }
}
