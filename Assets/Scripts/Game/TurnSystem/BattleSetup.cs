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
        [SerializeReference, SubclassSelector]
        private List<IStep> _steps;

        public void Execute()
        {
            foreach(var step in _steps)
            {
                step.Execute();
            }
        }
    }
}