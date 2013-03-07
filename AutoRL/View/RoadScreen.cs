using ConsoleLib;
using ConsoleLib.Widget;

namespace AutoRL
{
    public class RoadScreen : HorizontalComposite
    {

         public RoadScreen(Composite parent)
            : base(parent)
        {

            var RoadDisplayControl = new RoadDisplayControl(this);

            AddControl(RoadDisplayControl);
        }        
    }
}
