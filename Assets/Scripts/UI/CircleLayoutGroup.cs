using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SuperHanahuda.UI
{
    public class CircleLayoutGroup : MonoBehaviour
    {
        public Vector2 Raito = Vector2.one;
        public float Radius = 100;
        public float OffsetAngle = 1f;
        [Range(0f, 360f)]
        public float EffectiveAngle = 0f;

#if UNITY_EDITOR
        private void OnValidate() 
        {
            OnTransformChildrenChanged();
        }
#endif

        private void OnTransformChildrenChanged()
        {
            var childCount = transform.childCount;
            var splitAngle = EffectiveAngle / (childCount > 0 ? childCount : 0.000001f);
            var centerPosition = transform.position;
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                var currentAngle = splitAngle * i + OffsetAngle;
                var rotaion = (centerPosition - child.position).normalized;
                child.transform.localRotation = Quaternion.FromToRotation(Vector3.down, rotaion);
                child.transform.localPosition = new Vector2(
                    Mathf.Cos(currentAngle * Mathf.Deg2Rad) * Raito.x,
                    Mathf.Sin(currentAngle * Mathf.Deg2Rad) * Raito.y) * Radius;
            }
        }
    }
}