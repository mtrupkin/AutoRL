using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
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

            CurrentPhase = 1;
            MaxPhase = 5;

            Road = new Road(new Car("Mad Max"));
        }

        public void Initialize()
        {
            Road.Initialize();
        }

        int step = 0;

        public int Update(int duration)
        {
            if (Road != null)
            {
                if (!Pause)
                {
                    step += duration;

                    if (step > 1000 )
                    {
                        step -= 1000;
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
                CurrentPhase = 1;
            }

            Road.UpdatePhase(CurrentPhase);
        }



    }
}
