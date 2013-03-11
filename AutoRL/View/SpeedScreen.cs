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
        TextWidget SpeedDisplay { get; set; }
        
        public SpeedScreen(Composite parent)
            : base(parent)
        {
            PhaseControl = new PhaseControl(this) ;
            var phaseBox = new BoxWidget(PhaseControl);
            phaseBox.Compact();

            var spacer = new SpacerWidget(this, 1, 1);
            SpeedDisplay = new TextWidget(this, "Spd: 100");

            AddControl(phaseBox, HorizontalJustify.Center);
            AddControl(spacer);
            AddControl(SpeedDisplay);
        }

        public void SetSpeed(int speed)
        {
            string str = String.Format("Spd: {0,3}", speed * 10);
            SpeedDisplay.SetText(str);

            PhaseControl.Speed = speed;
        }
/*
   PhaseControl = new PhaseControl(this);

            var box = new BoxWidget(PhaseControl);
            box.Compact();

            AddControl(box);
 */

        public void Bind(RoadViewModel roadViewModel)
        {
            
        }
    }
}
