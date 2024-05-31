using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    class FightTurn: FightTurnTemplate
    {
        public IArmy AttackingArmy { get; set; }
        public IArmy DefendingArmy { get; set; }

        public FightTurn(IBattle battle)
        {
            AttackingArmy = battle.ArmyBlue;
            DefendingArmy = battle.ArmyRed;
        }

        public FightTurn(FightTurn fightTurn)
        {
            AttackingArmy = fightTurn.AttackingArmy;
            DefendingArmy = fightTurn.DefendingArmy;
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

        public override void BeatEachOther()
        {
            AttackingArmy.Units[0].AttackUnit(DefendingArmy.Units[0]);
            DefendingArmy.Units[0].AttackUnit(AttackingArmy.Units[0]);
        }

        public override void CastAbilities()
        {
            foreach (var unit in AttackingArmy.Units )
            {
                //тут наверное исправить на реализацию в классе
                if (unit is ISpecialAbility) ((ISpecialAbility)unit).CastAbility(this);
            }
        }

        public string GetArmysState()
        {
            string armysState = string.Empty;

            armysState += AttackingArmy.Name + "\n";
            foreach (var unit in AttackingArmy.Units)
            {
                armysState += unit.GetInfo() + "\n";
            }

            armysState += DefendingArmy.Name + "\n";
            foreach (var unit in DefendingArmy.Units)
            {
                armysState += unit.GetInfo() + "\n";
            }

            return armysState;
        }
    }
}
