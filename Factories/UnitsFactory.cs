using PatternsGame.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatternsGame.Factories
{
    interface IUnitsFactory
    {
        public Unit Create();
    }

    class WarriorFactory : IUnitsFactory
    {
        public Unit Create()
        {
            return new Warrior();
        }
    }
    class KnightFactory : IUnitsFactory
    {
        public Unit Create()
        {
            return new Knight();
        }
    }
    class ArcherFactory : IUnitsFactory
    {
        public Unit Create()
        {
            return new Archer();
        }
    }
    class HealerFactory : IUnitsFactory
    {
        public Unit Create()
        {
            return new Healer();
        }
    }
    class MageFactory : IUnitsFactory
    {
        public Unit Create()
        {
            return new Mage();
        }
    }
}
