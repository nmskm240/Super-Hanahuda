using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Utils
{
    [System.Serializable]
    public class NetworkFactory : Factory<GameObject>
    {
        public NetworkFactory(GameObject original) : base(original){}

        public override GameObject Create()
        {
            return PhotonNetwork.Instantiate(_original.name, Vector3.zero, Quaternion.identity);
        }
    }
}