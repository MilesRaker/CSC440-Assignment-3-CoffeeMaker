using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker.MoneyClasses
{
    public class StackOfFives : StackOfMoney
    {
        protected new readonly double _valueEach = 5;

        public StackOfFives(int count) : base(count)
        {
        }

        public override double TotalValue => _valueEach * _count;

        public override int Count => _count;
    }
}
