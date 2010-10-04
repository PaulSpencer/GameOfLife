using System;

namespace Life.Tests
{
    public class Surface
    {
        public Surface(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X
        {
            get ; set;
        }

        public int Y
        {
            get; set;
        }

        internal object GetCellValue(int p, int p_2)
        {
            throw new NotImplementedException();
        }

        internal void MakeCellAlive(int p, int p_2)
        {
            throw new NotImplementedException();
        }
    }
}