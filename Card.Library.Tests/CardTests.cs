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

//       expect(card2.suit).to eq "♥"
//       expect(card3.suit).to eq "♥"
//       expect(card4.suit).to eq "♥"
//       expect(card2.rank).to eq 2
//       expect(card3.rank).to eq 10
//       expect(card4.rank).to eq "K"
            //Assert.Pass();

            // public void Buzzer_WhenDefault_ReturnsInput(
            // [Values(1, 2, 4, 7, 8, 11, 13, 14, 16, 17, 19)] int input)
            // {
            //     string output = FizzBuzzer.GetValue(input);
            //     Assert.AreEqual(input.ToString(), output);

            // }

//             require "spec_helper"

// RSpec.describe Card do
//                 describe "card" do
//                 let(:card1) { Card.new("♦",2) }
//             let(:card2) { Card.new("♥",2) }
//             let(:card3) { Card.new("♥",10) }
//             let(:card4) { Card.new("♥","K") }
//             it "generates a distinctive suit and rank for each card" do
//                 expect(card1.suit).not_to eq "♥"
//       expect(card1.suit).to eq "♦"
//       expect(card1.rank).not_to eq 7
//       expect(card1.rank).not_to eq "K"
//       expect(card1.rank).to eq 2
//       expect(card2.suit).to eq "♥"
//       expect(card3.suit).to eq "♥"
//       expect(card4.suit).to eq "♥"
//       expect(card2.rank).to eq 2
//       expect(card3.rank).to eq 10
//       expect(card4.rank).to eq "K"
//     end
//   end
// end
        }
    }
}
