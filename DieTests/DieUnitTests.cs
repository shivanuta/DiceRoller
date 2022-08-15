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
        [TestCategory("Defaults")]
        public void DieNotNull()
        {
            def.Should().NotBeNull();
        }

        [TestMethod]
        [TestCategory("Defaults")]
        public void DieHasDefaultValues()
        {
            /*
             * Default value should be:
             * name:....d6
             /* numsides:.....6 
            */
            def.GetName().Should().Be("d6");
            def.GetNumSides().Should().Be(6);
            def.GetCurrentSide().Should().BeInRange(1, 6);
        }
        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3, "d3")]
        [DataRow(4, "d4")]
        [DataRow(8, "d8")]
        [DataRow(10, "d10")]
        [DataRow(12, "d12")]
        [DataRow(20, "d20")]
        public void DieHasCustomSides(int sides, string name)
        {
            Die d = new Die(sides);
            d.GetName().Should().Be(name);
            d.GetNumSides().Should().Be(sides);
            d.GetCurrentSide().Should().BeInRange(1, sides);
        }
        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(20)]
        public void RollSetsSideCorrectlyForCustomSides(int sides )
        {
            Die d = new Die(sides);
            for (int i = 0; i < 1000; i++)
            {
                d.Roll();
                d.GetCurrentSide().Should().BeInRange(1, sides);
            }
        }
        [TestMethod]
        [TestCategory("CustomName")]
        [DataRow("d3", 3)]
        [DataRow("d4", 4)]
        [DataRow("d8", 8)]
        [DataRow("d10", 10)]
        [DataRow("d12", 12)]
        [DataRow("d20", 20)]
        public void DieHasCustomName(string name, int sides)
        {
            Die d = new Die(name, sides);
            d.GetName().Should().Be(name);
            d.GetNumSides().Should().Be(sides);
            d.GetCurrentSide().Should().BeInRange(1, sides);
        }
        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        [DataRow(12, 2)]
        [DataRow(20, 2)]
        public void SetSideUpChangesSide(int sides, int newSide)
        {
            Die d = new Die(sides);
            d.SetSideUp(newSide);
            d.GetCurrentSide().Should().Be(newSide);
        }
        [TestMethod]
        [TestCategory("SetMethods")]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        [DataRow(12, 2)]
        [DataRow(20, 2)]
        public void SetSideUpSetsValidSide(int sides, int newSide)
        {
            Die d = new Die(sides);
            d.SetSideUp(newSide);
            d.GetCurrentSide().Should().BeInRange(1, sides);
            if (newSide >= 1 && newSide <= sides)
                d.GetCurrentSide().Should().Be(newSide);
        }
        [TestMethod]
        [TestCategory("CustomSides")]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(20)]
        public void NumSidesShouldNotBeNegative(int sides)
        {
            Die d = new Die(sides);
            d.GetNumSides().Should().BeGreaterThan(0);
        }
        [TestMethod]
        [TestCategory("GetMethods")]
        public void GetDefaultNameReturnsValue()
        {
            def.GetName().Should().BeOfType<string>();
            def.GetName().Should().Be("d6");
        }
        [TestMethod]
        [TestCategory("GetMethods")]
        public void GetDefaultNumSidesReturnsValue()
        {
            def.GetNumSides().Should().Be(6);
        }
        [TestCategory("GetMethods")]
        public void GetCurrentSideReturnsValue()
        {
            def.GetNumSides().Should().BeInRange(1, 6);
        }
    }
}
