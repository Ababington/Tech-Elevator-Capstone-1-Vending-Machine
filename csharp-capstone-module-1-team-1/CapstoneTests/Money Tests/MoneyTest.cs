using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapstoneTests.Money_Tests
{
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]

        public void FeedMoneyHappyPath()
        {
            Money money = new Money();

            // Arrange
            decimal expected = 0M;
            decimal inputOne = 0M;

            decimal result;

            // Act
            result = money.FeedMoney(inputOne);

            // Assert
            Assert.AreEqual(expected, result);

            //

            // Arrange
            expected = 1M;
            inputOne = 1M;

            // Act
            result = money.FeedMoney(inputOne);

            // Assert
            Assert.AreEqual(expected, result);

            //

            // Arrange
            expected = 2M;
            inputOne = -1M;

            // Act
            result = money.FeedMoney(inputOne);

            // Assert
            Assert.AreEqual(expected, result);

            //

            // Arrange
            expected = 5002M;
            inputOne = 5000M;

            // Act
            result = money.FeedMoney(inputOne);

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ChangeOutHappyPath()
        {

            Money money = new Money();

            // Arrange
            string expected = $" You recieved 0 Nickles, 0 Dimes, and 1 Quarters in Change";

            string result;

            // Act
            result = money.ChangeOut(.25M);

            // Assert
            Assert.AreEqual(expected, result);

            //

            // Arrange
             expected = $" You recieved 0 Nickles, 0 Dimes, and 48 Quarters in Change";

            // Act
            result = money.ChangeOut(12M);

            // Assert
            Assert.AreEqual(expected, result);

            //

            // Arrange
            expected = $" You recieved 1 Nickles, 1 Dimes, and 1 Quarters in Change";

            // Act
            result = money.ChangeOut(.40M);

            // Assert
            Assert.AreEqual(expected, result);
            
            //

            // Arrange
            expected = $" You recieved 1 Nickles, 1 Dimes, and 1 Quarters in Change";

            // Act
            result = money.ChangeOut(-0.40M);

            // Assert
            Assert.AreEqual(expected, result);
           
            //

            // Arrange
            expected = $" You recieved 0 Nickles, 0 Dimes, and 0 Quarters in Change";

            // Act
            result = money.ChangeOut(0M);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}

