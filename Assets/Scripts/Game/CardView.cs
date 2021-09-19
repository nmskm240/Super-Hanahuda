using UnityEngine;
using UnityEngine.UI;

namespace SuperHanahuda.Game
{
    [System.Serializable]
    public class CardView
    {
        private Sprite _face;
        [SerializeField]
        private Sprite _back;
        [SerializeField]
        private Image _image;

        public bool IsFace { get { return _image.sprite == _face; } }

        public void Init(Sprite face)
        {
            _face = face;
            _image.sprite = _back;
        }

        public void ToggleFace()
        {
            _image.sprite = IsFace ? _back : _face;
        }
    }
}