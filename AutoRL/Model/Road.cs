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

        Dictionary<Side, Size> SideMapOffsets{ get; set; }

        public Car Player { get; set; }

        // car location
        double X { get { return Player.X; } }
        double Y { get { return Player.Y; } }

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

                    if (roadSection != null)
                    {
                        return roadSection[x1 % 100, y1 % 100];
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

        public RoadSection GetRoadSection(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return null;
            }
            
            Point roadSectionPoint = new Point(x / 100, y / 100);

            

            RoadSection roadSection;
            RoadSections.TryGetValue(roadSectionPoint, out roadSection);

            if (roadSection == null)
            {
                roadSection = new RoadSection();

                RoadSection top = GetRoadSectionSide(roadSectionPoint, Side.Top);
                RoadSection right = GetRoadSectionSide(roadSectionPoint, Side.Right);
                RoadSection bottom = GetRoadSectionSide(roadSectionPoint, Side.Bottom);
                RoadSection left = GetRoadSectionSide(roadSectionPoint, Side.Left);

                roadSection.Initialize(top, right, bottom, left);

                RoadSections[roadSectionPoint] = roadSection;
            }

            return roadSection;
        }

        RoadSection GetRoadSectionSide(Point roadSectionPoint, Side side)
        {
            RoadSection roadSection;
            var point = Point.Add(roadSectionPoint, SideMapOffsets[side]);

            RoadSections.TryGetValue(point, out roadSection);

            return roadSection;

        }

        public void TransformToRoad(int x, int y, out int x1, out int y1)
        {
            x1 = x + (int)X;
            y1 = y + (int)Y;
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

            Player.X = 50;
            Player.Y = 50;

            Height = 100 * 100;
            Width = 100 * 100;

            RoadSections = new Dictionary<Point, RoadSection>();
            InitializeSideOffsets();



        }

        public void Initialize()
        {
            RoadSections.Clear();

            var roadSection = new RoadSection();

            roadSection.InitializeCrossRoad();

            int x1, y1 = 0;
            TransformToMap(0, 0, out x1, out y1);

            Point roadSectionPoint = new Point(x1 / 100, y1 / 100);


            RoadSections[roadSectionPoint] = roadSection;
        }

        public void InitializeSideOffsets()
        {
            SideMapOffsets = new Dictionary<Side, Size>();

            SideMapOffsets.Add(Side.Top, new Size(0, -1));
            SideMapOffsets.Add(Side.Right, new Size(1, 0));
            SideMapOffsets.Add(Side.Bottom, new Size(0, 1));
            SideMapOffsets.Add(Side.Left, new Size(-1, 0));

        }

     
        public void UpdatePhase(int phase)
        {
            Player.UpdatePhase(phase);
        }

    }
}
