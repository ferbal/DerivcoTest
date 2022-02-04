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
     * This Strategy will accept the possibility of a tie if the cards has the same number but we will resolve this tie throwing another card for each player.
     * In this case, we are generating the deck only once at the begining, so that the used cards are not repeated.
     */
    public class ReplayTieStrategy : HighCardBase, IHighCardStrategy
    {       
        public ReplayTieStrategy(DeckConfigurationModel deckConfig) : base(deckConfig)
        {            
            this.GenerateDeck();
        }
        public int Play()
        {
            this.TakeCardsForPlayers();

            if (this.GetCardPlayer1().GetNumber() == this.GetCardPlayer2().GetNumber())
                return Play();

            return this.GetCardPlayer1().GetNumber() > this.GetCardPlayer2().GetNumber() ? 1 : -1;
        }
    }
}
