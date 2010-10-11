using System;

namespace Life.Tests
{
    public class Surface
    {
        private bool[,] _surface;

        public Surface(int x, int y)
        {
            X = x;
            Y = y;

            _surface = new bool[X,Y];
        }

        public int X
        {
            get ; set;
        }

        public int Y
        {
            get; set;
        }

        internal bool GetCellValue(int x, int y)
        {
            ValidateSurfaceBounds(x, y);
            return _surface[x, y];
        }

        internal void MakeCellAlive(int x, int y)
        {
            ValidateSurfaceBounds(x, y);
            _surface[x, y] = true;
        }

        private void ValidateSurfaceBounds(int x, int y)
        {
            if ((x < 0 || x >= X) && (y < 0 || y >= Y))
            {
                throw new ArgumentException("Coordinates out of surface bounds");
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Surface p = obj as Surface;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (p.X != X || p.Y != Y)
            {
                return false;
            }

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (p.GetCellValue(i,j) != GetCellValue(i,j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
            
    }
}