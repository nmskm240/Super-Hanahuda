using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Network.CustomProperties;

namespace SuperHanahuda.Game.TurnSystem
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField]
        private BattleSetup _battleSetupPhase;

        private void Start()
        {
            PhotonNetwork.IsMessageQueueRunning = true;
            if (PhotonNetwork.IsMasterClient)
            {
                _battleSetupPhase.Execute();
            }
        }
    }
}