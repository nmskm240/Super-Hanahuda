using UnityEngine;
using UnityEngine.Events;

namespace SuperHanahuda.UI
{    
    public class DropArea : MonoBehaviour 
    {
        [SerializeField]
        private UnityEvent<GameObject> _onDropComplite;

        public UnityEvent<GameObject> OnDropComplite { get { return _onDropComplite; } }
    }
}