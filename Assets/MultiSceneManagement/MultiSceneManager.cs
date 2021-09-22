using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

namespace MultiSceneManagement
{
    public static class MultiSceneManager
    {
        private static SceneTable _sceneTable;
        private static List<SceneData> _loadedSceneDatas = new List<SceneData>();

        public static IEnumerable<SceneData> LoadedSceneDatas { get { return _loadedSceneDatas; } }

        private static Scene GetSceneOfSameCategoryInHierarchy(SceneData sceneData)
        {
            if(sceneData == null || string.IsNullOrEmpty(sceneData.Category))
            {
                return new Scene();
            }
            for(int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var data = _sceneTable.GetSceneData(scene.name);
                if(scene.name == sceneData.Name || data == null || string.IsNullOrEmpty(data.Category))
                {
                    continue;
                }
                if(data.Category == sceneData.Category)
                {
                    return scene;
                }
            }
            return new Scene();
        }

        private static IEnumerator LoadScene(SceneData sceneData)
        {
            if(sceneData == null)
            {
                throw new System.ArgumentNullException("sceneData");
            }
            var parentName = sceneData.ParentName;
            if(!string.IsNullOrEmpty(parentName))
            {
                var parentScene = SceneManager.GetSceneByName(parentName);
                if(!parentScene.IsValid())
                {
                    var parentSceneData = _sceneTable.GetSceneData(parentName);
                    if(parentSceneData == null)
                    {
                        Debug.LogError("Unknown SceneData");
                    }
                    yield return LoadScene(parentSceneData);
                    var sceneOfSomeCategory = GetSceneOfSameCategoryInHierarchy(parentSceneData);
                    if(sceneOfSomeCategory.IsValid())
                    {
                        yield return UnloadScene(sceneOfSomeCategory);
                    }
                }
            }
            yield return SceneManager.LoadSceneAsync(sceneData.Name, LoadSceneMode.Additive);
        }

        private static IEnumerator LoadSceneProcess(string sceneName, Action onLoaded = null)
        {
            var sceneData = _sceneTable.GetSceneData(sceneName);
            if(sceneData == null)
            {
                Debug.LogError("Unknown SceneData");
                yield break;
            }
            if(SceneManager.GetSceneByName(sceneName).IsValid())
            {
                Debug.LogWarning("Has already been loaded");
                yield break;
            }
            var sceneOfSomeCategory = GetSceneOfSameCategoryInHierarchy(sceneData);
            if(sceneOfSomeCategory.IsValid())
            {
                yield return UnloadScene(sceneOfSomeCategory);
            }
            _loadedSceneDatas.Add(sceneData);
            yield return LoadScene(sceneData);
            onLoaded?.Invoke();
        }

        private static IEnumerator UnloadScene(Scene scene)
        {
            if(!scene.IsValid())
            {
                throw new System.ArgumentException("scene");
            }
            var children = _sceneTable.GetChildScenes(scene.name);
            if(children != null)
            {
                foreach(var child in children)
                {
                    var childScene = SceneManager.GetSceneByName(child.Name);
                    if(childScene.IsValid())
                    {
                        yield return UnloadScene(childScene);
                    }
                }
            } 
            yield return SceneManager.UnloadSceneAsync(scene);
        }

        private static IEnumerator UnloadSceneProcess(string sceneName, Action onUnloaded = null)
        {
            if(!SceneManager.GetSceneByName(sceneName).IsValid())
            {
                yield break;
            }
            var children = _sceneTable.GetChildScenes(sceneName);
            if(children != null)
            {
                foreach(var child in children)
                {
                    var childScene = SceneManager.GetSceneByName(child.Name);
                    if(childScene.IsValid())
                    {
                        yield return UnloadSceneProcess(childScene.name);
                    }
                }
            }
            _loadedSceneDatas.Remove(_sceneTable.GetSceneData(sceneName));
            var scene = SceneManager.GetSceneByName(sceneName);
            yield return UnloadScene(scene);
            onUnloaded?.Invoke();
        }

        public static void Init()
        {
            _sceneTable = SceneTable.Load();
        }

        public static void LoadScene(string sceneName, Action onLoaded = null)
        {
            Observable.FromCoroutine(() => LoadSceneProcess(sceneName, onLoaded)).Subscribe();
        }

        public static void UnloadScene(string sceneName, Action onUnloaded = null)
        {
            Observable.FromCoroutine(() => UnloadSceneProcess(sceneName, onUnloaded)).Subscribe();
        }

        public static bool IsLoaded(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).IsValid();
        }

        public static void UndoParentScene()
        {
            foreach (var sceneData in _loadedSceneDatas)
            {
                if(!string.IsNullOrEmpty(sceneData.ParentName))
                {
                    LoadScene(sceneData.ParentName);
                    break;
                }
            }
        }
    }
}