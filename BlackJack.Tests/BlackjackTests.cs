using NUnit.Framework;
using System;
using CardLibrary;
using DeckLibrary;
using HandLibrary;
using BlackJackTDD;
using System.Collections.Generic;
namespace BlackJack.Tests
{
    [TestFixture]
    public class BlackJackTests
    {
        [Test]
        public void TestBlackjackConstructor()
        {
            Blackjack testBj = new Blackjack();
            Assert.AreEqual(testBj.GetGameDataDeck()["Game Deck"].theDeck.Length, 52);
            Assert.AreNotEqual(testBj.GetGameDataDeck()["Game Deck"].theDeck[0].output(), "(♦, 2)");
        }
        [Test]
        public void TestInitialDeal()
        {
            Blackjack testBj = new Blackjack();
            Assert.AreEqual(testBj.GetGameDataHand()["Player Hand"].cardCollection.Count, 0);
            Assert.AreEqual(testBj.GetGameDataHand()["Dealer Hand"].cardCollection.Count, 0);
            testBj.InitialDeal();
            Assert.AreEqual(testBj.GetGameDataHand()["Player Hand"].cardCollection.Count, 2);
            Assert.AreEqual(testBj.GetGameDataHand()["Dealer Hand"].cardCollection.Count, 2);
        }
        [Test]
        public void TestHit()
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            int thePlayerScore = testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1];
            int theDealerScore = testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1];
            testBj.Hit("Player");
            Assert.AreEqual(testBj.GetGameDataHand()["Player Hand"].cardCollection.Count, 3);
            Assert.AreEqual(testBj.GetGameDataHand()["Dealer Hand"].cardCollection.Count, 2);
            Assert.Greater(testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1], thePlayerScore);
            Assert.AreEqual(testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1], theDealerScore);
            testBj.Hit("Dealer");
            Assert.AreEqual(testBj.GetGameDataHand()["Dealer Hand"].cardCollection.Count, 3);
            Assert.Greater(testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1], theDealerScore);
        }
        [Test]
        public void TestStand()
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            int thePlayerScore = testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1];
            int theDealerScore = testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1];
            testBj.Stand("Player");
            Assert.AreEqual(testBj.GetGameDataHand()["Player Hand"].cardCollection.Count, 2);
            Assert.AreEqual(testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1], thePlayerScore);
            testBj.Stand("Dealer");
            Assert.AreEqual(testBj.GetGameDataHand()["Dealer Hand"].cardCollection.Count, 2);
            Assert.AreEqual(testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1], thePlayerScore);
            testBj.Hit("Player");
            testBj.Stand("Player");
            Assert.AreEqual(testBj.GetGameDataHand()["Player Hand"].cardCollection.Count, 3);
            Assert.Greater(testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1], thePlayerScore);
        }
        [Test]
        public void TestDealerMovesUntilDealerScoreAt17()
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            testBj.Stand("Player");
            testBj.DealerMoves();
            int lastScore = testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 2];
            int firstScore = testBj.GetGameDataListInt()["Player Score"][0];
            if (testBj.GetGameDataListInt()["Dealer Score"].Count > 1 && firstScore < 17)
            {
                Assert.Less(lastScore,17);
            }
        }
        [Test]
        public void TestDealerMovesStopBust()
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            int theComputerScore = testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1];
            testBj.Stand("Player");
            testBj.DealerMoves();
            if (testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1] > 21)
            {
                Assert.AreEqual(testBj.GetComputerBustOutput(), "Bust! You Win");
            }
        }

        [Test]
        public void TestDealerMovesAssertWinLossTie()
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            int theComputerScore = testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1];
            testBj.Stand("Player");
            testBj.DealerMoves();
            if (testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1] > 21 || testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1] > testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1])
            {
                Assert.AreEqual(testBj.gameDataString["Win Lose or Draw"], "win");
            }
            else if (testBj.GetGameDataListInt()["Player Score"][testBj.GetGameDataListInt()["Player Score"].Count - 1] == testBj.GetGameDataListInt()["Dealer Score"][testBj.GetGameDataListInt()["Dealer Score"].Count - 1])
            {
                Assert.AreEqual(testBj.gameDataString["Win Lose or Draw"], "tie");
            }
            else
            {
                Assert.AreEqual(testBj.gameDataString["Win Lose or Draw"], "loss");
            }
        }

    }
}
