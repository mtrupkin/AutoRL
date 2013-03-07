using ConsoleLib;
using ConsoleLib.Widget;

namespace AutoRL
{
    public class RoadScreen : HorizontalComposite
    {

         public RoadScreen(Composite parent)
            : base(parent)
        {

            var EntityDisplayControl = new EntityDisplayControl(this);

            AddControl(EntityDisplayControl);
        }        
    }
}
