using UnityEngine;
using UnityEngine.UI;

namespace SuperHanahuda.Game
{
    public class CardView : MonoBehaviour
    {
        [SerializeField]
        private Sprite _back;
        [SerializeField]
        private Image _image;

        public bool IsFace { get { return _image.sprite != _back; } }
    }
}