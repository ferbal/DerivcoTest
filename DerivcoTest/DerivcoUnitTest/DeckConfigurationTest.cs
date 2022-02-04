using DerivcoTest;
using DerivcoTest.Constants;
using DerivcoTest.Models;
using DerivcoTest.Services;
using NUnit.Framework;
using System;

namespace DerivcoUnitTest
{
    [TestFixture]
    public class DeckConfigurationTest
    {       
        [Test]
        public void TestNoDeckConfig()
        {
            try
            {
                DeckConfigurationModel deck = null;

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "The Deck Configuration should be setted.");
            }            
        }
        
        [Test]
        public void TestCardNumberNotAllowed()
        {
            try
            {
                DeckConfigurationModel deck = new DeckConfigurationModel() {
                    MaxCardNumber = int.MaxValue,
                };

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The value for the Max card number is not allowed");
            }
        }

        [Test]
        public void TestNoCardNumber()
        {
            try
            {
                DeckConfigurationModel deck = new DeckConfigurationModel() { };

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The value for the Max card number should be greater than 0");
            }
        }

        [Test]
        public void TestSuitesList()
        {
            try
            {
                DeckConfigurationModel deck = new DeckConfigurationModel() { 
                    MaxCardNumber = 13
                };

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The Suites list should have at least 1 suite defined.");
            }
        }

        [Test]
        public void TestDecksCount()
        {
            try
            {
                DeckConfigurationModel deck = new DeckConfigurationModel() {
                    MaxCardNumber = 13,
                    Suites = Suites.GetSuitesList(),
                };

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The number of decks should be equals or greater than 1.");
            }
        }

        [Test]
        public void TestWingCard()
        {
            try
            {
                DeckConfigurationModel deck = new DeckConfigurationModel()
                {
                    MaxCardNumber = 13,
                    Suites = Suites.GetSuitesList(),
                    DecksCount = 1,
                };

                HighCardGame card = new HighCardGame();
                card.SetStraegy(new ReplayTieStrategy(deck));

                card.Play();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The number of Wild cards should be equals or greater than 0.");
            }
        }
    }
}
