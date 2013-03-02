using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    class AutoGame
    {
                public bool Pause { get; set; }

        public bool Complete { get; set; }

        public Road Road { get; set; }

        public AutoGame()
        {
            Pause = false;
            Complete = false;
        }

        public int Update(int duration)
        {
            if (Road != null)
            {
                if (!Pause)
                {
                    return Road.Update(duration);
                }
            } 

            return duration;
        }

    }
}
