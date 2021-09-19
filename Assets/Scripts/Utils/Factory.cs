using UnityEngine;

namespace SuperHanahuda.Utils
{
    [System.Serializable]
    public class Factory<T> where T : Object
    {
        [SerializeField]
        private T _original;

        public T Create()
        {
            return Object.Instantiate(_original);
        }
    }
}