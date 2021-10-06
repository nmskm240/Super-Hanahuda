using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SuperHanahuda.Utils;

namespace SuperHanahuda.Game
{
    public class Deck
    {
        private List<CardModel> _cards;

        public IEnumerable<CardModel> Cards { get { return _cards; } }

        public Deck()
        {
            _cards = new List<CardModel>();
            for (int i = 1; i <= 48; i++)
            {
                var card = Resources.Load($"Datas/Cards/{ i }") as CardModel;
                _cards.Add(card);
            }
        }

        public Deck(IEnumerable<CardModel> cards)
        {
            _cards = new List<CardModel>(cards);
        }

        public void Shuffle()
        {
            _cards = _cards.OrderBy(item => Guid.NewGuid()).ToList();
        }

        public List<CardModel> Draw(int num)
        {
            var cards = _cards.GetRange(0, num);
            _cards.RemoveRange(0, num);
            return cards;
        }
    }
}