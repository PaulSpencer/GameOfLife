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
            return _surface[x, y];
        }

        internal void MakeCellAlive(int x, int y)
        {
            if ((x<0 || x>=X) && (y<0 || y>=Y))
            {
                throw new ArgumentException("Coordinates out of surface bounds");
            }
            _surface[x, y] = true;
        }
    }
}