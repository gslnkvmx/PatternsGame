using Baksteen.Extensions.DeepCopy;
using PatternsGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Mage: Unit, ISpecialAbility
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 50; }
        public override int Attack { get => 50; }
        public override int Defence { get => 5; }
        public override int Cost { get => 20; }
        public int Range { get => 3;}
        public Mage() : base() { }

        public Unit? ChooseTarget(FightTurn fightTurn)
        {
            var pos = fightTurn.AttackingArmy.Units.IndexOf(this);
            int i = pos;
            var distance = 0;
            while (i >= 0 & distance <= Range)
            {
                var unit = fightTurn.AttackingArmy.Units[i];
                if (unit is IClonable) return unit;
                i--;
                distance++;
            }

            return null;
        }

        //пофиксить, добавлять юнита в армию!
        public void UseAbility(Unit unit, FightTurn fightTurn)
        {
            var clonableUnit = unit as IClonable;
            if (clonableUnit != null) fightTurn.AttackingArmy.Units.Add(clonableUnit.Clone());
        }

        public override string GetInfo()
        {
            return $"Маг, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }
    }
}
