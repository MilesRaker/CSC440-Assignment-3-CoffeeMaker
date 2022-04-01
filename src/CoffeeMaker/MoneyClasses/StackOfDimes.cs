using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.MoneyClasses
{
    public class StackOfDimes : StackOfMoney
    {
        protected new readonly double _valueEach = .10;

        public StackOfDimes(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;
    }
}
