using UnityEngine;

namespace SuperHanahuda.Utils
{
    [System.Serializable]
    public class LocalFactory<T> : Factory<T> where T : Object
    {
        public LocalFactory(T original) : base(original){}

        public override T Create()
        {
            return Object.Instantiate(_original);
        }
    }
}