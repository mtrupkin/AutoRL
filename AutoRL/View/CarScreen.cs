using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLib;

namespace AutoRL
{
    public class CarScreen : VerticalComposite    
    {
        TextWidget NameText { get; set; }
        TextWidget ArmorText { get; set; }

        public CarScreen(Composite parent)
            : base(parent)
        {
            ArmorText = new TextWidget(this);
            NameText = new TextWidget(this);

            AddControl(NameText);
            AddControl(ArmorText);
        }

        public void SetCar(Car car)
        {
            var str1 = String.Format("Name : {0} ", car.Name);
            NameText.SetText(str1);

            var str2 = String.Format("Armor: {0} ", car.Armor);
            ArmorText.SetText(str2);

        }

    }
}
