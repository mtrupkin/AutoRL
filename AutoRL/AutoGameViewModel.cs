using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    class AutoGameViewModel
    {
        public AutoGame AutoGame { get; set; }

        public AutoGameScreen AutoGameScreen { get; set; }

        public MainScreenViewModel MainScreenViewModel { get; set; }
        public RoadScreenViewModel RoadScreenViewModel { get; set; }

        public void Initialize()
        {
            MainScreenViewModel = new MainScreenViewModel()
            {
                MainScreen = AutoGameScreen.MainScreen,
                FlagshipGameViewModel = this,
            };
            MainScreenViewModel.Initialize();

            RoadScreenViewModel = new RoadScreenViewModel()
            {
                RoadScreen = AutoGameScreen.RoadScreen,
                AutoGameViewModel = this,
            };
            RoadScreenViewModel.Initialize();

            DisplayMainMenu();
        }

        public void Update(int duration)
        {            
            if (AutoGame.Road != null)
            {
                AutoGame.Update(duration);
                RoadScreenViewModel.SetTime(TimeSpan.FromMilliseconds(AutoGame.Road.Time));
            }
        }                

        public void Quit()
        {
            AutoGame.Complete = true;
        }

        public void DisplayGame()
        {
            FlagshipGameScreen.GalaxyScreen.SetEnabled(true);
            FlagshipGameScreen.MainScreen.SetEnabled(false);

            GalaxyScreenViewModel.SetFlagshipGame(FlagshipGame);           
        }

        public void DisplayMainMenu()
        {
            FlagshipGameScreen.GalaxyScreen.SetEnabled(false);
            FlagshipGameScreen.MainScreen.SetEnabled(true);
        }
    }

    }
