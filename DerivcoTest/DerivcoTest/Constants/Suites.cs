using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Constants
{
    public struct Suites
    {
        public const string Hearts = "HEARTS";
        public const string Clubs = "CLUBS";
        public const string Spades = "SPADES";
        public const string Diamonds = "DIAMONDS";

        public const string Wildcard = "WILD_CARD";

        public static int GetSuiteTies(string suite)
        {
            switch (suite)
            {
                case Hearts:
                    return 1;
                    break;
                case Clubs:
                    return 2;
                    break;
                case Spades:
                    return 3;
                    break;
                case Diamonds:
                    return 4;
                    break;
                default:
                    return 10;
                    break;
            }
        }

        public static List<string> GetSuitesList()
        {
            return new List<string>() { Suites.Clubs, Suites.Diamonds, Suites.Hearts, Suites.Spades };            
        }
    }

    
}
