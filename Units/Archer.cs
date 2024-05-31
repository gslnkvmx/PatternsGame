using PatternsGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Archer: Unit, ISpecialAbility, IClonable
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 60; }
        public override int Attack { get => 50; }
        public override int Defence { get => 5; }
        public override int Cost { get => 8; }
        public int Range { get => 10; }
        public Archer() : base() { }

        public Archer(int hp)
        {
            HP = hp;
        }

        public Unit Clone()
        {
            return new Archer(this.HP);
        }

        public Unit? ChooseTarget(FightTurn fightTurn)
        {
            var pos = fightTurn.AttackingArmy.Units.IndexOf(this);
            int i = 0;
            var distance = pos;
            while (i < fightTurn.DefendingArmy.Units.Count() & distance <= Range)
            {
                var unit = fightTurn.DefendingArmy.Units[i];
                if (unit.HP < unit.MaxHP) return unit;
                i++;
                distance++;
            }

            return null;
        }

        public void UseAbility(Unit unit, FightTurn fightTurn)
        {
            this.AttackUnit(unit);
        }

        public override string GetInfo()
        {
            return $"Лучник, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }
    }
}
