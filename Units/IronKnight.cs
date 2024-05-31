

namespace PatternsGame.Units
{
    class IronKnight : KnightDecorator
    {
        public IronKnight(Knight knight) : base(knight) { }
        public override int Attack { get => 120; }
        public override string GetInfo()
        {
            return "Железный " + knight.GetInfo() + ", Дополнительный урон = 40";
        }
    }
}