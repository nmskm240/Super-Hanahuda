using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace  SuperHanahuda.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField, Tag]
        private string _targetTag;
        private CanvasGroup _canvasGroup;
        private Vector3 _moveBeforePos;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = false;
            _moveBeforePos = transform.position;
        }

        public void OnDrag(PointerEventData e)
        {
            transform.position = e.position;
        }

        public void OnEndDrag(PointerEventData e)
        {
            if(e.hovered.Where(i => i.CompareTag(_targetTag)).Count() > 0) 
            {
                _canvasGroup.blocksRaycasts = true;
            }
            else 
            {
                transform.position = _moveBeforePos;
            }
        }
    }
}