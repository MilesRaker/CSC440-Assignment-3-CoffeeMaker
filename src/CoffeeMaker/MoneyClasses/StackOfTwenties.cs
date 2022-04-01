using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.MoneyClasses
{
    public class StackOfTwenties : StackOfMoney
    {
        protected new readonly double _valueEach = 20;

        public StackOfTwenties(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;

    }
}
