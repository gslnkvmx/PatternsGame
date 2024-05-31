
namespace PatternsGame.Units
{
    abstract class KnightDecorator : Knight
    {
        protected Knight knight;
        public KnightDecorator(Knight knight) : base()
        {
            this.knight = knight;
        }
    }
}