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
            Reset();

            SetEntrances(top, right, bottom, left);            
            Randomize();
            DrawEntrances();
            Hollow();
        }

        public void InitializeCrossRoad()
        {
            Reset();

            Entrances |= Side.Top | Side.Right | Side.Bottom | Side.Left;

            Randomize();
            DrawEntrances();
            Hollow();
        }

        protected bool HasSide(Side entrance, Side side)
        {
            if ((entrance & side) == side)
            {
                return true;
            }
            return false;
        }

        protected Side OppositeSide(Side side)
        {
            switch (side)
            {
                case Side.Top: return Side.Bottom;
                case Side.Right: return Side.Left;
                case Side.Bottom: return Side.Top;
                case Side.Left: return Side.Right;

            }

            return Side.Top;
        }

        protected void SetEntrance(Side entrance, Side side)
        {
            Random rnd = new Random();
            int chance = 0;

            if (HasSide(entrance, side))
            {
                Entrances |= OppositeSide(side);
                chance = rnd.Next(100);
                //if (chance < 95)
                {
                    Entrances |= side;
                }
            }

        }

        protected void SetEntrances(RoadSection top, RoadSection right, RoadSection bottom, RoadSection left)
        {

            if (top != null)
            {
                SetEntrance(top.Entrances, Side.Bottom);
            }
            if (right != null)
            {
                SetEntrance(right.Entrances, Side.Left);
            }
            if (bottom != null)
            {
                SetEntrance(bottom.Entrances, Side.Top);
            }
            if (left != null)
            {
                SetEntrance(left.Entrances, Side.Right);
            }
        }

        void DrawEntrances()
        {
            if ((Entrances & Side.Bottom) == Side.Bottom)
            {
                DrawBottomEntrance();
            }

            if ((Entrances & Side.Left) == Side.Left)
            {
                DrawLeftEntrance();
            }

            if ((Entrances & Side.Top) == Side.Top)
            {
                DrawTopEntrance();
            }

            if ((Entrances & Side.Right) == Side.Right)
            {
                DrawRightEntrance();
            }
        }

        int RoadWidth = 20;

        protected void DrawTopEntrance()
        {
            
            int height = Height/2;
            int offset = (Width - RoadWidth) / 2;
            for (int i = 0; i < RoadWidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tiles[i + offset, j] = 2;
                }
            }
        }

        protected void DrawBottomEntrance()
        {

            int height = Height / 2;
            int offset = (Width - RoadWidth) / 2;
            for (int i = 0; i < RoadWidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tiles[i + offset, j + height] = 2;
                }
            }
        }
        protected void DrawLeftEntrance()
        {

            int height = Height / 2;
            int offset = (Width - RoadWidth) / 2;
            for (int i = 0; i < RoadWidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tiles[j, i + offset] = 2;
                }
            }
        }

        protected void DrawRightEntrance()
        {

            int height = Height / 2;
            int offset = (Width - RoadWidth) / 2;
            for (int i = 0; i < RoadWidth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    tiles[j + height, i + offset] = 2;
                }
            }
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
            int sideNum = rnd.Next(4);

            Side side = GetSide(sideNum);
            Entrances |= side;
            //Entrances |= Side.Top;
            
            for (int i = 0; i < items; i++ ) {
                x = rnd.Next(Width);
                y = rnd.Next(Height);

                tiles[x, y] = 1;
            }

        }

        Side GetSide(int sideNum)
        {
            Side side = Side.Top;
            switch (sideNum)
            {
                case 0:
                    side = Side.Top;
                    break;
                case 1:
                    side = Side.Right;
                    break;
                case 2:
                    side = Side.Bottom;
                    break;
                case 3:
                    side = Side.Left;
                    break;


            }
            return side;
        }

        protected void Hollow()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    bool isSurrounded = false;
                    if (IsRoad(i,j) && IsRoad(i - 1, j) && IsRoad(i + 1, j) && IsRoad(i, j - 1)  && IsRoad(i, j + 1) )
                    {
                        isSurrounded = true;
                    }
                    
                    if (isSurrounded)
                    {
                        tiles[i, j] = 3;
                    }
                }
            }
        }

        bool IsRoad(int x, int y)        
        {
            if ( (x < 0 || y < 0) || ( x >= Width) || ( y >= Height) ) 
            {
                return true;
            }

            int tile = tiles[x, y];
            return (tile == 2) || (tile == 3);
        }

    }
}
