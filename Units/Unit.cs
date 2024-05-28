using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Units
{
    public abstract class Unit
    {
        public abstract int HP { get; set; }
        public abstract int MaxHP { get; }
        public abstract int Attack { get; }
        public abstract int Defence { get; }
        public abstract int Cost { get; }
        
        public Unit()
        {
            HP = this.MaxHP;
        }

        public string GetInfo()
        {
            return "";
        }

        public void AttackUnit(Unit opp_unit)
        {
            opp_unit.HP = opp_unit.HP - (this.Attack - opp_unit.Defence);
        }

        public bool IsAlive()
        {
            return HP > 0;
        }
    }
}
