using System;
using System.Collections.Generic;

using ConsoleLib;
using ConsoleLib.Widget;

namespace AutoRL
{
    public class MainMenuViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        public MenuScreen MenuScreen { get; set; }


        public MainMenuViewModel(MainViewModel mainViewModel, MenuScreen menuScreen)
        {
            MainViewModel = mainViewModel;
            MenuScreen = menuScreen;
            Initialize();
        }

        public void Initialize()
        {
            MenuScreen.NewListWidget.AddItem(new Option() { Name = " Create Game ", OptionHandler = NewGame });
            //MenuScreen.NewListWidget.AddItem(new Option() { Name = "Load Game", OptionHandler = LoadGame });
            MenuScreen.NewListWidget.AddItem(new Option() { Name = "Quit", OptionHandler = Quit });

            MenuScreen.ContinueListWidget.AddItem(new Option() { Name = " Continue Game ", OptionHandler = ContinueGame });
            MenuScreen.ContinueListWidget.AddItem(new Option() { Name = "Create Game", OptionHandler = NewGame });            
            //MenuScreen.ContinueListWidget.AddItem(new Option() { Name = "Load Game", OptionHandler = LoadGame });
            MenuScreen.ContinueListWidget.AddItem(new Option() { Name = "Quit", OptionHandler = Quit });

            MenuScreen.NewListWidget.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);
            MenuScreen.ContinueListWidget.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);

            MenuScreen.NewListWidget.SetEnabled(true);
            MenuScreen.ContinueListWidget.SetEnabled(false);

            MenuScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);
        }

        void KeyPressedEvent(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Escape:
                    Quit();
                    break;
            }
        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }

        // initialization for each new game
        public void CreateNewGame()
        {
            MenuScreen.NewListWidget.SetEnabled(false);
            MenuScreen.ContinueListWidget.SetEnabled(true);

            MainViewModel.CreateNewGame();

        }

        public void EndGame()
        {
            MenuScreen.NewListWidget.SetEnabled(true);
            MenuScreen.ContinueListWidget.SetEnabled(false);

        }

        public AutoGame LoadGameFile(String filename)
        {
            return null;
        }

        public void SaveGameFile(AutoGame autoGame)
        {
        }

        public void NewGame()
        {
            CreateNewGame();
            MainViewModel.DisplayGame();
            //FlagshipGameViewModel.DisplayGame(); 
        }

        public void ContinueGame()
        {
            MainViewModel.DisplayGame();
            //FlagshipGameViewModel.DisplayGame();
        }

        public void LoadGame()
        {
            CreateNewGame();
            //FlagshipGameViewModel.DisplayGame(); 
        }

        public void Quit()
        {
            MainViewModel.Quit();
            //FlagshipGameViewModel.Quit();
            //FlagshipGameViewModel.Complete = true;
        }
    }
}
