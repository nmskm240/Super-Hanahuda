using System.Collections.Generic;
using UnityEngine;

namespace SuperHanahuda.Game.TurnSystem
{
    [System.Serializable]
    public class DealCards : IStep<IEnumerable<GameObject>>
    {
        [SerializeField]
        private Transform _target;

        public void Execute(IEnumerable<GameObject> objects)
        {
            foreach(var obj in objects)
            {
                obj.transform.SetParent(_target);
            }
        }
    }
}