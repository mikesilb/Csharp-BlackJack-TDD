using NUnit.Framework;
using System;
using CardLibrary;

namespace CardLibrary.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void TestingCardConstructor()
        {
            Card card1 = new Card("♦", "2");
            Card card2 = new Card("♥", "2");
            Card card3 = new Card("♥", "10");
            Card card4 = new Card("♥", "K");


            Assert.AreNotEqual(card1.suit, "♥");
            Assert.AreEqual(card1.suit, "♦");
            Assert.AreNotEqual(card1.rank, "7");
            Assert.AreNotEqual(card1.rank, "K");
            Assert.AreEqual(card1.rank, "2");
            Assert.AreEqual(card1.output(), "(♦, 2)");
            Assert.AreNotEqual(card1.output(), "(♥, 2)");
            Assert.AreNotEqual(card1.output(), "(♦, 5)");
            Assert.AreEqual(card2.suit, "♥");
            Assert.AreEqual(card3.suit, "♥");
            Assert.AreEqual(card4.suit, "♥");
            Assert.AreEqual(card2.rank, "2");
            Assert.AreEqual(card3.rank, "10");
            Assert.AreEqual(card4.rank, "K");
        }
    }
}
