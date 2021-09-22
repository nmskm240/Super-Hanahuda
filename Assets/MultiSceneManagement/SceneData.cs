using UnityEngine;

namespace MultiSceneManagement
{
    [System.Serializable]
    public class SceneData
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _category;
        [SerializeField]
        private string _parentName;

        public string Name { get { return _name; } }
        public string Category { get { return _category; } }
        public string ParentName { get { return _parentName; } }
    }
}