using DerivcoTest.Constants;
using DerivcoTest.Exceptions;
using DerivcoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DerivcoTest.Services
{
    public class HighCardBase
    {
        private Card card1;
        private Card card2;        
        private List<Card> Deck;
        private Random Rnd;
        private DeckConfigurationModel DeckConfig;

        public HighCardBase(DeckConfigurationModel deckConfig)
        {
            ValidateDeckConfiguration(deckConfig);
            this.Rnd = new Random();
            this.Deck = null;            
        }

        public void SetDeckConfiguration(DeckConfigurationModel deckConfig)
        {
            ValidateDeckConfiguration(deckConfig);
        }

        //This method will generate a deck based on the Deck Config
        public void GenerateDeck()
        {
            var deck = new List<Card>();

            for (int d = 1; d <= this.DeckConfig.DecksCount; d++)
            {
                foreach (var suite in this.DeckConfig.Suites)
                {
                    for (int i = 1; i <= this.DeckConfig.MaxCardNumber; i++)
                    {
                        deck.Add(new Card(suite, i));
                    }
                }
            }

            for (int w = 0; w < this.DeckConfig.WildCardsCount; w++)
                deck.Add(new Card(Suites.Wildcard, int.MaxValue));

            this.Deck = deck.OrderBy(item => this.Rnd.Next()).ToList();
        }

        /*
         This method will validate the values of the Deck Configuration variable
         to generate a correct and valid deck for the user.
        */
        public void ValidateDeckConfiguration(DeckConfigurationModel deckConfig)
        {
            if (deckConfig == null)
                throw new Exception("The Deck Configuration should be setted.");

            if (deckConfig.MaxCardNumber == null || deckConfig.MaxCardNumber <= 0)
                throw new Exception("The value for the Max card number should be greater than 0");

            if (deckConfig.MaxCardNumber == int.MaxValue)
                throw new Exception("The value for the Max card number is not allowed");

            if (deckConfig.Suites == null || deckConfig.Suites.Count == 0)
                throw new Exception("The Suites list should have at least 1 suite defined.");

            if (deckConfig.DecksCount == null || deckConfig.DecksCount == 0)
                throw new Exception("The number of decks should be equals or greater than 1.");

            if (deckConfig.WildCardsCount == null || deckConfig.WildCardsCount < 0)
                throw new Exception("The number of Wild cards should be equals or greater than 0.");

            this.DeckConfig = deckConfig;
        }

        /*
         * This method will deals one card for the player one and one card for the player two.         
         */
        public void TakeCardsForPlayers()
        {
            this.card1 = this.TakeCard();
            
            if (this.card1.GetSuite() == Suites.Wildcard)
                Console.WriteLine($"Player 1 has a Wild Card!");
            else
                Console.WriteLine($"Player 1 has {this.card1.GetNumber()} of {this.card1.GetSuite()}");

            this.card2 = this.TakeCard();

            if (this.card2.GetSuite() == Suites.Wildcard)
                Console.WriteLine($"Player 2 has a Wild Card!");
            else
                Console.WriteLine($"Player 2 has {this.card2.GetNumber()} of {this.card2.GetSuite()}");

        }

        public Card GetCardPlayer1()
        {
            return this.card1;
        }

        public Card GetCardPlayer2()
        {
            return this.card2;
        }
        
        /*
         * This method remove one card from the deck and return this card for a specific player.
         */
        public Card TakeCard()
        {
            if (this.Deck == null)
                throw new Exception("There is no Deck generated");
            
            if (this.Deck.Count == 0)
                throw new NoMoreCardsException();

            var index = this.Rnd.Next(0, this.Deck.Count -1);
            var card = this.Deck.ElementAt(index);

            this.Deck.Remove(card);

            return card;
        }
    }
}
