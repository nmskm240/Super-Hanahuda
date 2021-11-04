using UnityEngine;

namespace SuperHanahuda.UI
{
    public class GridLayoutGroup : MonoBehaviour
    {
        public Vector2 ElementSize = Vector2.one;
        public int Rows = 2;
        
#if UNITY_EDITOR
        private void OnValidate() 
        {
            OnTransformChildrenChanged();
        }
#endif

        private void OnTransformChildrenChanged()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.transform.localPosition = new Vector2(
                    ElementSize.x * (i / Rows),
                    ElementSize.y * (i % Rows)
                );
            }
        }
    }
}