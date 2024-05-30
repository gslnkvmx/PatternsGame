using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Warrior: Unit, IClonable
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 100; }
        public override int Attack { get => 50; }
        public override int Defence { get => 10; }
        public override int Cost { get => 5; }

        public Warrior() : base() { }

        public override string GetInfo()
        {
            return $"Воин, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }

        public Warrior(int hp)
        {
            HP = hp;
        }  

        public Unit Clone()
        {
            return new Warrior(this.HP);
        }
    }
}
