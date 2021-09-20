using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

namespace SuperHanahuda.UI
{
    public class CircleLayoutGroup : UIBehaviour, ILayoutGroup
    {
        public Vector2 Raito = Vector2.one;
        public float Radius = 100;
        public float OffsetAngle = 1f;
        [Range(0f, 360f)]
        public float EffectiveAngle = 0f;

        protected override void OnValidate()
        {
            base.OnValidate();
            CalChildPos();
        }

        public void SetLayoutHorizontal() { }
        public void SetLayoutVertical()
        {
            CalChildPos();
        }

        private void CalChildPos()
        {
            var childCount = transform.childCount;
            var splitAngle = EffectiveAngle / (childCount > 0 ? childCount : 0.00001f);
            var rect = transform as RectTransform;
            var centerPosition = rect.position;
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i) as RectTransform;
                var currentAngle = splitAngle * i + OffsetAngle;
                var rotaion = (centerPosition - child.position).normalized;
                child.transform.rotation = Quaternion.FromToRotation(Vector3.down, rotaion);
                child.anchoredPosition = new Vector2(
                    Mathf.Cos(currentAngle * Mathf.Deg2Rad) * Raito.x,
                    Mathf.Sin(currentAngle * Mathf.Deg2Rad) * Raito.y) * Radius;
            }
        }
    }
}