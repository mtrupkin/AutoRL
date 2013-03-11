
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
            SpeedScreen = new SpeedScreen(this) { GrabHorizontal = false, GrabVertical = true };
            //var speedBox = new BoxWidget(SpeedScreen);
            //speedBox.Compact();

            RoadScreen = new RoadScreen(this) { GrabHorizontal = true, GrabVertical = true };
            var roadBox = new BoxWidget(RoadScreen);
            roadBox.Compact();

            AddControl(SpeedScreen);
            AddControl(roadBox);
            
        }

        public void Bind(AutoGameViewModel autoGameViewModel)
        {
            RoadScreen.Bind(autoGameViewModel.RoadViewModel);
        }

    }
}
