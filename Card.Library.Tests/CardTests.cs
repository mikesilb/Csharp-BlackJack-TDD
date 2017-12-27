using NUnit.Framework;
using System;
using CardLibrary;

namespace CardLibrary.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void TestCases()
        {
            Card card1 = new Card("♦", "2");
            Card card2 = new Card("♥", "2");
            Card card3 = new Card("♥", "10");
            Card card4 = new Card("♥", "K");


            Assert.AreNotEqual(card1.GetSuit(), "♥");
            Assert.AreEqual(card1.GetSuit(), "♦");
            Assert.AreNotEqual(card1.GetRank(), "7");
            Assert.AreNotEqual(card1.GetRank(), "K");
            Assert.AreEqual(card1.GetRank(), "2");
            Assert.AreEqual(card2.GetSuit(), "♥");
            Assert.AreEqual(card3.GetSuit(), "♥");
            Assert.AreEqual(card4.GetSuit(), "♥");
            Assert.AreEqual(card2.GetRank(), "2");
            Assert.AreEqual(card3.GetRank(), "10");
            Assert.AreEqual(card4.GetRank(), "K");
        }
    }
}
