using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public enum Direction { Forwards, Backwards, Left, Right };

    public class AutoGame
    {
        public bool Pause { get; set; }

        public bool Complete { get; set; }

        public Road Road { get; set; }

        public int MaxPhase { get; protected set; }
        public int CurrentPhase { get; protected set; }

        public AutoGame()
        {
            Pause = true;
            Complete = false;

            CurrentPhase = 0;
            MaxPhase = 9;

            Road = new Road(new Car("Mad Max"));
        }

        public void Initialize()
        {
            Road.Initialize();
        }

        int step = 0;
        int timeStep = 5000;

        public int Update(int duration)
        {
            if (Road != null)
            {
                if (!Pause)
                {
                    step += duration;

                    if (step > timeStep)
                    {
                        step -= timeStep;
                        NextPhase();
                    }

                }
            } 

            return duration;
        }

        public void NextPhase()
        {
            CurrentPhase += 1;
            if (CurrentPhase > MaxPhase)
            {
                CurrentPhase = 0;
            }

            Road.UpdatePhase(CurrentPhase);
            step = 0;
        }

        static int[,] phases = new int[10, 10] {
//           0  1  2  3  4  5  6  7  8  9
            //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 0
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0}, // 1
            {0, 0, 0, 1, 0, 0, 0, 1, 0, 0}, // 2
            {0, 0, 1, 0, 0, 1, 0, 0, 1, 0}, // 3
            {0, 1, 0, 1, 0, 0, 1, 0, 1, 0}, // 4
            {0, 1, 0, 1, 0, 1, 0, 1, 0, 1}, // 5           
            {1, 0, 1, 0, 1, 0, 1, 0, 1, 1}, // 6
            {1, 0, 1, 0, 1, 1, 1, 0, 1, 1}, // 7
            {1, 0, 1, 1, 1, 1, 1, 0, 1, 1}, // 8
            {1, 0, 1, 1, 1, 1, 1, 1, 1, 1}, // 9
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 10
        };

        public static bool ManditoryMovementPhase(int phase, int speed)
        {
            if (speed > 0)
            {
                if (phases[speed - 1, phase] == 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
