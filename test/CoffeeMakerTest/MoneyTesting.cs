using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeMaker.MoneyClasses;
using CoffeeMaker;
using System;
//  
namespace CoffeeMakerTest
{
    [TestClass]
    public class MoneyTesting
    {
        [TestMethod]
        public void PennyTesting()
        {
            // arrange
            StackOfPennies pStack = new StackOfPennies(5);
            // act

            // assert
            Assert.AreEqual(.05, pStack.TotalValue);
        }

        [TestMethod]
        public void NickleTesting()
        {
            // arrange
            StackOfNickles pStack = new StackOfNickles(4);
            // act

            // assert
            Assert.AreEqual(.20, pStack.TotalValue);
        }

        [TestMethod]
        public void DimeTesting()
        {
            // arrange
            StackOfDimes pStack = new StackOfDimes(5);
            // act

            // assert
            Assert.AreEqual(.50, pStack.TotalValue);
        }

        [TestMethod]
        public void QuarterTesting()
        {
            // arrange
            StackOfQuarters pStack = new StackOfQuarters(5);
            // act

            // assert
            Assert.AreEqual(1.25, pStack.TotalValue);
        }

        [TestMethod]
        public void DollarTesting()
        {
            // arrange
            StackOfDollars pStack = new StackOfDollars(2);
            // act

            // assert
            Assert.AreEqual(2, pStack.TotalValue);
        }

        [TestMethod]
        public void FiveTesting()
        {
            // arrange
            StackOfFives pStack = new StackOfFives(3);
            // act

            // assert
            Assert.AreEqual(15, pStack.TotalValue);
        }

        [TestMethod]
        public void TenTesting()
        {
            // arrange
            StackOfTens pStack = new StackOfTens(1);
            // act

            // assert
            Assert.AreEqual(10, pStack.TotalValue);
        }

        [TestMethod]
        public void TwentyTesting()
        {
            // arrange
            StackOfTwenties pStack = new StackOfTwenties(5);
            // act

            // assert
            Assert.AreEqual(100, pStack.TotalValue);
        }
    }
}