using UnityEngine;
using UnityEngine.Events;

namespace SuperHanahuda.Game
{
    public class CardController : MonoBehaviour
    {
        [SerializeField]
        private CardView _view;
        private CardModel _model;
        [SerializeField]
        private UnityEvent _onPlay;

        public CardView View { get { return this._view; } }
        public CardModel Model { get { return this._model; } }
        public UnityEvent OnPlay { get { return _onPlay; } }

        public void Init(CardModel model)
        {
            _model = model;
            _view.Init(model.Image);
        }

        private void OnTransformParentChanged()
        {
            transform.localScale = Vector3.one;
        }
    }
}