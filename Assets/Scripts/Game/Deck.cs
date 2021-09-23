using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using SuperHanahuda.Utils;

namespace SuperHanahuda.Game
{
    public class Deck : SingletonMonoBehaviour<Deck>
    {
        [SerializeField]
        private Factory<GameObject> _factory;
        [SerializeField]
        private List<CardModel> _cards;

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