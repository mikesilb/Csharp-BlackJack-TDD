using NUnit.Framework;
using CardLibrary;
using System.Collections.Generic;
using System;

namespace DeckLibrary.Tests
{
    [TestFixture]
    public class DeckTests
    {
        Deck deck1 = new Deck();
        Deck deck2 = new Deck();
        Deck deck3 = new Deck();

        [Test]
        public void TestingDeckConstructor()
        {
            Assert.AreEqual(deck1.theDeck.Length, 52);
            Assert.AreEqual(deck1.theDeck[0].output(), "(♦, 2)");
        }

        [Test]
        public void TestingShuffle()
        {
            Assert.AreEqual(deck1.theDeck.Length, 52);
            Assert.AreEqual(deck1.theDeck[0].output(), "(♦, 2)");
            deck1.Shuffle();
            Assert.AreEqual(deck1.theDeck.Length, 52);
            Assert.AreNotEqual(deck1.theDeck[0].output(), "(♦, 2)");
        }

        [Test]
        public void TestingDeal()
        {
            Card topCard = deck2.theDeck[0];
            Card bottomCard = deck2.theDeck[51];
            Card theDealedCard = deck2.Deal();
            Assert.AreEqual(theDealedCard.output(), topCard.output());
            Assert.AreNotEqual(theDealedCard.output(), bottomCard.output());
        }
    }
}
