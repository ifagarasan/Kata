using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccount;

using Moq;
using System.Collections.Generic;

namespace BankAccountTests
{
    [TestClass]
    public class DateGeneratorFunctionality
    {
        string today = "25/12/2014";

        [TestMethod]
        public void TodayReturnsCurrentDateInDDMMYYYY()
        {
            TestableDateGenerator dateGenerator = new TestableDateGenerator();

            Assert.AreEqual(today, dateGenerator.TodayAsString());
        }

        internal class TestableDateGenerator : DateGenerator
        {
            protected override DateTime Today
            {
                get
                {
                    return new DateTime(2014, 12, 25);
                }
            }
        }
    }
}
