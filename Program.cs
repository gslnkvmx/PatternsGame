using PatternsGame.Factories;
using PatternsGame.Game;
using PatternsGame.Units;

namespace PatternsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var army1 = new Army("Max", new List<Unit>());
            var army2 = new Army("Bott *_*", new List<Unit>());

            var warriorFactory = new WarriorFactory();
            var mageFactory = new MageFactory();
            var healerfactory = new HealerFactory();
            var archerfactory = new ArcherFactory();
            var knightfactory = new KnightFactory();

            army1.Units.Add(warriorFactory.Create());
            army1.Units.Add(warriorFactory.Create());
            army1.Units.Add(mageFactory.Create());
            army1.Units.Add(healerfactory.Create());

            army2.Units.Add(knightfactory.Create());
            army2.Units.Add(warriorFactory.Create());
            army2.Units.Add(archerfactory.Create());
            var battleState = new BattleState(army1, army2);
            var fightTurn = new FightTurn(battleState);

            while (true)
            {
                Console.WriteLine(battleState.GetArmysState());

                fightTurn.AttackingArmy.Units[0].AttackUnit(fightTurn.DefendingArmy.Units[0]);
                fightTurn.DefendingArmy.Units[0].AttackUnit(fightTurn.AttackingArmy.Units[0]);

                fightTurn.DeleteDeadUnits();
                Console.WriteLine(battleState.GetArmysState());

                fightTurn.SwapTurn();

                foreach(var unit in fightTurn.AttackingArmy.Units)
                {
                    //тут наверное исправить на реализацию в классе
                    if (unit is ISpecialAbility) ((ISpecialAbility)unit).CastAbility(fightTurn);
                }

                fightTurn.DeleteDeadUnits();
                Console.WriteLine(battleState.GetArmysState());

                fightTurn.SwapTurn();

                foreach (var unit in fightTurn.AttackingArmy.Units)
                {
                    //тут наверное исправить на реализацию в классе
                    if (unit is ISpecialAbility) ((ISpecialAbility)unit).CastAbility(fightTurn);
                }

                fightTurn.DeleteDeadUnits();
                Console.WriteLine(battleState.GetArmysState());

                if(battleState.ArmyBlue.Units.Count() == 0)
                {
                    Console.WriteLine("Армия " + battleState.ArmyRed.Name + " победила!");
                    return;
                }

                if (battleState.ArmyRed.Units.Count() == 0)
                {
                    Console.WriteLine("Армия " + battleState.ArmyBlue.Name + " победила!");
                    return;
                }
            }
        }
    }
}
