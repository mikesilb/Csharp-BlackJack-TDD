using NUnit.Framework;
using System;
using System.Collections.Generic;
using CardLibrary;
using HandLibrary;
namespace HandLibrary.Tests
{
    
    [TestFixture]
    public class HandTests
    {
        
        [Test]
        public void TestingCalculateHandTwoNums()
        { 
            List<Card> cardCollection1 = new List<Card> { new Card("♦", "2"), new Card("♥", "3") };
            Hand hand1 = new Hand(cardCollection1);
            List<Card> cardCollection2 = new List<Card> { new Card("♥", "2"), new Card("♦", "3") };
            Hand hand2 = new Hand(cardCollection2);
            List<Card> cardCollection3 = new List<Card> { new Card("♠", "2"), new Card("♣", "3") };
            Hand hand3 = new Hand(cardCollection3);
            List<Card> cardCollection4 = new List<Card> { new Card("♠", "10"), new Card("♣", "9") };
            Hand hand4 = new Hand(cardCollection4);
            List<Card> cardCollection5 = new List<Card> { new Card("♠", "9"), new Card("♣", "10") };
            Hand hand5 = new Hand(cardCollection5); 

            Assert.AreEqual(hand1.CalculateHand(), 5);
            Assert.AreEqual(hand2.CalculateHand(), 5);
            Assert.AreEqual(hand3.CalculateHand(), 5);
            Assert.AreEqual(hand4.CalculateHand(), 19);
            Assert.AreEqual(hand5.CalculateHand(), 19);
        }
    

        [Test]
        public void TestingCalculateHandWithFaceCards()
        {
            Hand hand6 = new Hand(new List<Card> { new Card("♦", "6"), new Card("♥", "J")}); 
            Hand hand7 = new Hand(new List<Card> { new Card("♦", "6"), new Card("♥", "Q")}); 
            Hand hand8 = new Hand(new List<Card> { new Card("♦", "6"), new Card("♥", "K")}); 

            Assert.AreEqual(hand6.CalculateHand(), 16);
            Assert.AreEqual(hand7.CalculateHand(), 16);
            Assert.AreEqual(hand8.CalculateHand(), 16);
        }

        [Test]
        public void TestingCalculateHandWithAces()
        {
            Hand hand9 = new Hand(new List<Card> { new Card("♦", "6"), new Card("♥", "A") });
            Hand hand10 = new Hand(new List<Card> { new Card("♦", "10"), new Card("♥", "A") });
            Hand hand11 = new Hand(new List<Card> { new Card("♦", "Q"), new Card("♥", "A") });
            Hand hand12 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "6") });
            Hand hand13 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "10") });
            Hand hand14 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "Q") });
            Hand hand15 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "A") });
            Hand hand16 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "6"), new Card("♠", "A") });
            Hand hand17 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "A"), new Card("♠", "A") });
            Hand hand18 = new Hand(new List<Card> { new Card("♥", "A"), new Card("♦", "A"), new Card("♠", "A"), new Card("♣", "A") });

            Assert.AreEqual(hand9.CalculateHand(), 17);
            Assert.AreEqual(hand10.CalculateHand(), 21);
            Assert.AreEqual(hand11.CalculateHand(), 21);
            Assert.AreEqual(hand12.CalculateHand(), 17);
            Assert.AreEqual(hand13.CalculateHand(), 21);
            Assert.AreEqual(hand14.CalculateHand(), 21);
            Assert.AreEqual(hand15.CalculateHand(), 12);
            Assert.AreEqual(hand16.CalculateHand(), 18);
            Assert.AreEqual(hand17.CalculateHand(), 13);
            Assert.AreEqual(hand18.CalculateHand(), 14);
        }
    }
}
