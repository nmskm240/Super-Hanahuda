using UnityEngine;

namespace SuperHanahuda.Game
{
    [CreateAssetMenu(fileName = "Card", menuName = "Super Hanahuda/CardModel", order = 0)]
    public class CardModel : ScriptableObject
    {
        [SerializeField]
        private CardType _type;
        [SerializeField, Range(1, 12)]
        private int _month;
        [SerializeField]
        private Sprite _image;

        public CardType Type { get { return this._type; } }
        public int Month { get { return this._month; } }
        public Sprite Image { get { return this._image; } }
    }
}