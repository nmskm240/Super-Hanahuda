using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Network.CustomProperties;
using SuperHanahuda.Utils;

namespace SuperHanahuda.Game.TurnSystem
{
    [System.Serializable]
    public class DealCards : IStep
    {
        [SerializeField]
        private NetworkFactory _factory;
        [SerializeField]
        private List<Transform> _dealPoses;

        public void Execute()
        {
            var deck = PhotonNetwork.CurrentRoom.GetDeck();
            if (PhotonNetwork.CurrentRoom.GetParentPlayer() != PhotonNetwork.LocalPlayer)
            {
                _dealPoses.Reverse();
            }
            for(int i = 0; i < 4; i++)
            {
                foreach (var transform in _dealPoses)
                {
                    foreach (var card in deck.Draw(2))
                    {
                        var obj = _factory.Create();
                        obj.GetComponent<CardController>().Init(card);
                        obj.transform.SetParent(transform);
                    }
                }
            }
            PhotonNetwork.CurrentRoom.SetDeck(deck);
            PhotonNetwork.CurrentRoom.SetRoomProperties();
        }
    }
}