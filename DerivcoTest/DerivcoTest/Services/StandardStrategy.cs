using DerivcoTest.Constants;
using DerivcoTest.Interfaces;
using DerivcoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivcoTest.Services
{
    /*
     * This is the main strategy we are removing the configuration of the original deck to an specific deck with one Ties and 52 cards.
     * When we take 2 cards from the deck for each player, one of this cards will be greater than the other always returning Win or Lose.
     * In this case, the deck will be generated each time than the players wants to play
     */
    public class StandardStrategy : HighCardBase, IHighCardStrategy
    {
        public StandardStrategy(DeckConfigurationModel deckConfig) : base(deckConfig)
        {
            deckConfig.Suites = new List<string>(){ Suites.Hearts};
            deckConfig.MaxCardNumber = 52;
            this.SetDeckConfiguration(deckConfig);
        }        

        public int Play()
        {
            this.GenerateDeck();

            this.TakeCardsForPlayers();            

            return this.GetCardPlayer1().GetNumber() > this.GetCardPlayer2().GetNumber() ? 1 : -1;
        }
       
    }
}
