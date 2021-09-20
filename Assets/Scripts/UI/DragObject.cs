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

        public string TargetTag { get { return _targetTag; } }
        public Transform Parent { get; set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = false;
            Parent = transform.parent;
            _moveBeforePos = transform.position;
        }

        public void OnDrag(PointerEventData e)
        {
            transform.position = e.position;
        }

        public void OnEndDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = true;
            transform.SetParent(Parent);
            if(e.hovered.Where(i => i.CompareTag(_targetTag)).Count() <= 0) 
            {
                transform.position = _moveBeforePos;
            }
        }
    }
}