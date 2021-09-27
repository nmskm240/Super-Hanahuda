using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SuperHanahuda.Utils;

namespace SuperHanahuda.Game
{
    public class Deck
    {
        private Factory<GameObject> _factory;
        private List<CardModel> _cards;

        public IEnumerable<CardModel> Cards { get { return _cards; } }

        public Deck()
        {
            _factory = new NetworkFactory(Resources.Load("Prefabs/Card") as GameObject);
            _cards = new List<CardModel>();
            for (int i = 1; i <= 48; i++)
            {
                var card = Resources.Load($"Datas/Cards/{ i }") as CardModel;
                _cards.Add(card);
            }
        }

        public Deck(IEnumerable<CardModel> cards)
        {
            _factory = new NetworkFactory(Resources.Load("Prefabs/Card") as GameObject);
            _cards = new List<CardModel>(cards);
        }

        public void Shuffle()
        {
            _cards = _cards.OrderBy(item => Guid.NewGuid()).ToList();
        }

        public GameObject Draw()
        {
            var obj = _factory.Create();
            var card = _cards.First();
            _cards.Remove(card);
            obj.GetComponent<CardController>().Init(card);
            return obj;
        }
    }
}