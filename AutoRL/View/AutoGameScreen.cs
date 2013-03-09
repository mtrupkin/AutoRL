
using ConsoleLib;

namespace AutoRL
{
    public class AutoGameScreen : HorizontalComposite
    {
        public SpeedScreen SpeedScreen { get; set; }
        public RoadScreen RoadScreen { get; set; }        

        public AutoGameScreen(Composite parent)
            : base(parent)
        {

            SpeedScreen = new SpeedScreen(parent) { GrabHorizontal = false, GrabVertical = true };
            RoadScreen = new RoadScreen(parent) { GrabHorizontal = true, GrabVertical = true };

            AddControl(SpeedScreen);
            AddControl(RoadScreen);
        }

        public void Bind(AutoGameViewModel autoGameViewModel)
        {
            RoadScreen.Bind(autoGameViewModel.RoadViewModel);
        }

    }
}
