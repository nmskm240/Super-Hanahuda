using UnityEngine;
using SuperHanahuda.UI;

namespace SuperHanahuda.Game.TurnSystem
{
    public class DealCard : ITurn
    {
        [SerializeField]
        private Transform _place;
        [SerializeField]
        private int _size;
        [SerializeField]
        private float _scale;
        [SerializeField]
        private bool _isMovable;
        [SerializeField]
        private bool _isToggleFace;

        public void Execute()
        {
            for (int i = 0; i < _size; i++)
            {
                var card = Deck.Instance.Draw();
                card.transform.SetParent(_place);
                card.transform.localScale = Vector3.one * _scale;
                card.GetComponent<DragObject>().enabled = _isMovable;
                if (_isToggleFace)
                {
                    card.GetComponent<CardController>().View.ToggleFace();
                }
            }
        }
    }
}