using UnityEngine;
using MultiSceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        MultiSceneManager.Init();
    }
}