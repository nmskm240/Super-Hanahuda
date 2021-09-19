using UnityEngine;

namespace SuperHanahuda.Game
{
    public class CardController : MonoBehaviour
    {
        [SerializeField]
        private CardView _view;
        private CardModel _model;

        public void Init(CardModel model)
        {
            _model = model;
        }
    }
}