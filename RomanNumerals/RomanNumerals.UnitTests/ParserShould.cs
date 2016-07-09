using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static RomanNumerals.Parser;

namespace RomanNumerals.UnitTests
{
    [TestClass]
    public class ParserShould
    {
        [TestMethod]
        public void ParseNumberToRomanNumerals()
        {
            AreEqual("I", Parse(1));
            AreEqual("II", Parse(2));
            AreEqual("III", Parse(3));
            AreEqual("V", Parse(5));
            AreEqual("VI", Parse(6));
            AreEqual("VII", Parse(7));
            AreEqual("VIII", Parse(8));
            AreEqual("IV", Parse(4));
            AreEqual("IX", Parse(9));

            AreEqual("X", Parse(10));
            AreEqual("L", Parse(50));
            AreEqual("XL", Parse(40));
            AreEqual("XC", Parse(90));

            AreEqual("C", Parse(100));
            AreEqual("D", Parse(500));
            AreEqual("CD", Parse(400));
            AreEqual("CM", Parse(900));

            AreEqual("M", Parse(1000));

            AreEqual("MMMCDXCIX", Parse(3499));

            AreEqual("LIV", Parse(54));
            AreEqual("LIX", Parse(59));
            AreEqual("DIV", Parse(504));
            AreEqual("MIV", Parse(1004));
            AreEqual("MIX", Parse(1009));
            AreEqual("MLIX", Parse(1059));
            AreEqual("MCIX", Parse(1109));
        }
    }
}
