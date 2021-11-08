using UnityEngine;
using Photon.Pun;

namespace SuperHanahuda.Network
{
    public class PhotonHierarchyView : MonoBehaviour, IPunObservable
    {
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(transform.parent?.name);
            }
            else
            {
                var name = (string)stream.ReceiveNext();
                var parent = GameObject.Find(name);
                transform.SetParent(parent?.transform);
            }
        }
    }
}