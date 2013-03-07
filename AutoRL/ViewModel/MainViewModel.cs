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

        public MainViewModel(Shell shell)
        {
            Shell = shell;
     
            MainScreen = new MainScreen(Shell) { GrabHorizontal = true, GrabVertical = true };

            MainMenuViewModel = new MainMenuViewModel(this, MainScreen.MenuScreen);

            AutoGameViewModel = new AutoGameViewModel(this, MainScreen.AutoGameScreen);

            DisplayMainMenu();
        }

        public void Update(int duration)
        {            
            if (AutoGame.Road != null)
            {
                AutoGame.Update(duration);
            }
        }                

        public void Quit()
        {
            AutoGame.Complete = true;
        }

        public void CreateNewGame()
        {
            AutoGame = new AutoGame();            
        }

        public void DisplayGame()
        {
            MainScreen.AutoGameScreen.SetEnabled(true);
            MainScreen.MenuScreen.SetEnabled(false);
        }

        public void DisplayMainMenu()
        {
            MainScreen.AutoGameScreen.SetEnabled(false);
            MainScreen.MenuScreen.SetEnabled(true);
        }
    }

    }
