using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    public class Road
    {
        int[,] tiles;


        int Height { get; set; }
        int Width { get; set; }

        int Height2 { get { return Height / 2; } }
        int Width2 { get { return Width / 2; } }

        public Car Player { get; set; }

        // car location
        int X { get { return Player.X; } }
        int Y { get { return Player.Y; } }

        public int this[int x, int y]    // Indexer declaration
                                         // x,y is relative to car                                        
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

                    return tiles[x1, y1] ;
                }
            }
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

            Height = 2000;
            Width = 100;

            tiles = new int[Width, Height];

            Initialize();
        }

        public void Initialize()
        {
            Reset();
            Randomize();
        }

        void Reset()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    tiles[i, j] = 0;
                }
            }

        }

        public void Randomize()
        {
            int items = 2000;
            int x, y = 0;
            Random rnd = new Random();

            for (int i = 0; i < items; i++ ) {
                x = rnd.Next(Width);
                y = rnd.Next(Height);

                tiles[x, y] = 1;
            }

        }

        public void UpdatePhase(int phase)
        {
            Player.UpdatePhase(phase);
        }

    }
}
