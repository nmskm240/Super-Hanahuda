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
        private Transform _parent;
        private int _index;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData e)
        {
            _canvasGroup.blocksRaycasts = false;
            _parent = transform.parent;
            _index = transform.GetSiblingIndex();
            _moveBeforePos = transform.position;
            _moveBeforeRotate = transform.rotation;
            transform.localRotation = Quaternion.identity;
            transform.parent = null;
            _onBeginDrag.Invoke();
        }

        public void OnDrag(PointerEventData e)
        {
            var pos = Camera.main.ScreenToWorldPoint(e.position);
            pos.z = 0;
            transform.position = pos;
        }

        public void OnEndDrag(PointerEventData e)
        {
            var worldPoint = Camera.main.ScreenToWorldPoint(e.position);
            _canvasGroup.blocksRaycasts = true;
            _onEndDrag.Invoke();
            foreach (var hit in Physics2D.RaycastAll(worldPoint, Vector2.zero))
            {
                var obj = hit.collider.gameObject;
                Debug.Log(obj.name);
                var dropArea = obj.GetComponent<DropArea>();
                if (obj.CompareTag(_targetTag) && dropArea != null)
                {
                    dropArea.OnDropComplite.Invoke(gameObject);
                    return;
                }
            }
            transform.parent = _parent;
            transform.SetSiblingIndex(_index);
            transform.position = _moveBeforePos;
            transform.rotation = _moveBeforeRotate;
        }
    }
}