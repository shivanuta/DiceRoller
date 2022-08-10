using DiceRoller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;


namespace DieTests
{
    [TestClass]
    public class DieUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Die d = new Die();
            d.Should().NotBeNull();
        }
    }
}
