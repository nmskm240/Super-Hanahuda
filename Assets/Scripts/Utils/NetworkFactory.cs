using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Utils
{
    [System.Serializable]
    public class NetworkFactory : Factory<GameObject>
    {
        [SerializeField]
        private bool _isRoomObject;

        public NetworkFactory(GameObject original) : base(original) { }

        public override GameObject Create()
        {
            if (_isRoomObject)
            {
                return PhotonNetwork.InstantiateRoomObject(_original.name, Vector3.zero, Quaternion.identity);
            }
            else
            {
                return PhotonNetwork.Instantiate(_original.name, Vector3.zero, Quaternion.identity);
            }
        }
    }
}