using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Models
{
    public class DeckConfigurationModel
    {
        public int MaxCardNumber { get; set; }
        public int DecksCount { get; set; }
        public List<string> Suites { get; set; }
        public int WildCardsCount { get; set; }
    }
}