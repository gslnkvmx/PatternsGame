

namespace PatternsGame.Units
{
    class IronKnight : KnightDecorator
    {
        public override int Attack { get => 120; }
        public IronKnight(Knight knight)
        {
            base.SetKnight(knight);
        }
        public override string GetInfo()
        {
            return "Железный " + knight.GetInfo() + ", Дополнительный урон = 40";
        }
    }
}