using PatternsGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Healer : Unit, ISpecialAbility
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 150; }
        public override int Attack { get => 10; }
        public override int Defence { get => 5; }
        public override int Cost { get => 20; }
        public int Healing { get => 27; }
        public int Range { get => 6; }
        public Healer() : base() { }

        public Unit? ChooseTarget(FightTurn fightTurn)
        {
            var pos = fightTurn.AttackingArmy.Units.IndexOf(this);
            int i = pos;
            var distance = 0;
            while (i >= 0 & distance<=Range)
            {
                var unit = fightTurn.AttackingArmy.Units[i];
                if (unit.HP < unit.MaxHP) return unit;
                i--;
                distance++;
            }

            return null;
        }

        public void UseAbility(Unit unit, FightTurn fightTurn)
        {
            unit.HP += Healing;
        }

        public override string GetInfo()
        {
            return $"Целитель, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }
    }
}
