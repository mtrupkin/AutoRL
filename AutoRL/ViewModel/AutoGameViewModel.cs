using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLib;

namespace AutoRL
{
    public class AutoGameViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        public AutoGameScreen AutoGameScreen { get; set; }
        public RoadViewModel RoadViewModel { get; set; }

        

        public AutoGameViewModel(MainViewModel mainViewModel, AutoGameScreen autoGameScreen)
        {
            MainViewModel = mainViewModel;
            AutoGameScreen = autoGameScreen;

            RoadViewModel = new RoadViewModel(this);

            AutoGameScreen.KeyPressEvent += KeyPressedEvent;


        }

        void KeyPressedEvent(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Escape:
                    MainViewModel.DisplayMainMenu();
                    break;
                case ConsoleKey.Tab:
                    //ToggleView();
                    break;
                case ConsoleKey.Spacebar:
                    TogglePause();
                    break;

            }
        }

        public void TogglePause()
        {
            MainViewModel.AutoGame.Pause = !MainViewModel.AutoGame.Pause;
        }

        public void Update(int duration)
        {
            AutoGameScreen.SpeedScreen.PhaseControl.CurrentPhase = MainViewModel.AutoGame.CurrentPhase;
        }         
    }

  }
