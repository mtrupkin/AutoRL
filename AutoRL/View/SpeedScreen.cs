using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLib;

namespace AutoRL
{
    public class SpeedScreen : VerticalComposite    
    {
        public PhaseControl PhaseControl { get; set; }

        public SpeedScreen(Composite parent)
            : base(parent)
        {
            PhaseControl = new PhaseControl(this);

            var box = new BoxWidget(PhaseControl);
            box.Compact();

            AddControl(box);
        }

        public void Bind(RoadViewModel roadViewModel)
        {
            
        }
    }
}
