using System.Linq;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using SuperHanahuda.Game;
using SuperHanahuda.Network;
using SuperHanahuda.Network.CustomProperties;
using MultiSceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        CustomType.Register();
        MultiSceneManager.Init();
        PhotonNetwork.OfflineMode = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        var roomProp = new RoomOptions()
        {
            CustomRoomProperties = new Hashtable()
            {
                { RoomProperties.DeckPropKey, new Deck().Cards.ToArray() },
            }
        };
        PhotonNetwork.JoinOrCreateRoom(Random.Range(1000, 10000).ToString(), roomProp, null);
    }

    public override void OnJoinedRoom()
    {
        MultiSceneManager.LoadScene("Game");
    }
}