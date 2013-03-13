using ConsoleLib;
using ConsoleLib.Widget;

namespace AutoRL
{
    public class RoadScreen : VerticalComposite
    {
        public RoadDisplayControl RoadDisplayControl { get; set; }
        
        public RoadScreen(Composite parent)
            : base(parent)
        {

            RoadDisplayControl = new RoadDisplayControl(this);
            RoadDisplayControl.Resize(80, 60);

            //var boxWidget = new BoxWidget(RoadDisplayControl);
            //boxWidget.Compact();

            AddControl(RoadDisplayControl);
        }

        public void Bind(RoadViewModel roadViewModel)
        {
            RoadDisplayControl.Road = roadViewModel.Road;
        }
    }
}
