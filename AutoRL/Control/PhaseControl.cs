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
        public int MaxPhase = 10;

        public PhaseControl(Composite parent)
            : base(parent)
        {
            Height = MaxPhase * 2 + 1;
            Width = 3;

            CurrentPhase = 1;

        }

        public override void Render()
        {
            Screen.ForegroundColor = ConsoleRGB.Base0;
            for (int i = 0; i < MaxPhase; i++)
            {
                if (i == CurrentPhase)
                {
                    Screen.BackgroundColor = ConsoleRGB.Base2;
                }
                else
                {
                    Screen.BackgroundColor = ConsoleRGB.Black;
                }
                Screen.SetPosition( 1, i * 2 - 1);
                
                Screen.Write("" + i);
            }
        }


    }
}
