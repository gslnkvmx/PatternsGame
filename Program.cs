using PatternsGame.Factories;
using PatternsGame.Game;
using PatternsGame.Units;
using System.Collections.Generic;

namespace PatternsGame
{
    internal class Program
    {
        static string TurnMenu = "1. Сделать ход        2. Отменить ход";
        static void Main(string[] args)
        {
            var army1 = new Army("Player 1", new List<Unit>());
            var army2 = new Army("Player 2", new List<Unit>());

            var warriorFactory = new WarriorFactory();
            var mageFactory = new MageFactory();
            var healerfactory = new HealerFactory();
            var archerfactory = new ArcherFactory();
            var knightfactory = new KnightFactory();

            while (true)
            {
                switch (Secondary_functions.Menu())
                {
                    case 0:
                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        bool continueCount = true;
                        while (continueCount)
                        {
                            switch (Secondary_functions.BuyMenu())
                            {
                                case 0:
                                    continueCount = false;
                                    break;
                                case 1:
                                    army1.Units.Add(warriorFactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Воин успешно нанят!");
                                    break;
                                case 2:
                                    army1.Units.Add(knightfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Рыцарь успешно нанят!");
                                    break;
                                case 3:
                                    army1.Units.Add(archerfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Лучник успешно нанят!");
                                    break;
                                case 4:
                                    army1.Units.Add(mageFactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Маг успешно нанят!");
                                    break;
                                case 5:
                                    army1.Units.Add(healerfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Целитель успешно нанят!");
                                    break;
                                case 6:
                                    if (army1.Units.Count == 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Ваша армия пуста!");
                                        break;
                                    }
                                    else
                                    {
                                        army1.Units.RemoveAt(army1.Units.Count - 1);
                                        Console.WriteLine();
                                        Console.WriteLine("Последний нанятый юнит успешно удалён!");
                                        break;
                                    }
                                default:
                                    Console.WriteLine();
                                    Console.WriteLine("Данный символ не соответсвует меню!");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool continueCount2 = true;
                        while (continueCount2)
                        {
                            switch (Secondary_functions.BuyMenu())
                            {
                                case 0:
                                    continueCount2 = false;
                                    break;
                                case 1:
                                    army2.Units.Add(warriorFactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Воин успешно нанят!");
                                    break;
                                case 2:
                                    army2.Units.Add(knightfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Рыцарь успешно нанят!");
                                    break;
                                case 3:
                                    army2.Units.Add(archerfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Лучник успешно нанят!");
                                    break;
                                case 4:
                                    army2.Units.Add(mageFactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Маг успешно нанят!");
                                    break;
                                case 5:
                                    army2.Units.Add(healerfactory.Create());
                                    Console.WriteLine();
                                    Console.WriteLine("Целитель успешно нанят!");
                                    break;
                                case 6:
                                    if (army2.Units.Count == 0)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Ваша армия пуста!");
                                        break;
                                    }
                                    else
                                    {
                                        army2.Units.RemoveAt(army2.Units.Count - 1);
                                        Console.WriteLine();
                                        Console.WriteLine("Последний нанятый юнит успешно удалён!");
                                        break;
                                    }
                                default:
                                    Console.WriteLine();
                                    Console.WriteLine("Данный символ не соответсвует меню!");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        var battleState = new BattleState(army1, army2);
                        var fightTurn = new FightTurn(battleState);
                        var history = new FightHistory(battleState);

                        var command = new FightCommand(battleState, fightTurn);

                        Console.WriteLine(fightTurn.GetArmysState());

                        while (!fightTurn.SomeoneWins())
                        {
                            Console.WriteLine(TurnMenu);
                            var choose = Console.ReadLine();
                            switch (choose)
                            {
                                case "1":
                                    command.Execute();
                                    break;
                                case "2":
                                    fightTurn = command.Undo();
                                    break;
                                default:
                                    Console.WriteLine();
                                    Console.WriteLine("Данный символ не соответсвует меню!");
                                    break;
                            }

                            Console.WriteLine(fightTurn.GetArmysState());
                        }

                        Console.WriteLine("Побеждает армия " + battleState.GetWinner().Name);
                        army1.Units.Clear();
                        army2.Units.Clear();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Данный символ не соответсвует меню!");
                        break;
                }
            }
        }
    }
}
