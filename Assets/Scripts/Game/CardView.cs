using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Game
{
    [System.Serializable]
    public class CardView : MonoBehaviour
    {
        private Sprite _face;
        [SerializeField]
        private Sprite _back;
        [SerializeField]
        private SpriteRenderer _renderer;

        public bool IsFaceUp { get { return _renderer.sprite == _face; } }

        public void Init(Sprite face)
        {
            _face = face;
            _renderer.sprite = _back;
        }

        [PunRPC]
        public void ToggleFace()
        {
            _renderer.sprite = IsFaceUp ? _back : _face;
        }

        [PunRPC]
        public void FaceUp()
        {
            _renderer.sprite = _face;
        }

        [PunRPC]
        public void FaceDown()
        {
            _renderer.sprite = _back;
        }
    }
}