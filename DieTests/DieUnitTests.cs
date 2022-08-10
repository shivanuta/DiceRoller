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
    }
}
