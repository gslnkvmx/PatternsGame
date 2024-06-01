using PatternsGame.Game;


namespace PatternsGame.Units
{
    internal class Warrior : Unit, IClonable, ISpecialAbility
    {
        public override int HP { get; set; }
        public override int MaxHP { get => 100; }
        public override int Attack { get => 50; }
        public override int Defence { get => 10; }
        public override int Cost { get => 5; }
        public int Range { get; set; }

        public Warrior() : base() { }

        public override string GetInfo()
        {
            return $"Воин, HP: {HP}, атака: {Attack}, защита: {Defence}, цена: {Cost}";
        }

        public Warrior(int hp)
        {
            HP = hp;
        }
        public Unit? ChooseTarget(FightTurn fightTurn)
        {
            var pos = fightTurn.AttackingArmy.Units.IndexOf(this);
            if (pos == 0) return null;
            var unit = fightTurn.AttackingArmy.Units[pos - 1];
            if (unit.GetType() == typeof(Knight))
                return unit;
            return null;
        }

        public void UseAbility(Unit unit, FightTurn fightTurn)
        {
            var ironKnight = new IronKnight((Knight)unit);
            fightTurn.AttackingArmy.Units[0] = ironKnight;
        }

        public Unit Clone()
        {
            return new Warrior(this.HP);
        }
    }
}
