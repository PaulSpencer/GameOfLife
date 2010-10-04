using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Life.Tests
{
    [TestFixture]
    public class LifeTestSuite
    {
        [Test]
        [TestCase(5,5)]
        public void Constructor_TwoDimensions_SurfaceCreated(int x, int y)
        {
            var result = new Surface(x,y);
            Assert.AreEqual(result.X, x);
            Assert.AreEqual(result.Y, y);
        }

        [Test]
        public void MakeCellAlive_PassedCoordinates_CellIsAlive()
        {
            var result = new Surface(3,3);
            result.MakeCellAlive(1, 1);
            Assert.AreEqual(true, result.GetCellValue(1,1));
        }
    }
}
