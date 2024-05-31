using PatternsGame.Factories;
using PatternsGame.Game;
using PatternsGame.Units;

namespace PatternsGame
{
    internal class Program
    {
        static string Menu = "1. Сделать ход        2. Отменить ход";
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

            var command = new FightCommand(battleState, fightTurn);

            Console.WriteLine(fightTurn.GetArmysState());

            while (!battleState.SomeoneWins())
            {
                Console.WriteLine(Menu);
                var choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        command.Execute();
                        break;
                    case "2":
                        fightTurn = command.Undo();
                        break;
                }

                Console.WriteLine(fightTurn.GetArmysState());
            }

            Console.WriteLine("Побеждает армия " + battleState.GetWinner().Name); 
        }
    }
}
