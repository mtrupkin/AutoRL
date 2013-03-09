using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Car
    {
        public string Name { get; protected set; }
        public int Speed { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Car(String name)
        {
            Name = name;
            Speed = 1;
        }

        public void UpdatePhase(int phase)
        {
            Y += Speed;
        }
    }
}
