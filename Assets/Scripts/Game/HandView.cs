using UnityEngine;

using SuperHanahuda.UI;

namespace SuperHanahuda.Game
{
    [System.Serializable]
    public class HandView
    {
        [SerializeField]
        private CircleLayoutGroup _circleLayout;

        public void LayoutUpdate(int childCount)
        {
            _circleLayout.OffsetAngle = -30.5f * Mathf.Log(childCount) + 99.5f;
            _circleLayout.EffectiveAngle = childCount * 10 + 40;
            _circleLayout.SetLayoutHorizontal();
            _circleLayout.SetLayoutVertical();
        }

    }
}