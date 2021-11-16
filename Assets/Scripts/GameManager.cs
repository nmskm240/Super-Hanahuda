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
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        MultiSceneManager.LoadScene("Game");
    }

    public override void OnJoinRandomFailed(short code, string message)
    {
        var roomProp = new RoomOptions()
        {
            CustomRoomProperties = new Hashtable()
            {
                { RoomProperties.DECK_KEY, new Deck().Cards.ToArray() },
            }
        };
        PhotonNetwork.JoinOrCreateRoom(Random.Range(1000, 10000).ToString(), roomProp, null);
    }
}