using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutoRL
{
    public class Road
    {
     //   int[,] tiles;


        int Height { get; set; }
        int Width { get; set; }

        int Height2 { get { return Height / 2; } }
        int Width2 { get { return Width / 2; } }
         
        Dictionary<Point, RoadSection> RoadSections { get; set; }

        public Car Player { get; set; }

        // car location
        int X { get { return Player.X; } }
        int Y { get { return Player.Y; } }

        // x,y is relative to car                                        
        public int this[int x, int y]                                           
        {
            get {
                if ((x == 0) && (y == 0))
                {
                    return -1;
                }
                else
                {
                    int x1, y1 = 0;

                    TransformToMap(x, y, out x1, out y1);

                    var roadSection = GetRoadSection(x1, y1);

                    return roadSection[x1 % 100, y1 % 100];
                }
            }
        }

        public RoadSection GetRoadSection(int x, int y)
        {
            Point roadSectionPoint = new Point(x / 100, y / 100);

            RoadSection roadSection;
            RoadSections.TryGetValue(roadSectionPoint, out roadSection);

            if (roadSection == null)
            {
                roadSection = new RoadSection();
                RoadSections[roadSectionPoint] = roadSection;
            }

            return roadSection;
        }

        public void TransformToRoad(int x, int y, out int x1, out int y1)
        {
            x1 = x + X;
            y1 = y + Y;
        }

        public void TransformToMap(int x, int y, out int x1, out int y1)
        {
            TransformToRoad(x, y, out x1, out y1);

            x1 = x1 + Width2;
            y1 = Height2 - y1;
        }

        public Road(Car player)
        {
            Player = player;

            Height = 100 * 100;
            Width = 100 * 100;

            RoadSections = new Dictionary<Point, RoadSection>();

        }

        public void Initialize()
        {
            RoadSections.Clear();
        }

     
        public void UpdatePhase(int phase)
        {
            Player.UpdatePhase(phase);
        }

    }
}
