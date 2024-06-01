
namespace PatternsGame.Units
{
    abstract class KnightDecorator : Knight
    {
        public Knight knight;
        public void SetKnight(Knight knight)
        {
            this.knight = knight;
        }
    }
}