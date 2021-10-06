using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Game.TurnSystem
{
    [System.Serializable]
    public class DealCards : IStep<IEnumerable<GameObject>>
    {
        public void Execute(IEnumerable<GameObject> objects)
        {
            Debug.Log(objects);
        }
    }
}