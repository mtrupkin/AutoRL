using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class AutoGameViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        public AutoGameScreen AutoGameScreen { get; set; }

        public AutoGameViewModel(MainViewModel mainViewModel, AutoGameScreen autoGameScreen)
        {
            MainViewModel = mainViewModel;
            AutoGameScreen = autoGameScreen;
        }

    }

  }
