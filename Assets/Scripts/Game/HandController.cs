using UnityEngine;

namespace SuperHanahuda.Game
{
    public class HandController : MonoBehaviour
    {
        [SerializeField]
        private HandView _view;

        private void OnTransformChildrenChanged()
        {
            _view.LayoutUpdate(transform.childCount);
        }
    }
}