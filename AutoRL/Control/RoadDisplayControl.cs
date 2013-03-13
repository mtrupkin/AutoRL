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
                        RoadTile tile = Road[x1, y1];

                        switch (tile)
                        {
                            case RoadTile.Rock:
                                Screen.Write('*');
                                break;
                            case RoadTile.Paint:
                                Screen.Write('.');
                                break;
                            //case 3:
                                //Screen.Write(' ');
                                //break;
                            //case 0:
                                //Screen.Write(' ');
                                //break;
                        }

                        if (x1 == 0 && y1 == 0)
                        {
                            Screen.Write('@');
                        }
                    }
                }

                foreach (Car enemy in Road.Enemies)
                {
                    x = enemy.X1;
                    y = enemy.Y1;
                    FromRoadCoords(x, y, out x1, out y1);
                    Screen.SetPosition(x1, y1);
                    Screen.Write('K');
                }
            }
        }

        void ToRoadCoords(int x, int y, out int x1, out int y1)
        {
            x1 = x - CarOffsetWidth;
            y1 = (CarOffsetHeigthAbove) - y;
        }

        void FromRoadCoords(int x, int y, out int x1, out int y1)
        {
            //x1 = x;
            //y1 = y;
            x1 = x - Road.Player.X1;
            y1 = y - Road.Player.Y1 ;

            x1 = x1 + CarOffsetWidth;
            y1 = (CarOffsetHeigthAbove) - y1;

            //x1 = x - CarOffsetWidth;
            //y1 = (CarOffsetHeigthAbove) - y;
        }

    }
   
}
