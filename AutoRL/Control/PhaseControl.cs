using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLib;

namespace AutoRL
{
    public class PhaseControl : ControlBase
    {
        public int CurrentPhase { get; set; }
        public int MaxPhases = 10;

        public int Speed { get; set; }

        public PhaseControl(Composite parent)
            : base(parent)
        {
            Height = MaxPhases * 2 + 1;
            Width = 3;

            CurrentPhase = 1;

            Resize(Width, Height);
        }

        public override void Render()
        {            

            for (int i = 0; i < MaxPhases; i++)
            {

                Screen.BackgroundColor = ConsoleRGB.Black;
                Screen.ForegroundColor = ConsoleRGB.Black;
                DrawBox(i);

                if (AutoGame.ManditoryMovementPhase(i, Speed))
                {
                    Screen.BackgroundColor = ConsoleRGB.Base3;
                    Screen.ForegroundColor = ConsoleRGB.Base03; 
                }
                else
                {
                    Screen.BackgroundColor = ConsoleRGB.Black;
                    Screen.ForegroundColor = ConsoleRGB.Base3;
                }
                DrawPhase(i);
            }

            Screen.BackgroundColor = ConsoleRGB.Black;
            Screen.ForegroundColor = ConsoleRGB.Base0;
            DrawBox(CurrentPhase);
        }

        void DrawBox(int phase)
        {
            Screen.SetPosition(0, phase * 2);
            Screen.WriteFrame(3, 3);

        }

        void DrawPhase(int phase)
        {
            Screen.SetPosition(1, phase * 2 + 1);
            Screen.Write("" + phase);

        }

     


    }
}
