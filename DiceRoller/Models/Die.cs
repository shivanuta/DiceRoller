using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    public class Die
    {
        //name ,type,or colout of the die
        private string Name { get; set; }

        //how many sides are the die
        private int NumSides { get; set; }

        //which number is currently up
        private int CurrentSide { get; set; }

        public Die()
        {
            NumSides = 6;
            Name = "d6";
            Roll();
        }
        public Die(int numSides)
        {
            NumSides = numSides;
            Name = "d" + numSides;
            Roll();
        }
        public Die(String name, int numSides)
        {
            NumSides = numSides;
            Name = name;
            Roll();
        }
        public void SetSideUp(int newSideUp)
        {
            if (newSideUp >= 1 && newSideUp <= NumSides)
                this.CurrentSide = newSideUp;
        }
        public void Roll()
        {
            Random r = new Random();
            CurrentSide = r.Next(NumSides) + 1;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetNumSides()
        {
            return NumSides;
        }
        public int GetCurrentSide()
        {
            return CurrentSide;
        }
    }
}
