using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    class FightTurn
    {
        public IArmy AttackingArmy { get; set; }
        public IArmy DefendingArmy { get; set; }

        public FightTurn(IBattle battle)
        {
            AttackingArmy = battle.ArmyBlue;
            DefendingArmy = battle.ArmyRed;
        }

        public void SwapTurn()
        {
            IArmy tempArmy = AttackingArmy;
            AttackingArmy = DefendingArmy;
            DefendingArmy = tempArmy;
        }
    }
}
