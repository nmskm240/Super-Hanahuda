using UnityEngine;

namespace SuperHanahuda.Game
{
    public class CardController : MonoBehaviour
    {
        [SerializeField]
        private CardView _view;
        private CardModel _model;

        public CardView View { get { return this._view; } }
        public CardModel Model { get { return this._model; } }

        public void Init(CardModel model)
        {
            _model = model;
            _view.Init(model.Image);
        }
    }
}