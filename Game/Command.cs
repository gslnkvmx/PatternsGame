using Baksteen.Extensions.DeepCopy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Game
{
    interface ICommand
    {
        public void Execute();
        public FightTurn Undo();
    }

    internal class FightCommand: ICommand
    {
        BattleState _battle;
        FightTurn _turn;

        public FightCommand(BattleState battle, FightTurn fightTurn)
        {
            _battle = battle;
            _turn = fightTurn;
        }

        public void Execute()
        {
            _turn.MakeAMove();
            _battle.fightHistory.Add(_battle.DeepCopy());
        }

        public FightTurn Undo()
        {
            _battle.fightHistory.RemoveAt(_battle.fightHistory.Count - 1);
            _turn = new FightTurn(_battle.fightHistory[_battle.fightHistory.Count - 1]);
            return _turn;
        }
    }
}
