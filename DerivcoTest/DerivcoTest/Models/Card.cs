using DerivcoTest.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Models
{
    public class Card
    {
        private string Suite;
        private int Number;

        public Card(string suite, int number)
        {
            this.Suite = suite;
            this.Number = number;
        }

        public int GetNumber()
        {
            return this.Number;
        }

        public string GetSuite()
        {
            return this.Suite;
        }
        
    }
}
