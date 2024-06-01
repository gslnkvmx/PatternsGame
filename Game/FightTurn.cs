using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    class FightTurn : FightTurnTemplate
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
        public bool SomeoneWins()
        {
            return AttackingArmy.Units.Count() == 0 || DefendingArmy.Units.Count() == 0;
        }

        public override void DeleteDeadUnits()
        {
            AttackingArmy.Units.RemoveAll(unit => !unit.IsAlive());
            DefendingArmy.Units.RemoveAll(unit => !unit.IsAlive());
        }

        public override void BeatEachOther()
        {
            if (AttackingArmy.Units.Count() != 0 & DefendingArmy.Units.Count() != 0)
            {
                AttackingArmy.Units[0].AttackUnit(DefendingArmy.Units[0]);
                DefendingArmy.Units[0].AttackUnit(AttackingArmy.Units[0]);
            }
        }

        public override void CastAbilities()
        {
            for (int i = 0; i < AttackingArmy.Units.Count(); i++)
            {
                //тут наверное исправить на реализацию в классе
                if (AttackingArmy.Units[i] is ISpecialAbility) ((ISpecialAbility)AttackingArmy.Units[i]).CastAbility(this);
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
