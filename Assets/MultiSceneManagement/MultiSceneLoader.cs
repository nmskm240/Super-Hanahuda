using UnityEngine;

namespace MultiSceneManagement
{    
    public class MultiSceneLoader : MonoBehaviour 
    {
        public void Load(string sceneName)
        {
            MultiSceneManager.LoadScene(sceneName);
        }

        public void Unload(string sceneName)
        {
            MultiSceneManager.UnloadScene(sceneName);
        }
    }
}