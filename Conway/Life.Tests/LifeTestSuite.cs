﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

//   1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
//   2. Any live cell with more than three live neighbours dies, as if by overcrowding.
//   3. Any live cell with two or three live neighbours lives on to the next generation.
//   4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

namespace Life.Tests
{
    [TestFixture]
    public class LifeTestSuite
    {
        private Surface _testedSurface;
        private Surface _simpleSurface;
        private Surface _emptySurface;
        [SetUp]
        public void SetUp()
        {
            _testedSurface = new Surface(5, 5);
            _simpleSurface = new Surface(3, 3);
            _emptySurface = new Surface(3, 3);
        }

        [Test]
        [TestCase(5, 5)]
        public void Constructor_TwoDimensions_SurfaceCreated(int x, int y)
        {
            var result = new Surface(x, y);
            Assert.AreEqual(result.X, x);
            Assert.AreEqual(result.Y, y);
        }

        [Test]
        public void MakeCellAlive_PassedCoordinates_CellIsAlive()
        {
            _testedSurface.MakeCellAlive(1, 1);
            Assert.AreEqual(true, _testedSurface.GetCellValue(1, 1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MakeCellAlive_CoordinatesOutOfBounds_ThrowsArgumentException()
        {
            _testedSurface.MakeCellAlive(6, 6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCellValue_CoordinatesOutOfBounds_ThrowsArgumentException()
        {
            _testedSurface.GetCellValue(6, 6);
        }

        [Test]
        public void MakeCellAlive_CoordinatesEdgeCondition_NoError()
        {
            _testedSurface.MakeCellAlive(4, 4);
        }

        [Test]
        public void Darwin_GivenOldSurface_ReturnsNewSurface()
        {
            var result = new Darwin();
            Assert.IsInstanceOf<Surface>(result.Evolve(_testedSurface));
        }

        [Test]
        public void Darwin_GivenSurfaceWithOneLiveCell_ReturnsEmtyCell()
        {
            _simpleSurface.MakeCellAlive(0, 0);
            var result = new Darwin().Evolve(_simpleSurface);
            Assert.AreEqual(_emptySurface, result);
        }

        [Test]
        public void Equals_NonMatching_ReturnsFalse()
        {
            _simpleSurface.MakeCellAlive(0, 0);
            Assert.AreNotEqual(_emptySurface, _simpleSurface);
        }

    }
}
