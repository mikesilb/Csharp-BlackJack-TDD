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
    }
//       let(:bj)
//     { Blackjack.new }
//     describe "Blackjack" do
//     it "a new deck exists and consists of 52 unique cards" do
//       expect(bj.game_data[:deck].class).to eq Deck
//       expect(bj.game_data[:deck].the_deck.length).to eq 52
//     end
//   end
//   describe "#initial_deal" do
//     it "will deal two cards to the player" do
//       bj.initial_deal
//       expect(bj.game_data[:player].cards.length).to eq 2

//     end
//     it "will deal two cards to the computer" do
//       bj.initial_deal
//       expect(bj.game_data[:computer].cards.length).to eq 2
//     end
//   end
//   describe "#hit" do
//     it "will deal one card and the score will increase by the value of the dealt card" do
//       bj.initial_deal
//       the_player_score = bj.game_data[:player_scores][-1]
//       the_computer_score = bj.game_data[:computer_scores][-1]
//       bj.hit(:player)
//       expect(bj.game_data[:player].cards.length).to eq 3
//       expect(bj.game_data[:computer].cards.length).to eq 2
//       expect(bj.game_data[:player_scores][-1]).to be > the_player_score
//       expect(bj.game_data[:computer_scores][-1]).to eq the_computer_score
//       bj.hit(:computer)
//       expect(bj.game_data[:computer].cards.length).to eq 3
//       expect(bj.game_data[:computer_scores][-1]).to be > the_computer_score
//     end
//   end
//   describe "#stand" do
//     it "will not deal any cards and score will remain the same" do
//       bj.initial_deal
//       the_player_score = bj.game_data[:player_scores][-1]
//       the_computer_score = bj.game_data[:computer_scores][-1]
//       bj.stand(:player)
//       expect(bj.game_data[:player].cards.length).to eq 2
//       expect(bj.game_data[:player_scores][-1]).to eq the_player_score

//       bj.stand(:computer)
//       expect(bj.game_data[:computer].cards.length).to eq 2
//       expect(bj.game_data[:computer_scores][-1]).to eq the_computer_score

//       bj.hit(:player)
//       bj.stand(:player)
//       expect(bj.game_data[:player].cards.length).to eq 3
//       expect(bj.game_data[:player_scores][-1]).to be > the_player_score
//     end
//   end
//   describe "#dealer_moves" do
//     it "continues hitting until dealer's score is at least 17" do
//       bj.initial_deal
//       bj.stand(:player)
//       bj.dealer_moves
//       last_score = bj.game_data[:computer_scores][-2]
//       first_score = bj.game_data[:computer_scores][0]
//       if bj.game_data[:computer_scores].length > 1 && first_score< 17
//         expect(last_score).to be< 17
//       end
//     end
//     it "outputs 'Bust! You win!' when dealer's score exceeds 21" do
//       bj.initial_deal
//       the_computer_score = bj.game_data[:computer_scores][-1]
//       bj.stand(:player)
//       bj.dealer_moves
//       if bj.game_data[:computer_scores][-1] > 21
//         expect(bj.computer_bust_output).to eq "Bust! You Win"
//       end
//     end
//     it "accurately asserts player win/loss/tie" do
//       bj.initial_deal
//       the_computer_score = bj.game_data[:computer_scores][-1]
//       bj.stand(:player)
//       bj.dealer_moves
//       if bj.game_data[:computer_scores][-1] > 21 || bj.game_data[:player_scores][-1] > bj.game_data[:computer_scores][-1]
//         expect(bj.game_data[:player_win_loss]).to eq "win"
//       elsif bj.game_data[:computer_scores][-1] == bj.game_data[:player_scores][-1]
//         expect(bj.game_data[:player_win_loss]).to eq "tie"
//       else
//         expect(bj.game_data[:player_win_loss]).to eq "loss"
//       end
}
