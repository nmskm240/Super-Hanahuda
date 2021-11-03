using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;
using SuperHanahuda.Network.CustomProperties;
using SuperHanahuda.Utils;

namespace SuperHanahuda.Game.TurnSystem
{
    [System.Serializable]
    public class BattleSetup : IPhase
    {
        [SerializeField]
        private NetworkFactory _factory;

        [SerializeField]
        private List<DealCards> _steps;

        public void Execute()
        {
            var deck = PhotonNetwork.CurrentRoom.GetDeck();
            foreach (var step in _steps)
            {
                var models = deck.Draw(2);
                var objects = models.Select(model => {
                    var card = _factory.Create();
                    card.GetComponent<CardController>().Init(model);
                    return card;
                });
                step.Execute(objects);
            }
            PhotonNetwork.CurrentRoom.SetDeck(deck);
            PhotonNetwork.CurrentRoom.SetRoomProperties();
        }
    }
}