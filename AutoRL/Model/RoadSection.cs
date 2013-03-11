using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRL
{
    [Flags]
    public enum Side { Top = 1, Right = 2, Bottom = 4, Left = 8 };

    public class RoadSection {
        int[,] tiles;


        int Height { get; set; }
        int Width { get; set; }
        public Side Entrances { get; set; }

        public int this[int x, int y]    
        {
            get
            {
                return tiles[x, y];
            }
        }


        public RoadSection()
        {

            Height = 100;
            Width = 100;

            tiles = new int[Width, Height];

        }

        public void Initialize(RoadSection top, RoadSection right, RoadSection bottom, RoadSection left)
        {
            SetEntrances(top, right, bottom, left);

            Reset();
            Randomize();
        }

        protected void SetEntrances(RoadSection top, RoadSection right, RoadSection bottom, RoadSection left)
        {
            if ((top.Entrances & Side.Bottom) == Side.Bottom)
            {
                Entrances &= Side.Top;
            }

            if ((right.Entrances & Side.Left) == Side.Left)
            {
                Entrances &= Side.Right;
            }

            if ((bottom.Entrances & Side.Top) == Side.Top)
            {
                Entrances &= Side.Bottom;
            }

            if ((left.Entrances & Side.Right) == Side.Right)
            {
                Entrances &= Side.Left;
            }
        }

        protected void DrawTopEntrance()
        {
            int width = 20;
            int height = Height/2;




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
            int items = 200;
            int x, y = 0;
            Random rnd = new Random();

            for (int i = 0; i < items; i++ ) {
                x = rnd.Next(Width);
                y = rnd.Next(Height);

                tiles[x, y] = 1;
            }

        }

    }
}
