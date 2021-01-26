using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dot.Challenge.Model.Enums;

namespace Dot.Challenge.Model
{
    /// <summary>
    /// Represents a 6-side dice with L-C-R-DOT-DOT-DOT values
    /// </summary>
    public class Dice
    {
        public List<int> Sides { set; get; }

        public Dice()
        {
            Sides = new List<int>();
            Sides.Add((int)Dots.Dot1);
            Sides.Add((int)Dots.Dot2);
            Sides.Add((int)Dots.Dot3);
            Sides.Add((int)Dots.L);
            Sides.Add((int)Dots.C);
            Sides.Add((int)Dots.R);
        }
    }
}
