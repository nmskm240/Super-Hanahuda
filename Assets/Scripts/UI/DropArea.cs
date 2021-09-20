using UnityEngine;
using UnityEngine.EventSystems;

namespace SuperHanahuda.UI
{    
    public class DropArea : MonoBehaviour, IDropHandler 
    {
        public void OnDrop(PointerEventData e)
        {
            var obj = e.pointerDrag.GetComponent<DragObject>();
            if(obj != null || gameObject.CompareTag(obj.TargetTag)) 
            {
                obj.Parent = transform;
            }
        }
    }
}