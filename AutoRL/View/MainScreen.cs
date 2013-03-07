using ConsoleLib;

namespace AutoRL
{
    public class MainScreen : StackedComposite
    {
        public MenuScreen MenuScreen { get; set; }
        public AutoGameScreen AutoGameScreen { get; set; }

        public MainScreen(Composite parent)
            : base(parent)
        {

            MenuScreen = new MenuScreen(parent) { GrabHorizontal = true, GrabVertical = true };

            AutoGameScreen = new AutoGameScreen(parent) { GrabHorizontal = true, GrabVertical = false };

            AddControl(new LayoutData(MenuScreen) { VerticalJustify = VerticalJustify.Center });

            AddControl(AutoGameScreen);
        }
    } 
}
