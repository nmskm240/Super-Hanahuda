using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SuperHanahuda.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField, Tag]
        private string _targetTag;
        private CanvasGroup _canvasGroup;
        private Vector3 _moveBeforePos;
        private Quaternion _moveBeforeRotate;
        [SerializeField]
        private UnityEvent _onBeginDrag;
        [SerializeField]
        private UnityEvent _onEndDrag;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = false;
            _moveBeforePos = transform.position;
            _moveBeforeRotate = transform.rotation;
            transform.localRotation = Quaternion.identity;
            _onBeginDrag.Invoke();
        }

        public void OnDrag(PointerEventData e)
        {
            transform.position = e.position;
        }

        public void OnEndDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = true;
            if (e.hovered.Count() > 0)
            {
                var dropPlace = e.hovered.First();
                var dropArea = dropPlace.GetComponent<DropArea>();
                if (dropPlace.CompareTag(_targetTag) && dropArea != null)
                {
                    dropArea.OnDropComplite.Invoke(gameObject);
                }
                else
                {
                    transform.position = _moveBeforePos;
                    transform.rotation = _moveBeforeRotate;
                }
            }
            else
            {
                transform.position = _moveBeforePos;
                transform.rotation = _moveBeforeRotate;
            }
            _onEndDrag.Invoke();
        }
    }
}