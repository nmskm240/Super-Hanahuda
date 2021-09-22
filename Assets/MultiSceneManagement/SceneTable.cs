using System.Linq;
using UnityEngine;

namespace MultiSceneManagement
{
    [CreateAssetMenu(fileName = "SceneTable", menuName = "MultiSceneManagement/SceneTable", order = 0)]
    public class SceneTable : ScriptableObject 
    {
        private static readonly string RESOURCE_PATH = "SceneTable";
        [SerializeField]
        private SceneData[] _scenes;

        public static SceneTable Load()
        {
            return Resources.Load(RESOURCE_PATH) as SceneTable;
        }

        public SceneData GetSceneData(string sceneName)
        {
            if(string.IsNullOrEmpty(sceneName) || _scenes == null || _scenes.Length == 0)
            {
                return null;
            }

            return _scenes.FirstOrDefault(e => e.Name == sceneName);
        }

        public SceneData[] GetChildScenes(string parentName)
        {
            if(string.IsNullOrEmpty(parentName) || _scenes == null || _scenes.Length == 0)
            {
                return null;
            }

            return _scenes.Where(e => e.ParentName == parentName).ToArray();
        }
    }
}