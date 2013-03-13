using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Dice
    {
        public static Random RND = new Random();

        public static int D6()
        {
            return RND.Next(6) + 1;            
        }

        public static int D100()
        {
            return RND.Next(100) + 1;            
        }

        public static int D6(int num)
        {
            int sum = 0;

            for (int i = 0; i < num; i++)
            {
                sum += D6();
            }

            return sum;
            
        }

    }
}
