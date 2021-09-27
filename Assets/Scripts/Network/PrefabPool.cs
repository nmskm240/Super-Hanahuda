using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Network
{
    public class PrefabPool : MonoBehaviourPunCallbacks, IPunPrefabPool
    {
        [SerializeField]
        private List<GameObject> _prefabs;

        private void Start()
        {
            PhotonNetwork.PrefabPool = this;
        }

        public GameObject Instantiate(string name, Vector3 pos, Quaternion rotat)
        {
            foreach (var prefab in _prefabs)
            {
                if (prefab.name == name)
                {
                    var go = GameObject.Instantiate(prefab, pos, rotat);
                    go.SetActive(false);
                    return go;
                }
            }
            return null;
        }

        public void Destroy(GameObject go)
        {
            GameObject.Destroy(go);
        }
    }
}