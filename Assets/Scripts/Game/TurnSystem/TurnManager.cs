using System.Collections.Generic;
using UnityEngine;

namespace SuperHanahuda.Game.TurnSystem
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeReference, SubclassSelector]
        private List<ITurn> _battleStandbyPhases;

        private void Start()
        {
            Deck.Instance.Shuffle();
            foreach (var turn in _battleStandbyPhases)
            {
                turn.Execute();
            }
        }
    }
}