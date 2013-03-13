
using ConsoleLib;

namespace AutoRL
{
    public class AutoGameScreen : HorizontalComposite
    {
        public SpeedScreen SpeedScreen { get; set; }
        public RoadScreen RoadScreen { get; set; }
        public CarScreen CarScreen { get; set; }   

        public AutoGameScreen(Composite parent)
            : base(parent)
        {
            SpeedScreen = new SpeedScreen(this) { GrabHorizontal = false, GrabVertical = true };
            //var speedBox = new BoxWidget(SpeedScreen);
            //speedBox.Compact();

            RoadScreen = new RoadScreen(this) { GrabHorizontal = true, GrabVertical = true };
            var roadBox = new BoxWidget(RoadScreen);
            roadBox.Compact();


            CarScreen = new CarScreen(this) { GrabHorizontal = true, GrabVertical = true };
            var carBox = new BoxWidget(CarScreen);
            carBox.Compact();

            AddControl(SpeedScreen);
            AddControl(roadBox);
            AddControl(carBox);
            
        }

        public void Bind(AutoGameViewModel autoGameViewModel)
        {
            RoadScreen.Bind(autoGameViewModel.RoadViewModel);
        }

    }
}
