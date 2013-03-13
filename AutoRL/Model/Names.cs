using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Names
    {
        static string[] NameList = { "X", "Y", "Charlie", "Jack", "Harry", "Noah", "Oliver", "Thomas", "William", "Joshua", "Daniel", "Billy" };

        public static String GenerateName()
        {
            int count = NameList.Count();

            int index = Dice.RND.Next(count);

            return NameList[index];
        }
    }
}
