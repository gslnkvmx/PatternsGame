using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame
{
    internal class Secondary_functions
    {
        public static int Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Сформировать армию 1");
            Console.WriteLine("2. Сформировать армию 2");
            Console.WriteLine("3. В Бой!");
            Console.WriteLine("0. Выход");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            var s = Console.ReadLine();
            var c = int.TryParse(s, out var a);
            return !c ? 10 : a;
        }
        public static int BuyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Нанять Воина");
            Console.WriteLine("2. Нанять Рыцаря");
            Console.WriteLine("3. Нанять Лучника");
            Console.WriteLine("4. Нанять Мага");
            Console.WriteLine("5. Нанять Целителя");
            Console.WriteLine("6. Удалить последний нанятый юнит");
            Console.WriteLine("0. Выйти в главное меню");
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            var s = Console.ReadLine();
            var c = int.TryParse(s, out var a);
            return !c ? 10 : a;
        }
    }
}
