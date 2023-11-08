﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT
{
    class Deck
    {

        /**
         * cards contains all the cards in the deck.
         */
        private List<Card> cards;

        /**
         * size is the number of not-yet-dealt cards.
         * Cards are dealt from the top (highest index) down.
         * The next card to be dealt is at size - 1.
         */
        private int size;


        /**
         * Creates a new <code>Deck</code> instance.<BR>
         * It pairs each element of ranks with each element of suits,
         * and produces one of the corresponding card.
         * @param ranks is an array containing all of the card ranks.
         * @param suits is an array containing all of the card suits.
         * @param values is an array containing all of the card point values.
         */
        public Deck(String[] ranks, String[] suits, int[] values)
        {
            cards = new List<Card>();
            for (int j = 0; j < ranks.Length; j++)
            {
                foreach (String suitString in suits)
                {
                    cards.Add(new Card(ranks[j], suitString, values[j]));
                }
            }
            size = cards.Count();
            shuffle();
        }


        /**
         * Determines if this deck is empty (no undealt cards).
         * @return true if this deck is empty, false otherwise.
         */
        public bool isEmpty()
        {
            return size == 0;
        }

        /**
         * Accesses the number of undealt cards in this deck.
         * @return the number of undealt cards in this deck.
         */
        public int getSize()
        {
            return size;
        }

        /**
         * Randomly permute the given collection of cards
         * and reset the size to represent the entire deck.
         */
        public void shuffle()
        {
            Random random = new Random();
            for (int k = cards.Count() - 1; k > 0; k--)
            {
                int howMany = k + 1;
                int randPos = (int)(random.Next(0, howMany));
                Card temp = cards[k];
                cards[k] = cards[randPos];
                cards[randPos] = temp;
            }
            size = cards.Count();
        }

        /**
         * Deals a card from this deck.
         * @return the card just dealt, or null if all the cards have been
         *         previously dealt.
         */
        public Card deal()
        {
            if (isEmpty())
            {
                return null;
            }
            size--;
            Card c = cards[size];
            return c;
        }

        /**
         * Generates and returns a string representation of this deck.
         * @return a string representation of this deck.
         */

        public String toString()
        {
            String rtn = "size = " + size + "\nUndealt cards: \n";

            for (int k = size - 1; k >= 0; k--)
            {

                rtn = rtn + cards[k];
                if (k != 0)
                {
                    rtn = rtn + ", ";
                }
                if ((size - k) % 2 == 0)
                {
                    // Insert carriage returns so entire deck is visible on console.
                    rtn = rtn + "\n";
                }
            }

            rtn = rtn + "\nDealt cards: \n";
            for (int k = cards.Count() - 1; k >= size; k--)
            {
                rtn = rtn + cards[k];
                if (k != size)
                {
                    rtn = rtn + ", ";
                }
                if ((k - cards.Count() % 2 == 0))
                {
                    // Insert carriage returns so entire deck is visible on console.
                    rtn = rtn + "\n";
                }
            }

            rtn = rtn + "\n";
            return rtn;
        }
    }
}
