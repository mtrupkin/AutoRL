
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Libtcod;
using ConsoleLib;
using System.Timers;

namespace AutoRL
{
    //
    // Main class for running game
    //
    class AutoRL
    {
        Shell Shell { get; set; }

        AutoGame AutoGame { get; set; }
        MainViewModel MainViewModel { get; set; }

        System.Timers.Timer updateTimer;
        DateTime lastUpdateTime;
        TimeSpan updateTimeSpan = new TimeSpan(0, 0, 0, 0, 10);

        DateTime lastDrawTime;        
        TimeSpan drawTimeSpan = new TimeSpan(0, 0, 0, 0, 25);

        bool Completed { get; set; }

        static void Main(string[] args)
        {
            AutoRL autoRL = new AutoRL();
            autoRL.Run();
        }

        private void Run()
        {
            // first time initialization
            Initialize();

            bool complete = false;
            // main loop
            do
            {
                Shell.Render();

                if (Shell.isClosed() || AutoGame.Complete)
                {
                    complete = true;
                }

            } while (!complete);
            
            Dispose();
        }

        // first time initialization
        private void Initialize()
        {
            Completed = false;

            // initialize game model
            AutoGame = new AutoGame();

            // intialize console
            Shell = new Libtcod.LibtcodShell("AutoRL", 160, 90);
            

            // initialize view model
            MainViewModel = new MainViewModel(Shell, AutoGame);

            Shell.AddControl(new LayoutData(MainViewModel.MainScreen));
            Shell.Resize();

            // intialize game update tick
            updateTimer = new Timer(100);
            updateTimer.Elapsed += new ElapsedEventHandler(updateTimer_Elapsed);
            updateTimer.Start();

            lastUpdateTime = DateTime.Now;
            lastDrawTime = DateTime.Now;
        }

        // clean-up
        private void Dispose()
        {
            updateTimer.Stop();

            Shell.Dispose();

            AutoGame.Complete = true;
        }

        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {            
            Update();
        }
        
        //
        private void Update()
        {
            TimeSpan lastUpdateTimeSpan = DateTime.Now.Subtract(lastUpdateTime);

            if (lastUpdateTimeSpan > updateTimeSpan)
            {
                MainViewModel.Update(lastUpdateTimeSpan.Milliseconds);

                lastUpdateTime = DateTime.Now;
            }
        }
    }
}
