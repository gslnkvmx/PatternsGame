using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal class Army: IArmy
    {
        public string Name { get; set; }
        public List<Unit> Units { get; set; }

        public Army(string name, List<Unit> units)
        {
            Name = name;
            Units = units;
        }
    }
}
