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

        private void OnGUI()
        {
            if (GUI.Button(new Rect(0, 0, 100, 80), "battle setup"))
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    _battleSetupPhase.Execute();
                }
            }
        }

        private void Start()
        {
            PhotonNetwork.IsMessageQueueRunning = true;
            if(!PhotonNetwork.IsMasterClient)
            {
                Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
    }
}