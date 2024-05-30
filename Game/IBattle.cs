using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal interface IBattle
    {
        public IArmy ArmyRed { get; set; }
        public IArmy ArmyBlue { get; set; }

        public string GetArmysState();

        public void DeleteDeadUnits();
    }
}
