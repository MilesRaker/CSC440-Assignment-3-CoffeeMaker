using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.MoneyClasses
{
    public class StackOfTens : StackOfMoney
    {
        protected new readonly double _valueEach = 10;

        public StackOfTens(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;

    }
}
