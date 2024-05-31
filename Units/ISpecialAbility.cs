using PatternsGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal interface ISpecialAbility
    {
        public int Range { get; set; }
        protected Unit? ChooseTarget(FightTurn fightTurn);
        public void UseAbility(Unit unit, FightTurn fightTurn);
        public void CastAbility(FightTurn fightTurn)
        {
            var target = ChooseTarget(fightTurn);
            if (target != null) UseAbility(target, fightTurn);
        }
    }
}
