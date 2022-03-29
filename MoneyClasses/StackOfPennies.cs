// this file is showing up in folder MoneyClasses, but the path has it outside.
namespace CoffeeMaker
{
    public class StackOfPennies : StackOfMoney
    {
        protected new readonly double _valueEach = 0.01;

        public StackOfPennies(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;

    }
}
