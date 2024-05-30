using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal class BattleState
    {
        public IArmy ArmyRed { get; set; }
        public IArmy ArmyBlue { get; set; }

        BattleState(IArmy army1, IArmy army2) {
            ArmyRed = army1;
            ArmyBlue = army2;
        }
    }
}
