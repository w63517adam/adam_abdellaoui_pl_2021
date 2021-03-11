using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public enum PointColour
    {
        Red,
        Green,
        Blue
    }
    class ColourfulPoint: Point
    {
        public PointColour Colour { get; set; }

        public ColourfulPoint(double x, PointColour col) : base(x)
        {
            Colour = col;
        }

        public ColourfulPoint(double x, double y, PointColour col) : base(x, y)
        {
            Colour = col;
        }
    }
}
