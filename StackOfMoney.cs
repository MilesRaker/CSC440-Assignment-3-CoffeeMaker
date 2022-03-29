using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public abstract class StackOfMoney
    {
        // members
        protected readonly double _valueEach;
        protected int _count;

        // properties
        public abstract double TotalValue { get; } // I want to implement TotalValue in StackOfMoney
        public abstract int Count { get; }


        // constructors
        public StackOfMoney() { }
        public StackOfMoney(int count)
        {
            _count = count;
        }

        // methods
        public void getPaid(int amount) => _count += amount; // increment _count
        public int payOut(int amount) 
        { 
            _count -= amount;
            return amount; 
        } 
    }
}
