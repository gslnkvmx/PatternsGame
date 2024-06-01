using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal class FightHistory
    {
        public List<BattleState> fightHistory { get; set; } = [];

        public FightHistory(BattleState battle)
        {
            fightHistory.Add(battle);
        }
    }
}
