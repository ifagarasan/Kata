using Microsoft.VisualStudio.TestTools.UnitTesting;
using parrot.Parrot;
using parrot.Parrot.Type;

namespace parrot
{
    [TestClass]
    public class ParrotTest
    {
        [TestMethod]
        public void GetSpeedOfEuropeanParrot()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new European());
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new African(1));
            Assert.AreEqual(3.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new African(2));
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new African(0));
            Assert.AreEqual(12.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new NorwegianBlue(0, true));
            Assert.AreEqual(0.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new NorwegianBlue(1.5, false));
            Assert.AreEqual(18.0, parrot.GetSpeed());
        }

        [TestMethod]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            Parrot.Parrot parrot = new Parrot.Parrot(new NorwegianBlue(4, false));
            Assert.AreEqual(24.0, parrot.GetSpeed());
        }
    }
}
