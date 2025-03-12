using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Test
    {
        public static void TestForPositiveInteger(int value)
        {
            Debug.Assert(value > 0, "Error: Value wasn't a positive integer");
        }
        public static void TestForZeroOrAbove(int value)
        {
            Debug.Assert(value >= 0, "Error: Value wasn't a positive integer or 0");
        }

    }
}
