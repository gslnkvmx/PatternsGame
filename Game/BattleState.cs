﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    internal class BattleState : IBattle
    {
        public IArmy ArmyRed { get; set; }
        public IArmy ArmyBlue { get; set; }

        public List<BattleState> fightHistory { get; set; } = [];

        public BattleState(IArmy army1, IArmy army2)
        {
            ArmyRed = army1;
            ArmyBlue = army2;
            fightHistory.Add(this);
        }

        //убрать повторяющийся код в IArmy
        public string GetArmysState()
        {
            string armysState = string.Empty;

            armysState += ArmyRed.Name + "\n";
            foreach (var unit in ArmyRed.Units)
            {
                armysState += unit.GetInfo() + "\n";
            }

            armysState += ArmyBlue.Name + "\n";
            foreach (var unit in ArmyBlue.Units)
            {
                armysState += unit.GetInfo() + "\n";
            }

            return armysState;
        }

        public void DeleteDeadUnits()
        {
            foreach (var unit in ArmyRed.Units)
            {
                if (!unit.IsAlive()) ArmyRed.Units.Remove(unit);
            }

            foreach (var unit in ArmyRed.Units)
            {
                if (!unit.IsAlive()) ArmyBlue.Units.Remove(unit);
            }
        }

        public bool SomeoneWins()
        {
            return ArmyBlue.Units.Count() == 0 || ArmyRed.Units.Count() == 0;
        }

        public IArmy GetWinner()
        {
            if (ArmyBlue.Units.Count() == 0)
            {
                return ArmyRed;
            }

            else
            {
                return ArmyBlue;
            }
        }
    }
}
