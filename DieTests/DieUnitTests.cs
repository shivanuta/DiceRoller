using DiceRoller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;


namespace DieTests
{
    [TestClass]
    public class DieUnitTests
    {
        private Die def = new Die();
        [TestMethod]
        public void DieNotNull()
        {
            Die d = new Die();
            d.Should().NotBeNull();
        }

        [TestMethod]
        public void DieHasDefaultValues()
        {
            /*
             * Default value should be:
             * name:....d6
             /* numsides:.....6 
            */
            def.Name.Should().Be("d6");
            def.NumSides.Should().Be(6);
            def.CurrentSide.Should().BeInRange(1, 6);
        }
        [TestMethod]
        [DataRow(3, 3)]
        [DataRow(4, 4)]
        [DataRow(8, 8)]
        [DataRow(10, 10)]
        [DataRow(12, 12)]
        [DataRow(20, 20)]
        public void DieHasCustomSides(int sides, int expected)
        {
            Die d = new Die(8);
            d.Name.Should().Be("d8");
            d.NumSides.Should().Be(8);
            d.CurrentSide.Should().BeInRange(1, 8);
        }
    }
}
