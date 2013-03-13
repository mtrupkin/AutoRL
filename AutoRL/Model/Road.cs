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

        public List<Car> Enemies { get; set; }

        // car location
        double X { get { return Player.X; } }
        double Y { get { return Player.Y; } }

        int X1 { get { return Player.X1; } }
        int Y1 { get { return Player.Y1; } }


        // x,y is relative to car                                        
        public RoadTile this[int x, int y]                                           
        {
            get
            {

                double x1, y1 = 0;

                TransformToMap(x, y, out x1, out y1);

                var roadSection = GetRoadSection((int)x1, (int)y1);

                if (roadSection != null)
                {
                    int x2 = (int)Math.Floor(x1 % 100);
                    int y2 = (int)Math.Floor(y1 % 100);

                    return roadSection[x2, y2];
                }
                else
                {
                    return RoadTile.Rock;
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

                GenerateEnemy(roadSectionPoint);
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

        public void TransformToRoad(int x, int y, out double x2, out double y2)
        {
            double x1, y1;

            double heading = Player.Heading;

            heading -= Math.PI / 2;
            //x1 = (x * Math.Cos(heading) - y * Math.Sin(heading));
            //y1 = (x * Math.Sin(heading) + y * Math.Cos(heading));
            //x2 = (x1 + X);
            //y2 = (y1 + Y);

            x2 = (x + X);
            y2 = (y + Y);

            //

        }

        public void TransformToMap(int x, int y, out double x2, out double y2)
        {
            double x1, y1;
            TransformToRoad(x, y, out x1, out y1);

            x1 = x1 + Width2;
            y1 = Height2 - y1;
            

            //X += Math.Cos(heading);
            //Y += Math.Sin(heading);

            //x2 = (int)(x1 * Math.Cos(heading) - y1 * Math.Sin(heading));
            //y2 = (int)(-x1 * Math.Sin(heading) + y1 * Math.Cos(heading));

            x2 = x1;
            y2 = y1;

        }

        public void TransformFromRoad(int x, int y, out double x2, out double y2)
        {
            double x1, y1;

            double heading = Player.Heading;

            heading -= Math.PI / 2;
            //x1 = (x * Math.Cos(heading) - y * Math.Sin(heading));
            //y1 = (x * Math.Sin(heading) + y * Math.Cos(heading));
            //x2 = (x1 + X);
            //y2 = (y1 + Y);

            //x2 = (x - X);
            //y2 = (y - Y);

            x2 = x;
            y2 = y;

            //

        }


        public void TransformFromMap(int x, int y, out double x2, out double y2)
        {
            int x1, y1;

            x1 = x - Width2;
            y1 =  Height2 - y;

            TransformFromRoad(x1, y1, out x2, out y2);



            //X += Math.Cos(heading);
            //Y += Math.Sin(heading);

            //x2 = (int)(x1 * Math.Cos(heading) - y1 * Math.Sin(heading));
            //y2 = (int)(-x1 * Math.Sin(heading) + y1 * Math.Cos(heading));

            //x2 = x1;
            //y2 = y1;
        }

        public Road(Car player)
        {
            Player = player;

            Player.X = 50;
            Player.Y = 50;

            Height = 100 * 100;
            Width = 100 * 100;

            Enemies = new List<Car>();

            RoadSections = new Dictionary<Point, RoadSection>();
            InitializeSideOffsets();

            

        }

        public void Initialize()
        {
            RoadSections.Clear();

            var roadSection = new RoadSection();

            roadSection.InitializeCrossRoad();

            double x1, y1 = 0;
            TransformToMap(0, 0, out x1, out y1);

            Point roadSectionPoint = new Point((int)x1 / 100, (int)y1 / 100);


            RoadSections[roadSectionPoint] = roadSection;

            GenerateEnemy(roadSectionPoint);

        }

        public void InitializeSideOffsets()
        {
            SideMapOffsets = new Dictionary<Side, Size>();

            SideMapOffsets.Add(Side.Top, new Size(0, -1));
            SideMapOffsets.Add(Side.Right, new Size(1, 0));
            SideMapOffsets.Add(Side.Bottom, new Size(0, 1));
            SideMapOffsets.Add(Side.Left, new Size(-1, 0));

        }


        void GenerateEnemy(Point roadSection)
        {
            //int x = Dice.D100() - 1;
            //int y = Dice.D100() - 1;

            int x = 52;
            int y = 52;            

            Car enemy = new Car(Names.GenerateName());

            x = roadSection.X * 100 + x;
            y = roadSection.Y * 100 + y;

            enemy.Speed = 0;

            double x1, y1;

            //TransformFromMap(x, y, x1, y1);
            TransformFromMap(x, y, out x1, out y1);

            enemy.X = x1;
            enemy.Y = y1;

            Enemies.Add(enemy);

        }

        public void UpdatePhase(int phase)
        {
            Player.UpdatePhase(phase);

            if (RoadTile.Rock == this[0, 0])
            {
                Player.Collision();
            }


        }

    }
}
