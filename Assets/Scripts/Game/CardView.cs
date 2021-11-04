using UnityEngine;

namespace SuperHanahuda.Game
{
    [System.Serializable]
    public class CardView
    {
        private Sprite _face;
        [SerializeField]
        private Sprite _back;
        [SerializeField]
        private SpriteRenderer _renderer;

        public bool IsFace { get { return _renderer.sprite == _face; } }

        public void Init(Sprite face)
        {
            _face = face;
            _renderer.sprite = _back;
        }

        public void ToggleFace()
        {
            _renderer.sprite = IsFace ? _back : _face;
        }
    }
}