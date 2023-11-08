using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT
{
    class ElevensBoard
    {

        private static readonly int BOARD_SIZE = 9;

        /**
         * The ranks of the cards for this game to be sent to the deck.
         */
        private static readonly String[] RANKS =
        {"ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "JO"};

        /**
         * The suits of the cards for this game to be sent to the deck.
         */
        private static readonly String[] SUITS =
            {"spades", "hearts", "diamonds", "clubs"};

        /**
         * The values of the cards for this game to be sent to the deck.
         */
        private static readonly int[] POINT_VALUES =
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0, 0, 0, 0};


        /**
         * The cards on this board.
         */
        private Card[] cards;

        /**
         * The deck of cards being used to play the current game.
         */
        private Deck deck;

        /**
         * Flag used to control debugging print statements.
         */
        private static readonly bool I_AM_DEBUGGING = false;


        /**
         * Creates a new <code>ElevensBoard</code> instance.
         */
        public ElevensBoard()
        {
            cards = new Card[BOARD_SIZE];
            deck = new Deck(RANKS, SUITS, POINT_VALUES);
            if (I_AM_DEBUGGING)
            {
                Console.WriteLine(deck);
                Console.WriteLine("----------");
            }
            dealMyCards();
        }

        /**
         * Start a new game by shuffling the deck and
         * dealing some cards to this board.
         */
        public void newGame()
        {
            deck.shuffle();
            dealMyCards();
        }

        /**
         * Accesses the size of the board.
         * Note that this is not the number of cards it contains,
         * which will be smaller near the end of a winning game.
         * @return the size of the board
         */
        public int size()
        {
            return cards.Length;
        }

        /**
         * Determines if the board is empty (has no cards).
         * @return true if this board is empty; false otherwise.
         */
        public bool isEmpty()
        {
            for (int k = 0; k < cards.Length; k++)
            {
                if (cards[k] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Deal a card to the kth position in this board.
         * If the deck is empty, the kth card is set to null.
         * @param k the index of the card to be dealt.
         */
        public void deal(int k)
        {
            cards[k] = deck.deal();
        }

        /**
         * Accesses the deck's size.
         * @return the number of undealt cards left in the deck.
         */
        public int deckSize()
        {
            return deck.getSize();
        }

        /**
         * Accesses a card on the board.
         * @return the card at position k on the board.
         * @param k is the board position of the card to return.
         */
        public Card cardAt(int k)
        {
            return cards[k];
        }


        public Card[] getCards()
        {
            return cards;
        }
        /**
         * Replaces selected cards on the board by dealing new cards.
         * @param selectedCards is a list of the indices of the
         *        cards to be replaced.
         */
        public void replaceSelectedCards(List<int> selectedCards)
        {
            foreach (int k in selectedCards)
            {
                deal(k);
            }
        }

        /**
         * Gets the indexes of the actual (non-null) cards on the board.
         *
         * @return a List that contains the locations (indexes)
         *         of the non-null entries on the board.
         */
        public List<int> cardIndexes()
        {
            List<int> selected = new List<int>();
            for (int k = 0; k < cards.Length; k++)
            {
                if (cards[k] != null)
                {
                    selected.Add(k);
                }
            }
            return selected;
        }

        /**
         * Generates and returns a string representation of this board.
         * @return the string version of this board.
         */
        public String toString()
        {
            String s = "";
            for (int k = 0; k < cards.Length; k++)
            {
                s = s + k + ": " + cards[k] + "\n";
            }
            return s;
        }

        /**
         * Determine whether or not the game has been won,
         * i.e. neither the board nor the deck has any more cards.
         * @return true when the current game has been won;
         *         false otherwise.
         */
        public bool gameIsWon()
        {
            if (deck.isEmpty())
            {
                foreach (Card c in cards)
                {
                    if (c != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /**
          * Deal cards to this board to start the game.
          */
        private void dealMyCards()
        {
            for (int k = 0; k < cards.Length; k++)
            {
                cards[k] = deck.deal();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////// DO NOT CHANGE ANY METHODS ABOVE THIS LINE.
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /////  ONLY ALTER THE METHODS BELOW THIS LINE.
        ////////////////////////////////////////////////////////////////////////////////////////////////////



        /**
         * Determines if the selected cards form a valid group for removal.
         * In Elevens, the legal groups are (1) a pair of non-face cards
         * whose values add to 11, and (2) a group of three cards consisting of
         * a jack, a queen, and a king in some order.
         * @param selectedCards the list of the indices of the selected cards.
         * @return true if the selected cards form a valid group for removal;
         *         false otherwise.
         */
        public bool isLegal(List<int> selectedCards)
        {
            if (selectedCards.Count() == 2)
            {
                return containsPairSum11(selectedCards);
            }
            else if (selectedCards.Count() == 3)
            {
                return containsJQK(selectedCards);
            }
            else
            {
                return false;
            }
        }


        /**
         * Determine if there are any legal plays left on the board.
         * In Elevens, there is a legal play if the board contains
         * (1) a pair of non-face cards whose values add to 11, or (2) a group
         * of three cards consisting of a jack, a queen, and a king in some order.
         * @return true if there is a legal play left on the board;
         *         false otherwise.
         */
        public bool anotherPlayIsPossible()
        {
            List<int> cIndexes = cardIndexes();
            return containsPairSum11(cIndexes) || containsJQK(cIndexes);
        }


        /**
          * Check for an 11-pair in the selected cards.
          * @param selectedCards selects a subset of this board.  It is list
          *                      of indexes into this board that are searched
          *                      to find an 11-pair.
          * @return true if the board entries in selectedCards
          *              contain an 11-pair; false otherwise.
          */
        private bool containsPairSum11(List<int> selectedCards)
        {
            for (int sk1 = 0; sk1 < selectedCards.Count(); sk1++)
            {
                int k1 = selectedCards[sk1];
                for (int sk2 = sk1 + 1; sk2 < selectedCards.Count(); sk2++)
                {
                    int k2 = selectedCards[sk2];
                    if (cardAt(k1).getPointValue() + cardAt(k2).getPointValue() == 11)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        /**
         * Check for a JQK in the selected cards.
         * @param selectedCards selects a subset of this board.  It is list
         *                      of indexes into this board that are searched
         *                      to find a JQK group.
         * @return true if the board entries in selectedCards
         *              include a jack, a queen, and a king; false otherwise.
         */
        private bool containsJQK(List<int> selectedCards)
        {
            bool foundJack = false;
            bool foundQueen = false;
            bool foundKing = false;
            bool foundJO = false;
            foreach (int kObj in selectedCards)
            {
                int k = kObj;
                if (cardAt(k).getRank().Equals("jack"))
                {
                    foundJack = true;
                }
                else if (cardAt(k).getRank().Equals("queen"))
                {
                    foundQueen = true;
                }
                else if (cardAt(k).getRank().Equals("king"))
                {
                    foundKing = true;
                }
                else if (cardAt(k).getRank().Equals("JO"))
                {
                    foundJO= true;
                }
            }
            return foundJack && foundQueen && foundKing;
        }


    }
}
