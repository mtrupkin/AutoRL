
using ConsoleLib;

namespace AutoRL
{
    public class AutoGameScreen : StackedComposite
    {
        public RoadScreen RoadScreen { get; set; }

        public AutoGameScreen(Composite parent)
            : base(parent)
        {

            RoadScreen = new RoadScreen(parent) { GrabHorizontal = true, GrabVertical = false };

            AddControl(RoadScreen);
        }
    }
}
