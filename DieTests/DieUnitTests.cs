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
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(20)]
        public void DieHasCustomSides(int sides)
        {
            Die d = new Die(sides);
            d.Name.Should().Be("d" + sides);
            d.NumSides.Should().Be(sides);
            d.CurrentSide.Should().BeInRange(1, sides);
        }
        [TestMethod]
        public void DieHasCustomName()
        {
            //not implemented
        }
        [TestMethod]
        public void SetSideUpChangesSide()
        {
            //not implemented
        }

        [TestMethod]
        public void NumSidesShouldNotBeNegative()
        {
            // not implemented
        }

        [TestMethod]
        public void RollSetSideCorrectly()
        {
            for (int i = 0; i < 100; i++)
            {
                def.Roll();
                def.CurrentSide.Should().BeInRange(1, 6);
            }
        }
    }
}
