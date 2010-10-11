using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Tests
{
    public class Darwin 
    {

        internal Surface Evolve(Surface _testedSurface)
        {
            return new Surface(_testedSurface.X, _testedSurface.Y);
        }
    }
}
