using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal interface IArmy
    {
        public List<Unit> Units { get; set; }
        public string Name { get; set; }
    }
}
