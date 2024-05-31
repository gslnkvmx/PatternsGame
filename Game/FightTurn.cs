using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    class FightTurn: FightTurnTemplate
    {
        public IArmy AttackingArmy { get; set; }
        public IArmy DefendingArmy { get; set; }
        private IBattle _battle;

        public FightTurn(IBattle battle)
        {
            AttackingArmy = battle.ArmyBlue;
            DefendingArmy = battle.ArmyRed;
            _battle = battle;
        }

        public override void SwapTurn()
        {
            IArmy tempArmy = AttackingArmy;
            AttackingArmy = DefendingArmy;
            DefendingArmy = tempArmy;
        }

        public override void DeleteDeadUnits()
        {
            AttackingArmy.Units.RemoveAll(unit => !unit.IsAlive());
            DefendingArmy.Units.RemoveAll(unit => !unit.IsAlive());
        }

        public override string GetState()
        {
            DeleteDeadUnits();
            return _battle.GetArmysState();
        }

        public override void BeatEachOther()
        {
            AttackingArmy.Units[0].AttackUnit(DefendingArmy.Units[0]);
            DefendingArmy.Units[0].AttackUnit(AttackingArmy.Units[0]);
        }

        public override void CastAbilities()
        {
            foreach (var unit in AttackingArmy.Units)
            {
                //тут наверное исправить на реализацию в классе
                if (unit is ISpecialAbility) ((ISpecialAbility)unit).CastAbility(this);
            }
        }
    }
}
