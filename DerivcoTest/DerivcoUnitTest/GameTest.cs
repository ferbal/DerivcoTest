using DerivcoTest.Models;
using DerivcoTest;
using System;
using DerivcoTest.Constants;
using NUnit.Framework;
using System.Collections.Generic;
using DerivcoTest.Services;

namespace DerivcoUnitTest
{    
    [TestFixture]
    public class GameTest
    {
        public static List<DeckConfigurationModel> GetTestCases
        {
            get
            {
                return new List<DeckConfigurationModel>()
                {
                    new DeckConfigurationModel() { MaxCardNumber = 1, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 0 },
                    new DeckConfigurationModel() { MaxCardNumber = 1, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 1 },
                    new DeckConfigurationModel() { MaxCardNumber = 13, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 0 },
                    new DeckConfigurationModel() { MaxCardNumber = 13, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 1 },
                    new DeckConfigurationModel() { MaxCardNumber = 20, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 0 },
                    new DeckConfigurationModel() { MaxCardNumber = 20, DecksCount = 1, Suites = Suites.GetSuitesList(), WildCardsCount = 1 },
                    new DeckConfigurationModel() { MaxCardNumber = 13, DecksCount = 2, Suites = Suites.GetSuitesList(), WildCardsCount = 0 },
                    new DeckConfigurationModel() { MaxCardNumber = 13, DecksCount = 2, Suites = Suites.GetSuitesList(), WildCardsCount = 1 }
                };                
            }
        }

        private bool IsValidResponse(string response)
        {
            return response.Equals("RESULT: Player 1 Win - Player 2 Lose")
                    || response.Equals("RESULT: Player 1 Lose - Player 2 Win")
                    || response.Equals("RESULT: Tie");
        }
                
        [TestCaseSource("GetTestCases")]        
        public void GameTest_StandardStrategy(DeckConfigurationModel deck)
        {            
            HighCardGame card = new HighCardGame();
            card.SetStraegy(new StandardStrategy(deck));

            var response = card.Play();

            Assert.IsTrue(IsValidResponse(response));                                     
        }

        [TestCaseSource("GetTestCases")]
        public void GameTest_AcceptTieStrategy(DeckConfigurationModel deck)
        {
            HighCardGame card = new HighCardGame();
            card.SetStraegy(new AcceptTieStrategy(deck));

            var response = card.Play();

            Assert.IsTrue(IsValidResponse(response));
        }

        [TestCaseSource("GetTestCases")]
        public void GameTest_ResolveTieStrategy(DeckConfigurationModel deck)
        {
            HighCardGame card = new HighCardGame();
            card.SetStraegy(new ResolveTieStrategy(deck));

            var response = card.Play();

            Assert.IsTrue(IsValidResponse(response));
        }

        [TestCaseSource("GetTestCases")]
        public void GameTest_ReplayTieStrategy(DeckConfigurationModel deck)
        {
            HighCardGame card = new HighCardGame();
            card.SetStraegy(new ReplayTieStrategy(deck));

            var response = card.Play();

            Assert.IsTrue(IsValidResponse(response));
        }


    }
}
