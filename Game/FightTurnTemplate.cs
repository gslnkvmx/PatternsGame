using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    abstract class FightTurnTemplate
    {
        public void MakeAMove()
        {

            BeatEachOther();

            DeleteDeadUnits();

            SwapTurn();

            CastAbilities();

            DeleteDeadUnits();

            SwapTurn();

            CastAbilities();

            DeleteDeadUnits();
        }

        public abstract void SwapTurn();

        public abstract void DeleteDeadUnits();

        public abstract string GetState();

        public abstract void BeatEachOther();

        public abstract void CastAbilities();
    }
}
