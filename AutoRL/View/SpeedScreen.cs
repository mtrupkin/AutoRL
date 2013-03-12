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
            var spacer1 = new SpacerWidget(this, 1, 1);
            var phaseLabel = new TextWidget(this, "Phase");

            PhaseControl = new PhaseControl(this) ;
            var phaseBox = new BoxWidget(PhaseControl);
            phaseBox.Compact();

            var spacer2 = new SpacerWidget(this, 1, 1);
            SpeedDisplay = new TextWidget(this, " Spd: 000 ");

            AddControl(spacer1);
            AddControl(phaseLabel, HorizontalJustify.Center);
            AddControl(phaseBox, HorizontalJustify.Center);
            AddControl(spacer2);
            AddControl(SpeedDisplay);
        }

        public void SetSpeed(int speed)
        {
            string str = String.Format(" Spd: {0,3} ", speed * 10);
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
