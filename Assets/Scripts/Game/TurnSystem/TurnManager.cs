using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Network.CustomProperty;

namespace SuperHanahuda.Game.TurnSystem
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeReference, SubclassSelector]
        private List<ITurn> _setupPhases;

        private void Start()
        {
            var deck = PhotonNetwork.CurrentRoom.GetDeck();
            foreach (var turn in _setupPhases)
            {
                turn.Execute(deck);
            }
        }
    }
}