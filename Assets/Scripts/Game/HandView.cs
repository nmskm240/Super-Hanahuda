using UnityEngine;
using SuperHanahuda.UI;

namespace SuperHanahuda.Game
{
    [RequireComponent(typeof(CircleLayoutGroup))]
    public class HandView : MonoBehaviour
    {
        private CircleLayoutGroup _circleLayout;

        private void Awake()
        {
            _circleLayout = GetComponent<CircleLayoutGroup>();
        }

        private void OnTransformChildrenChanged()
        {
            LayoutUpdate(transform.childCount);
        }

        public void LayoutUpdate(int childCount)
        {
            _circleLayout.OffsetAngle = -30.5f * Mathf.Log(childCount) + 99.5f;
            _circleLayout.EffectiveAngle = childCount * 10 + 40;
            _circleLayout.SetLayoutHorizontal();
            _circleLayout.SetLayoutVertical();
        }
    }
}