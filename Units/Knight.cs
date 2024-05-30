using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    internal class Knight : Unit
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 120; }
        public override int Attack { get => 80; }
        public override int Defence { get => 20; }
        public override int Cost { get => 15; }

        public override string GetInfo()
        {
            return $"Рыцарь, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }
    }
}
