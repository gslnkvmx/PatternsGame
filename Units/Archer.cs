using PatternsGame.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Archer: Unit, ISpecialAbility
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 60; }
        public override int Attack { get => 50; }
        public override int Defence { get => 5; }
        public override int Cost { get => 8; }
        public int Range { get; set; }
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
            return fightTurn.DefendingArmy.Units[1];
        }

        public void UseAbility(Unit unit)
        {
            this.AttackUnit(unit);
        }
    }
}
