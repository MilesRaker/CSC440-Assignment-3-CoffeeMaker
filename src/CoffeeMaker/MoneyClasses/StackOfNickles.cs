using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.MoneyClasses
{
    public class StackOfNickles : StackOfMoney
    {
        protected new readonly double _valueEach = 0.05;

        public StackOfNickles(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;
    }
}
