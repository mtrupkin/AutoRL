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
                case ConsoleKey.A:
                    Accelerate();
                    break;
                case ConsoleKey.Z:
                    Decelerate();
                    break;
                case ConsoleKey.X:
                    Decelerate2();
                    break;
                case ConsoleKey.LeftArrow:
                    Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Move(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                    Move(Direction.Forwards);
                    break;
                case ConsoleKey.DownArrow:
                    Move(Direction.Backwards);
                    break;

            }
        }

        public void Move(Direction direction) 
        {
            MainViewModel.AutoGame.Road.Player.Move(direction);
            MainViewModel.AutoGame.NextPhase();
        }


        public void Accelerate()
        {
            bool ok = MainViewModel.AutoGame.Road.Player.Accelerate();

            if (ok)
            {
                MainViewModel.AutoGame.NextPhase();
            }
        }

        public void Decelerate()
        {
            bool ok = MainViewModel.AutoGame.Road.Player.Decelerate();
            if (ok)
            {
                MainViewModel.AutoGame.NextPhase();
            }
        }

        public void Decelerate2()
        {
            bool ok = MainViewModel.AutoGame.Road.Player.Decelerate2();
            if (ok)
            {
                MainViewModel.AutoGame.NextPhase();
            }
        }

        public void TogglePause()
        {
            MainViewModel.AutoGame.Pause = !MainViewModel.AutoGame.Pause;
        }

        public void Update(int duration)
        {
            AutoGameScreen.SpeedScreen.PhaseControl.CurrentPhase = MainViewModel.AutoGame.CurrentPhase;
            AutoGameScreen.SpeedScreen.SetSpeed(MainViewModel.AutoGame.Road.Player.Speed);                        
        }         
    }

  }
