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
        public int Healing { get => 20; }
        public int Range { get; set; }
        public Healer() : base() { }

        public Unit? ChooseTarget(FightTurn fightTurn)
        {
            int i = 0;
            while (i <= Range)
            {
                var unit = fightTurn.AttackingArmy.Units[i];
                return unit;
            }

            return null;
        }

        public void UseAbility(Unit unit)
        {
            unit.HP += Healing;
        }

        public override string GetInfo()
        {
            return $"Целитель, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }
    }
}
