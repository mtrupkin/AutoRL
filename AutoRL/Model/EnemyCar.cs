using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class EnemyCar : Car
    {
        public EnemyCar(String name)
            : base(name)
        {
            MaxSpeed = 7;
        }

        public override bool UpdatePhase(int phase)
        {
            var moved = base.UpdatePhase(phase);


            return moved;
        }

        public bool UpdatePhase(int phase, Car player )
        {
            var moved = UpdatePhase(phase);

            if (Distance2(player) < (50 * 50))
            {
                Accelerate();
                Turn(player);
            }
            return moved;
        }

        int Distance2(Car car)
        {
            int dx = (car.X1 - X1);
            int dy = (car.Y1 - Y1);

            return dx * dx + dy * dy;
        }

        void Turn(Car car)
        {
            int dx = (car.X1 - X1);
            int dy = (car.Y1 - Y1);

            double desiredHeading = Math.Atan2(dy, dx);

            double turnHeading = desiredHeading - Heading;

            Heading = desiredHeading;
        }

    }
}
