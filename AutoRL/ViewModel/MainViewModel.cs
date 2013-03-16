using System;
using ConsoleLib;

namespace AutoRL
{
    public class MainViewModel
    {
        Shell Shell { get; set; }

        public AutoGame AutoGame { get; set; }

        public MainScreen MainScreen { get; set; }
        public MainMenuViewModel MainMenuViewModel { get; set; }
        public AutoGameViewModel AutoGameViewModel { get; set; }

        public MainViewModel(Shell shell, AutoGame autoGame)
        {
            Shell = shell;

            AutoGame = autoGame;

            MainScreen = new MainScreen(Shell) { GrabHorizontal = true, GrabVertical = true };

            MainMenuViewModel = new MainMenuViewModel(this, MainScreen.MenuScreen);

            AutoGameViewModel = new AutoGameViewModel(this, MainScreen.AutoGameScreen);

            MainScreen.Bind(this);


            DisplayMainMenu();
        }


        public void Update(int duration)
        {            
            if (AutoGame.Road != null)
            {
                AutoGame.Update(duration);
            }

            AutoGameViewModel.Update(duration);

            if (AutoGame.EndGame)
            {
                MainMenuViewModel.EndGame();
                DisplayMainMenu();
            }

        }                

        public void Quit()
        {
            AutoGame.Complete = true;
        }

        public void CreateNewGame()
        {
            AutoGame.Initialize();
        }

        public void DisplayGame()
        {
            AutoGame.Pause = false;

            MainScreen.AutoGameScreen.SetEnabled(true);
            MainScreen.MenuScreen.SetEnabled(false);
        }

        public void DisplayMainMenu()
        {
            AutoGame.Pause = true;

            MainScreen.AutoGameScreen.SetEnabled(false);
            MainScreen.MenuScreen.SetEnabled(true);
        }
    }

    }
