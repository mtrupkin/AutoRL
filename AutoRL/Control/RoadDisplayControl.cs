using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLib;

namespace AutoRL
{
    public class RoadDisplayControl : ControlBase
    {
        int CarOffsetHeigthBelow { get; set; } // space below car
        int CarOffsetHeigthAbove { get{return Height-CarOffsetHeigthBelow;}   } // space below car
        int CarOffsetWidth { get {return Width/2;}  } // space left and right of car

        public Road Road { get; set; }
        
        public RoadDisplayControl(Composite parent) : base(parent) {
            CarOffsetHeigthBelow = 20;            
        }

        public override void Render()
        {
            if (Road != null)
            {
                int x = 0;
                int y = 0;

                int x1 = 0;
                int y1 = 0;

                Screen.Clear();
                for (x = 0; x < Width; x++)
                {
                    for (y = 0; y < Height; y++)
                    {
                        ToRoadCoords(x, y, out x1, out y1);
                        Screen.SetPosition(x, y);
                        int tile = Road[x1, y1];

                        switch (tile)
                        {
                            case -1:
                                Screen.Write('@');
                                break;
                            case 1:
                                Screen.Write('*');
                                break;
                            case 2:
                                Screen.Write('.');
                                break;
                            case 3:
                                //Screen.Write(' ');
                                break;
                            case 0:
                                //Screen.Write(' ');
                                break;

                        }

                    }
                }
            }
        }

        void ToRoadCoords(int x, int y, out int x1, out int y1)
        {
            x1 = x - CarOffsetWidth;
            y1 = (CarOffsetHeigthAbove) - y;
        }

    }
   
}
