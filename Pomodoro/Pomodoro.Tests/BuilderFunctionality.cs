using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Pomodoro.Exceptions;

namespace Pomodoro.Tests
{
    [TestClass]
    public class BuilderFunctionality
    {
        Builder builder;
        List<ICycle> cycles;

        [TestInitialize]
        public void Setup()
        {
            builder = new Builder();
            cycles = builder.Build();
        }

        [TestMethod]
        public void ReturnsANonNullList()
        {
            Assert.IsNotNull(cycles);
        }

        [TestMethod]
        public void ListHasEightElements()
        {
            Assert.AreEqual(8, cycles.Count);
        }

        [TestMethod]
        public void ListHasNonNullElements()
        {
            foreach (ICycle cycle in cycles)
                Assert.IsNotNull(cycle);
        }

        [TestMethod]
        public void EvenItemsArePomodoroCycles()
        {
            for (int i = 0; i < 7; i += 2)
                Assert.IsInstanceOfType(cycles[i], typeof(PomodoroCycle));
        }

        [TestMethod]
        public void FirstThreeOddItemsAreShortPauses()
        {
            for (int i = 1; i < 7; i += 2)
                Assert.IsInstanceOfType(cycles[i], typeof(ShortPause));
        }
    }
}
