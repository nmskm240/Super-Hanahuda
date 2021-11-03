using UnityEngine;

namespace SuperHanahuda.Utils
{
    [System.Serializable]
    public abstract class Factory<T> where T : Object
    {
        [SerializeField]
        protected T _original;

        public Factory(T original)
        {
            _original = original;
        }

        public abstract T Create();
    }
}