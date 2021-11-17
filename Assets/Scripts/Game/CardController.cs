using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;

namespace SuperHanahuda.Game
{
    public class CardController : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    {
        [SerializeField]
        private CardView _view;
        private CardModel _model;
        [SerializeField]
        private UnityEvent _onPlay;
        [SerializeField]
        private UnityEvent _onPlacedField;

        public CardModel Model { get { return this._model; } }
        public UnityEvent OnPlay { get { return _onPlay; } }
        public UnityEvent OnPlacedField { get { return _onPlacedField; } }

        public override void OnEnable()
        {
            base.OnEnable();
            PhotonNetwork.AddCallbackTarget(this);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        [PunRPC]
        public void Init(CardModel model)
        {
            _model = model;
            _view.Init(model.Image);
            _onPlacedField.AddListener(_view.FaceUp);
        }

        private void OnTransformParentChanged()
        {
            transform.localScale = Vector3.one;
            if(transform.parent != null && transform.parent.CompareTag("Field"))
            {
                _onPlacedField.Invoke();
            }
        }

        public void OnOwnershipRequest(PhotonView photonView, Player player)
        {

        }

        public void OnOwnershipTransfered(PhotonView photonView, Player player)
        {
            if(this.photonView.ViewID == photonView.ViewID && photonView.IsMine)
            {
                _view.FaceUp();
            }
        }

        public void OnOwnershipTransferFailed(PhotonView photonView, Player player)
        {

        }
    }
}