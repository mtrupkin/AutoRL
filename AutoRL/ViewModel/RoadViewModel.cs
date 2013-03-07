using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class RoadViewModel
    {
        public AutoGameViewModel AutoGameViewModel { get; set; }
        public RoadScreen RoadScreen { get; set; }

        public RoadViewModel(AutoGameViewModel autoGameViewModel) {
            AutoGameViewModel = autoGameViewModel;
        }

    }
}
