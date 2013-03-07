using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Road
    {
        public int this[int x, int y]    // Indexer declaration
        {
            get {return 0;}
        }

        public int Update(int duration)
        {
            return duration;
        }
    }
}
